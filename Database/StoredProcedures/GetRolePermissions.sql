create or replace procedure GetRolePermissions
(
	roleName in varchar2,
	permissionNames out varchar2
)as
	c1 SYS_REFCURSOR;
	permissionName SYS_PERMISSION.NAME%TYPE;
	isAdmin SYS_PERMISSION.IS_ADMIN%TYPE;
	isPolice SYS_PERMISSION.IS_POLICE%TYPE;
begin
	open c1 for select SYS_PERMISSION.NAME, IS_ADMIN, IS_POLICE from SYS_PERMISSION, SYS_ROLE_PERMISSION, SYS_ROLE where SYS_PERMISSION.CODE=SYS_ROLE_PERMISSION.PERMISSION_CODE and SYS_ROLE_PERMISSION.ROLE_ID=SYS_ROLE.ID and SYS_ROLE.NAME=roleName and (SYS_PERMISSION.CATEGORY is null or SYS_PERMISSION.CATEGORY=SYS_ROLE.CATEGORY);
	loop 
		fetch c1 into permissionName, isAdmin, isPolice;
		exit when c1%NOTFOUND;
		if isAdmin=1 then
			permissionName:='*'||permissionName;
		end if;
		if isPolice=1 then
			permissionName:='#'||permissionName;
		end if;
		if permissionNames is null then
			permissionNames:=permissionName;
		else
			permissionNames:=permissionNames||','||permissionName;
		end if;
	end loop;
	close c1;
end getRolePermissions;
/
