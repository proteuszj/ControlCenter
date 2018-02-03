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
			update SYS_PERMISSION set NAME='支付流水' where CODE='0202'; 
			update SYS_PERMISSION set NAME='分车叫号' where CODE='0203'; 
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
			@@..\Views\BAS_STUDENT_VIEW
			@@..\Views\BUZ_PAYMENT_DETAIL_VIEW;
			@@..\Views\SYS_ROLE_PERMISSION_VIEW;
			@@..\Views\SYS_USER_ROLE_PERMISSION_VIEW;
			@@..\StoredProcedures\GetRolePermissions;
			@@..\StoredProcedures\GrantRolePermission;
			@@..\StoredProcedures\Logout;
			@@..\StoredProcedures\RevokeRolePermission;
			@@..\StoredProcedures\BookFromManagement;
			@@..\StoredProcedures\BookFromVehicleNoPassword;
			@@..\StoredProcedures\ShowDateTime;
			@@..\StoredProcedures\AddUpdateCar;
			@@..\StoredProcedures\AddUpdateDevice;
			@@..\StoredProcedures\AddUpdateExaminer;
			@@..\StoredProcedures\AddUpdatePlace;
			@@..\StoredProcedures\AddUpdateSchool;
			@@..\StoredProcedures\Query17C01Place;
			@@..\StoredProcedures\Query17C02Device;
			@@..\StoredProcedures\Query17C03Car;
			@@..\StoredProcedures\Query17C04Examinator;
			@@..\StoredProcedures\Query17C05School;
			@@..\Views\BAS_CAR_VIEW;
			@@..\Views\BAS_DEVICE_VIEW;
			@@..\Views\BAS_DRIVING_SCHOOL_VIEW;
			@@..\Views\BAS_EXAMINER_VIEW;
			@@..\Views\BAS_PLACE_VIEW;
			@@..\Views\CAR_ALLOCATION_CAR_VIEW;
			@@..\Views\CAR_ALLOCATION_STUDENT_VIEW;
		when '1.0.0.2' then
            dbms_output.put_line('version 1.0.0.2');
        else
            dbms_output.put_line('unknown version');
	end case;
end;
/

@@reCompileAll;


exit;
