create or replace procedure Query17C06Group
(
	xh in varchar2,			--序号  char	8	不可空
	kskm in varchar2,		--考试科目    Char	1	不可空
	ksrq in varchar2,		--考试日期 Date        不可空 yyyymmdd
	ksdd in varchar2,		--考试地点 Varchar2	64	不可空 考试地点代号
	kcxh in varchar2,		--考场序号    Char	8	不可空 考场唯一编号
	kscx in varchar2,		--考试车型    Varchar2	15	不可空
	kscc in number,			--考试场次 Number      不可空
	kchp in varchar2,		--考车号牌 Varchar2	15	可空
	ksy in varchar2,		--考试员 Varchar2	30	可空
	ksxm in varchar2,		--考试项目 Varchar2	256	可空
	glbm in varchar2,		--管理部门 Varchar2	12	可空
	ksxl in varchar2		--考试线路 Char	10	可空
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
