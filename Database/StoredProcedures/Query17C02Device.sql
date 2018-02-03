create or replace procedure Query17C02Device
(
	xh in varchar2,			--���  char	8	���ɿ�
	sbbh in varchar2,		--�豸��� Varchar2	10	���ɿ�
	sbms in varchar2,		--�豸���� Varchar2	512	���ɿ�
	zzcs in varchar2,		--���쳧�� Varchar2	512	���ɿ�
	sbxh in varchar2,		--�豸�ͺ� Varchar2	512	���ɿ�
	ksxm in varchar2,		--������Ŀ Char	5	���ɿ�
	ksxmsm in varchar2,		--������Ŀ˵�� Varchar2	256	���ɿ�
	ppfs in varchar2,		--���з�ʽ Char	1	���ɿ�	0������Զ����У�1�˹�����
	kcxh in varchar2,		--������� char	8	���ɿ�
	syzjcx in varchar2,		--����׼�ݳ��ͷ�Χ Varchar2	30	���ɿ�
	ysrq in varchar2,		--�������� Date        ���ɿ� yyyymmdd
	badckssj number,		--�������ο���ʱ�� Number      ���ɿ� ��λΪmin
	bamxsksrs number,		--����ÿСʱ�����˴�   Number ���ɿ�
	jyyxqz in varchar2,		--������Ч��ֹ  Date ���ɿ� yyyymmdd
	syzt in varchar2,		--ʹ��״̬ Char        ���ɿ� A������B���ϣ�C��ͣ���ԣ�D����
	cjsj in varchar2,		--����ʱ�� Date        ���ɿ� yyyymmddhh24miss
	gxsj in varchar2		--�������� Date        ���ɿ� yyyymmddhh24miss
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
