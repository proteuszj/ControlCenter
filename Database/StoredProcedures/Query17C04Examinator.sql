create or replace procedure Query17C04Examinator
(
	xh in varchar2,			--序号  char	8	不可空
	sszd in varchar2,		--所属发证机关  Varchar2	10	不可空
	glbm in varchar2,		--管理部门 Varchar2	12	可空
	sfzmmc in varchar2,		--身份证明名称 Char	1	不可空
	sfzmhm in varchar2,		--身份证明号码 Varchar2	18	不可空
	dabh in varchar2,		--驾驶证档案编号 Varchar2	12	可空 符合GA/T 16.21
	xm in varchar2,			--姓名  Varchar2	30	不可空
	xb in varchar2,			--性别 Char	1	不可空 符合GB/T 2261.1
	csrq in varchar2,		--出生日期    Date 不可空 yyyymmdd
	zkcx in varchar2,		--考试准驾车型范围 Varchar2	32	不可空
	fzrq in varchar2,		--考试员证发证日期 Date        不可空 yyyymmdd
	kszyxqz in varchar2,	--考试员证有效期止 Date        不可空 yyyymmdd
	kszzt in varchar2,		--考试员证状态 Varchar2	1       A正常；B过期；C注销
	gzdw in varchar2,		--工作单位 Varchar2	128	可空
	jbr in varchar2,		--经办人 Varchar2	30	不可空
	fzjg in varchar2,		--考试员证发证单位 Varchar2	64	不可空
	cjsj in varchar2,		--创建时间 Date        不可空 yyyymmddhh24miss
	gxsj in varchar2		--更新时间 Date        不可空 yyyymmddhh24miss
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
