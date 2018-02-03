create or replace function BookFromVehicle
(
	message out varchar2,
	bookingID out BAS_BOOKING.ID%TYPE,
	operatorIDNumber in varchar2,
	operatorPasswordSha1 in varchar2,
	studentIDNumber in BAS_STUDENT.IDNUMBER%TYPE,
	subjectName in varchar2,
	times in integer,
	amount in number,
	paymentWay in CFG_DICT.DICT_NAME%TYPE,
	hostIP in varchar2,					--host ip
	hostMAC in varchar2					--host mac
) return integer as
	n integer;
	operatorLoginName SYS_USER.LOGIN_NAME%TYPE;
	operatorPassword SYS_USER.PASSWORD%TYPE;
	operatorName SYS_USER.USER_NAME%TYPE;
	studentID BAS_STUDENT.ID%TYPE;
	licenseType BAS_STUDENT.DRIVER_LICENSE_TYPE%TYPE;
	schoolName BAS_DRIVING_SCHOOL.NAME%TYPE;
	currentDate BAS_BOOKING.BOOKING_DATETIME%TYPE;
	tradeNumber BUZ_PAYMENT_DETAIL.TRADE_NO%TYPE;
begin
	select count(*) into n from SYS_USER where IDNUMBER=operatorIDNumber;
	if n=0 then
		message:='����Ա��'||operatorIDNumber||'������';
		AddLog('', 'ѧԱ����', 'ԤԼ', message, 0, hostIP, hostMAC);
		return -1;
	end if;
	
	select LOGIN_NAME, PASSWORD, USER_NAME into operatorLoginName, operatorPassword, operatorName from SYS_USER where IDNUMBER=operatorIDNumber;
	if operatorPasswordSha1 is not null and length(operatorPasswordSha1) is not null and operatorPassword <> DESEncrypt(operatorPasswordSha1||operatorLoginName||operatorName||operatorIDNumber) then
		message:='���벻��ȷ';
		AddLog(operatorLoginName, 'ѧԱ����', 'ԤԼ', message, 0, hostIP, hostMAC);
		return -2;
	end if;

	select count(*) into n from BAS_STUDENT where IDNUMBER=studentIDNumber;
	if n=0 then
		message:='ѧԱ��'||studentIDNumber||'������';
		AddLog(operatorLoginName, 'ѧԱ����', 'ԤԼ', message, 0, hostIP, hostMAC);
		return -3;
	end if;
	select ID, DRIVER_LICENSE_TYPE, SCHOOL_NAME into studentID, licenseType, schoolName from BAS_STUDENT where IDNUMBER=studentIDNumber;
	if amount<>GetPriceByTimes(message, times, to_char(current_date, 'yyyymmddhh24miss'), schoolName, studentIDNumber) then
		message:='����ȷ';
		AddLog(operatorLoginName, 'ѧԱ����', 'ԤԼ', message, 0, hostIP, hostMAC);
		return -4;
	end if;

	bookingID:=SEQU_BAS_BOOKING_ID.nextval;
	currentDate:=to_char(current_date, 'yyyymmddhh24miss');
	insert into BAS_BOOKING(
		ID,
		SEQUENCENUMBER,
		SUBJECT,
		EXAMNUMBER,
		STUDENT_ID,
		BOOKING_DATETIME,
		BOOKING_TIMES,
		BOOKING_EXAM_DATE,
		DRIVER_LICENSE_TYPE,
		PLACE_ID,
		OPERATOR_NAME,
		BRANCH_ADMINISTRATION,
		SCHOOL_ID,
		BRANCH_BUSINESS,
		SIGN_STATUS)
	values(
		bookingID,
		NewBookSequenceNumber,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName),
		NewExamNumber,
		studentID,
		currentDate,
		times,
		substr(currentDate, 1, 8),
		licenseType,
		(select max(ID) from BAS_PLACE),
		operatorLoginName,
		'����',
		(select ID from BAS_DRIVING_SCHOOL where NAME=schoolName),
		'ҵ��',
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1031 and DICT_NAME='��ǩ��'));

	tradeNumber:=NewTradeNumber;
	insert into BUZ_PAYMENT_DETAIL(
		ID,
		TRADE_NO,
		PAY_TIME,
		OPERATOR_NAME,
		OPERATOR_IDNUMBER,
		STUDENT_IDNUMBER,
		SUBJECT,
		FEE_TYPE,
		TIMES,
		AMOUNT,
		PAYMENT_WAY,
		BOOKING_ID,
		PRICING_STRATEGY,
		HASH)
	values(
		SEQU_BUZ_PAYMENT_DETAIL_ID.nextval,
		tradeNumber,
		currentDate,
		operatorName,
		operatorIDNumber,
		studentIDNumber,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName),
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1002 and DICT_NAME='�ƴ�'),
		times,
		amount,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1001 and DICT_NAME=paymentWay),
		bookingID,
		message,
		GenerateSHA1(tradeNumber||currentDate||operatorName||operatorIDNumber||studentIDNumber||times||amount||bookingID||message));

	commit;
	message:='������ţ�'||tradeNumber||chr(13)||chr(10)
		||'����ʱ�䣺'||currentDate||chr(13)||chr(10)
		||'����Ա������'||operatorName||chr(13)||chr(10)
		||'����Ա���֤�ţ�'||operatorIDNumber||chr(13)||chr(10)
		||'ѧԱ���֤�ţ�'||studentIDNumber||chr(13)||chr(10)
		||'������'||times||chr(13)||chr(10)
		||'��'||amount||chr(13)||chr(10);
	AddLog(operatorLoginName, 'ѧԱ����', 'ԤԼ', message, 1, hostIP, hostMAC);
	return 0;
end BookFromVehicle;
/
