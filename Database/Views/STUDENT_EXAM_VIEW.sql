create or replace force view STUDENT_EXAM_VIEW as
select  case when HASH is not null and HASH=GenerateSHA1(ID||SUBJECT||BOOKING_ID||EXAM_START_TIME||EXAM_END_TIME||CURRENT_EXAM_TIMES||CURRENT_EXAM_SCORE||EXAM_STATUS||CONTRAIL_PATH||VIDEO_PATH) then 'TRUE' else 'FALSE' end VERIFY,
        (select STUDENT_ID from BAS_BOOKING where ID=BOOKING_ID) STUDENT_ID,
		ID EXAM_ID,
		(select NAME from BAS_STUDENT where ID=(select STUDENT_ID from BAS_BOOKING where ID=BOOKING_ID)) NAME,
		(select IDNUMBER from BAS_STUDENT where ID=(select STUDENT_ID from BAS_BOOKING where ID=BOOKING_ID)) IDNUMBER,
		CURRENT_EXAM_SCORE,
		case when EXAM_START_TIME is null then '待考' when EXAM_END_TIME is null then '未完成' when EXAM_STATUS=2 then '不合格' when EXAM_STATUS=1 then '合格' end STATUS
from BUZ_EXAM_INFO
where (select BOOKING_EXAM_DATE from BAS_BOOKING where ID=BOOKING_ID)=to_char(current_date, 'yyyymmdd') and
	  (EXAM_START_TIME is null or substr(EXAM_START_TIME,1,8)=to_char(current_date, 'yyyymmdd'));