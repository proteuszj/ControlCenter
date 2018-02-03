create or replace procedure Query17C03Car
(
	xh in varchar2,			--���  char	8	���ɿ�
	jbr in varchar2,		--������ Varchar2	30	���ɿ�
	shr in varchar2,		--����� Varchar2	30	���ɿ�
	hpzl in varchar2,		--��������    CHAR	2
	zt in varchar2,			--����״̬
	ksczt in varchar2,		--���Գ�״̬��ʹ��״̬��  ���ɿգ�A������B��ͣ���ԣ�Cȡ������
	cllx in varchar2,		--��������
	shsj in varchar2,		--??        Date        ���ɿ� yyyymmddhh24miss
	clpp in varchar2,		--����Ʒ��
	ccdjrq in varchar2,		--���εǼ�����        Date       yyyymmdd
	qzbfqz in varchar2,		--ǿ�Ʊ�����ֹ Date       yyyymmdd
	fzjg in varchar2,		--��֤����    Varchar2	10	���ɿ�
	hphm in varchar2,		--���ƺ���    VARCHAR2	15
	syzjcx in varchar2,		--����׼�ݳ��ͷ�Χ    Varchar2	30	���ɿ�
	ipdz in varchar2,		--IP��ַ
	cjsj in varchar2,		--����ʱ��    Date ���ɿ� yyyymmddhh24miss
	gxsj in varchar2		--�������� Date        ���ɿ� yyyymmddhh24miss
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
