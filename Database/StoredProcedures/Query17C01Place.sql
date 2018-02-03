create or replace procedure Query17C01Place
(
	xh in varchar2,			--���  Char	8	���ɿ�
	fzjg in varchar2,		--��֤���� Varchar2	10	���ɿ�
	glbm in varchar2,		--������ Varchar2	12	���ɿ�
	kskm in varchar2,		--���Կ�Ŀ Char	1	���ɿ� ͬ��
	kcmc in varchar2,		--��������    Varchar2	128	���ɿ�
	kcdddh in varchar2,		--�������� Varchar2	64	���ɿ�
	kkcx in varchar2,		--����׼�ݳ��ͷ�Χ Varchar2	24	���ɿ�
	ywlx in varchar2,		--����ҵ�����ͷ�Χ Varchar2	10	�ɿ�
	zdysrq in varchar2,		--�ܶ��������� Date        ���ɿ� yyyymmdd
	ysr in varchar2,		--������ Varchar2	32	���ɿ�
	kmeyyms in varchar2,	--��Ŀ��ԤԼģʽ Char	1	���ɿ�	1һ��ԤԼ��2����ԤԼ
	fzms in varchar2,		--����ģʽ Char	1	���ɿ�	1��ѧԱ��2��������
	kmeksrsxz number,		--������������ Number      ���ɿ�
	kmezkrsxz number,		--��Ŀ��׮���������� Number      ���ɿ�
	kmeckrsxz number,		--��Ŀ�������������� Number      ���ɿ�
	zksfdz in varchar2,		--׮�����з�ʽ Char	1	���ɿ�	1������Զ����У�0�˹�����
	cksfdz in varchar2,		--�������з�ʽ Char	1	���ɿ�	1������Զ����У�0�˹�����
	zklwrq in varchar2,		--׮����ʼ����ʱ�� Date        �ɿ� yyyymmddhh24miss
	cklwrq in varchar2,		--������ʼ����ʱ�� Date        �ɿ� yyyymmddhh24miss
	kczt in varchar2,		--ʹ��״̬ Char	1	���ɿ� A������B��ͣ���ԣ�Cȡ������
	zksbs number,			--׮���豸�� Number      ���ɿ�
	cksbs number,			--�����豸�� Number      ���ɿ�
	cjsj in varchar2,		--�������� Date        ���ɿ� yyyymmddhh24miss
	gxsj in varchar2		--�������� Date        ���ɿ� yyyymmddhh24miss
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
