create or replace function RemoveUser
(
  message out varchar2,					--error message or loginName if no error
  operatorLoginName in varchar2,
  loginName in varchar2,				--do NOT changed
  hostIP in varchar2,					--host ip
  hostMAC in varchar2					--host mac
) return number as
  n integer;
begin
  select count(*) into n from SYS_USER where LOGIN_NAME=loginName and STATUS<>(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='已删除');
  if n=0 then
    message:='用户不存在: '||loginName;
    addLog(operatorLoginName, '系统', '删除', message, 0, hostIP, hostMAC);
    return -1;
  end if;
  
  if (loginName=operatorLoginName) then
	message:='管理员不能删除自身'||loginName;
    addLog(operatorLoginName, '系统', '删除', message, 0, hostIP, hostMAC);
    return -2;
  end if;
  
  update SYS_USER set STATUS=(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='已删除') where LOGIN_NAME=loginName;
  message:='删除用户成功：'||loginName;
  addLog(operatorLoginName, '系统', '删除', message, 1, hostIP, hostMAC);
  return 0;
end RemoveUser;
/
