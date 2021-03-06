CREATE OR REPLACE FORCE VIEW BAS_PLACE_VIEW AS
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
FROM BAS_PLACE;
