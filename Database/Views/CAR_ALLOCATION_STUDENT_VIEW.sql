CREATE OR REPLACE FORCE VIEW CAR_ALLOCATION_STUDENT_VIEW AS 
select 
	(select SEQUENCENUMBER+1-(select min(SEQUENCENUMBER) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd')) from bas_booking where id=(select max(id) from bas_booking where STUDENT_ID=bas_student.ID and BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd'))) SEQUENCE_NUMBER,
    NAME,
    IDNUMBER,
    DRIVER_LICENSE_TYPE,
    (select CARNUMBER from bas_car where ID=(select CAR_ID from bas_booking where id=(select max(id) from bas_booking where STUDENT_ID=bas_student.ID and BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd')))) BOOKING_CAR,
    (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID) BOOKING_TIMES,
    (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=BAS_STUDENT.ID)-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and  STUDENT_ID=BAS_STUDENT.ID)) LEFT_TIMES
from bas_student
where ID in (select distinct(STUDENT_ID) from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and not exists(select * from buz_exam_info where BOOKING_ID=bas_booking.ID))
order by (select min(id) from bas_booking where student_id=bas_student.id and BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and not exists(select *from buz_exam_info where BOOKING_ID=bas_booking.ID));