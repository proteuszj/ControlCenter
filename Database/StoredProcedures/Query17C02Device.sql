create or replace procedure Query17C02Device
(
	xh in varchar2,			--序号  char	8	不可空
	sbbh in varchar2,		--设备编号 Varchar2	10	不可空
	sbms in varchar2,		--设备描述 Varchar2	512	不可空
	zzcs in varchar2,		--制造厂商 Varchar2	512	不可空
	sbxh in varchar2,		--设备型号 Varchar2	512	不可空
	ksxm in varchar2,		--考试项目 Char	5	不可空
	ksxmsm in varchar2,		--考试项目说明 Varchar2	256	不可空
	ppfs in varchar2,		--评判方式 Char	1	不可空	0计算机自动评判；1人工评判
	kcxh in varchar2,		--考场序号 char	8	不可空
	syzjcx in varchar2,		--适用准驾车型范围 Varchar2	30	不可空
	ysrq in varchar2,		--验收日期 Date        不可空 yyyymmdd
	badckssj number,		--备案单次考试时间 Number      不可空 单位为min
	bamxsksrs number,		--备案每小时考试人次   Number 不可空
	jyyxqz in varchar2,		--检验有效期止  Date 不可空 yyyymmdd
	syzt in varchar2,		--使用状态 Char        不可空 A正常；B故障；C暂停考试；D报废
	cjsj in varchar2,		--创建时间 Date        不可空 yyyymmddhh24miss
	gxsj in varchar2		--更新日期 Date        不可空 yyyymmddhh24miss
) as
	n number;
begin
	select count(*) into n from BAS_DEVICE where DEVICENUMBER=sbbh;
	if n>0 then
		update BAS_DEVICE set
			SEQUENCENUMBER=xh,
			DESCRIPTION=sbms,
			MANUFACTURER=zzcs,
			SERIALNUMBER=sbxh,
			EXAM_ITEM=ksxm,
			EXAM_ITEM_NAME=ksxmsm,
			JUDGING_TYPE=ppfs,
			PLACE_ID=(select ID from BAS_PLACE where SEQUENCENUMBER=kcxh),
			QUALIFIED_CAR_TYPE=syzjcx,
			ACCEPTANCE_DATE=ysrq,
			EXPIRE_DATE=jyyxqz,
			SINGLE_EXAM_TIMES=badckssj,
			HOURLY_EXAM_TIMES=bamxsksrs,
			STATUS=syzt,
			CREATE_TIME=cjsj,
			UPDATE_TIME=gxsj
		where DEVICENUMBER=sbbh;
	else
		insert into BAS_DEVICE(
			ID,
			SEQUENCENUMBER,
			DEVICENUMBER,
			DESCRIPTION,
			MANUFACTURER,
			SERIALNUMBER,
			EXAM_ITEM,
			EXAM_ITEM_NAME,
			JUDGING_TYPE,
			PLACE_ID,
			QUALIFIED_CAR_TYPE,
			ACCEPTANCE_DATE,
			EXPIRE_DATE,
			SINGLE_EXAM_TIMES,
			HOURLY_EXAM_TIMES,
			STATUS,
			CREATE_TIME,
			UPDATE_TIME)
		values(
			SEQU_BAS_DEVICE_ID.nextval,
			xh,
			sbbh,
			sbms,
			zzcs,
			sbxh,
			ksxm,
			ksxmsm,
			ppfs,
			(select ID from BAS_PLACE where SEQUENCENUMBER=kcxh),
			syzjcx,
			ysrq,
			jyyxqz,
			badckssj,
			bamxsksrs,
			syzt,
			cjsj,
			gxsj);
	end if;
	commit;
end Query17C02Device;
/
