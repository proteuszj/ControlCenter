
declare
	version varchar2(20);
	n integer;
begin
	select count(*) into n from CFG_PARAM where PARAM_NAME='DATABASE_VERSION';
	if n=0 then version:='0';
	else select PARAM_VALUE into version from CFG_PARAM where PARAM_NAME='DATABASE_VERSION';
	end if;

	case version
		when '0' then
            dbms_output.put_line('version 0');
            delete cfg_dict where dict_type=1004;
			delete cfg_dict where dict_code='1004';
			execute immediate 'alter table cfg_dict modify (DICT_CODE varchar2(20))';
			execute immediate 'alter table cfg_dict modify (DICT_NAME varchar2(100))';
			execute immediate 'alter table cfg_dict modify (DICT_MEMO varchar2(100))';
            execute immediate 'alter table sys_permission rename column IS_ADMIN_PRIVILEGES to IS_ADMIN';
			execute immediate 'alter table sys_permission modify (IS_ADMIN integer default 0 not null)';
			execute immediate 'alter table sys_permission add (IS_POLICE integer default 0 not null)';
			execute immediate 'alter table sys_permission add (CATEGORY varchar2(10))';
			execute immediate 'alter table bas_place rename column qulified_car_type to QUALIFIED_CAR_TYPE';
			execute immediate 'alter table bas_device rename column qulified_car_type to QUALIFIED_CAR_TYPE';
			execute immediate 'alter table bas_car rename column qulified_car_type to QUALIFIED_CAR_TYPE';
			execute immediate 'alter table bas_examiner rename column qulified_car_type to QUALIFIED_CAR_TYPE';
			execute immediate 'alter table bas_driving_school rename column qulified_car_type to QUALIFIED_CAR_TYPE';
			INSERT INTO CFG_DICT (ID, DICT_TYPE, DICT_CODE, DICT_NAME, VIEW_INDEX, DICT_MEMO)
			VALUES (SEQU_CFG_DICT_ID.NEXTVAL, -1, '1039', '权限分类', -1, '业务字典类型');
			INSERT INTO CFG_DICT (ID, DICT_TYPE, DICT_CODE, DICT_NAME, VIEW_INDEX, DICT_MEMO)
			VALUES (SEQU_CFG_DICT_ID.NEXTVAL, 1039, 'BUSINESS', '业务办理', 1, '权限分类');
			INSERT INTO CFG_DICT (ID, DICT_TYPE, DICT_CODE, DICT_NAME, VIEW_INDEX, DICT_MEMO)
			VALUES (SEQU_CFG_DICT_ID.NEXTVAL, 1039, 'SYSTEM', '系统管理', 2, '权限分类');
			INSERT INTO CFG_DICT (ID, DICT_TYPE, DICT_CODE, DICT_NAME, VIEW_INDEX, DICT_MEMO)
			VALUES (SEQU_CFG_DICT_ID.NEXTVAL, 1039, 'SECURITY', '安全管理', 3, '权限分类');
			INSERT INTO CFG_DICT (ID, DICT_TYPE, DICT_CODE, DICT_NAME, VIEW_INDEX, DICT_MEMO)
			VALUES (SEQU_CFG_DICT_ID.NEXTVAL, 1039, 'AUDIT', '审计管理', 4, '权限分类');
			execute immediate 'alter table sys_role add (CATEGORY varchar2(10) default ''BUSINESS'' not null)';
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'BOOKING_DATE_LIMIT', '预约日期限制', 'INT', '1', '1为当天；2为2天之内；3为3天之内；依此类推');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '000000', '00:00:00', 'BOOL', 'FALSE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '010000', '01:00:00', 'BOOL', 'FALSE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '020000', '02:00:00', 'BOOL', 'FALSE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '030000', '03:00:00', 'BOOL', 'FALSE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '040000', '04:00:00', 'BOOL', 'FALSE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '050000', '05:00:00', 'BOOL', 'FALSE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '060000', '06:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '070000', '07:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '080000', '08:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '090000', '09:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '100000', '10:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '110000', '11:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '120000', '12:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '130000', '13:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '140000', '14:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '150000', '15:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '160000', '16:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '170000', '17:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '180000', '18:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '190000', '19:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '200000', '20:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '210000', '21:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '220000', '22:00:00', 'BOOL', 'TRUE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '230000', '23:00:00', 'BOOL', 'FALSE', 'TRUE当前时段可用；FALSE当前时段不可用');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'DATABASE_VERSION', '数据库版本', 'CHAR', '1.0.0.2', '主版本.次版本.分支版本.发布版本，分支版本0表示通用版本');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 1, 1, 'VEHICLE_VERSION', '车载程序版本', 'CHAR', '1.0.1013.2', '主版本.次版本.分支版本.发布版本，分支版本0表示通用版本');

			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'CAR_ALLOCATION_INTERVAL', '刷新时间（秒）', 'INT', '1', '分车程序车辆状态刷新时间间隔');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'CAR_ALLOCATION_PROJECT_ADDRESS', '投显地址', 'CHAR', '192.168.1.100', '分车程序投显终端地址');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'CAR_ALLOCATION_PROJECT_PORT', '投显端口', 'INT', '5678', '分车程序投显终端端口');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'CAR_ALLOCATION_PROJECT_COUNT', '投显数量', 'INT', '10', '分车程序投显学员数量');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'CAR_ALLOCATION_WAITING_TIMEOUT', '等候超时（分钟）', 'INT', '10', '已分车学员上车等待时间，过号重排时间');

			update SYS_PERMISSION set NAME='培训管理' where CODE='0200';
			update SYS_PERMISSION set NAME='预约培训' where CODE='0201';
			update SYS_PERMISSION set NAME='分车叫号' where CODE='0203'; 
			update SYS_PERMISSION set NAME='支付流水' where CODE='0202'; 
			insert into SYS_PERMISSION(CODE, NAME) values('0204', '过程查询');

			insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0204');
			insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0204');
			execute immediate 'alter table BUZ_EXAM_INFO add(CAR_ID integer)';
			
			commit;
			update bas_booking set CAR_ID=(select id from bas_car where license_plate='冀A-9630学') where student_id=(select id from bas_student where idnumber='111111111111119630');
			execute immediate 'update buz_exam_info set car_id=(select id from bas_car where license_plate=''冀A-9630学'') where booking_id in (select id from bas_booking where student_id=(select id from bas_student where idnumber=''111111111111119630''))';
			update bas_booking set car_id=(select id from bas_car where license_plate='冀A-E433学') where student_id=(select id from bas_student where idnumber='222222222222226433');
			execute immediate 'update buz_exam_info set car_id=(select id from bas_car where license_plate=''冀A-E433学'') where booking_id in (select id from bas_booking where student_id=(select id from bas_student where idnumber=''222222222222226433''))';
			update bas_booking set car_id=(select id from bas_car where license_plate='冀A-2690学') where student_id=(select id from bas_student where idnumber='111111111111112690');
			execute immediate 'update buz_exam_info set car_id=(select id from bas_car where license_plate=''冀A-2690学'') where booking_id in (select id from bas_booking where student_id=(select id from bas_student where idnumber=''111111111111112690''))';
			update bas_booking set car_id=(select id from bas_car where license_plate='冀A-2663学') where student_id=(select id from bas_student where idnumber='111111111111112663');
			execute immediate 'update buz_exam_info set car_id=(select id from bas_car where license_plate=''冀A-2663学'') where booking_id in (select id from bas_booking where student_id=(select id from bas_student where idnumber=''111111111111112663''))';
			update bas_booking set car_id=(select id from bas_car where license_plate='冀A-2677学') where student_id=(select id from bas_student where idnumber='111111111111112677');
			execute immediate 'update buz_exam_info set car_id=(select id from bas_car where license_plate=''冀A-2677学'') where booking_id in (select id from bas_booking where student_id=(select id from bas_student where idnumber=''111111111111112677''))';
			commit;
            
            --Views\BAS_STUDENT_VIEW
execute immediate 'CREATE OR REPLACE FORCE VIEW BAS_STUDENT_VIEW AS
SELECT  (select DICT_NAME from CFG_DICT where DICT_TYPE=2002 and DICT_CODE=IDTYPE) IDTYPE_DICT_NAME,
		IDNUMBER,
		NAME,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=2001 and DICT_CODE=GENDER) GENDER_DICT_NAME,
		DRIVER_LICENSE_TYPE,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=2003 and DICT_CODE=DRIVER_LICENSE_TYPE) DRIVER_LICENSE_TYPE_DICT_NAME,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1036 and DICT_CODE=STATUS) STATUS_DICT_NAME,
		SCHOOL_NAME,
		ID,
		PHOTO1,
		PHOTO2,
		case when exists(select * from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=BAS_STUDENT.ID) then ''已预约'' else ''未预约'' end BOOKED,
		case when exists(select * from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=BAS_STUDENT.ID) then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=BAS_STUDENT.ID) else null end BOOK_TIMES,
		case when exists(select * from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=BAS_STUDENT.ID) then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=BAS_STUDENT.ID)-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=BAS_STUDENT.ID)) else null end LEFT_TIMES,
		CREATE_TIME,
		UPDATE_TIME
FROM BAS_STUDENT
order by ID';
            --Views\BUZ_PAYMENT_DETAIL_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW BUZ_PAYMENT_DETAIL_VIEW AS
SELECT  case when HASH is not null and HASH=GenerateSHA1(TRADE_NO||PAY_TIME||OPERATOR_NAME||OPERATOR_IDNUMBER||STUDENT_IDNUMBER||TIMES||AMOUNT||BOOKING_ID||PRICING_STRATEGY) then ''TRUE'' else ''FALSE'' end VERIFY,
		TRADE_NO,
		PAY_TIME,
		OPERATOR_NAME,
		OPERATOR_IDNUMBER,
		(select NAME from BAS_STUDENT where IDNUMBER=STUDENT_IDNUMBER) STUDENT_NAME,
		STUDENT_IDNUMBER,
		(select SCHOOL_NAME from BAS_STUDENT where IDNUMBER=STUDENT_IDNUMBER) SCHOOL_NAME,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1006 and DICT_CODE=SUBJECT) SUBJECT_DICT_NAME,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1002 and DICT_CODE=FEE_TYPE) FEE_TYPE_DICT_NAME,
		TIMES,
		AMOUNT,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1001 and DICT_CODE=PAYMENT_WAY) PAYMENT_WAY,
		(select DRIVER_LICENSE_TYPE from BAS_BOOKING where ID=BOOKING_ID) DRIVER_LICENSE_TYPE,
		case when (select CAR_ID from BAS_BOOKING where ID=BOOKING_ID) is null then null else (select LICENSE_PLATE from BAS_CAR where ID=(select CAR_ID from BAS_BOOKING where ID=BOOKING_ID)) end CAR,
		(select BOOKING_DATETIME from BAS_BOOKING where ID=BOOKING_ID) BOOKING_DATETIME,
		PRICING_STRATEGY,
		HASH
FROM BUZ_PAYMENT_DETAIL
order by ID';
            --Views\SYS_ROLE_PERMISSION_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW SYS_ROLE_PERMISSION_VIEW AS
SELECT	ROLE_ID,
		(select NAME from SYS_ROLE where ID=ROLE_ID) ROLE_NAME,
		PERMISSION_CODE,
		(select NAME from SYS_PERMISSION where CODE=PERMISSION_CODE) PERMISSION_NAME,
		(select IS_ADMIN from SYS_PERMISSION where CODE=PERMISSION_CODE) IS_ADMIN,
		(select IS_POLICE from SYS_PERMISSION where CODE=PERMISSION_CODE) IS_POLICE
FROM SYS_ROLE_PERMISSION';
            --Views\SYS_USER_ROLE_PERMISSION_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW SYS_USER_ROLE_PERMISSION_VIEW AS
SELECT	SYS_USER.LOGIN_NAME,
		SYS_USER.USER_NAME,
		SYS_USER.ROLE_ID,
		(select NAME from SYS_ROLE where ID=SYS_ROLE_PERMISSION.ROLE_ID) ROLE_NAME,
		PERMISSION_CODE,
		(select NAME from SYS_PERMISSION where CODE=PERMISSION_CODE) PERMISSION_NAME,
		(select IS_ADMIN from SYS_PERMISSION where CODE=PERMISSION_CODE) IS_ADMIN,
		(select IS_POLICE from SYS_PERMISSION where CODE=PERMISSION_CODE) IS_POLICE
FROM SYS_ROLE_PERMISSION, SYS_USER
WHERE SYS_USER.ROLE_ID=SYS_ROLE_PERMISSION.ROLE_ID';
            --StoredProcedures\GetRolePermissions;
execute immediate 'create or replace procedure GetRolePermissions
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
			permissionName:=''*''||permissionName;
		end if;
		if isPolice=1 then
			permissionName:=''#''||permissionName;
		end if;
		if permissionNames is null then
			permissionNames:=permissionName;
		else
			permissionNames:=permissionNames||'',''||permissionName;
		end if;
	end loop;
	close c1;
end getRolePermissions;';
            --StoredProcedures\GrantRolePermission;
execute immediate 'create or replace function GrantRolePermission 
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
	message:=roleName||''+''||permissionName;
	select count(*) into n from SYS_ROLE where NAME=roleName;
	if n=0 then
		message:=message||'', 角色不存在: ''||roleName;
		AddLog(operatorLoginName, ''权限管理'', ''增加'', message, 0, null, null);
		return -1;
	else
		select ID, CATEGORY into roleID, roleCategory from SYS_ROLE where NAME=roleName;
	end if;

	select count(*) into n from SYS_PERMISSION where NAME=permissionName;
	if n=0 then
		message:=message||'', 权限不存在: ''||permissionName;
		AddLog(operatorLoginName, ''权限管理'', ''增加'', message, 0, null, null);
		return -2;
	else
		select CODE, CATEGORY into permissionCode, permissionCategory from SYS_PERMISSION where NAME=permissionName;
	end if;

	if permissionCategory is not null and roleCategory<>permissionCategory then
		message:=message||'', 角色与权限类别不同: ''||roleCategory||'' vs ''||permissionCategory;
		AddLog(operatorLoginName, ''权限管理'', ''增加'', message, 0, null, null);
		return -3;
	end if;

	select count(*) into n from SYS_ROLE_PERMISSION where ROLE_ID=roleID and PERMISSION_CODE=permissionCode;
	if n=0 then
		insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values(roleID, permissionCode);
		message:=message||'', 成功'';
		AddLog(operatorLoginName, ''权限管理'', ''增加'', message, 1, null, null);
	else
		message:=message||'', 权限已存在'';
		AddLog(operatorLoginName, ''权限管理'', ''增加'', message, 0, null, null);
	end if;
	return 0;
end GrantRolePermission;';
            --StoredProcedures\Logout;
execute immediate 'create or replace procedure Logout 
(
	loginName in varchar2,
	ip in varchar2,
	mac in varchar2
) as
	code CFG_DICT.DICT_CODE%TYPE;
begin
	select DICT_CODE into code from CFG_DICT where DICT_TYPE=1013 and DICT_NAME=''未登录'';
	update SYS_USER set STATUS=code where LOGIN_NAME=loginName;
	
	addLog(loginName, ''系统'', ''离开'', NULL, 1, ip, mac);
end logout;';
            --StoredProcedures\RevokeRolePermission;
execute immediate 'create or replace function RevokeRolePermission
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
	message:=roleName||''-''||permissionName;
	select count(*) into n from SYS_ROLE where NAME=roleName;
	if n=0 then
		message:=message||'', 角色不存在: ''||roleName;
		AddLog(operatorLoginName, ''权限管理'', ''删除'', message, 0, null, null);
		return -1;
	else
		select ID into roleID from SYS_ROLE where NAME=roleName;
	end if;

	select count(*) into n from SYS_PERMISSION where NAME=permissionName;
	if n=0 then
		message:=message||'', 权限不存在: ''||permissionName;
		AddLog(operatorLoginName, ''权限管理'', ''删除'', message, 0, null, null);
		return -2;
	else
		select CODE into permissionCode from SYS_PERMISSION where NAME=permissionName;
	end if;

	select count(*) into n from SYS_ROLE_PERMISSION where ROLE_ID=roleID and PERMISSION_CODE=permissionCode;
	if n=0 then
		message:=message||'', 授权不存在'';
		AddLog(operatorLoginName, ''权限管理'', ''删除'', message, 0, null, null);
		return -3;
	else
		delete from SYS_ROLE_PERMISSION where ROLE_ID=roleID and PERMISSION_CODE=permissionCode;
		message:=message||'', 成功'';
		AddLog(operatorLoginName, ''权限管理'', ''删除'', message, 1, null, null);
		return 0;
	end if;
end RevokeRolePermission;';
            --StoredProcedures\BookFromManagement;
execute immediate 'create or replace function BookFromManagement
(
	message out varchar2,
	operatorLoginName in varchar2,
	studentIDNumber in BAS_STUDENT.IDNUMBER%TYPE,
	subjectName in varchar2,
	times in integer,
	amount in number,
	paymentWay in CFG_DICT.DICT_NAME%TYPE,
	bookingDatetime in BAS_BOOKING.BOOKING_DATETIME%TYPE,
	carLicensePlate in BAS_CAR.LICENSE_PLATE%TYPE,
	cashierName in varchar2,
	cashierIDNumber in varchar2,
	hostIP in varchar2,					--host ip
	hostMAC in varchar2					--host mac
) return integer as
	n integer;
	studentID BAS_STUDENT.ID%TYPE;
	licenseType BAS_STUDENT.DRIVER_LICENSE_TYPE%TYPE;
	schoolName BAS_DRIVING_SCHOOL.NAME%TYPE;
	carID BAS_CAR.ID%TYPE;
	bookingID BAS_BOOKING.ID%TYPE;
	tradeNumber BUZ_PAYMENT_DETAIL.TRADE_NO%TYPE;
	currentDate BAS_BOOKING.BOOKING_DATETIME%TYPE;
begin
	select count(*) into n from SYS_USER where LOGIN_NAME=operatorLoginName;
	if n=0 then
		message:=''操作员：''||operatorLoginName||''不存在'';
		AddLog(operatorLoginName, ''学员管理'', ''预约'', message, 0, hostIP, hostMAC);
		return -1;
	end if;

	select count(*) into n from BAS_STUDENT where IDNUMBER=studentIDNumber;
	if n=0 then
		message:=''学员：''||studentIDNumber||''不存在'';
		AddLog(operatorLoginName, ''学员管理'', ''预约'', message, 0, hostIP, hostMAC);
		return -2;
	end if;
	select ID, DRIVER_LICENSE_TYPE, SCHOOL_NAME into studentID, licenseType, schoolName from BAS_STUDENT where IDNUMBER=studentIDNumber;

	if amount<>GetPriceByTimes(message, times, bookingDatetime, schoolName, studentIDNumber) then
		message:=''金额不正确'';
		AddLog(operatorLoginName, ''学员管理'', ''预约'', message, 0, hostIP, hostMAC);
		return -3;
	end if;

	if carLicensePlate is not null and length(carLicensePlate)>0 then
		select count(*) into n from BAS_CAR where LICENSE_PLATE=carLicensePlate;
		if n=0 then
			message:=''车辆：''||carLicensePlate||''不存在'';
			AddLog(operatorLoginName, ''学员管理'', ''预约'', message, 0, hostIP, hostMAC);
			return -4;
		end if;
		select ID into carID from BAS_CAR where LICENSE_PLATE=carLicensePlate;
	end if;

	select count(*) into n from BAS_BOOKING where STUDENT_ID=studentID and BOOKING_EXAM_DATE=substr(bookingDatetime, 1, 8) and not exists((select * from buz_exam_info where BOOKING_ID=BAS_BOOKING.ID));
	if n>0 then
		message:=''预约失败，有未使用的预约'';
		AddLog(operatorLoginName, ''学员管理'', ''预约'', message, 0, hostIP, hostMAC);
		return -5;
	end if;

	bookingID:=SEQU_BAS_BOOKING_ID.nextval;
	insert into BAS_BOOKING(
		ID,
		SEQUENCENUMBER,
		SUBJECT,
		EXAMNUMBER,
		STUDENT_ID,
		BOOKING_DATETIME,
		BOOKING_TIMES,
		BOOKING_EXAM_DATE,
		DRIVER_LICENSE_TYPE,
		PLACE_ID,
		CAR_ID,
		OPERATOR_NAME,
		BRANCH_ADMINISTRATION,
		SCHOOL_ID,
		BRANCH_BUSINESS,
		SIGN_STATUS)
	values(
		bookingID,
		NewBookSequenceNumber,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName),
		NewExamNumber,
		studentID,
		bookingDatetime,
		times,
		substr(bookingDatetime, 1, 8),
		licenseType,
		(select max(ID) from BAS_PLACE),
		carID,
		operatorLoginName,
		''管理'',
		(select ID from BAS_DRIVING_SCHOOL where NAME=schoolName),
		''业务'',
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1031 and DICT_NAME=''已签到''));

	tradeNumber:=NewTradeNumber;
	currentDate:=to_char(current_date, ''yyyymmddhh24miss'');
	insert into BUZ_PAYMENT_DETAIL(
		ID,
		TRADE_NO,
		PAY_TIME,
		OPERATOR_NAME,
		OPERATOR_IDNUMBER,
		STUDENT_IDNUMBER,
		SUBJECT,
		FEE_TYPE,
		TIMES,
		AMOUNT,
		PAYMENT_WAY,
		BOOKING_ID,
		PRICING_STRATEGY,
		HASH)
	values(
		SEQU_BUZ_PAYMENT_DETAIL_ID.nextval,
		tradeNumber,
		currentDate,
		cashierName,
		cashierIDNumber,
		studentIDNumber,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName),
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1002 and DICT_NAME=''计次''),
		times,
		amount,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1001 and DICT_NAME=paymentWay),
		bookingID,
		message,
		GenerateSHA1(tradeNumber||currentDate||cashierName||cashierIDNumber||studentIDNumber||times||amount||bookingID||message));

	commit;
	message:=''交易序号：''||tradeNumber||chr(13)||chr(10)
		||''交易时间：''||currentDate||chr(13)||chr(10)
		||''收银员姓名：''||cashierName||chr(13)||chr(10)
		||''收银员身份证号：''||cashierIDNumber||chr(13)||chr(10)
		||''学员身份证号：''||studentIDNumber||chr(13)||chr(10)
		||''次数：''||times||chr(13)||chr(10)
		||''金额：''||amount||chr(13)||chr(10);
	AddLog(operatorLoginName, ''学员管理'', ''预约'', message, 1, hostIP, hostMAC);
	return 0;
end BookFromManagement;';
            --StoredProcedures\BookFromVehicleNoPassword;
execute immediate 'create or replace function BookFromVehicleNoPassword
(
	message out varchar2,
	bookingID out BAS_BOOKING.ID%TYPE,
	operatorIDNumber in varchar2,
	studentIDNumber in BAS_STUDENT.IDNUMBER%TYPE,
	subjectName in varchar2,
	times in integer,
	amount in number,
	paymentWay in CFG_DICT.DICT_NAME%TYPE,
	hostIP in varchar2,					--host ip
	hostMAC in varchar2					--host mac
) return integer as
	n integer;
	operatorLoginName SYS_USER.LOGIN_NAME%TYPE;
	operatorName SYS_USER.USER_NAME%TYPE;
	studentID BAS_STUDENT.ID%TYPE;
	licenseType BAS_STUDENT.DRIVER_LICENSE_TYPE%TYPE;
	schoolName BAS_DRIVING_SCHOOL.NAME%TYPE;
	currentDate BAS_BOOKING.BOOKING_DATETIME%TYPE;
	tradeNumber BUZ_PAYMENT_DETAIL.TRADE_NO%TYPE;
begin
	select count(*) into n from SYS_USER where IDNUMBER=operatorIDNumber;
	if n=0 then
		message:=''操作员：''||operatorIDNumber||''不存在'';
		AddLog('''', ''学员管理'', ''预约'', message, 0, hostIP, hostMAC);
		return -1;
	end if;
	
	select LOGIN_NAME, USER_NAME into operatorLoginName, operatorName from SYS_USER where IDNUMBER=operatorIDNumber;

	select count(*) into n from BAS_STUDENT where IDNUMBER=studentIDNumber;
	if n=0 then
		message:=''学员：''||studentIDNumber||''不存在'';
		AddLog(operatorLoginName, ''学员管理'', ''预约'', message, 0, hostIP, hostMAC);
		return -3;
	end if;
	select ID, DRIVER_LICENSE_TYPE, SCHOOL_NAME into studentID, licenseType, schoolName from BAS_STUDENT where IDNUMBER=studentIDNumber;
	if amount<>GetPriceByTimes(message, times, to_char(current_date, ''yyyymmddhh24miss''), schoolName, studentIDNumber) then
		message:=''金额不正确'';
		AddLog(operatorLoginName, ''学员管理'', ''预约'', message, 0, hostIP, hostMAC);
		return -4;
	end if;

	bookingID:=SEQU_BAS_BOOKING_ID.nextval;
	currentDate:=to_char(current_date, ''yyyymmddhh24miss'');
	insert into BAS_BOOKING(
		ID,
		SEQUENCENUMBER,
		SUBJECT,
		EXAMNUMBER,
		STUDENT_ID,
		BOOKING_DATETIME,
		BOOKING_TIMES,
		BOOKING_EXAM_DATE,
		DRIVER_LICENSE_TYPE,
		PLACE_ID,
		OPERATOR_NAME,
		BRANCH_ADMINISTRATION,
		SCHOOL_ID,
		BRANCH_BUSINESS,
		SIGN_STATUS)
	values(
		bookingID,
		NewBookSequenceNumber,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName),
		NewExamNumber,
		studentID,
		currentDate,
		times,
		substr(currentDate, 1, 8),
		licenseType,
		(select max(ID) from BAS_PLACE),
		operatorLoginName,
		''管理'',
		(select ID from BAS_DRIVING_SCHOOL where NAME=schoolName),
		''业务'',
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1031 and DICT_NAME=''已签到''));

	tradeNumber:=NewTradeNumber;
	insert into BUZ_PAYMENT_DETAIL(
		ID,
		TRADE_NO,
		PAY_TIME,
		OPERATOR_NAME,
		OPERATOR_IDNUMBER,
		STUDENT_IDNUMBER,
		SUBJECT,
		FEE_TYPE,
		TIMES,
		AMOUNT,
		PAYMENT_WAY,
		BOOKING_ID,
		PRICING_STRATEGY,
		HASH)
	values(
		SEQU_BUZ_PAYMENT_DETAIL_ID.nextval,
		tradeNumber,
		currentDate,
		operatorName,
		operatorIDNumber,
		studentIDNumber,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName),
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1002 and DICT_NAME=''计次''),
		times,
		amount,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1001 and DICT_NAME=paymentWay),
		bookingID,
		message,
		GenerateSHA1(tradeNumber||currentDate||operatorName||operatorIDNumber||studentIDNumber||times||amount||bookingID||message));

	commit;
	message:=''交易序号：''||tradeNumber||chr(13)||chr(10)
		||''交易时间：''||currentDate||chr(13)||chr(10)
		||''操作员姓名：''||operatorName||chr(13)||chr(10)
		||''操作员身份证号：''||operatorIDNumber||chr(13)||chr(10)
		||''学员身份证号：''||studentIDNumber||chr(13)||chr(10)
		||''次数：''||times||chr(13)||chr(10)
		||''金额：''||amount||chr(13)||chr(10);
	AddLog(operatorLoginName, ''学员管理'', ''预约'', message, 1, hostIP, hostMAC);
	return 0;
end BookFromVehicleNoPassword;';
            --StoredProcedures\ShowDateTime;
execute immediate 'create or replace function ShowDateTime
(
	datetimeStr in varchar2
)return varchar2 as
begin
	case length(datetimeStr)
		when 14	then return to_char(to_date(datetimeStr, ''yyyymmddhh24miss''), ''yyyy-mm-dd hh24:mi:ss'');
		when 8 then return to_char(to_date(datetimeStr, ''yyyymmdd''), ''yyyy-mm-dd'');
		when 6 then return to_char(to_date(datetimeStr, ''hh24miss''), ''hh24:mi:ss'');
		else return datetimeStr;
	end case;
end ShowDateTime;';
			--StoredProcedures\AddUpdateCar;
execute immediate 'create or replace procedure AddUpdateCar
(
  message out varchar2,
  operatorLoginName in varchar2,
  licenseNo in varchar2,
  subjectName in varchar2,
  carNo in varchar2,
  qualifiedLicenseTypes in varchar2,
  carBrand in varchar2,
  ip in varchar2,
  expireDate in varchar2,
  carMap blob
) as
  n number;
  newSubject BAS_CAR.SUBJECT%TYPE;
  newCarNumber BAS_CAR.CARNUMBER%TYPE;
  newQualifiedLicenseType BAS_CAR.QUALIFIED_CAR_TYPE%TYPE;
  newBrand BAS_CAR.BRAND%TYPE;
  newExpireDate BAS_CAR.SCRAP_DATE%TYPE;
  newIP BAS_CAR.CAR_IP%TYPE;
begin
  select count(*) into n from BAS_CAR where LICENSE_PLATE=licenseNo;
  if n>0 then
    select SUBJECT, CARNUMBER, QUALIFIED_CAR_TYPE, BRAND, SCRAP_DATE, CAR_IP into newSubject, newCarNumber, newQualifiedLicenseType, newBrand, newExpireDate, newIP from BAS_CAR where LICENSE_PLATE=licenseNo;
	if subjectName is not null then select DICT_CODE into newSubject from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName; end if;
	if carNo is not null then newCarNumber:=carNo; end if;
	if qualifiedLicenseTypes is not null then newQualifiedLicenseType:=qualifiedLicenseTypes; end if;
	if carBrand is not null then newBrand:=carBrand; end if;
	if ip is not null then newIP:=ip; end if;
	if expireDate is not null then newExpireDate:=expireDate; end if;
	update BAS_CAR set SUBJECT=newSubject, CARNUMBER=newCarNumber, QUALIFIED_CAR_TYPE=newQualifiedLicenseType, BRAND=newBrand, SCRAP_DATE=newExpireDate, CAR_IP=newIP, UPDATE_TIME=to_char(current_date, ''yyyymmddhh24miss'') where LICENSE_PLATE=licenseNo;
	if carMap is not null then update BAS_CAR set CAR_MAP=carMap where LICENSE_PLATE=licenseNo; end if;
	message:=''车辆''||licenseNo;
	AddLog(operatorLoginName, ''备案信息管理'', ''修改'', message, 1, null, null);
	commit;
  else
    insert into BAS_CAR(
	  ID,
	  SEQUENCENUMBER,
	  SUBJECT,
	  LICENSE_PLATE_TYPE,
	  CARNUMBER,
	  LICENSE_PLATE,
	  QUALIFIED_CAR_TYPE,
	  CAR_TYPE,
	  BRAND,
	  REGISTER_DATE,
	  SCRAP_DATE, 
	  ISSUING_AUTHORITY, 
	  CAR_STATUS, 
	  USE_STATUS,
	  AUDITOR,
	  CAR_IP,
	  CAR_MAP,
	  CREATE_TIME,
	  UPDATE_TIME)
	values(
	  SEQU_BAS_CAR_ID.nextval,
	  NewCarSequenceNumber,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName),
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2006 and DICT_NAME=''小型汽车''),
	  carNo,
	  licenseNo,
	  qualifiedLicenseTypes,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2004 and DICT_NAME=''小型轿车''),
	  carBrand,
	  to_char(current_date, ''yyyymmdd''),
	  expireDate,
	  ''发证'',
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2005 and DICT_NAME=''正常''),
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1016 and DICT_NAME=''正常''),
	  ''审核人'',
	  ip,
	  carMap,
	  to_char(current_date, ''yyyymmddhh24miss''),
	  to_char(current_date, ''yyyymmddhh24miss'')
	);
	message:=''车辆''||licenseNo;
    AddLog(operatorLoginName, ''备案信息管理'', ''增加'', message, 1, null, null);
	commit;
  end if;
end addUpdateCar;';
			--StoredProcedures\AddUpdateDevice;
execute immediate 'create or replace procedure AddUpdateDevice
(
  message out varchar2,
  operatorLoginName in varchar2,
  deviceNo in varchar2,
  deviceDescription in varchar2,
  deviceManufacture in varchar2,
  deviceSerial in varchar2,
  examItemName in varchar2,
  placeCode in varchar2,
  acceptanceDate in varchar2,
  expireDate in varchar2
) as
  n number;
  newDescription BAS_DEVICE.DESCRIPTION%TYPE;
  newManufacture BAS_DEVICE.MANUFACTURER%TYPE;
  newSerial BAS_DEVICE.SERIALNUMBER%TYPE;
  newExamItemCode BAS_DEVICE.EXAM_ITEM%TYPE;
  newExamItemName BAS_DEVICE.EXAM_ITEM_NAME%TYPE;
  newPlace BAS_DEVICE.PLACE_ID%TYPE;
  newAcceptanceDate BAS_DEVICE.ACCEPTANCE_DATE%TYPE;
  newExpireDate BAS_DEVICE.EXPIRE_DATE%TYPE;
begin
  select count(*) into n from BAS_DEVICE where DEVICENUMBER=deviceNo;
  if (n>0) then
	select DESCRIPTION, MANUFACTURER, SERIALNUMBER, EXAM_ITEM, EXAM_ITEM_NAME, PLACE_ID, ACCEPTANCE_DATE, EXPIRE_DATE into newDescription, newManufacture, newSerial, newExamItemCode, newExamItemName, newPlace, newAcceptanceDate, newExpireDate from BAS_DEVICE where DEVICENUMBER=deviceNo;
	if deviceDescription is not null then newDescription:=deviceDescription; end if;
	if deviceManufacture is not null then newManufacture:=deviceManufacture; end if;
	if deviceSerial is not null then newSerial:=deviceSerial; end if;	
	if examItemName is not null then select ITEM_CODE into newExamItemCode from CFG_ITEMS where ITEM_NAME=examItemName; newExamItemName:=examItemName; end if;
	if placeCode is not null then select ID into newPlace from BAS_PLACE where CODE=placeCode; end if;
	if acceptanceDate is not null then newAcceptanceDate:=acceptanceDate; end if;
	if expireDate is not null then newExpireDate:=expireDate; end if;
	update BAS_DEVICE set DESCRIPTION=newDescription, MANUFACTURER=newManufacture, SERIALNUMBER=newSerial, EXAM_ITEM=newExamItemCode, EXAM_ITEM_NAME=newExamItemName, PLACE_ID=newPlace, ACCEPTANCE_DATE=newAcceptanceDate, EXPIRE_DATE=newExpireDate, UPDATE_TIME=to_char(current_date, ''yyyymmddhh24miss'') where DEVICENUMBER=deviceNo;
	message:=''设备:''||deviceNo||deviceDescription;
	AddLog(operatorLoginName, ''备案信息管理'', ''修改'', message, 1, null, null);
	commit;
  else
    insert into BAS_DEVICE(
	  ID,
	  SEQUENCENUMBER,
	  DEVICENUMBER,
	  DESCRIPTION,
	  MANUFACTURER,
	  SERIALNUMBER,
	  EXAM_ITEM,
	  EXAM_ITEM_NAME,
	  PLACE_ID,
	  QUALIFIED_CAR_TYPE,
	  ACCEPTANCE_DATE,
	  EXPIRE_DATE,
	  SINGLE_EXAM_TIMES,
	  HOURLY_EXAM_TIMES,
	  STATUS,
	  CREATE_TIME,
	  UPDATE_TIME)
	values(
	  SEQU_BAS_DEVICE_ID.nextval,
	  NewDeviceSequenceNumber,
	  deviceNo,
	  deviceDescription,
	  deviceManufacture,
	  deviceSerial,
	  (select ITEM_CODE from CFG_ITEMS where ITEM_NAME=examItemName),
	  examItemName,
	  (select ID from BAS_PLACE where CODE=placeCode),
	  ''C1C2'',
	  acceptanceDate,
	  expireDate,
	  0,	--temp
	  0,	--temp
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1022 and DICT_NAME=''正常''),
	  to_char(current_date, ''yyyymmddhh24miss''),
	  to_char(current_date, ''yyyymmddhh24miss''));
	message:=''设备:''||deviceNo||deviceDescription;
	AddLog(operatorLoginName, ''备案信息管理'', ''增加'', message, 1, null, null);
	commit;
  end if;
end AddUpdateDevice;';
			--StoredProcedures\AddUpdateExaminer;
execute immediate 'create or replace procedure AddUpdateExaminer
(
  message out varchar2,
  operatorLoginName in varchar2,
  idNo in varchar2,
  idTypeName in varchar2,
  examinerName in varchar2,
  examinerGender in varchar2,
  birth in varchar2,
  issuingAuthority in varchar2,
  issuingDate in varchar2,
  expireDate in varchar2,
  office in varchar2,
  operatorName in varchar2,
  issuingOffice in varchar2
) as
  n number;
  newIDType BAS_EXAMINER.IDTYPE%TYPE;
  newName BAS_EXAMINER.NAME%TYPE;
  newGender BAS_EXAMINER.GENDER%TYPE;
  newBirth BAS_EXAMINER.BIRTH_DATE%TYPE;
  newIssuingAuthority BAS_EXAMINER.ISSUING_AUTHORITY%TYPE;
  newIssuingDate BAS_EXAMINER.ISSUING_DATE%TYPE;
  newExpireDate BAS_EXAMINER.EXPIRE_DATE%TYPE;
  newOffice BAS_EXAMINER.WORK_OFFICE%TYPE;
  newOperatorName BAS_EXAMINER.OPERATOR_NAME%TYPE;
  newIssuingOffice BAS_EXAMINER.ISSUING_OFFICE%TYPE;
begin
  select count(*) into n from BAS_EXAMINER where IDNUMBER=idNo;
  if (n>0) then
	select IDTYPE, NAME, GENDER, BIRTH_DATE, ISSUING_AUTHORITY, ISSUING_DATE, EXPIRE_DATE, WORK_OFFICE, OPERATOR_NAME, ISSUING_OFFICE into newIDType, newName, newGender, newBirth, newIssuingAuthority, newIssuingDate, newExpireDate, newOffice, newOperatorName, newIssuingOffice from BAS_EXAMINER where IDNUMBER=idNo;
	if idTypeName is not null then select DICT_CODE into newIDType from CFG_DICT where DICT_TYPE=2002 and DICT_NAME=idTypeName; end if;
	if examinerName is not null then newName:=examinerName; end if;
	if examinerGender is not null then select DICT_CODE into newGender from CFG_DICT where DICT_TYPE=2001 and DICT_NAME=examinerGender; end if;
	if birth is not null then newBirth:=birth; end if;
	if issuingAuthority is not null then newIssuingAuthority:=issuingAuthority; end if;
	if issuingDate is not null then newIssuingDate:=issuingDate; end if;
	if expireDate is not null then newExpireDate:=expireDate; end if;
	if office is not null then newOffice:=office; end if;
	if operatorName is not null then newOperatorName:=operatorName; end if;
	if issuingOffice is not null then newIssuingOffice:=issuingOffice; end if;	
	update BAS_EXAMINER set IDTYPE=newIDType, NAME=newName, GENDER=newGender, BIRTH_DATE=newBirth, ISSUING_AUTHORITY=newIssuingAuthority, ISSUING_DATE=newIssuingDate, EXPIRE_DATE=newExpireDate, WORK_OFFICE=newOffice, OPERATOR_NAME=newOperatorName, ISSUING_OFFICE=newIssuingOffice, UPDATE_TIME=to_char(current_date, ''yyyymmddhh24miss'') where IDNUMBER=idNo;
	message:=''考试员：''||examinerName||idNo;
	AddLog(operatorLoginName, ''备案信息管理'', ''修改'', message, 1, null, null);
	commit;
  else
    insert into BAS_EXAMINER(
	  ID,
	  SEQUENCENUMBER,
	  IDNUMBER,
	  IDTYPE,
	  NAME,
	  GENDER,
	  BIRTH_DATE,
	  ISSUING_AUTHORITY,
	  QUALIFIED_CAR_TYPE,
	  ISSUING_DATE,
	  EXPIRE_DATE,
	  STATUS,
	  WORK_OFFICE,
	  OPERATOR_NAME,
	  ISSUING_OFFICE,
	  CREATE_TIME,
	  UPDATE_TIME)
	values(
	  SEQU_BAS_EXAMINER_ID.nextval,
	  NewExaminerSequenceNumber,
	  idNo,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2002 and DICT_NAME=idTypeName),
	  examinerName,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2001 and DICT_NAME=examinerGender),
	  birth,
	  issuingAuthority,	  
	  ''C1C2'',
	  issuingDate,
	  expireDate,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1015 and DICT_NAME=''正常''),
	  office,
	  operatorName,
	  issuingOffice,
	  to_char(current_date, ''yyyymmddhh24miss''),
	  to_char(current_date, ''yyyymmddhh24miss''));
	message:=''考试员：''||examinerName||idNo;
	AddLog(operatorLoginName, ''备案信息管理'', ''增加'', message, 1, null, null);
	commit;
  end if;
end AddUpdateExaminer;';
			--StoredProcedures\AddUpdatePlace;
execute immediate 'create or replace procedure AddUpdatePlace
(
  message out varchar2,
  operatorLoginName in varchar2,
  placeCode in varchar2,
  placeName in varchar2,
  subjectName in varchar2,
  issuingAuthority in varchar2,
  branch in varchar2,
  acceptanceDate in varchar2,
  accepterName in varchar2
) as
  n number;
  newName BAS_PLACE.NAME%TYPE;
  newSubject BAS_PLACE.SUBJECT%TYPE;
  newIssuingAuthority BAS_PLACE.ISSUING_AUTHORITY%TYPE;
  newBranch BAS_PLACE.BRANCH_ADMINISTRATION%TYPE;
  newAcceptanceDate BAS_PLACE.ACCEPTANCE_DATE%TYPE;
  newAccepter BAS_PLACE.ACCEPTER%TYPE;
begin
  select count(*) into n from BAS_PLACE where CODE=placeCode;
  if (n>0) then
	select NAME, SUBJECT, ISSUING_AUTHORITY, BRANCH_ADMINISTRATION, ACCEPTANCE_DATE, ACCEPTER into newName, newSubject, newIssuingAuthority, newBranch, newAcceptanceDate, newAccepter from BAS_PLACE where CODE=placeCode;
	if placeName is not null then newName:=placeName; end if;
	if subjectName is not null then select DICT_CODE into newSubject from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName; end if;
	if issuingAuthority is not null then newIssuingAuthority:=issuingAuthority; end if;
	if branch is not null then newBranch:=branch; end if;
	if acceptanceDate is not null then newAcceptanceDate:=acceptanceDate; end if;
	if accepterName is not null then newAccepter:=accepterName; end if;
	update BAS_PLACE set NAME=newName, SUBJECT=newSubject, ISSUING_AUTHORITY=newIssuingAuthority, BRANCH_ADMINISTRATION=newBranch, ACCEPTANCE_DATE=newAcceptanceDate, ACCEPTER=newAccepter, UPDATE_TIME=to_char(current_date, ''yyyymmddhh24miss'') where CODE=placeCode;
	message:=''场地:''||placeName||placeCode;
	AddLog(operatorLoginName, ''备案信息管理'', ''修改'', message, 1, null, null);
	commit;
  else
    insert into BAS_PLACE(
	  ID,
	  SEQUENCENUMBER,
	  CODE,
	  NAME,
	  SUBJECT,
	  QUALIFIED_CAR_TYPE,
	  ISSUING_AUTHORITY,
	  BRANCH_ADMINISTRATION,
	  ACCEPTANCE_DATE,
	  ACCEPTER,
	  RESERVATION_MODE,
	  GROUPING_MODE,
	  PILE_EXAM_NETWORK_TIME,
	  PLACE_EXAM_NETWORK_TIME,
	  CREATE_TIME,
	  UPDATE_TIME)
	values(
	  SEQU_BAS_PLACE_ID.nextval,
	  NewPlaceSequenceNumber,
	  placeCode,
	  placeName,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName),
	  ''C1C2'',
	  issuingAuthority,
	  branch,
	  acceptanceDate,
	  accepterName,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1017 and DICT_NAME=''一次预约''),
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1018 and DICT_NAME=''按学员分组''),
	  to_char(current_date, ''yyyymmddhh24miss''),
	  to_char(current_date, ''yyyymmddhh24miss''),
	  to_char(current_date, ''yyyymmddhh24miss''),
	  to_char(current_date, ''yyyymmddhh24miss''));
	message:=''场地:''||placeName||placeCode;
	AddLog(operatorLoginName, ''备案信息管理'', ''增加'', message, 1, null, null);
	commit;
  end if;
end AddUpdatePlace;';
			--StoredProcedures\AddUpdateSchool;
execute immediate 'create or replace procedure AddUpdateSchool
(
  message out varchar2,
  operatorLoginName in varchar2,
  schoolCode in varchar2,
  schoolName in varchar2,
  shortName in varchar2,
  schoolAddress in varchar2,
  contactAddress in varchar2,
  contactName in varchar2,
  corporation in varchar2,
  schoolGrade in varchar2 
) as
  n number;
  newName BAS_DRIVING_SCHOOL.NAME%TYPE;
  newShortName BAS_DRIVING_SCHOOL.SHORT_NAME%TYPE;
  newAddress BAS_DRIVING_SCHOOL.ADDRESS%TYPE;
  newContactAddress BAS_DRIVING_SCHOOL.CONTACT_ADDRESS%TYPE;
  newContact BAS_DRIVING_SCHOOL.CONTACT%TYPE;
  newCorporation BAS_DRIVING_SCHOOL.CORPORATION%TYPE;
  newGrade BAS_DRIVING_SCHOOL.GRADE%TYPE;
begin
  select count(*) into n from BAS_DRIVING_SCHOOL where CODE=schoolCode;
  if (n>0) then
	select NAME, SHORT_NAME, ADDRESS, CONTACT_ADDRESS, CONTACT, CORPORATION, GRADE into newName, newShortName, newAddress, newContactAddress, newContact, newCorporation, newGrade from BAS_DRIVING_SCHOOL where CODE=schoolCode;
	if schoolName is not null then newName:=schoolName; end if;
	if shortName is not null then newShortName:=shortName; end if;
	if schoolAddress is not null then newAddress:=schoolAddress; end if;
	if contactAddress is not null then newContactAddress:=contactAddress; end if;
	if contactName is not null then newContact:=contactName; end if;
	if corporation is not null then newCorporation:=corporation; end if;
	if schoolGrade is not null then select DICT_CODE into newGrade from CFG_DICT where DICT_TYPE=1020 and DICT_NAME=schoolGrade; end if;
	update BAS_DRIVING_SCHOOL set NAME=newName, SHORT_NAME=newShortName, ADDRESS=newAddress, CONTACT_ADDRESS=newContactAddress, CONTACT=newContact, CORPORATION=newCorporation, GRADE=newGrade, UPDATE_TIME=to_char(current_date, ''yyyymmddhh24miss'') where CODE=schoolCode;
	message:=''驾校:''||schoolName||schoolCode;
	AddLog(operatorLoginName, ''备案信息管理'', ''修改'', message, 1, null, null);
	commit;
  else
    insert into BAS_DRIVING_SCHOOL(
	  ID,
	  SEQUENCENUMBER,
	  CODE,
	  NAME,
	  SHORT_NAME,
	  ADDRESS,
	  CONTACT_ADDRESS,
	  CONTACT,
	  CORPORATION,
	  GRADE,
	  QUALIFIED_CAR_TYPE,
	  AUDITOR,
	  CREATE_TIME,
	  UPDATE_TIME)
	values(
	  SEQU_BAS_DRIVING_SCHOOL_ID.nextval,
	  NewSchoolSequenceNumber,
	  schoolCode,
	  schoolName,
	  shortName,
	  schoolAddress,
	  contactAddress,
	  contactName,
	  corporation,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1020 and DICT_NAME=schoolGrade),
	  ''C1C2'',
	  ''审核人'',
	  to_char(current_date, ''yyyymmddhh24miss''),
	  to_char(current_date, ''yyyymmddhh24miss''));
	message:=''驾校:''||schoolName||schoolCode;
	AddLog(operatorLoginName, ''备案信息管理'', ''增加'', message, 1, null, null);
	commit;
  end if;
end AddUpdateSchool;';
			--StoredProcedures\Query17C01Place;
execute immediate 'create or replace procedure Query17C01Place
(
	xh in varchar2,			--序号  Char	8	不可空
	fzjg in varchar2,		--发证机关 Varchar2	10	不可空
	glbm in varchar2,		--管理部门 Varchar2	12	不可空
	kskm in varchar2,		--考试科目 Char	1	不可空 同上
	kcmc in varchar2,		--考场名称    Varchar2	128	不可空
	kcdddh in varchar2,		--考场代码 Varchar2	64	不可空
	kkcx in varchar2,		--适用准驾车型范围 Varchar2	24	不可空
	ywlx in varchar2,		--适用业务类型范围 Varchar2	10	可空
	zdysrq in varchar2,		--总队验收日期 Date        不可空 yyyymmdd
	ysr in varchar2,		--验收人 Varchar2	32	不可空
	kmeyyms in varchar2,	--科目二预约模式 Char	1	不可空	1一次预约；2两次预约
	fzms in varchar2,		--分组模式 Char	1	不可空	1按学员；2按教练车
	kmeksrsxz number,		--考试人数限制 Number      不可空
	kmezkrsxz number,		--科目二桩考人数限制 Number      不可空
	kmeckrsxz number,		--科目二场考人数限制 Number      不可空
	zksfdz in varchar2,		--桩考评判方式 Char	1	不可空	1计算机自动评判；0人工评判
	cksfdz in varchar2,		--场考评判方式 Char	1	不可空	1计算机自动评判；0人工评判
	zklwrq in varchar2,		--桩考开始联网时间 Date        可空 yyyymmddhh24miss
	cklwrq in varchar2,		--场考开始联网时间 Date        可空 yyyymmddhh24miss
	kczt in varchar2,		--使用状态 Char	1	不可空 A正常；B暂停考试；C取消考试
	zksbs number,			--桩考设备数 Number      不可空
	cksbs number,			--场考设备数 Number      不可空
	cjsj in varchar2,		--创建日期 Date        不可空 yyyymmddhh24miss
	gxsj in varchar2		--更新日期 Date        不可空 yyyymmddhh24miss
) as
	n number;
begin
	select count(*) into n from BAS_PLACE where CODE=kcdddh;
	if n>0 then
		update BAS_PLACE set
			SEQUENCENUMBER=xh,
			NAME=kcmc,
			SUBJECT=kskm,
			QUALIFIED_CAR_TYPE=kkcx,
			ISSUING_AUTHORITY=fzjg,
			BRANCH_ADMINISTRATION=glbm,
			BUSINESS_TYPE=ywlx,
			ACCEPTANCE_DATE=zdysrq,
			ACCEPTER=ysr,
			RESERVATION_MODE=kmeyyms,
			GROUPING_MODE=fzms,
			CAPACITY=kmeksrsxz,
			PILE_EXAM_CAPACITY=kmezkrsxz,
			PLACE_EXAM_CAPACITY=kmeckrsxz,
			PILE_EXAM_JUDGING=zksfdz,
			PLACE_EXAM_JUDGING=cksfdz,
			PILE_EXAM_NETWORK_TIME=zklwrq,
			PLACE_EXAM_NETWORK_TIME=cklwrq,
			STATUS=kczt,
			PILE_EXAM_DEVICE_COUNT=zksbs,
			PLACE_EXAM_DEVICE_COUNT=cksbs,
			CREATE_TIME=cjsj,
			UPDATE_TIME=gxsj
		where CODE=kcdddh;
	else
		insert into BAS_PLACE(
			ID,
			SEQUENCENUMBER,
			CODE,
			NAME,
			SUBJECT,
			QUALIFIED_CAR_TYPE,
			ISSUING_AUTHORITY,
			BRANCH_ADMINISTRATION,
			BUSINESS_TYPE,
			ACCEPTANCE_DATE,
			ACCEPTER,
			RESERVATION_MODE,
			GROUPING_MODE,
			CAPACITY,
			PILE_EXAM_CAPACITY,
			PLACE_EXAM_CAPACITY,
			PILE_EXAM_JUDGING,
			PLACE_EXAM_JUDGING,
			PILE_EXAM_NETWORK_TIME,
			PLACE_EXAM_NETWORK_TIME,
			STATUS,
			PILE_EXAM_DEVICE_COUNT,
			PLACE_EXAM_DEVICE_COUNT,
			CREATE_TIME,
			UPDATE_TIME)
		values(
			SEQU_BAS_PLACE_ID.nextval,
			xh,
			kcdddh,
			kcmc,
			kskm,
			kkcx,
			fzjg,
			glbm,
			ywlx,
			zdysrq,
			ysr,
			kmeyyms,
			fzms,
			kmeksrsxz,
			kmezkrsxz,
			kmeckrsxz,
			zksfdz,
			cksfdz,
			zklwrq,
			cklwrq,
			kczt,
			zksbs,
			cksbs,
			cjsj,
			gxsj);
	end if;
	commit;
end Query17C01Place;';
			--StoredProcedures\Query17C02Device;
execute immediate 'create or replace procedure Query17C02Device
(
	xh in varchar2,			--序号  char	8	不可空
	sbbh in varchar2,		--设备编号 Varchar2	10	不可空
	sbms in varchar2,		--设备描述 Varchar2	512	不可空
	zzcs in varchar2,		--制造厂商 Varchar2	512	不可空
	sbxh in varchar2,		--设备型号 Varchar2	512	不可空
	ksxm in varchar2,		--考试项目 Char	5	不可空
	ksxmsm in varchar2,		--考试项目说明 Varchar2	256	不可空
	ppfs in varchar2,		--评判方式 Char	1	不可空	0计算机自动评判；1人工评判
	kcxh in varchar2,		--考场序号 char	8	不可空
	syzjcx in varchar2,		--适用准驾车型范围 Varchar2	30	不可空
	ysrq in varchar2,		--验收日期 Date        不可空 yyyymmdd
	badckssj number,		--备案单次考试时间 Number      不可空 单位为min
	bamxsksrs number,		--备案每小时考试人次   Number 不可空
	jyyxqz in varchar2,		--检验有效期止  Date 不可空 yyyymmdd
	syzt in varchar2,		--使用状态 Char        不可空 A正常；B故障；C暂停考试；D报废
	cjsj in varchar2,		--创建时间 Date        不可空 yyyymmddhh24miss
	gxsj in varchar2		--更新日期 Date        不可空 yyyymmddhh24miss
) as
	n number;
begin
	select count(*) into n from BAS_DEVICE where DEVICENUMBER=sbbh;
	if n>0 then
		update BAS_DEVICE set
			SEQUENCENUMBER=xh,
			DESCRIPTION=sbms,
			MANUFACTURER=zzcs,
			SERIALNUMBER=sbxh,
			EXAM_ITEM=ksxm,
			EXAM_ITEM_NAME=ksxmsm,
			JUDGING_TYPE=ppfs,
			PLACE_ID=(select ID from BAS_PLACE where SEQUENCENUMBER=kcxh),
			QUALIFIED_CAR_TYPE=syzjcx,
			ACCEPTANCE_DATE=ysrq,
			EXPIRE_DATE=jyyxqz,
			SINGLE_EXAM_TIMES=badckssj,
			HOURLY_EXAM_TIMES=bamxsksrs,
			STATUS=syzt,
			CREATE_TIME=cjsj,
			UPDATE_TIME=gxsj
		where DEVICENUMBER=sbbh;
	else
		insert into BAS_DEVICE(
			ID,
			SEQUENCENUMBER,
			DEVICENUMBER,
			DESCRIPTION,
			MANUFACTURER,
			SERIALNUMBER,
			EXAM_ITEM,
			EXAM_ITEM_NAME,
			JUDGING_TYPE,
			PLACE_ID,
			QUALIFIED_CAR_TYPE,
			ACCEPTANCE_DATE,
			EXPIRE_DATE,
			SINGLE_EXAM_TIMES,
			HOURLY_EXAM_TIMES,
			STATUS,
			CREATE_TIME,
			UPDATE_TIME)
		values(
			SEQU_BAS_DEVICE_ID.nextval,
			xh,
			sbbh,
			sbms,
			zzcs,
			sbxh,
			ksxm,
			ksxmsm,
			ppfs,
			(select ID from BAS_PLACE where SEQUENCENUMBER=kcxh),
			syzjcx,
			ysrq,
			jyyxqz,
			badckssj,
			bamxsksrs,
			syzt,
			cjsj,
			gxsj);
	end if;
	commit;
end Query17C02Device;';
			--StoredProcedures\Query17C03Car;
execute immediate 'create or replace procedure Query17C03Car
(
	xh in varchar2,			--序号  char	8	不可空
	jbr in varchar2,		--经办人 Varchar2	30	不可空
	shr in varchar2,		--审核人 Varchar2	30	不可空
	hpzl in varchar2,		--号牌种类    CHAR	2
	zt in varchar2,			--车辆状态
	ksczt in varchar2,		--考试车状态（使用状态）  不可空；A正常，B暂停考试，C取消考试
	cllx in varchar2,		--车辆类型
	shsj in varchar2,		--??        Date        不可空 yyyymmddhh24miss
	clpp in varchar2,		--车辆品牌
	ccdjrq in varchar2,		--初次登记日期        Date       yyyymmdd
	qzbfqz in varchar2,		--强制报废期止 Date       yyyymmdd
	fzjg in varchar2,		--发证机关    Varchar2	10	不可空
	hphm in varchar2,		--号牌号码    VARCHAR2	15
	syzjcx in varchar2,		--适用准驾车型范围    Varchar2	30	不可空
	ipdz in varchar2,		--IP地址
	cjsj in varchar2,		--创建时间    Date 不可空 yyyymmddhh24miss
	gxsj in varchar2		--更新日期 Date        不可空 yyyymmddhh24miss
) as
	n number;
begin
	select count(*) into n from BAS_CAR	where LICENSE_PLATE=hphm;
	if n>0 then
		update BAS_CAR set
			SEQUENCENUMBER=xh,
			SUBJECT=2,
			LICENSE_PLATE_TYPE=hpzl,
			QUALIFIED_CAR_TYPE=syzjcx,
			CAR_TYPE=cllx,
			BRAND=clpp,
			REGISTER_DATE=ccdjrq,
			SCRAP_DATE=qzbfqz,
			ISSUING_AUTHORITY=fzjg,
			CAR_STATUS=zt,
			USE_STATUS=ksczt,
			AUDITOR=shr,
			CAR_IP=ipdz,
			CREATE_TIME=cjsj,
			UPDATE_TIME=gxsj
		where LICENSE_PLATE=hphm;
	else
		insert into BAS_CAR(
			ID,
			SEQUENCENUMBER,
			LICENSE_PLATE,
			SUBJECT,
			LICENSE_PLATE_TYPE,
			QUALIFIED_CAR_TYPE,
			CAR_TYPE,
			BRAND,
			REGISTER_DATE,
			SCRAP_DATE,
			ISSUING_AUTHORITY,
			CAR_STATUS,
			USE_STATUS,
			AUDITOR,
			CAR_IP,
			CREATE_TIME,
			UPDATE_TIME)
		values(
			SEQU_BAS_CAR_ID.nextval,
			xh,
			hphm,
			2,
			hpzl,
			syzjcx,
			cllx,
			clpp,
			ccdjrq,
			qzbfqz,
			fzjg,
			zt,
			ksczt,
			shr,
			ipdz,
			cjsj,
			gxsj);
	end if;
	commit;
end Query17C03Car;';
			--StoredProcedures\Query17C04Examinator;
execute immediate 'create or replace procedure Query17C04Examinator
(
	xh in varchar2,			--序号  char	8	不可空
	sszd in varchar2,		--所属发证机关  Varchar2	10	不可空
	glbm in varchar2,		--管理部门 Varchar2	12	可空
	sfzmmc in varchar2,		--身份证明名称 Char	1	不可空
	sfzmhm in varchar2,		--身份证明号码 Varchar2	18	不可空
	dabh in varchar2,		--驾驶证档案编号 Varchar2	12	可空 符合GA/T 16.21
	xm in varchar2,			--姓名  Varchar2	30	不可空
	xb in varchar2,			--性别 Char	1	不可空 符合GB/T 2261.1
	csrq in varchar2,		--出生日期    Date 不可空 yyyymmdd
	zkcx in varchar2,		--考试准驾车型范围 Varchar2	32	不可空
	fzrq in varchar2,		--考试员证发证日期 Date        不可空 yyyymmdd
	kszyxqz in varchar2,	--考试员证有效期止 Date        不可空 yyyymmdd
	kszzt in varchar2,		--考试员证状态 Varchar2	1       A正常；B过期；C注销
	gzdw in varchar2,		--工作单位 Varchar2	128	可空
	jbr in varchar2,		--经办人 Varchar2	30	不可空
	fzjg in varchar2,		--考试员证发证单位 Varchar2	64	不可空
	cjsj in varchar2,		--创建时间 Date        不可空 yyyymmddhh24miss
	gxsj in varchar2		--更新时间 Date        不可空 yyyymmddhh24miss
) as
	n number;
begin
	select count(*) into n from BAS_EXAMINER where IDNUMBER=sfzmhm;
	if n>0 then
		update BAS_EXAMINER set
			SEQUENCENUMBER=xh,
			IDTYPE=sfzmmc,
			NAME=xm,
			GENDER=xb,
			BIRTH_DATE=csrq,
			ISSUING_AUTHORITY=sszd,
			BRANCH_ADMINISTRATION=glbm,
			ARCHIVESNUMBER=dabh,
			QUALIFIED_CAR_TYPE=zkcx,
			ISSUING_DATE=fzrq,
			EXPIRE_DATE=kszyxqz,
			STATUS=kszzt,
			WORK_OFFICE=gzdw,
			OPERATOR_NAME=jbr,
			ISSUING_OFFICE=fzjg,
			CREATE_TIME=cjsj,
			UPDATE_TIME=gxsj
		where IDNUMBER=sfzmhm;
	else
		insert into BAS_EXAMINER(
			ID,
			SEQUENCENUMBER,
			IDNUMBER,
			IDTYPE,
			NAME,
			GENDER,
			BIRTH_DATE,
			ISSUING_AUTHORITY,
			BRANCH_ADMINISTRATION,
			ARCHIVESNUMBER,
			QUALIFIED_CAR_TYPE,
			ISSUING_DATE,
			EXPIRE_DATE,
			STATUS,
			WORK_OFFICE,
			OPERATOR_NAME,
			ISSUING_OFFICE,
			CREATE_TIME,
			UPDATE_TIME)
		values(
			SEQU_BAS_EXAMINER_ID.nextval,
			xh,
			sfzmhm,
			sfzmmc,
			xm,
			xb,
			csrq,
			sszd,
			glbm,
			dabh,
			zkcx,
			fzrq,
			kszyxqz,
			kszzt,
			gzdw,
			jbr,
			fzjg,
			cjsj,
			gxsj);
	end if;
	commit;
end Query17C04Examinator;';
			--StoredProcedures\Query17C05School;
execute immediate 'create or replace procedure Query17C05School
(
	xh in varchar2,			--序号  char	8	不可空
	jxmc in varchar2,		--驾校名称    Varchar2	256	可空
	jxjc in varchar2,		--驾校简称 Varchar2	64	不可空
	jxdm in varchar2,		--驾校代码 Varchar2	64	不可空
	jxdz in varchar2,		--驾校地址 Varchar2	256	不可空
	lxdh in varchar2,		--联系电话 Varchar2	20	不可空
	lxr in varchar2,		--联系人 Varchar2	30	不可空
	frdb in varchar2,		--法人代表 Varchar2	30	不可空
	zczj in number,			--注册资金 number      可空
	jxjb in varchar2,		--驾校级别 Char	1	不可空	1一级；2二级；3三级；0其他
	kpxcx in varchar2,		--培训准驾车型 Varchar2	30	可空
	fzjg in varchar2,		--所属发证机关 Varchar2	10	可空
	jxzt in varchar2,		--驾校状态 Char	1	可空 A正常；B暂停受理；C取消资格
	shr in varchar2,		--审核人 Varchar2	30	不可空
	cjsj in varchar2,		--创建时间 Date        不可空 yyyymmddhh24miss
	gxsj in varchar2		--更新时间 Date        不可空 yyyymmddhh24miss
) as
	n number;
begin
	select count(*) into n from BAS_DRIVING_SCHOOL where CODE=jxdm;
	if n>0 then
		update BAS_DRIVING_SCHOOL set
			SEQUENCENUMBER=xh,
			NAME=jxmc,
			SHORT_NAME=jxjc,
			ADDRESS=jxdz,
			CONTACT_ADDRESS=lxdh,
			CONTACT=lxr,
			CORPORATION=frdb,
			REGISTERED_CAPITAL=zczj,
			GRADE=jxjb,
			QUALIFIED_CAR_TYPE=kpxcx,
			ISSUING_AUTHORITY=fzjg,
			STATUS=jxzt,
			AUDITOR=shr,
			CREATE_TIME=cjsj,
			UPDATE_TIME=gxsj
		where CODE=jxdm;
	else
		insert into BAS_DRIVING_SCHOOL(
			ID,
			SEQUENCENUMBER,
			CODE,
			NAME,
			SHORT_NAME,
			ADDRESS,
			CONTACT_ADDRESS,
			CONTACT,
			CORPORATION,
			REGISTERED_CAPITAL,
			GRADE,
			QUALIFIED_CAR_TYPE,
			ISSUING_AUTHORITY,
			STATUS,
			AUDITOR,
			CREATE_TIME,
			UPDATE_TIME)
		values(
			SEQU_BAS_DRIVING_SCHOOL_ID.nextval,
			xh,
			jxdm,
			jxmc,
			jxjc,
			jxdz,
			lxdh,
			lxr,
			frdb,
			zczj,
			jxjb,
			kpxcx,
			fzjg,
			jxzt,
			shr,
			cjsj,
			gxsj);
	end if;
	commit;
end Query17C05School;';
			--Views\BAS_CAR_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW BAS_CAR_VIEW AS
SELECT  SEQUENCENUMBER,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1006 and DICT_CODE=SUBJECT) SUBJECT_DICT_NAME,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=2006 and DICT_CODE=LICENSE_PLATE_TYPE) LICENSE_PLATE_TYPE_DICT_NAME,
		CARNUMBER,
		LICENSE_PLATE,
		QUALIFIED_CAR_TYPE,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=2004 and DICT_CODE=CAR_TYPE) CAR_TYPE_DICT_NAME,
		BRAND,
		REGISTER_DATE,
		SCRAP_DATE,
		ISSUING_AUTHORITY,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=2005 and DICT_CODE=CAR_STATUS) CAR_STATUS_DICT_NAME,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1016 and DICT_CODE=USE_STATUS) USE_STATUS_DICT_NAME,
		AUDITOR,
		CAR_IP,
		CREATE_TIME,
		UPDATE_TIME
FROM BAS_CAR';
			--Views\BAS_DEVICE_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW BAS_DEVICE_VIEW AS
SELECT  SEQUENCENUMBER,
		DEVICENUMBER,
		DESCRIPTION,
		MANUFACTURER,
		SERIALNUMBER,
		EXAM_ITEM,
		EXAM_ITEM_NAME,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1019 and DICT_CODE=JUDGING_TYPE) JUDGING_TYPE,
		(select NAME from BAS_PLACE where ID=PLACE_ID) PLACE_NAME,
		(select CODE from BAS_PLACE where ID=PLACE_ID) PLACE_CODE,
		(select SEQUENCENUMBER from BAS_PLACE where ID=PLACE_ID) PLACE_SEQUENCENUMBER,
		QUALIFIED_CAR_TYPE,
		ACCEPTANCE_DATE,
		SINGLE_EXAM_TIMES,
		HOURLY_EXAM_TIMES,
		EXPIRE_DATE,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1022 and DICT_CODE=STATUS) STATUS,
 		CREATE_TIME,
		UPDATE_TIME
FROM BAS_DEVICE';
			--Views\BAS_DRIVING_SCHOOL_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW BAS_DRIVING_SCHOOL_VIEW AS
SELECT  SEQUENCENUMBER,
		NAME,
		SHORT_NAME,
		CODE,
		ADDRESS,
		CONTACT_ADDRESS,
		CONTACT,
		CORPORATION,
		REGISTERED_CAPITAL,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1020 and DICT_CODE=GRADE) GRADE,
		QUALIFIED_CAR_TYPE,
		ISSUING_AUTHORITY,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1021 and DICT_CODE=STATUS) STATUS,
		AUDITOR,
		CREATE_TIME,
		UPDATE_TIME
FROM BAS_DRIVING_SCHOOL';
			--Views\BAS_EXAMINER_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW BAS_EXAMINER_VIEW AS
SELECT  SEQUENCENUMBER,
		NAME,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=2001 and DICT_CODE=GENDER) GENDER_DICT_NAME,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=2002 and DICT_CODE=IDTYPE) ID_TYPE_DICT_NAME,
		IDNUMBER,
		BIRTH_DATE,
		ISSUING_AUTHORITY,
		BRANCH_ADMINISTRATION,
		ARCHIVESNUMBER,
		QUALIFIED_CAR_TYPE,
		ISSUING_DATE,
		EXPIRE_DATE,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1015 and DICT_CODE=STATUS) STATUS_DICT_NAME,
		WORK_OFFICE,
		OPERATOR_NAME,
		ISSUING_OFFICE,
		CREATE_TIME,
		UPDATE_TIME
FROM BAS_EXAMINER';
			--Views\BAS_PLACE_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW BAS_PLACE_VIEW AS
SELECT  SEQUENCENUMBER,
		ISSUING_AUTHORITY,
		BRANCH_ADMINISTRATION,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1006 and DICT_CODE=SUBJECT) SUBJECT_DICT_NAME,
		NAME,
		CODE,
		QUALIFIED_CAR_TYPE,
		BUSINESS_TYPE,
		ACCEPTANCE_DATE,
		ACCEPTER,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1017 and DICT_CODE=RESERVATION_MODE) RESERVATION_MODE,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1018 and DICT_CODE=GROUPING_MODE) GROUPING_MODE,
		CAPACITY,
		PILE_EXAM_CAPACITY,
		PLACE_EXAM_CAPACITY,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1019 and DICT_CODE=PILE_EXAM_JUDGING) PILE_EXAM_JUDGING,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1019 and DICT_CODE=PLACE_EXAM_JUDGING) PLACE_EXAM_JUDGING,
		PILE_EXAM_NETWORK_TIME,
		PLACE_EXAM_NETWORK_TIME,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1016 and DICT_CODE=STATUS) STATUS,
		PILE_EXAM_DEVICE_COUNT,
		PLACE_EXAM_DEVICE_COUNT,
		EXAM_CAR_TOTAL_COUNT,
		PLACE_AREA,
		ROADWAY_LENGTH,
		EXAM_CAR_COUNT,
		CREATE_TIME,
		UPDATE_TIME
FROM BAS_PLACE';
			--Views\CAR_ALLOCATION_CAR_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW CAR_ALLOCATION_CAR_VIEW AS 
select
    LICENSE_PLATE,
    CARNUMBER,
    QUALIFIED_CAR_TYPE,
    (select DICT_NAME from CFG_DICT where DICT_TYPE=1025 and DICT_CODE=PROCESS_TYPE) PROCESS_TYPE_DICTNAME,
	(select ITEM_NAME from CFG_ITEMS where ITEM_CODE=EXAM_ITEM) EXAM_ITEM_DICTNAME,

    case when USE_STATUS=''A''
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select NAME from bas_student where ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))) 
        else null 
    end STUDENT_NAME,
    
    case when USE_STATUS=''A''
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select IDNUMBER from bas_student where ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))) 
        else null 
    end STUDENT_IDNUMBER,
    
    case when USE_STATUS=''A''
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))) 
        else null 
    end BOOKING_TIMES,
    
    case when USE_STATUS=''A''
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))) 
        else null 
    end LEFT_TIMES,
    
    USE_STATUS
from bas_car left join buz_exam_process on buz_exam_process.ID in (select max(ID) from buz_exam_process where EXAM_ID in (select max(ID) from buz_exam_info where substr(EXAM_START_TIME,1,8)=to_char(current_date, ''yyyymmdd'') group by CAR_ID) group by EXAM_ID) and bas_car.ID=(select CAR_ID from buz_exam_info where ID= buz_exam_process.EXAM_ID)
order by bas_car.USE_STATUS, bas_car.ID';
			--Views\CAR_ALLOCATION_STUDENT_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW CAR_ALLOCATION_STUDENT_VIEW AS 
select 
    NAME,
    IDNUMBER,
    DRIVER_LICENSE_TYPE,
    (select CARNUMBER from bas_car where ID=(select CAR_ID from bas_booking where id=(select max(id) from bas_booking where STUDENT_ID=bas_student.ID and BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'')))) BOOKING_CAR,
    (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=BAS_STUDENT.ID) BOOKING_TIMES,
    (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=BAS_STUDENT.ID)-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=BAS_STUDENT.ID)) LEFT_TIMES
from bas_student
where ID in (select distinct(STUDENT_ID) from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and not exists(select * from buz_exam_info where BOOKING_ID=bas_booking.ID))
order by (select min(id) from bas_booking where student_id=bas_student.id and BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and not exists(select *from buz_exam_info where BOOKING_ID=bas_booking.ID))';




		when '1.0.0.2' then
            dbms_output.put_line('version 1.0.0.2');
			--Views\CAR_ALLOCATION_STUDENT_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW CAR_ALLOCATION_STUDENT_VIEW AS 
select 
	(select SEQUENCENUMBER+1-(select min(SEQUENCENUMBER) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'')) from bas_booking where id=(select max(id) from bas_booking where STUDENT_ID=bas_student.ID and BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd''))) SEQUENCE_NUMBER,
    NAME,
    IDNUMBER,
    DRIVER_LICENSE_TYPE,
    (select CARNUMBER from bas_car where ID=(select CAR_ID from bas_booking where id=(select max(id) from bas_booking where STUDENT_ID=bas_student.ID and BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'')))) BOOKING_CAR,
    (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=BAS_STUDENT.ID) BOOKING_TIMES,
    (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=BAS_STUDENT.ID)-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=BAS_STUDENT.ID)) LEFT_TIMES
from bas_student
where ID in (select distinct(STUDENT_ID) from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and not exists(select * from buz_exam_info where BOOKING_ID=bas_booking.ID))
order by (select min(id) from bas_booking where student_id=bas_student.id and BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and not exists(select *from buz_exam_info where BOOKING_ID=bas_booking.ID))';

			--Views\CAR_ALLOCATION_CAR_VIEW;
execute immediate 'CREATE OR REPLACE FORCE VIEW CAR_ALLOCATION_CAR_VIEW AS 
select
    LICENSE_PLATE,
    CARNUMBER,
    QUALIFIED_CAR_TYPE,
    (select DICT_NAME from CFG_DICT where DICT_TYPE=1025 and DICT_CODE=PROCESS_TYPE) PROCESS_TYPE_DICTNAME,
	(select ITEM_NAME from CFG_ITEMS where ITEM_CODE=EXAM_ITEM) EXAM_ITEM_DICTNAME,

    case when USE_STATUS=''A''
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select SEQUENCENUMBER+1-(select min(SEQUENCENUMBER) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'')) from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) 
        else null 
    end SEQUENCE_NUMBER,

    case when USE_STATUS=''A''
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select NAME from bas_student where ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))) 
        else null 
    end STUDENT_NAME,
    
    case when USE_STATUS=''A''
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select IDNUMBER from bas_student where ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))) 
        else null 
    end STUDENT_IDNUMBER,
    
    case when USE_STATUS=''A''
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))) 
        else null 
    end BOOKING_TIMES,
    
    case when USE_STATUS=''A''
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, ''yyyymmdd'') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))) 
        else null 
    end LEFT_TIMES,
    
    USE_STATUS
from bas_car left join buz_exam_process on buz_exam_process.ID in (select max(ID) from buz_exam_process where EXAM_ID in (select max(ID) from buz_exam_info where substr(EXAM_START_TIME,1,8)=to_char(current_date, ''yyyymmdd'') group by CAR_ID) group by EXAM_ID) and bas_car.ID=(select CAR_ID from buz_exam_info where ID= buz_exam_process.EXAM_ID)
order by bas_car.USE_STATUS, bas_car.ID';
			update cfg_param set param_value=5 where param_name='CAR_ALLOCATION_INTERVAL';



			update CFG_PARAM set PARAM_VALUE='1.0.0.3' where PARAM_NAME='DATABASE_VERSION';




		when '1.0.0.3' then
            dbms_output.put_line('version 1.0.0.3');

        else
            dbms_output.put_line('unknown version');
	end case;
end;
/
alter function AddRole compile;
alter function AddUpdatePricingStrategy compile;
alter function AddUpdateUser compile;
alter function BookFromManagement compile;
alter function BookFromVehicle compile;
alter function BookFromVehicleNoPassword compile;
alter function ChangePassword compile;
alter function DESDecrypt compile;
alter function DESEncrypt compile;
alter function GenerateHMAC compile;
alter function GenerateSHA1 compile;
alter function GenerateSUB2 compile;
alter function GetPriceByTimes compile;
alter function GrantRolePermission compile;
alter function Login compile;
alter function NewBookSequenceNumber compile;
alter function NewCarSequenceNumber compile;
alter function NewDeviceSequenceNumber compile;
alter function NewExaminerSequenceNumber compile;
alter function NewExamNumber compile;
alter function NewPlaceSequenceNumber compile;
alter function NewSchoolCode compile;
alter function NewSchoolSequenceNumber compile;
alter function NewTradeNumber compile;
alter function RemoveUser compile;
alter function RevokeRolePermission compile;
alter function SetParameter compile;
alter function ShowDateTime compile;
alter function UnblockUser compile;

alter procedure AddLog compile;
alter procedure AddUpdateCar compile;
alter procedure AddUpdateDevice compile;
alter procedure AddUpdateExaminer compile;
alter procedure AddUpdatePlace compile;
alter procedure AddUpdateSchool compile;
alter procedure AddUpdateStudent compile;
alter procedure GetRolePermissions compile;
alter procedure HandleMisjudge compile;
alter procedure Logout compile;
alter procedure Query17C01Place compile;
alter procedure Query17C02Device compile;
alter procedure Query17C03Car compile;
alter procedure Query17C04Examinator compile;
alter procedure Query17C05School compile;
alter procedure Query17C06Group compile;
alter procedure Query17C07GroupDetail compile;
alter procedure Query17C08Book compile;

alter view BAS_BOOKING_VIEW compile;
alter view BAS_CAR_VIEW compile;
alter view BAS_DEVICE_VIEW compile;
alter view BAS_DRIVING_SCHOOL_VIEW compile;
alter view BAS_EXAMINER_VIEW compile;
alter view BAS_GROUPING_DETAIL_VIEW compile;
alter view BAS_GROUPING_VIEW compile;
alter view BAS_PLACE_VIEW compile;
alter view BAS_STUDENT_VIEW compile;
alter view BUZ_EXAM_INFO_VIEW compile;
alter view BUZ_EXAM_PROCESS_VIEW compile;
alter view BUZ_PAYMENT_DETAIL_VIEW compile;
alter view BUZ_SUB2_RECORD_VIEW compile;
alter view CFG_PRICING_STRATEGY_VIEW compile;
--alter view DBA_AUDIT_TRAIL compile;
alter view STUDENT_EXAM_VIEW compile;
alter view STUDENT_SCORE_VIEW compile;
alter view SYS_LOG_VIEW compile;
alter view SYS_ROLE_PERMISSION_VIEW compile;
alter view SYS_USER_ROLE_PERMISSION_VIEW compile;
alter view SYS_USER_VIEW compile;

--exit;
