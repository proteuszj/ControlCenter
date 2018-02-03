CREATE OR REPLACE FORCE VIEW CAR_ALLOCATION_CAR_VIEW AS 
select
    LICENSE_PLATE,
    CARNUMBER,
    QUALIFIED_CAR_TYPE,
    (select DICT_NAME from CFG_DICT where DICT_TYPE=1025 and DICT_CODE=PROCESS_TYPE) PROCESS_TYPE_DICTNAME,
	(select ITEM_NAME from CFG_ITEMS where ITEM_CODE=EXAM_ITEM) EXAM_ITEM_DICTNAME,

    case when USE_STATUS='A'
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select SEQUENCENUMBER+1-(select min(SEQUENCENUMBER) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd')) from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) 
        else null 
    end SEQUENCE_NUMBER,

    case when USE_STATUS='A'
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select NAME from bas_student where ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))) 
        else null 
    end STUDENT_NAME,
    
    case when USE_STATUS='A'
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select IDNUMBER from bas_student where ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))) 
        else null 
    end STUDENT_IDNUMBER,
    
    case when USE_STATUS='A'
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))) 
        else null 
    end BOOKING_TIMES,
    
    case when USE_STATUS='A'
        and not exists(select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)) and not exists(select * from buz_exam_info where booking_id=bas_booking.id))
        and ((select EXAM_END_TIME from buz_exam_info where ID=EXAM_ID) is null 
            or (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID))))>0)    
        then (select sum(BOOKING_TIMES) from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))-(select count(*) from BUZ_EXAM_INFO where BOOKING_ID in (select ID from BAS_BOOKING where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and  STUDENT_ID=(select STUDENT_ID from bas_booking where ID=(select BOOKING_ID from buz_exam_info where ID=buz_exam_process.EXAM_ID)))) 
        else null 
    end LEFT_TIMES,
    
    USE_STATUS
from bas_car left join buz_exam_process on buz_exam_process.ID in (select max(ID) from buz_exam_process where EXAM_ID in (select max(ID) from buz_exam_info where substr(EXAM_START_TIME,1,8)=to_char(current_date, 'yyyymmdd') group by CAR_ID) group by EXAM_ID) and bas_car.ID=(select CAR_ID from buz_exam_info where ID= buz_exam_process.EXAM_ID)
order by bas_car.USE_STATUS, bas_car.ID;
