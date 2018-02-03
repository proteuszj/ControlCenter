create or replace function ChangePassword
(
  message out varchar2,                 --error message or USER_FLAG||ROLE_NAME if no error
  loginName in varchar2,
  oldPasswordSHA1 in varchar2,
  newPasswordSHA1 in varchar2,
  hostIP in varchar2,					--host ip
  hostMAC in varchar2					--host mac
) return number as
  n integer;
  passwd SYS_USER.PASSWORD%TYPE;
  userName SYS_USER.USER_NAME%TYPE;
  idNo SYS_USER.IDNUMBER%TYPE;
  userStatus SYS_USER.STATUS%TYPE;
  defaultPasswordValidPeriod CFG_PARAM.PARAM_VALUE%TYPE;
begin
  --check user existance
  select count(*) into n from SYS_USER where LOGIN_NAME=loginName and STATUS<>(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='已删除');
  if n=0 then
    message:='用户不存在: '||loginName;
    addLog(loginName, '系统', '修改', message, 0, hostIP, hostMAC);
    return -1;
  end if;
  
  --check status
  select PASSWORD, USER_NAME, IDNUMBER, STATUS
  into passwd, userName, idNo, userStatus
  from SYS_USER where LOGIN_NAME=loginName;
  
  if userStatus<>1 then
	message:='用户未登录：'||loginName;
    addLog(loginName, '系统', '修改', message, 0, hostIP, hostMAC);
    return -2;
  end if;
  
  --verify old password
  if passwd <> DESEncrypt(oldPasswordSHA1||loginName||userName||idNo) then
	message:='密码连续错误'||1||'次';
	update SYS_USER set FAILURE_TIMES=1, STATUS=(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='未登录') where LOGIN_NAME=loginName;
	update SYS_TERMINAL_LIST set FAILURE_TIMES=1 where MAC=hostMAC;
	addLog(loginName, '系统', '修改', message, '0', hostIP, hostMAC);
	return -3;
  end if;

  --change PASSWORD, reset FAILURE_TIMES
  select PARAM_VALUE into defaultPasswordValidPeriod from CFG_PARAM where PARAM_NAME='PASSWORD_VALID_PERIOD';
  update SYS_USER set PASSWORD=DESEncrypt(newPasswordSHA1||loginName||userName||idNo), FAILURE_TIMES=0, PASSWORD_MODIFY_DATE=to_char(trunc(current_date, 'dd')+defaultPasswordValidPeriod, 'yyyymmdd') where LOGIN_NAME=loginName;
  message:='密码修改成功：'||loginName;
  addLog(loginName, '系统', '修改', message, '1', hostIP, hostMAC);
  return 0;
end ChangePassword;
/
