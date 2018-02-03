delete SYS_ROLE;
delete SYS_PERMISSION;
delete SYS_ROLE_PERMISSION;
delete SYS_USER;
drop sequence SEQU_SYS_USER_ID;
CREATE SEQUENCE SEQU_SYS_USER_ID INCREMENT BY 1 START WITH 1;
drop sequence SEQU_SYS_ROLE_ID;
CREATE SEQUENCE SEQU_SYS_ROLE_ID INCREMENT BY 1 START WITH 1;

insert into SYS_ROLE(ID, NAME, CATEGORY) values(SEQU_SYS_ROLE_ID.nextval, '����Ա', 'SYSTEM');
insert into SYS_ROLE(ID, NAME) values(SEQU_SYS_ROLE_ID.nextval, '����Ա');
insert into SYS_ROLE(ID, NAME) values(SEQU_SYS_ROLE_ID.nextval, '����Ա');
commit;

insert into SYS_PERMISSION(CODE, NAME, CATEGORY) values('0100', 'ϵͳ����', NULL);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY) values('0101', '�����޸�', NULL);

insert into SYS_PERMISSION(CODE, NAME) values('0200', '��ѵ����');
insert into SYS_PERMISSION(CODE, NAME) values('0201', 'ԤԼ��ѵ');
insert into SYS_PERMISSION(CODE, NAME) values('0202', '֧����ˮ');
insert into SYS_PERMISSION(CODE, NAME) values('0203', '�ֳ��к�');
insert into SYS_PERMISSION(CODE, NAME) values('0204', '���̲�ѯ');

insert into SYS_PERMISSION(CODE, NAME, IS_POLICE) values('0300', '���Թ���', 1);
insert into SYS_PERMISSION(CODE, NAME, IS_POLICE) values('0301', 'ԤԼ��ǩ��', 1);
insert into SYS_PERMISSION(CODE, NAME, IS_POLICE) values('0302', '���鼰�ֳ�', 1);
insert into SYS_PERMISSION(CODE, NAME, IS_POLICE) values('0303', '����״̬', 1);
insert into SYS_PERMISSION(CODE, NAME, IS_POLICE) values('0304', '�ɼ���ӡ', 1);

insert into SYS_PERMISSION(CODE, NAME) values('0400', 'ͳ�Ʋ�ѯ');
insert into SYS_PERMISSION(CODE, NAME) values('0401', '�ۺ�ͳ��');
insert into SYS_PERMISSION(CODE, NAME) values('0402', '�ۺϲ�ѯ');

insert into SYS_PERMISSION(CODE, NAME) values('0500', '������Ϣ����');
insert into SYS_PERMISSION(CODE, NAME) values('0501', '������Ϣ');
insert into SYS_PERMISSION(CODE, NAME) values('0502', '�豸��Ϣ');
insert into SYS_PERMISSION(CODE, NAME) values('0503', '������Ϣ');
insert into SYS_PERMISSION(CODE, NAME) values('0504', '����Ա��Ϣ');
insert into SYS_PERMISSION(CODE, NAME) values('0505', '��У��Ϣ');

insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0600', '֧������', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0601', '֧������', 'SYSTEM', 1);

insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0700', 'ϵͳ����', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0701', '���ݿ���������', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0702', '��������', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0703', '�û�����', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0704', 'Ȩ�޹���', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0705', '��־��ѯ', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0706', '��Ʋ�ѯ', 'SYSTEM', 1);
insert into SYS_PERMISSION(CODE, NAME, CATEGORY, IS_ADMIN) values('0707', '�û�����', 'SYSTEM', 1);
commit;

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0100');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0101');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0500');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0501');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0502');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0503');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0504');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0505');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0600');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0601');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0700');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0701');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0702');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0703');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0704');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0705');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0706');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0707');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0100');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0101');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0200');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0201');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0202');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0203');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0204');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0300');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0301');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0302');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0303');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0304');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0400');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0401');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0402');

insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0100');
insert into SYS_ROLE_PERMISSION(ROLE_ID, PERMISSION_CODE) values((select id from sys_role where name='����Ա'), '0101');

commit;


insert into SYS_USER(ID, LOGIN_NAME, PASSWORD, USER_NAME, GENDER, IDNUMBER, USER_FLAG, USERNUMBER, FAILURE_TIMES, STATUS, PASSWORD_MODIFY_DATE, ROLE_ID, QUALIFIED_ADDRESS_LIST) 
values(SEQU_SYS_USER_ID.nextval, 'admin', DESEnCrypt(GenerateSHA1('admin')||'admin'||'administrator'||'123456789012345671'), 'administrator', '1', '123456789012345671', '0', '12345670', 0, '0', '20180921', (select id from sys_role where name='����Ա'), '');
insert into SYS_USER(ID, LOGIN_NAME, PASSWORD, USER_NAME, GENDER, IDNUMBER, USER_FLAG, USERNUMBER, FAILURE_TIMES, STATUS, PASSWORD_MODIFY_DATE, ROLE_ID, QUALIFIED_ADDRESS_LIST) 
values(SEQU_SYS_USER_ID.nextval, 'cashier', DESEnCrypt(GenerateSHA1('hello')||'cashier'||'cashier'||'123456789012345674'), 'cashier', '1', '123456789012345674', '0', '12345674', 0, '0', '20180921', (select id from sys_role where name='����Ա'), '');
insert into SYS_USER(ID, LOGIN_NAME, PASSWORD, USER_NAME, GENDER, IDNUMBER, USER_FLAG, USERNUMBER, FAILURE_TIMES, STATUS, PASSWORD_MODIFY_DATE, ROLE_ID, QUALIFIED_ADDRESS_LIST) 
values(SEQU_SYS_USER_ID.nextval, 'coach', DESEnCrypt(GenerateSHA1('hello')||'coach'||'coach'||'123456789012345675'), 'coach', '1', '123456789012345675', '0', '12345675', 0, '0', '20180921', (select id from sys_role where name='����Ա'), '');

commit;
