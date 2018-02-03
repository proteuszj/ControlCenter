create or replace function RevokeRolePermission
(
	message out varchar2,
	operatorLoginName in varchar2,
	roleName in varchar2,
	permissionName in varchar2
) return number as
	n integer;
	roleID SYS_ROLE.ID%TYPE;
	permissionCode SYS_PERMISSION.CODE%TYPE;
begin
	message:=roleName||'-'||permissionName;
	select count(*) into n from SYS_ROLE where NAME=roleName;
	if n=0 then
		message:=message||', ��ɫ������: '||roleName;
		AddLog(operatorLoginName, 'Ȩ�޹���', 'ɾ��', message, 0, null, null);
		return -1;
	else
		select ID into roleID from SYS_ROLE where NAME=roleName;
	end if;

	select count(*) into n from SYS_PERMISSION where NAME=permissionName;
	if n=0 then
		message:=message||', Ȩ�޲�����: '||permissionName;
		AddLog(operatorLoginName, 'Ȩ�޹���', 'ɾ��', message, 0, null, null);
		return -2;
	else
		select CODE into permissionCode from SYS_PERMISSION where NAME=permissionName;
	end if;

	select count(*) into n from SYS_ROLE_PERMISSION where ROLE_ID=roleID and PERMISSION_CODE=permissionCode;
	if n=0 then
		message:=message||', ��Ȩ������';
		AddLog(operatorLoginName, 'Ȩ�޹���', 'ɾ��', message, 0, null, null);
		return -3;
	else
		delete from SYS_ROLE_PERMISSION where ROLE_ID=roleID and PERMISSION_CODE=permissionCode;
		message:=message||', �ɹ�';
		AddLog(operatorLoginName, 'Ȩ�޹���', 'ɾ��', message, 1, null, null);
		return 0;
	end if;
end RevokeRolePermission;
/
