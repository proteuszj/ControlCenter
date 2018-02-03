CREATE OR REPLACE FORCE VIEW BAS_STUDENT_VIEW AS
SELECT  
    (select DICT_NAME from CFG_DICT where DICT_TYPE=2002 and DICT_CODE=IDTYPE) IDTYPE_DICT_NAME,
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
    case when exists(select * from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME=0) then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME=0) else null end BOOKING_TIMES,
    case when exists(select * from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME=0) then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME=0)-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME=0)) else null end LEFT_TIMES,
    case when exists(select * from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0) then (select sum(STUDY_TIME) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0) else null end BOOKING_STUDY_TIME,
    case when exists(select * from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0)
        then
            case when exists(select * from BUZ_EXAM_INFO where EXAM_END_TIME is not null and BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0))
                then (select sum(STUDY_TIME) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0)-(select sum(round((to_date(EXAM_END_TIME,'yyyymmddhh24miss')-to_date(EXAM_START_TIME,'yyyymmddhh24miss'))*24*60)) from BUZ_EXAM_INFO where EXAM_END_TIME is not null and BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0))
                else (select sum(STUDY_TIME) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0)
            end
        else null
        end LEFT_STUDY_TIME,
		CREATE_TIME,
		UPDATE_TIME
FROM BAS_STUDENT
order by ID;
