create or replace function UnblockUser
(
  message out varchar2,
  operatorLoginName in varchar2,
  loginName in varchar2,
  hostIP in varchar2,					--host ip
  hostMAC in varchar2					--host mac
)return number as
  n number;
  userName SYS_USER.USER_NAME%TYPE;
  idNo SYS_USER.IDNUMBER%TYPE;
  defaultPassword CFG_PARAM.PARAM_VALUE%TYPE;
begin
  --check operator existance
  select count(*) into n from SYS_USER where LOGIN_NAME=operatorLoginName;
  if n=0 then
    message:='����Ա������: '||operatorLoginName;
    addLog(operatorLoginName, 'ϵͳ', '����', message, 0, hostIP, hostMAC);
    return -1;
  end if;

  --check user existance
  select count(*) into n from SYS_USER where LOGIN_NAME=loginName;
  if n=0 then
    message:='�û�������: '||loginName;
    addLog(operatorLoginName, 'ϵͳ', '����', message, 0, hostIP, hostMAC);
    return -2;
  end if;
  
  --check operator permission
  select count(*) into n from SYS_USER_ROLE_PERMISSION_VIEW where LOGIN_NAME=operatorLoginName and PERMISSION_NAME='�û�����';
  if n=0 then
	message:='����ԱȨ�޲���';
	addLog(operatorLoginName, 'ϵͳ', '����', message, 0, hostIP, hostMAC);
	return -3;
  end if;
  
  select USER_NAME, IDNUMBER into userName, idNo from SYS_USER where LOGIN_NAME=loginName;
  select PARAM_VALUE into defaultPassword from CFG_PARAM where PARAM_NAME='DEFAULT_USER_PASSWORD';
  update SYS_USER set FAILURE_TIMES=0, PASSWORD=DESEncrypt(GenerateSHA1(defaultPassword)||loginName||userName||idNo), PASSWORD_MODIFY_DATE=to_char(current_date-1, 'yyyymmdd') where LOGIN_NAME=loginName;
  message:='����'||loginName||'�ɹ�';
  addLog(operatorLoginName, 'ϵͳ', '����', message, 1, hostIP, hostMAC);
  return 0;
end UnblockUser;
/
