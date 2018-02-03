create or replace function AddUpdatePricingStrategy
(
	message out varchar2,
	operatorLoginName in varchar2,
	hostIP in varchar2,
	hostMAC in varchar2,
	pricingPriority in CFG_PRICING_STRATEGY.PRIORITY%TYPE,
	pricingActionName in CFG_DICT.DICT_NAME%TYPE,
	pricingAmount in CFG_PRICING_STRATEGY.AMOUNT%TYPE,
	effectiveDate in CFG_PRICING_STRATEGY.EFFECTIVE_DATE%TYPE,
	expiredDate in CFG_PRICING_STRATEGY.EXPIRED_DATE%TYPE,
	startDate in CFG_PRICING_STRATEGY.START_DATE%TYPE,
	endDate in CFG_PRICING_STRATEGY.END_DATE%TYPE,
	startTime in CFG_PRICING_STRATEGY.START_TIME%TYPE,
	endTime in CFG_PRICING_STRATEGY.END_TIME%TYPE,
	schoolName in CFG_PRICING_STRATEGY.SCHOOL_NAME%TYPE,
	studentIDNumber in CFG_PRICING_STRATEGY.STUDENT_IDNUMBER%TYPE,
	methodName1 in CFG_PRICING_STRATEGY.REFERENCE_METHOD1%TYPE,
	amount1 in CFG_PRICING_STRATEGY.REFERENCE_AMOUNT1%TYPE,
	relation in CFG_PRICING_STRATEGY.REFERENCE_RELATION%TYPE,
	methodName2 in CFG_PRICING_STRATEGY.REFERENCE_METHOD2%TYPE,
	amount2 in CFG_PRICING_STRATEGY.REFERENCE_AMOUNT2%TYPE
) return integer as
	n integer;
	pricingAction CFG_PRICING_STRATEGY.ACTION%TYPE;
	method1 CFG_PRICING_STRATEGY.REFERENCE_METHOD1%TYPE;
	relationCode CFG_PRICING_STRATEGY.REFERENCE_RELATION%TYPE;
	method2 CFG_PRICING_STRATEGY.REFERENCE_METHOD2%TYPE;
begin
	select count(*) into n from CFG_DICT where DICT_TYPE=1037 and DICT_NAME=pricingActionName;
	if n=0 then
		message:='DICT_NAME '||pricingActionName||' not found in DICT_TYPE=1037';
		AddLog(operatorLoginName, '支付管理', '修改', message, 0, hostIP, hostMAC);
		return -1;
	else
		select DICT_CODE into pricingAction from CFG_DICT where DICT_TYPE=1037 and DICT_NAME=pricingActionName;
	end if;
	
	select count(*) into n from CFG_DICT where DICT_TYPE=1038 and DICT_NAME=methodName1;
	if n=0 then
		method1:=null;
	else
		select DICT_CODE into method1 from CFG_DICT where DICT_TYPE=1038 and DICT_NAME=methodName1;
	end if;
	
	relationCode:=case relation when '并且' then '&&' when '或者' then '||' else null end;
	
	select count(*) into n from CFG_DICT where DICT_TYPE=1038 and DICT_NAME=methodName2;
	if n=0 then
		method2:=null;
	else
		select DICT_CODE into method2 from CFG_DICT where DICT_TYPE=1038 and DICT_NAME=methodName2;
	end if;

	select count(*) into n from CFG_PRICING_STRATEGY where
		((effectiveDate='' or effectiveDate is null) and EFFECTIVE_DATE is null or EFFECTIVE_DATE=effectiveDate) and
		((expiredDate='' or expiredDate is null) and EXPIRED_DATE is null or EXPIRED_DATE=expiredDate) and
		((startDate='' or startDate is null) and START_DATE is null or START_DATE=startDate) and
		((endDate='' or endDate is null) and END_DATE is null or END_DATE=endDate) and
		((startTime='' or startTime is null) and START_TIME is null or START_TIME=startTime) and
		((endTime='' or endTime is null) and END_TIME is null or END_TIME=endTime) and
		((schoolName='' or schoolName is null) and SCHOOL_NAME is null or SCHOOL_NAME=schoolName) and
		((studentIDNumber='' or studentIDNumber is null) and STUDENT_IDNUMBER is null or STUDENT_IDNUMBER=studentIDNumber) and
		(method1 is null and REFERENCE_METHOD1 is null or REFERENCE_METHOD1=method1) and
		((amount1='' or amount1 is null) and REFERENCE_AMOUNT1 is null or REFERENCE_AMOUNT1=amount1) and
		((relationCode='' or relationCode is null) and REFERENCE_RELATION is null or REFERENCE_RELATION=relationCode) and
		(method2 is null and REFERENCE_METHOD2 is null or REFERENCE_METHOD2=method2) and
		((amount2='' or amount2 is null) and REFERENCE_AMOUNT2 is null or REFERENCE_AMOUNT2=amount2);
	message:='priority: '||pricingPriority||' '||pricingAction||' '||pricingAmount
		||' effect on: '||case when effectiveDate is null then 'now' else effectiveDate end
		||' to '||case when expiredDate is null then 'forever' else expiredDate end
		||case when method1 is null then '' else ' when '||method1||amount1||case when method2 is null then '' else relationCode||method2||amount2 end end
		||' at '||case when startTime is null then '000000' else startTime end
		||'-'||case when endTime is null then '235959' else endTime end
		||' from '||case when startDate is null then 'now' else startDate end
		||' to '||case when endDate is null then 'forever' else endDate end
		||case when schoolName is null then '' else ' for school: '||schoolName end
		||case when studentIDNumber is null then '' else ' for student: '||studentIDNumber end;
	if n>0 then--update
		update CFG_PRICING_STRATEGY
		set
			PRIORITY=pricingPriority,
			ACTION=pricingAction,
			AMOUNT=pricingAmount
		where
			((effectiveDate='' or effectiveDate is null) and EFFECTIVE_DATE is null or EFFECTIVE_DATE=effectiveDate) and
			((expiredDate='' or expiredDate is null) and EXPIRED_DATE is null or EXPIRED_DATE=expiredDate) and
			((startDate='' or startDate is null) and START_DATE is null or START_DATE=startDate) and
			((endDate='' or endDate is null) and END_DATE is null or END_DATE=endDate) and
			((startTime='' or startTime is null) and START_TIME is null or START_TIME=startTime) and
			((endTime='' or endTime is null) and END_TIME is null or END_TIME=endTime) and
			((schoolName='' or schoolName is null) and SCHOOL_NAME is null or SCHOOL_NAME=schoolName) and
			((studentIDNumber='' or studentIDNumber is null) and STUDENT_IDNUMBER is null or STUDENT_IDNUMBER=studentIDNumber) and
			(method1 is null and REFERENCE_METHOD1 is null or REFERENCE_METHOD1=method1) and
			((amount1='' or amount1 is null) and REFERENCE_AMOUNT1 is null or REFERENCE_AMOUNT1=amount1) and
			((relationCode='' or relationCode is null) and REFERENCE_RELATION is null or REFERENCE_RELATION=relationCode) and
			(method2 is null and REFERENCE_METHOD2 is null or REFERENCE_METHOD2=method2) and
			((amount2='' or amount2 is null) and REFERENCE_AMOUNT2 is null or REFERENCE_AMOUNT2=amount2);
		AddLog(operatorLoginName, '支付管理', '修改', message, 1, hostIP, hostMAC);
		return 0;
	else
		insert into CFG_PRICING_STRATEGY(
			ID,
			PRIORITY,
			ACTION,
			AMOUNT,
			EFFECTIVE_DATE,
			EXPIRED_DATE,
			START_DATE,
			END_DATE,
			START_TIME,
			END_TIME,
			SCHOOL_NAME,
			STUDENT_IDNUMBER,
			REFERENCE_METHOD1,
			REFERENCE_AMOUNT1,
			REFERENCE_RELATION,
			REFERENCE_METHOD2,
			REFERENCE_AMOUNT2)
		values(
			SEQU_CFG_PRICING_STRATEGY_ID.nextval,
			pricingPriority,
			pricingAction,
			pricingAmount,
			effectiveDate,
			expiredDate,
			startDate,
			endDate,
			startTime,
			endTime,
			schoolName,
			studentIDNumber,
			method1,
			amount1,
			relationCode,
			method2,
			amount2);
		AddLog(operatorLoginName, '支付管理', '增加', message, 1, hostIP, hostMAC);
		return 0;
	end if;
end AddUpdatePricingStrategy;
/
