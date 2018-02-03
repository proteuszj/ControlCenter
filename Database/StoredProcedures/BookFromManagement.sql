create or replace function BookFromManagement
(
	message out varchar2,
	operatorLoginName in varchar2,
	studentIDNumber in BAS_STUDENT.IDNUMBER%TYPE,
	subjectName in varchar2,
	times in integer,
	amount in number,
	paymentWay in CFG_DICT.DICT_NAME%TYPE,
	bookingDatetime in BAS_BOOKING.BOOKING_DATETIME%TYPE,
	carLicensePlate in BAS_CAR.LICENSE_PLATE%TYPE,
	cashierName in varchar2,
	cashierIDNumber in varchar2,
	hostIP in varchar2,					--host ip
	hostMAC in varchar2					--host mac
) return integer as
	n integer;
	studentID BAS_STUDENT.ID%TYPE;
	licenseType BAS_STUDENT.DRIVER_LICENSE_TYPE%TYPE;
	schoolName BAS_DRIVING_SCHOOL.NAME%TYPE;
	carID BAS_CAR.ID%TYPE;
	bookingID BAS_BOOKING.ID%TYPE;
	tradeNumber BUZ_PAYMENT_DETAIL.TRADE_NO%TYPE;
	currentDate BAS_BOOKING.BOOKING_DATETIME%TYPE;
begin
	select count(*) into n from SYS_USER where LOGIN_NAME=operatorLoginName;
	if n=0 then
		message:='����Ա��'||operatorLoginName||'������';
		AddLog(operatorLoginName, 'ѧԱ����', 'ԤԼ', message, 0, hostIP, hostMAC);
		return -1;
	end if;

	select count(*) into n from BAS_STUDENT where IDNUMBER=studentIDNumber;
	if n=0 then
		message:='ѧԱ��'||studentIDNumber||'������';
		AddLog(operatorLoginName, 'ѧԱ����', 'ԤԼ', message, 0, hostIP, hostMAC);
		return -2;
	end if;
	select ID, DRIVER_LICENSE_TYPE, SCHOOL_NAME into studentID, licenseType, schoolName from BAS_STUDENT where IDNUMBER=studentIDNumber;

	if amount<>GetPriceByTimes(message, times, bookingDatetime, schoolName, studentIDNumber) then
		message:='����ȷ';
		AddLog(operatorLoginName, 'ѧԱ����', 'ԤԼ', message, 0, hostIP, hostMAC);
		return -3;
	end if;

	if carLicensePlate is not null and length(carLicensePlate)>0 then
		select count(*) into n from BAS_CAR where LICENSE_PLATE=carLicensePlate;
		if n=0 then
			message:='������'||carLicensePlate||'������';
			AddLog(operatorLoginName, 'ѧԱ����', 'ԤԼ', message, 0, hostIP, hostMAC);
			return -4;
		end if;
		select ID into carID from BAS_CAR where LICENSE_PLATE=carLicensePlate;
	end if;

	select count(*) into n from BAS_BOOKING where STUDENT_ID=studentID and BOOKING_EXAM_DATE=substr(bookingDatetime, 1, 8) and not exists((select * from buz_exam_info where BOOKING_ID=BAS_BOOKING.ID));
	if n>0 then
		message:='ԤԼʧ�ܣ���δʹ�õ�ԤԼ';
		AddLog(operatorLoginName, 'ѧԱ����', 'ԤԼ', message, 0, hostIP, hostMAC);
		return -5;
	end if;

	bookingID:=SEQU_BAS_BOOKING_ID.nextval;
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
		CAR_ID,
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
		bookingDatetime,
		times,
		substr(bookingDatetime, 1, 8),
		licenseType,
		(select max(ID) from BAS_PLACE),
		carID,
		operatorLoginName,
		'����',
		(select ID from BAS_DRIVING_SCHOOL where NAME=schoolName),
		'ҵ��',
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1031 and DICT_NAME='��ǩ��'));

	tradeNumber:=NewTradeNumber;
	currentDate:=to_char(current_date, 'yyyymmddhh24miss');
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
		cashierName,
		cashierIDNumber,
		studentIDNumber,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName),
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1002 and DICT_NAME='�ƴ�'),
		times,
		amount,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1001 and DICT_NAME=paymentWay),
		bookingID,
		message,
		GenerateSHA1(tradeNumber||currentDate||cashierName||cashierIDNumber||studentIDNumber||times||amount||bookingID||message));

	commit;
	message:='������ţ�'||tradeNumber||chr(13)||chr(10)
		||'����ʱ�䣺'||currentDate||chr(13)||chr(10)
		||'����Ա������'||cashierName||chr(13)||chr(10)
		||'����Ա���֤�ţ�'||cashierIDNumber||chr(13)||chr(10)
		||'ѧԱ���֤�ţ�'||studentIDNumber||chr(13)||chr(10)
		||'������'||times||chr(13)||chr(10)
		||'��'||amount||chr(13)||chr(10);
	AddLog(operatorLoginName, 'ѧԱ����', 'ԤԼ', message, 1, hostIP, hostMAC);
	return 0;
end BookFromManagement;
/
