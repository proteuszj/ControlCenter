CREATE OR REPLACE FORCE VIEW BAS_CAR_VIEW AS
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
FROM BAS_CAR;
