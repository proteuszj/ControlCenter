create or replace procedure Query17C05School
(
	xh in varchar2,			--���  char	8	���ɿ�
	jxmc in varchar2,		--��У����    Varchar2	256	�ɿ�
	jxjc in varchar2,		--��У��� Varchar2	64	���ɿ�
	jxdm in varchar2,		--��У���� Varchar2	64	���ɿ�
	jxdz in varchar2,		--��У��ַ Varchar2	256	���ɿ�
	lxdh in varchar2,		--��ϵ�绰 Varchar2	20	���ɿ�
	lxr in varchar2,		--��ϵ�� Varchar2	30	���ɿ�
	frdb in varchar2,		--���˴��� Varchar2	30	���ɿ�
	zczj in number,			--ע���ʽ� number      �ɿ�
	jxjb in varchar2,		--��У���� Char	1	���ɿ�	1һ����2������3������0����
	kpxcx in varchar2,		--��ѵ׼�ݳ��� Varchar2	30	�ɿ�
	fzjg in varchar2,		--������֤���� Varchar2	10	�ɿ�
	jxzt in varchar2,		--��У״̬ Char	1	�ɿ� A������B��ͣ����Cȡ���ʸ�
	shr in varchar2,		--����� Varchar2	30	���ɿ�
	cjsj in varchar2,		--����ʱ�� Date        ���ɿ� yyyymmddhh24miss
	gxsj in varchar2		--����ʱ�� Date        ���ɿ� yyyymmddhh24miss
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
