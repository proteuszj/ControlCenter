create or replace function AddRole
(
  message out varchar2,
  operatorLoginName in varchar2,
  roleName in varchar2,
  hostIP in varchar2,
  hostMAC in varchar2
) return number as
  n number;
begin
  select count(*) into n from SYS_ROLE where NAME=roleName;
  if n>0 then
	message:='��ɫ�Ѵ��ڣ�'||roleName;
    addLog(operatorLoginName, 'ϵͳ', '����', message, 0, hostIP, hostMAC);
	return -1;
  end if;

  insert into SYS_ROLE(ID, NAME) values(SEQU_SYS_ROLE_ID.nextval, roleName);
  message:='���ӽ�ɫ�ɹ���'||roleName;
  addLog(operatorLoginName, 'ϵͳ', '����', message, 1, hostIP, hostMAC);
  return 0;
end AddRole;
/
