create or replace procedure Query17C08Book
(
	lsh in varchar2,		--��ˮ�� Varchar2	13	���ɿ�
	kskm in varchar2,		--���Կ�Ŀ Char	1	���ɿ�	1��Ŀһ��2��Ŀ����3��Ŀ��	
	zkzmbh in varchar2,		--׼��֤����� Char	12	���ɿ�	
	sfzmmc in varchar2,		--���֤������ Char	1	���ɿ�
	sfzmhm in varchar2,		--���֤������ Varchar2	18	���ɿ�
	xm in varchar2,			--���� Varchar2	30	���ɿ�
	ksyy in varchar2,		--����ԭ�� Char	1	���ɿ�
	xxsj in number,			--ѧϰʱ�� Number      �ɿ�
	yyrq in varchar2,		--ԤԼ���� Date        ���ɿ� yyyymmddhhmmss
	ykrq in varchar2,		--Լ������ Date        ���ɿ� yyyymmdd
	kscx in varchar2,		--���Գ��� Varchar2	6	���ɿ�
	ksdd in varchar2,		--���Եص� Varchar2	64	���ɿ�
	kscc in number,			--���Գ��� Number      ���ɿ�
	kchp in varchar2,		--���Գ������� Varchar2	15	�ɿ�
	jbr in varchar2,		--������ Varchar2	30	���ɿ�
	glbm in varchar2,		--������ Varchar2	12	���ɿ�
	dlr in varchar2,		--������ Varchar2	64	�ɿ�
	ksrq in varchar2,		--�������� Date        �ɿ� yyyymmdd
	kscs in number,			--���Դ��� Number      �ɿ�
	ksy1 in varchar2,		--����Ա1 Varchar2	30	�ɿ�
	ksy2 in varchar2,		--����Ա2 Varchar2	30	�ɿ�
	zt in varchar2,			--״̬ Char	1	���ɿ�	0δ���ԣ�2���Բ��ϸ�
	pxshrq in varchar2,		--��ѵ������� Date        �ɿ� yyyymmdd
	sfyk in varchar2,		--�Ƿ�ҹ�� Char	1	�ɿ�	0��1��
	zkykrq in varchar2,		--׮��Լ������ Date        �ɿ� yyyymmdd
	zksfhg in varchar2,		--׮���Ƿ�ϸ� Char	1	�ɿ�
	clzl in varchar2,		--�������� Varchar2	10	�ɿ�
	jly in varchar2,		--����Ա Varchar2	30	�ɿ�
	zkkf in number,			--׮���۷� Number      �ɿ�
	ckyy in varchar2,		--�����Ƿ���Լ Char	1	���ɿ�	0δԤԼ��1��ԤԼ
	ywblbm in varchar2,		--ҵ������� Varchar2	12	���ɿ�
	yycs in number,			--ԤԼ���� Number	1	���ɿ�
	bcyykscs in number		--����ԤԼ���Դ��� Number	1	���ɿ�
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
