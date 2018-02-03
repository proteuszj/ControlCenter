create or replace procedure Query17C03Car
(
	xh in varchar2,			--序号  char	8	不可空
	jbr in varchar2,		--经办人 Varchar2	30	不可空
	shr in varchar2,		--审核人 Varchar2	30	不可空
	hpzl in varchar2,		--号牌种类    CHAR	2
	zt in varchar2,			--车辆状态
	ksczt in varchar2,		--考试车状态（使用状态）  不可空；A正常，B暂停考试，C取消考试
	cllx in varchar2,		--车辆类型
	shsj in varchar2,		--??        Date        不可空 yyyymmddhh24miss
	clpp in varchar2,		--车辆品牌
	ccdjrq in varchar2,		--初次登记日期        Date       yyyymmdd
	qzbfqz in varchar2,		--强制报废期止 Date       yyyymmdd
	fzjg in varchar2,		--发证机关    Varchar2	10	不可空
	hphm in varchar2,		--号牌号码    VARCHAR2	15
	syzjcx in varchar2,		--适用准驾车型范围    Varchar2	30	不可空
	ipdz in varchar2,		--IP地址
	cjsj in varchar2,		--创建时间    Date 不可空 yyyymmddhh24miss
	gxsj in varchar2		--更新日期 Date        不可空 yyyymmddhh24miss
) as
	n number;
begin
	select count(*) into n from BAS_CAR	where LICENSE_PLATE=hphm;
	if n>0 then
		update BAS_CAR set
			SEQUENCENUMBER=xh,
			SUBJECT=2,
			LICENSE_PLATE_TYPE=hpzl,
			QUALIFIED_CAR_TYPE=syzjcx,
			CAR_TYPE=cllx,
			BRAND=clpp,
			REGISTER_DATE=ccdjrq,
			SCRAP_DATE=qzbfqz,
			ISSUING_AUTHORITY=fzjg,
			CAR_STATUS=zt,
			USE_STATUS=ksczt,
			AUDITOR=shr,
			CAR_IP=ipdz,
			CREATE_TIME=cjsj,
			UPDATE_TIME=gxsj
		where LICENSE_PLATE=hphm;
	else
		insert into BAS_CAR(
			ID,
			SEQUENCENUMBER,
			LICENSE_PLATE,
			SUBJECT,
			LICENSE_PLATE_TYPE,
			QUALIFIED_CAR_TYPE,
			CAR_TYPE,
			BRAND,
			REGISTER_DATE,
			SCRAP_DATE,
			ISSUING_AUTHORITY,
			CAR_STATUS,
			USE_STATUS,
			AUDITOR,
			CAR_IP,
			CREATE_TIME,
			UPDATE_TIME)
		values(
			SEQU_BAS_CAR_ID.nextval,
			xh,
			hphm,
			2,
			hpzl,
			syzjcx,
			cllx,
			clpp,
			ccdjrq,
			qzbfqz,
			fzjg,
			zt,
			ksczt,
			shr,
			ipdz,
			cjsj,
			gxsj);
	end if;
	commit;
end Query17C03Car;
/
