CREATE OR REPLACE FORCE VIEW BAS_GROUPING_DETAIL_VIEW AS
SELECT  case when GROUPING_ID is null then null else (select SEQUENCENUMBER from BAS_GROUPING where ID=GROUPING_ID) end GROUPING_SEQUENCENUMBER,
		case when STUDENT_ID is null then null else (select IDNUMBER from BAS_STUDENT where ID=STUDENT_ID) end STUDENT_IDNUMBER,
		case when STUDENT_ID is null then null else (select NAME from BAS_STUDENT where ID=STUDENT_ID) end STUDENT_NAME,
		case when SCHOOL_ID is null then null else (select CODE from BAS_DRIVING_SCHOOL where ID=SCHOOL_ID) end SCHOOL_CODE,
		case when CAR_ID is null then null else (select LICENSE_PLATE from BAS_CAR where ID=CAR_ID) end CAR_LICENSE_NUMBER,
--		(select LICENSE_PLATE from BAS_CAR where ID=(select CAR_ID from BAS_GROUPING where ID=GROUPING_ID)) CAR_LICENSE_NUMBER,
		QUEUE_ORDER,
		case when QUEUE_STATUS is null then null else (select DICT_NAME from CFG_DICT where DICT_TYPE=1023 and DICT_CODE=QUEUE_STATUS) end QUEUE_STATUS_DICT_NAME
FROM BAS_GROUPING_DETAIL;
