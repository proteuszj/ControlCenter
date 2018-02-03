create or replace function GrantRolePermission 
(
	message out varchar2,
	operatorLoginName in varchar2,
	roleName in varchar2,
	permissionName in varchar2
) return number as
	n integer;
	roleID SYS_ROLE.ID%TYPE;
	permissionCode SYS_PERMISSION.CODE%TYPE;
	roleCategory SYS_ROLE.CATEGORY%TYPE;
	permissionCategory SYS_PERMISSION.CATEGORY%TYPE;
begin
	message:=roleName||'+'||permissionName;
	select count(*) into n from SYS_ROLE where NAME=roleName;
	if n=0 then
		message:=message||', ��ɫ������: '||roleName;
		AddLog(operatorLoginName, 'Ȩ�޹���', '����', message, 0, null, null);
		return -1;
	else
		select ID, CATEGORY into roleID, roleCategory from SYS_ROLE where NAME=roleName;
	end if;

	select count(*) into n from SYS_PERMISSION where NAME=permissionName;
	if n=0 then
		message:=message||', Ȩ�޲�����: '||permissionName;
		AddLog(operatorLoginName, 'Ȩ�޹���', '����', message, 0, null, null);
		return -2;
	else
		select CODE, CATEGORY into permissionCode, permissionCategory from SYS_PERMISSION where NAME=permissionName;
	end if;

	if permissionCategory is not null and roleCategory<>permissionCategory then
		message:=message||', ��ɫ��Ȩ�����ͬ: '||roleCategory||' vs '||permissionCategory;
		AddLog(operatorLoginName, 'Ȩ�޹���', '����', message, 0, null, null);
		return -3;
	end if;

	select count(*) into n from SYS_ROLE_PERMISSION where ROLE_ID=roleID and PERMISSION_CODE=permissionCode;
	if n=0 then
		insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values(roleID, permissionCode);
		message:=message||', �ɹ�';
		AddLog(operatorLoginName, 'Ȩ�޹���', '����', message, 1, null, null);
	else
		message:=message||', Ȩ���Ѵ���';
		AddLog(operatorLoginName, 'Ȩ�޹���', '����', message, 0, null, null);
	end if;
	return 0;
end GrantRolePermission;
/
