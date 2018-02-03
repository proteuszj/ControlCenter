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
  select count(*) into n from SYS_USER where LOGIN_NAME=loginName and STATUS<>(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='��ɾ��');
  if n=0 then
    message:='�û�������: '||loginName;
    addLog(operatorLoginName, 'ϵͳ', 'ɾ��', message, 0, hostIP, hostMAC);
    return -1;
  end if;
  
  if (loginName=operatorLoginName) then
	message:='����Ա����ɾ������'||loginName;
    addLog(operatorLoginName, 'ϵͳ', 'ɾ��', message, 0, hostIP, hostMAC);
    return -2;
  end if;
  
  update SYS_USER set STATUS=(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='��ɾ��') where LOGIN_NAME=loginName;
  message:='ɾ���û��ɹ���'||loginName;
  addLog(operatorLoginName, 'ϵͳ', 'ɾ��', message, 1, hostIP, hostMAC);
  return 0;
end RemoveUser;
/
