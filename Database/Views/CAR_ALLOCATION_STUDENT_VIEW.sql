CREATE OR REPLACE FORCE VIEW CAR_ALLOCATION_STUDENT_VIEW AS 
select 
	(select SEQUENCENUMBER+1-(select min(SEQUENCENUMBER) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd')) from bas_booking where id=(select max(id) from bas_booking where STUDENT_ID=bas_student.ID and BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd'))) SEQUENCE_NUMBER,
    NAME,
    IDNUMBER,
    DRIVER_LICENSE_TYPE,
    (select CARNUMBER from bas_car where ID=(select CAR_ID from bas_booking where id=(select max(id) from bas_booking where STUDENT_ID=bas_student.ID and BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd')))) BOOKING_CAR,
    (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME=0) BOOKING_TIMES,
    (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME=0)-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME=0)) LEFT_TIMES,
    (select sum(STUDY_TIME) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0) BOOKING_STUDY_TIME,
    case when exists(select * from BUZ_EXAM_INFO where EXAM_END_TIME is not null and BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0))
        then (select sum(STUDY_TIME) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0)-(select sum(round((to_date(EXAM_END_TIME,'yyyymmddhh24miss')-to_date(EXAM_START_TIME,'yyyymmddhh24miss'))*24*60)) from BUZ_EXAM_INFO where EXAM_END_TIME is not null and BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0))
        else (select sum(STUDY_TIME) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID and STUDY_TIME>0)
    end LEFT_STUDY_TIME
from bas_student
where ID in (select distinct(STUDENT_ID) from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and not exists(select * from buz_exam_info where BOOKING_ID=bas_booking.ID))
order by (select min(id) from bas_booking where student_id=bas_student.id and BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and not exists(select *from buz_exam_info where BOOKING_ID=bas_booking.ID));