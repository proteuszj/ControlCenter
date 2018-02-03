CREATE OR REPLACE FORCE VIEW SYS_USER_VIEW AS
SELECT	LOGIN_NAME,
		USER_NAME,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=2001 and DICT_CODE=GENDER) GENDER_DICT_NAME,
		IDNUMBER,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1010 and DICT_CODE=USER_FLAG) USER_FLAG_DICT_NAME,
		USERNUMBER,
		case when FAILURE_TIMES<case when MAX_FAILURE_COUNT is not null then MAX_FAILURE_COUNT else (select to_number(PARAM_VALUE) from CFG_PARAM where PARAM_NAME='DEFAULT_USER_MAX_FAILURE_COUNT') end then 'δ����' else '������' end LOCKED_STATUS,
		MAX_FAILURE_COUNT,
		(select DICT_NAME from CFG_DICT where DICT_TYPE=1013 and DICT_CODE=STATUS) STATUS_DICT_NAME,
		(select NAME from SYS_ROLE where ID=ROLE_ID) AS ROLE_NAME,
		PASSWORD_MODIFY_DATE,
		ENABLE_DATE,
		DISABLE_DATE,
		QUALIFIED_START_TIME,
		QUALIFIED_END_TIME,
		QUALIFIED_ADDRESS_LIST
FROM SYS_USER
where STATUS<>(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='��ɾ��');