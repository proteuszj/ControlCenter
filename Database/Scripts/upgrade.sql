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
			VALUES (SEQU_CFG_DICT_ID.NEXTVAL, -1, '1039', 'Ȩ�޷���', -1, 'ҵ���ֵ�����');
			INSERT INTO CFG_DICT (ID, DICT_TYPE, DICT_CODE, DICT_NAME, VIEW_INDEX, DICT_MEMO)
			VALUES (SEQU_CFG_DICT_ID.NEXTVAL, 1039, 'BUSINESS', 'ҵ�����', 1, 'Ȩ�޷���');
			INSERT INTO CFG_DICT (ID, DICT_TYPE, DICT_CODE, DICT_NAME, VIEW_INDEX, DICT_MEMO)
			VALUES (SEQU_CFG_DICT_ID.NEXTVAL, 1039, 'SYSTEM', 'ϵͳ����', 2, 'Ȩ�޷���');
			INSERT INTO CFG_DICT (ID, DICT_TYPE, DICT_CODE, DICT_NAME, VIEW_INDEX, DICT_MEMO)
			VALUES (SEQU_CFG_DICT_ID.NEXTVAL, 1039, 'SECURITY', '��ȫ����', 3, 'Ȩ�޷���');
			INSERT INTO CFG_DICT (ID, DICT_TYPE, DICT_CODE, DICT_NAME, VIEW_INDEX, DICT_MEMO)
			VALUES (SEQU_CFG_DICT_ID.NEXTVAL, 1039, 'AUDIT', '��ƹ���', 4, 'Ȩ�޷���');
			execute immediate 'alter table sys_role add (CATEGORY varchar2(10) default ''BUSINESS'' not null)';
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'BOOKING_DATE_LIMIT', 'ԤԼ��������', 'INT', '1', '1Ϊ���죻2Ϊ2��֮�ڣ�3Ϊ3��֮�ڣ���������');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '000000', '00:00:00', 'BOOL', 'FALSE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '010000', '01:00:00', 'BOOL', 'FALSE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '020000', '02:00:00', 'BOOL', 'FALSE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '030000', '03:00:00', 'BOOL', 'FALSE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '040000', '04:00:00', 'BOOL', 'FALSE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '050000', '05:00:00', 'BOOL', 'FALSE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '060000', '06:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '070000', '07:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '080000', '08:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '090000', '09:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '100000', '10:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '110000', '11:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '120000', '12:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '130000', '13:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '140000', '14:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '150000', '15:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '160000', '16:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '170000', '17:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '180000', '18:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '190000', '19:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '200000', '20:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '210000', '21:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '220000', '22:00:00', 'BOOL', 'TRUE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, '230000', '23:00:00', 'BOOL', 'FALSE', 'TRUE��ǰʱ�ο��ã�FALSE��ǰʱ�β�����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'DATABASE_VERSION', '���ݿ�汾', 'CHAR', '1.0.0.2', '���汾.�ΰ汾.��֧�汾.�����汾����֧�汾0��ʾͨ�ð汾');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 1, 1, 'VEHICLE_VERSION', '���س���汾', 'CHAR', '1.0.1013.2', '���汾.�ΰ汾.��֧�汾.�����汾����֧�汾0��ʾͨ�ð汾');

			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'CAR_ALLOCATION_INTERVAL', 'ˢ��ʱ�䣨�룩', 'INT', '1', '�ֳ�������״̬ˢ��ʱ����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'CAR_ALLOCATION_PROJECT_ADDRESS', 'Ͷ�Ե�ַ', 'CHAR', '192.168.1.100', '�ֳ�����Ͷ���ն˵�ַ');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'CAR_ALLOCATION_PROJECT_PORT', 'Ͷ�Զ˿�', 'INT', '5678', '�ֳ�����Ͷ���ն˶˿�');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'CAR_ALLOCATION_PROJECT_COUNT', 'Ͷ������', 'INT', '10', '�ֳ�����Ͷ��ѧԱ����');
			insert into CFG_PARAM(ID, SUBSYS_ID, PARAM_GRADE, PARAM_NAME, DISPLAY_NAME, PARAM_TYPE, PARAM_VALUE, MEMO)
			values(SEQU_CFG_PARAM_ID.nextval, 2, 1, 'CAR_ALLOCATION_WAITING_TIMEOUT', '�Ⱥ�ʱ�����ӣ�', 'INT', '10', '�ѷֳ�ѧԱ�ϳ��ȴ�ʱ�䣬��������ʱ��');
			
			update SYS_PERMISSION set NAME='��ѵ����' where CODE='0200';
			update SYS_PERMISSION set NAME='ԤԼ��ѵ' where CODE='0201';
			update SYS_PERMISSION set NAME='֧����ˮ' where CODE='0202'; 
			update SYS_PERMISSION set NAME='�ֳ��к�' where CODE='0203'; 
			insert into SYS_PERMISSION(CODE, NAME) values('0204', '���̲�ѯ');

			insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0204');
			insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0204');
			execute immediate 'alter table BUZ_EXAM_INFO add(CAR_ID integer)';
			
			commit;
			update bas_booking set CAR_ID=(select id from bas_car where license_plate='��A-9630ѧ') where student_id=(select id from bas_student where idnumber='111111111111119630');
			execute immediate 'update buz_exam_info set car_id=(select id from bas_car where license_plate=''��A-9630ѧ'') where booking_id in (select id from bas_booking where student_id=(select id from bas_student where idnumber=''111111111111119630''))';
			update bas_booking set car_id=(select id from bas_car where license_plate='��A-E433ѧ') where student_id=(select id from bas_student where idnumber='222222222222226433');
			execute immediate 'update buz_exam_info set car_id=(select id from bas_car where license_plate=''��A-E433ѧ'') where booking_id in (select id from bas_booking where student_id=(select id from bas_student where idnumber=''222222222222226433''))';
			update bas_booking set car_id=(select id from bas_car where license_plate='��A-2690ѧ') where student_id=(select id from bas_student where idnumber='111111111111112690');
			execute immediate 'update buz_exam_info set car_id=(select id from bas_car where license_plate=''��A-2690ѧ'') where booking_id in (select id from bas_booking where student_id=(select id from bas_student where idnumber=''111111111111112690''))';
			update bas_booking set car_id=(select id from bas_car where license_plate='��A-2663ѧ') where student_id=(select id from bas_student where idnumber='111111111111112663');
			execute immediate 'update buz_exam_info set car_id=(select id from bas_car where license_plate=''��A-2663ѧ'') where booking_id in (select id from bas_booking where student_id=(select id from bas_student where idnumber=''111111111111112663''))';
			update bas_booking set car_id=(select id from bas_car where license_plate='��A-2677ѧ') where student_id=(select id from bas_student where idnumber='111111111111112677');
			execute immediate 'update buz_exam_info set car_id=(select id from bas_car where license_plate=''��A-2677ѧ'') where booking_id in (select id from bas_booking where student_id=(select id from bas_student where idnumber=''111111111111112677''))';
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
