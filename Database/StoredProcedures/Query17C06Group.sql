create or replace procedure Query17C06Group
(
	xh in varchar2,			--���  char	8	���ɿ�
	kskm in varchar2,		--���Կ�Ŀ    Char	1	���ɿ�
	ksrq in varchar2,		--�������� Date        ���ɿ� yyyymmdd
	ksdd in varchar2,		--���Եص� Varchar2	64	���ɿ� ���Եص����
	kcxh in varchar2,		--�������    Char	8	���ɿ� ����Ψһ���
	kscx in varchar2,		--���Գ���    Varchar2	15	���ɿ�
	kscc in number,			--���Գ��� Number      ���ɿ�
	kchp in varchar2,		--�������� Varchar2	15	�ɿ�
	ksy in varchar2,		--����Ա Varchar2	30	�ɿ�
	ksxm in varchar2,		--������Ŀ Varchar2	256	�ɿ�
	glbm in varchar2,		--������ Varchar2	12	�ɿ�
	ksxl in varchar2		--������· Char	10	�ɿ�
) as
	n number;
begin
	select count(*) into n from BAS_PLACE where (kcxh is null or SEQUENCENUMBER=kcxh) and CODE=ksdd;
	if n=0 then
		return;
	end if;
	select count(*) into n from BAS_GROUPING where SEQUENCENUMBER=xh;
	if n>0 then
		update BAS_GROUPING set
			SUBJECT=kskm,
			EXAM_DATE=ksrq,
			PLACE_ID=(select ID from BAS_PLACE where (kcxh is null or SEQUENCENUMBER=kcxh) and CODE=ksdd),
			DRIVER_LICENSE_TYPE=kscx,
			EXAM_SESSION=kscc,
			CAR_ID=case when kchp is null then null else (select ID from BAS_CAR where LICENSE_PLATE=kchp) end,
			EXAMINER_ID=case when ksy is null then null else (select ID from BAS_EXAMINER where NAME=ksy) end,
			BRANCH_ADMINISTRATION=glbm,
			EXAM_ITEM=ksxm,
			CIRCUITRY=ksxl
		where SEQUENCENUMBER=xh;
	else
		insert into BAS_GROUPING(
			ID,
			SEQUENCENUMBER,
			SUBJECT,
			EXAM_DATE,
			PLACE_ID,
			DRIVER_LICENSE_TYPE,
			EXAM_SESSION,
			CAR_ID,
			EXAMINER_ID,
			BRANCH_ADMINISTRATION,
			EXAM_ITEM,
			CIRCUITRY)
		values(
			SEQU_BAS_GROUPING_ID.nextval,
			xh,
			kskm,
			ksrq,
			(select ID from BAS_PLACE where (kcxh is null or SEQUENCENUMBER=kcxh) and CODE=ksdd),
			kscx,
			kscc,
			case when kchp is null then null else (select ID from BAS_CAR where LICENSE_PLATE=kchp) end,
			case when ksy is null then null else (select ID from BAS_EXAMINER where NAME=ksy) end,
			glbm,
			ksxm,
			ksxl);
	end if;
	commit;
end Query17C06Group;
/
