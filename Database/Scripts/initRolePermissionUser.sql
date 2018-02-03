delete SYS_ROLE;
delete SYS_PERMISSION;
delete SYS_ROLE_PERMISSION;
delete SYS_USER;
drop sequence SEQU_SYS_USER_ID;
CREATE SEQUENCE SEQU_SYS_USER_ID INCREMENT BY 1 START WITH 1;
drop sequence SEQU_SYS_ROLE_ID;
CREATE SEQUENCE SEQU_SYS_ROLE_ID INCREMENT BY 1 START WITH 1;

insert into SYS_ROLE(ID, NAME, CATEGORY) values(SEQU_SYS_ROLE_ID.nextval, '管理员', 'SYSTEM');
insert into SYS_ROLE(ID, NAME) values(SEQU_SYS_ROLE_ID.nextval, '收银员');
insert into SYS_ROLE(ID, NAME) values(SEQU_SYS_ROLE_ID.nextval, '教练员');
commit;

insert into SYS_PERMISSION(CODE, NAME, CATEGORY) values('0100', '系统操作', NULL);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY) values('0101', '密码修改', NULL);

insert into SYS_PERMISSION(CODE, NAME) values('0200', '培训管理');
insert into SYS_PERMISSION(CODE, NAME) values('0201', '预约培训');
insert into SYS_PERMISSION(CODE, NAME) values('0202', '支付流水');
insert into SYS_PERMISSION(CODE, NAME) values('0203', '分车叫号');
insert into SYS_PERMISSION(CODE, NAME) values('0204', '过程查询');

insert into SYS_PERMISSION(CODE, NAME, IS_POLICE) values('0300', '考试管理', 1);
insert into SYS_PERMISSION(CODE, NAME, IS_POLICE) values('0301', '预约及签到', 1);
insert into SYS_PERMISSION(CODE, NAME, IS_POLICE) values('0302', '分组及分车', 1);
insert into SYS_PERMISSION(CODE, NAME, IS_POLICE) values('0303', '考试状态', 1);
insert into SYS_PERMISSION(CODE, NAME, IS_POLICE) values('0304', '成绩打印', 1);

insert into SYS_PERMISSION(CODE, NAME) values('0400', '统计查询');
insert into SYS_PERMISSION(CODE, NAME) values('0401', '综合统计');
insert into SYS_PERMISSION(CODE, NAME) values('0402', '综合查询');

insert into SYS_PERMISSION(CODE, NAME) values('0500', '备案信息管理');
insert into SYS_PERMISSION(CODE, NAME) values('0501', '场地信息');
insert into SYS_PERMISSION(CODE, NAME) values('0502', '设备信息');
insert into SYS_PERMISSION(CODE, NAME) values('0503', '车辆信息');
insert into SYS_PERMISSION(CODE, NAME) values('0504', '考试员信息');
insert into SYS_PERMISSION(CODE, NAME) values('0505', '驾校信息');

insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0600', '支付管理', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0601', '支付定价', 'SYSTEM', 1);

insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0700', '系统设置', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0701', '数据库连接设置', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0702', '参数设置', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0703', '用户管理', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0704', '权限管理', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0705', '日志查询', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0706', '审计查询', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0707', '用户解锁', 'SYSTEM', 1);
commit;

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0100');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0101');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0500');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0501');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0502');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0503');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0504');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0505');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0600');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0601');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0700');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0701');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0702');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0703');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0704');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0705');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0706');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='管理员'), '0707');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0100');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0101');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0200');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0201');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0202');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0203');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0204');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0300');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0301');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0302');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0303');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0304');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0400');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0401');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='收银员'), '0402');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='教练员'), '0100');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='教练员'), '0101');

commit;


insert into SYS_USER(ID, LOGIN_NAME, PASSWORD, USER_NAME, GENDER, IDNUMBER, USER_FLAG, USERNUMBER, FAILURE_TIMES, STATUS, PASSWORD_MODIFY_DATE, ROLE_ID, QUALIFIED_ADDRESS_LIST) 
values(SEQU_SYS_USER_ID.nextval, 'admin', DESEnCrypt(GenerateSHA1('admin')||'admin'||'administrator'||'123456789012345671'), 'administrator', '1', '123456789012345671', '0', '12345670', 0, '0', '20180921', (select id from sys_role where name='管理员'), '');
insert into SYS_USER(ID, LOGIN_NAME, PASSWORD, USER_NAME, GENDER, IDNUMBER, USER_FLAG, USERNUMBER, FAILURE_TIMES, STATUS, PASSWORD_MODIFY_DATE, ROLE_ID, QUALIFIED_ADDRESS_LIST) 
values(SEQU_SYS_USER_ID.nextval, 'cashier', DESEnCrypt(GenerateSHA1('hello')||'cashier'||'cashier'||'123456789012345674'), 'cashier', '1', '123456789012345674', '0', '12345674', 0, '0', '20180921', (select id from sys_role where name='收银员'), '');
insert into SYS_USER(ID, LOGIN_NAME, PASSWORD, USER_NAME, GENDER, IDNUMBER, USER_FLAG, USERNUMBER, FAILURE_TIMES, STATUS, PASSWORD_MODIFY_DATE, ROLE_ID, QUALIFIED_ADDRESS_LIST) 
values(SEQU_SYS_USER_ID.nextval, 'coach', DESEnCrypt(GenerateSHA1('hello')||'coach'||'coach'||'123456789012345675'), 'coach', '1', '123456789012345675', '0', '12345675', 0, '0', '20180921', (select id from sys_role where name='教练员'), '');

commit;
