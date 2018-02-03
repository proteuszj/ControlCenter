create or replace procedure Query17C08Book
(
	lsh in varchar2,		--流水号 Varchar2	13	不可空
	kskm in varchar2,		--考试科目 Char	1	不可空	1科目一；2科目二；3科目三	
	zkzmbh in varchar2,		--准考证明编号 Char	12	不可空	
	sfzmmc in varchar2,		--身份证明名称 Char	1	不可空
	sfzmhm in varchar2,		--身份证明号码 Varchar2	18	不可空
	xm in varchar2,			--姓名 Varchar2	30	不可空
	ksyy in varchar2,		--考试原因 Char	1	不可空
	xxsj in number,			--学习时间 Number      可空
	yyrq in varchar2,		--预约日期 Date        不可空 yyyymmddhhmmss
	ykrq in varchar2,		--约考日期 Date        不可空 yyyymmdd
	kscx in varchar2,		--考试车型 Varchar2	6	不可空
	ksdd in varchar2,		--考试地点 Varchar2	64	不可空
	kscc in number,			--考试场次 Number      不可空
	kchp in varchar2,		--考试车辆号牌 Varchar2	15	可空
	jbr in varchar2,		--经办人 Varchar2	30	不可空
	glbm in varchar2,		--管理部门 Varchar2	12	不可空
	dlr in varchar2,		--代理人 Varchar2	64	可空
	ksrq in varchar2,		--考试日期 Date        可空 yyyymmdd
	kscs in number,			--考试次数 Number      可空
	ksy1 in varchar2,		--考试员1 Varchar2	30	可空
	ksy2 in varchar2,		--考试员2 Varchar2	30	可空
	zt in varchar2,			--状态 Char	1	不可空	0未考试；2考试不合格
	pxshrq in varchar2,		--培训审核日期 Date        可空 yyyymmdd
	sfyk in varchar2,		--是否夜考 Char	1	可空	0否；1是
	zkykrq in varchar2,		--桩考约考日期 Date        可空 yyyymmdd
	zksfhg in varchar2,		--桩考是否合格 Char	1	可空
	clzl in varchar2,		--车辆种类 Varchar2	10	可空
	jly in varchar2,		--教练员 Varchar2	30	可空
	zkkf in number,			--桩考扣分 Number      可空
	ckyy in varchar2,		--场考是否已约 Char	1	不可空	0未预约；1已预约
	ywblbm in varchar2,		--业务办理部门 Varchar2	12	不可空
	yycs in number,			--预约次数 Number	1	不可空
	bcyykscs in number		--本次预约考试次数 Number	1	不可空
) as
	n number;
	studentID BAS_STUDENT.ID%TYPE;
begin
	select count(*) into n from BAS_PLACE where CODE=ksdd;
	if n=0 then
		return;
	end if;

	select count(*) into n from BAS_STUDENT where IDNUMBER=sfzmhm;
	if n=0 then
		studentID:=SEQU_BAS_STUDENT_ID.nextval;
		insert into BAS_STUDENT(
			ID,
			IDTYPE,
			IDNUMBER,
			NAME,
			DRIVER_LICENSE_TYPE,
			SCHOOL_NAME,
			PASSWORD,
			CREATE_TIME,
			UPDATE_TIME)
		values(
			studentID,
			sfzmmc,
			sfzmhm,
			xm,
			kscx,
			case when dlr is null then null else (select NAME from BAS_DRIVING_SCHOOL where CODE=dlr) end,
			'123',
			to_char(current_date, 'yyyymmddhh24miss'),
			to_char(current_date, 'yyyymmddhh24miss'));
	else
		update BAS_STUDENT set
			IDTYPE=sfzmmc,
			NAME=xm,
			DRIVER_LICENSE_TYPE=kscx,
			SCHOOL_NAME=case when dlr is null then null else (select NAME from BAS_DRIVING_SCHOOL where CODE=dlr) end,
			CREATE_TIME=to_char(current_date, 'yyyymmddhh24miss'),
			UPDATE_TIME=to_char(current_date, 'yyyymmddhh24miss')
		where IDNUMBER=sfzmhm;
		select ID into studentID from BAS_STUDENT where IDNUMBER=sfzmhm;
	end if;
	select count(*) into n from BAS_BOOKING where SEQUENCENUMBER=lsh;
	if n>0 then
		update BAS_BOOKING set
			SUBJECT=kskm,
			EXAMNUMBER=zkzmbh,
			STUDENT_ID=studentID,
			EXAM_REASON=ksyy,
			STUDY_TIME=xxsj,
			BOOKING_DATETIME=yyrq,
			BOOKING_TIMES=yycs,
			BOOKING_EXAM_DATE=ykrq,
			DRIVER_LICENSE_TYPE=kscx,
			PLACE_ID=(select ID from BAS_PLACE where CODE=ksdd),
			EXAM_SESSION=kscc,
			CAR_ID=case when kchp is null then null else (select ID from BAS_CAR where LICENSE_PLATE=kchp) end,
			OPERATOR_NAME=jbr,
			BRANCH_ADMINISTRATION=glbm,
			SCHOOL_ID=case when dlr is null then null else (select ID from BAS_DRIVING_SCHOOL where CODE=dlr) end,
			EXAM_DATE=ksrq,
			EXAM_TIMES=kscs,
			EXAMINER1_ID=case when ksy1 is null then null else (select ID from BAS_EXAMINER where NAME=ksy1) end,
			EXAMINER2_ID=case when ksy2 is null then null else (select ID from BAS_EXAMINER where NAME=ksy2) end,
			EXAM_STATUS=zt,
			TRAINING_AUDIT_DATE=pxshrq,
			IS_NIGHT_EXAM=sfyk,
			PILE_EXAM_BOOKING_DATE=zkykrq,
			PILE_EXAM_STATUS=zksfhg,
			CAR_BREED=clzl,
			COACH=jly,
			PILE_EXAM_DEDUCT_SCORE=zkkf,
			IS_PLACE_EXAM=ckyy,
			BRANCH_BUSINESS=ywblbm,
			UPDATE_TIME=to_char(current_date,'yyyymmddhh24miss')
		where SEQUENCENUMBER=lsh;
	else
		insert into BAS_BOOKING(
			ID,
			SEQUENCENUMBER,
			SUBJECT,
			EXAMNUMBER,
			STUDENT_ID,
			EXAM_REASON,
			STUDY_TIME,
			BOOKING_DATETIME,
			BOOKING_TIMES,
			BOOKING_EXAM_DATE,
			DRIVER_LICENSE_TYPE,
			PLACE_ID,
			EXAM_SESSION,
			CAR_ID,
			OPERATOR_NAME,
			BRANCH_ADMINISTRATION,
			SCHOOL_ID,
			EXAM_DATE,
			EXAM_TIMES,
			EXAMINER1_ID,
			EXAMINER2_ID,
			EXAM_STATUS,
			TRAINING_AUDIT_DATE,
			IS_NIGHT_EXAM,
			PILE_EXAM_BOOKING_DATE,
			PILE_EXAM_STATUS,
			CAR_BREED,
			COACH,
			PILE_EXAM_DEDUCT_SCORE,
			IS_PLACE_EXAM,
			BRANCH_BUSINESS,
			UPDATE_TIME)
		values(
			SEQU_BAS_BOOKING_ID.nextval,
			lsh,
			kskm,
			zkzmbh,
			studentID,
			ksyy,
			xxsj,
			yyrq,
			yycs,
			ykrq,
			kscx,
			(select ID from BAS_PLACE where CODE=ksdd),
			kscc,
			case when kchp is null then null else (select ID from BAS_CAR where LICENSE_PLATE=kchp) end,
			jbr,
			glbm,
			case when dlr is null then null else (select ID from BAS_DRIVING_SCHOOL where CODE=dlr) end,
			ksrq,
			kscs,
			case when ksy1 is null then null else (select ID from BAS_EXAMINER where NAME=ksy1) end,
			case when ksy2 is null then null else (select ID from BAS_EXAMINER where NAME=ksy2) end,
			zt,
			pxshrq,
			sfyk,
			zkykrq,
			zksfhg,
			clzl,
			jly,
			zkkf,
			ckyy,
			ywblbm,
			to_char(current_date,'yyyymmddhh24miss'));
	end if;
	commit;
end Query17C08Book;
/
