CREATE OR REPLACE FORCE VIEW BAS_STUDENT_VIEW AS
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
		case when exists(select * from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID) then '��ԤԼ' else 'δԤԼ' end BOOKED,
		case when exists(select * from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID) then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID) else null end BOOK_TIMES,
		case when exists(select * from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID) then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID)-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID)) else null end LEFT_TIMES,
		CREATE_TIME,
		UPDATE_TIME
FROM BAS_STUDENT
order by ID;
