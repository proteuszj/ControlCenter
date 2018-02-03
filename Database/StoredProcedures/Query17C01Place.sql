create or replace procedure Query17C01Place
(
	xh in varchar2,			--序号  Char	8	不可空
	fzjg in varchar2,		--发证机关 Varchar2	10	不可空
	glbm in varchar2,		--管理部门 Varchar2	12	不可空
	kskm in varchar2,		--考试科目 Char	1	不可空 同上
	kcmc in varchar2,		--考场名称    Varchar2	128	不可空
	kcdddh in varchar2,		--考场代码 Varchar2	64	不可空
	kkcx in varchar2,		--适用准驾车型范围 Varchar2	24	不可空
	ywlx in varchar2,		--适用业务类型范围 Varchar2	10	可空
	zdysrq in varchar2,		--总队验收日期 Date        不可空 yyyymmdd
	ysr in varchar2,		--验收人 Varchar2	32	不可空
	kmeyyms in varchar2,	--科目二预约模式 Char	1	不可空	1一次预约；2两次预约
	fzms in varchar2,		--分组模式 Char	1	不可空	1按学员；2按教练车
	kmeksrsxz number,		--考试人数限制 Number      不可空
	kmezkrsxz number,		--科目二桩考人数限制 Number      不可空
	kmeckrsxz number,		--科目二场考人数限制 Number      不可空
	zksfdz in varchar2,		--桩考评判方式 Char	1	不可空	1计算机自动评判；0人工评判
	cksfdz in varchar2,		--场考评判方式 Char	1	不可空	1计算机自动评判；0人工评判
	zklwrq in varchar2,		--桩考开始联网时间 Date        可空 yyyymmddhh24miss
	cklwrq in varchar2,		--场考开始联网时间 Date        可空 yyyymmddhh24miss
	kczt in varchar2,		--使用状态 Char	1	不可空 A正常；B暂停考试；C取消考试
	zksbs number,			--桩考设备数 Number      不可空
	cksbs number,			--场考设备数 Number      不可空
	cjsj in varchar2,		--创建日期 Date        不可空 yyyymmddhh24miss
	gxsj in varchar2		--更新日期 Date        不可空 yyyymmddhh24miss
) as
	n number;
begin
	select count(*) into n from BAS_PLACE where CODE=kcdddh;
	if n>0 then
		update BAS_PLACE set
			SEQUENCENUMBER=xh,
			NAME=kcmc,
			SUBJECT=kskm,
			QUALIFIED_CAR_TYPE=kkcx,
			ISSUING_AUTHORITY=fzjg,
			BRANCH_ADMINISTRATION=glbm,
			BUSINESS_TYPE=ywlx,
			ACCEPTANCE_DATE=zdysrq,
			ACCEPTER=ysr,
			RESERVATION_MODE=kmeyyms,
			GROUPING_MODE=fzms,
			CAPACITY=kmeksrsxz,
			PILE_EXAM_CAPACITY=kmezkrsxz,
			PLACE_EXAM_CAPACITY=kmeckrsxz,
			PILE_EXAM_JUDGING=zksfdz,
			PLACE_EXAM_JUDGING=cksfdz,
			PILE_EXAM_NETWORK_TIME=zklwrq,
			PLACE_EXAM_NETWORK_TIME=cklwrq,
			STATUS=kczt,
			PILE_EXAM_DEVICE_COUNT=zksbs,
			PLACE_EXAM_DEVICE_COUNT=cksbs,
			CREATE_TIME=cjsj,
			UPDATE_TIME=gxsj
		where CODE=kcdddh;
	else
		insert into BAS_PLACE(
			ID,
			SEQUENCENUMBER,
			CODE,
			NAME,
			SUBJECT,
			QUALIFIED_CAR_TYPE,
			ISSUING_AUTHORITY,
			BRANCH_ADMINISTRATION,
			BUSINESS_TYPE,
			ACCEPTANCE_DATE,
			ACCEPTER,
			RESERVATION_MODE,
			GROUPING_MODE,
			CAPACITY,
			PILE_EXAM_CAPACITY,
			PLACE_EXAM_CAPACITY,
			PILE_EXAM_JUDGING,
			PLACE_EXAM_JUDGING,
			PILE_EXAM_NETWORK_TIME,
			PLACE_EXAM_NETWORK_TIME,
			STATUS,
			PILE_EXAM_DEVICE_COUNT,
			PLACE_EXAM_DEVICE_COUNT,
			CREATE_TIME,
			UPDATE_TIME)
		values(
			SEQU_BAS_PLACE_ID.nextval,
			xh,
			kcdddh,
			kcmc,
			kskm,
			kkcx,
			fzjg,
			glbm,
			ywlx,
			zdysrq,
			ysr,
			kmeyyms,
			fzms,
			kmeksrsxz,
			kmezkrsxz,
			kmeckrsxz,
			zksfdz,
			cksfdz,
			zklwrq,
			cklwrq,
			kczt,
			zksbs,
			cksbs,
			cjsj,
			gxsj);
	end if;
	commit;
end Query17C01Place;
/
