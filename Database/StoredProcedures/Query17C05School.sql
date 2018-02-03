create or replace procedure Query17C05School
(
	xh in varchar2,			--序号  char	8	不可空
	jxmc in varchar2,		--驾校名称    Varchar2	256	可空
	jxjc in varchar2,		--驾校简称 Varchar2	64	不可空
	jxdm in varchar2,		--驾校代码 Varchar2	64	不可空
	jxdz in varchar2,		--驾校地址 Varchar2	256	不可空
	lxdh in varchar2,		--联系电话 Varchar2	20	不可空
	lxr in varchar2,		--联系人 Varchar2	30	不可空
	frdb in varchar2,		--法人代表 Varchar2	30	不可空
	zczj in number,			--注册资金 number      可空
	jxjb in varchar2,		--驾校级别 Char	1	不可空	1一级；2二级；3三级；0其他
	kpxcx in varchar2,		--培训准驾车型 Varchar2	30	可空
	fzjg in varchar2,		--所属发证机关 Varchar2	10	可空
	jxzt in varchar2,		--驾校状态 Char	1	可空 A正常；B暂停受理；C取消资格
	shr in varchar2,		--审核人 Varchar2	30	不可空
	cjsj in varchar2,		--创建时间 Date        不可空 yyyymmddhh24miss
	gxsj in varchar2		--更新时间 Date        不可空 yyyymmddhh24miss
) as
	n number;
begin
	select count(*) into n from BAS_DRIVING_SCHOOL where CODE=jxdm;
	if n>0 then
		update BAS_DRIVING_SCHOOL set
			SEQUENCENUMBER=xh,
			NAME=jxmc,
			SHORT_NAME=jxjc,
			ADDRESS=jxdz,
			CONTACT_ADDRESS=lxdh,
			CONTACT=lxr,
			CORPORATION=frdb,
			REGISTERED_CAPITAL=zczj,
			GRADE=jxjb,
			QUALIFIED_CAR_TYPE=kpxcx,
			ISSUING_AUTHORITY=fzjg,
			STATUS=jxzt,
			AUDITOR=shr,
			CREATE_TIME=cjsj,
			UPDATE_TIME=gxsj
		where CODE=jxdm;
	else
		insert into BAS_DRIVING_SCHOOL(
			ID,
			SEQUENCENUMBER,
			CODE,
			NAME,
			SHORT_NAME,
			ADDRESS,
			CONTACT_ADDRESS,
			CONTACT,
			CORPORATION,
			REGISTERED_CAPITAL,
			GRADE,
			QUALIFIED_CAR_TYPE,
			ISSUING_AUTHORITY,
			STATUS,
			AUDITOR,
			CREATE_TIME,
			UPDATE_TIME)
		values(
			SEQU_BAS_DRIVING_SCHOOL_ID.nextval,
			xh,
			jxdm,
			jxmc,
			jxjc,
			jxdz,
			lxdh,
			lxr,
			frdb,
			zczj,
			jxjb,
			kpxcx,
			fzjg,
			jxzt,
			shr,
			cjsj,
			gxsj);
	end if;
	commit;
end Query17C05School;
/
