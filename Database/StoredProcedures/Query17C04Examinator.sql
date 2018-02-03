create or replace procedure Query17C04Examinator
(
	xh in varchar2,			--���  char	8	���ɿ�
	sszd in varchar2,		--������֤����  Varchar2	10	���ɿ�
	glbm in varchar2,		--������ Varchar2	12	�ɿ�
	sfzmmc in varchar2,		--���֤������ Char	1	���ɿ�
	sfzmhm in varchar2,		--���֤������ Varchar2	18	���ɿ�
	dabh in varchar2,		--��ʻ֤������� Varchar2	12	�ɿ� ����GA/T 16.21
	xm in varchar2,			--����  Varchar2	30	���ɿ�
	xb in varchar2,			--�Ա� Char	1	���ɿ� ����GB/T 2261.1
	csrq in varchar2,		--��������    Date ���ɿ� yyyymmdd
	zkcx in varchar2,		--����׼�ݳ��ͷ�Χ Varchar2	32	���ɿ�
	fzrq in varchar2,		--����Ա֤��֤���� Date        ���ɿ� yyyymmdd
	kszyxqz in varchar2,	--����Ա֤��Ч��ֹ Date        ���ɿ� yyyymmdd
	kszzt in varchar2,		--����Ա֤״̬ Varchar2	1       A������B���ڣ�Cע��
	gzdw in varchar2,		--������λ Varchar2	128	�ɿ�
	jbr in varchar2,		--������ Varchar2	30	���ɿ�
	fzjg in varchar2,		--����Ա֤��֤��λ Varchar2	64	���ɿ�
	cjsj in varchar2,		--����ʱ�� Date        ���ɿ� yyyymmddhh24miss
	gxsj in varchar2		--����ʱ�� Date        ���ɿ� yyyymmddhh24miss
) as
	n number;
begin
	select count(*) into n from BAS_EXAMINER where IDNUMBER=sfzmhm;
	if n>0 then
		update BAS_EXAMINER set
			SEQUENCENUMBER=xh,
			IDTYPE=sfzmmc,
			NAME=xm,
			GENDER=xb,
			BIRTH_DATE=csrq,
			ISSUING_AUTHORITY=sszd,
			BRANCH_ADMINISTRATION=glbm,
			ARCHIVESNUMBER=dabh,
			QUALIFIED_CAR_TYPE=zkcx,
			ISSUING_DATE=fzrq,
			EXPIRE_DATE=kszyxqz,
			STATUS=kszzt,
			WORK_OFFICE=gzdw,
			OPERATOR_NAME=jbr,
			ISSUING_OFFICE=fzjg,
			CREATE_TIME=cjsj,
			UPDATE_TIME=gxsj
		where IDNUMBER=sfzmhm;
	else
		insert into BAS_EXAMINER(
			ID,
			SEQUENCENUMBER,
			IDNUMBER,
			IDTYPE,
			NAME,
			GENDER,
			BIRTH_DATE,
			ISSUING_AUTHORITY,
			BRANCH_ADMINISTRATION,
			ARCHIVESNUMBER,
			QUALIFIED_CAR_TYPE,
			ISSUING_DATE,
			EXPIRE_DATE,
			STATUS,
			WORK_OFFICE,
			OPERATOR_NAME,
			ISSUING_OFFICE,
			CREATE_TIME,
			UPDATE_TIME)
		values(
			SEQU_BAS_EXAMINER_ID.nextval,
			xh,
			sfzmhm,
			sfzmmc,
			xm,
			xb,
			csrq,
			sszd,
			glbm,
			dabh,
			zkcx,
			fzrq,
			kszyxqz,
			kszzt,
			gzdw,
			jbr,
			fzjg,
			cjsj,
			gxsj);
	end if;
	commit;
end Query17C04Examinator;
/
