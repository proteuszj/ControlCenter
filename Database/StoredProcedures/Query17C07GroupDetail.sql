create or replace procedure Query17C07GroupDetail
(
	xh in varchar2,			--分组序号, 来自请求参数
	sfzmhm in varchar2,		--身份证明号码  Varchar2	20	不可空
	xm in varchar2,			--姓名 Varchar2	30	不可空
	dlr in varchar2,		--代理人 Varchar2	64	可空 对应驾校代码
	kchp in varchar2,		--考车号牌    Varchar2	15	可空
	Jxxh in varchar2		--驾校序号 Char	8	可空 对应驾校唯一编号
) as
	n number;
begin
	select count(*) into n from BAS_GROUPING_DETAIL where GROUPING_ID=(select ID from BAS_GROUPING where SEQUENCENUMBER=xh) and STUDENT_ID=(select ID from BAS_STUDENT where IDNUMBER=sfzmhm);
	if n>0 then
		update BAS_GROUPING_DETAIL set
			SCHOOL_ID=case when dlr is null then case when Jxxh is null then null else (select ID from BAS_DRIVING_SCHOOL where SEQUENCENUMBER=Jxxh) end else (select ID from BAS_DRIVING_SCHOOL where CODE=dlr) end,
			CAR_ID=case when kchp is null then null else (select ID from BAS_CAR where LICENSE_PLATE=kchp) end
		where GROUPING_ID=(select ID from BAS_GROUPING where SEQUENCENUMBER=xh) and STUDENT_ID=(select ID from BAS_STUDENT where IDNUMBER=sfzmhm);
	else
		insert into BAS_GROUPING_DETAIL(
			GROUPING_ID,
			STUDENT_ID,
			SCHOOL_ID,
			CAR_ID)
		values(
			(select ID from BAS_GROUPING where SEQUENCENUMBER=xh),
			(select ID from BAS_STUDENT where IDNUMBER=sfzmhm),
			case when dlr is null then case when Jxxh is null then null else (select ID from BAS_DRIVING_SCHOOL where SEQUENCENUMBER=Jxxh) end else (select ID from BAS_DRIVING_SCHOOL where CODE=dlr) end,
			case when kchp is null then null else (select ID from BAS_CAR where LICENSE_PLATE=kchp) end);
	end if;
	commit;
end Query17C07GroupDetail;
/
