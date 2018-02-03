create or replace function GenerateSUB2
(
  message out varchar2,
  operatorLoginName in varchar2,
  examID in BUZ_EXAM_INFO.ID%TYPE,
  hostIP in varchar2,					--host ip
  hostMAC in varchar2					--host mac
)return number as
  n number;
  aSubject BAS_BOOKING.SUBJECT%TYPE;
  aExamNumber BAS_BOOKING.EXAMNUMBER%TYPE;
  aIdType BAS_STUDENT.IDTYPE%TYPE;
  aIdNumber BAS_STUDENT.IDNUMBER%TYPE;
  aName BAS_STUDENT.NAME%TYPE;
  aExamReason BAS_BOOKING.EXAM_REASON%TYPE;
  aDriverLicenseType BAS_BOOKING.DRIVER_LICENSE_TYPE%TYPE;
  aPlaceCode BAS_PLACE.CODE%TYPE;
  aExamSession BAS_BOOKING.EXAM_SESSION%TYPE;
  aLicensePlate BAS_CAR.LICENSE_PLATE%TYPE;
  aOperatorName BAS_BOOKING.OPERATOR_NAME%TYPE;
  aBranchAdministration BAS_BOOKING.BRANCH_ADMINISTRATION%TYPE;
  aSchoolCode BAS_DRIVING_SCHOOL.CODE%TYPE;
  aSchoolName BAS_DRIVING_SCHOOL.NAME%TYPE;
  aExamTimes BAS_BOOKING.EXAM_TIMES%TYPE;
  aExaminer1 BAS_EXAMINER.NAME%TYPE;
  aExaminer2 BAS_EXAMINER.NAME%TYPE;
  aScore BUZ_EXAM_INFO.CURRENT_EXAM_SCORE%TYPE;
  aExamStartTime BUZ_EXAM_INFO.EXAM_START_TIME%TYPE;
  aExamEndTime BUZ_EXAM_INFO.EXAM_END_TIME%TYPE;
  score_ZH_10xxx number;
  score_DK_201xx number;
  scroe_PQ_203xx number;
  score_CF_204xx number;
  score_QX_206xx number;
  score_ZJ_207xx number;
  aCarSequenceNumber BAS_CAR.SEQUENCENUMBER%TYPE;
  aExamStatus BUZ_EXAM_INFO.EXAM_STATUS%TYPE;
  
  aBookID BAS_BOOKING.ID%TYPE;
  aCarID BAS_CAR.ID%TYPE;
  aStudentID BAS_STUDENT.ID%TYPE;
  aPlaceID BAS_PLACE.ID%TYPE;
  aExaminer1ID BAS_EXAMINER.ID%TYPE;
  aExaminer2ID BAS_EXAMINER.ID%TYPE;
  aSchoolID BAS_DRIVING_SCHOOL.ID%TYPE;
begin
  select count(*) into n from BUZ_EXAM_INFO where ID=examID;
  if n<=0 then
	message:='考试信息不存在，ID：'||examID;
	AddLog(operatorLoginName, '考试管理', '增加', message, 0, hostIP, hostMAC);
	return -1;
  end if;
  
  select BOOKING_ID, CURRENT_EXAM_SCORE, EXAM_START_TIME, EXAM_END_TIME, EXAM_STATUS
  into aBookID, aScore, aExamStartTime, aExamEndTime, aExamStatus
  from BUZ_EXAM_INFO
  where ID=examID;
  
  select STUDENT_ID, PLACE_ID, CAR_ID, EXAMINER1_ID, EXAMINER2_ID, SCHOOL_ID, SUBJECT, EXAMNUMBER, EXAM_REASON, DRIVER_LICENSE_TYPE, EXAM_SESSION, OPERATOR_NAME, BRANCH_ADMINISTRATION, EXAM_TIMES
  into aStudentID, aPlaceID, aCarID, aExaminer1ID, aExaminer2ID, aSchoolID, aSubject, aExamNumber, aExamReason, aDriverLicenseType, aExamSession, aOperatorName, aBranchAdministration, aExamTimes
  from BAS_BOOKING
  where ID=aBookID;
  
  select IDTYPE, IDNUMBER, NAME
  into aIdType, aIdNumber, aName
  from BAS_STUDENT
  where ID=aStudentID;
  
  select CODE 
  into aPlaceCode
  from BAS_PLACE
  where ID=aPlaceID;
  
  select LICENSE_PLATE, SEQUENCENUMBER
  into aLicensePlate, aCarSequenceNumber
  from BAS_CAR
  where ID=aCarID;
  
  if aSchoolID is not null then
	  select CODE, NAME
	  into aSchoolCode, aSchoolName
	  from BAS_DRIVING_SCHOOL
	  where ID=aSchoolID;
  end if;
  
  if aExaminer1ID is not null then
	select NAME into aExaminer1 from BAS_EXAMINER where ID=aExaminer1ID;
  end if;
  
  if aExaminer2ID is not null then
	select Name into aExaminer2 from BAS_EXAMINER where ID=aExaminer2ID; 
  end if;
  
  select count(*) into n from BUZ_SUB2_RECORD where JTGLYWDXSFZMHM=aIdNumber and KSZT=aExamStatus;
  if n>0 then
	message:='考试记录已存在，身份证明号码：'||aIdNumber||' 考试状态：'||aExamStatus;
	AddLog(operatorLoginName, '考试管理', '增加', message, 0, hostIP, hostMAC);
	return -2;
  end if;
  
  insert into BUZ_SUB2_RECORD(
	ID,
	JDCJSZKSKMDM,
	JDCJSJNZKZMBH,
--	XXJSZMBH,
	JTGLYWDXSFZMDM,
	JTGLYWDXSFZMHM,
	XM,
	KSYY,
	JDCJSZZJCXDM,
	JDCJSZKSKCDM,
	KSCCBH,
	JDCHPHM,
	JBR,
	GLBM,
	DLR,
	JDCJSRPXXXDM,
	KSCS,
	CZY,
	KSY1,
	KSY2,
	KSCJ,
	KSQSSJ,
	KSJSSJ,
--	XKXM,
	ZHPPKF,
	ZKKF,
	PDDDKF,
	CFTCKF,
--	DBQKF,
	QXXSKF,
	ZJZWKF,
--	XKMKF,
--	LXZAKF,
--	QFLKF,
--	ZLDTKF,
--	GSKF,
--	LXJWKF,
--	SDKF,
--	YWKF,
--	SHKF,
--	JJQKF,
--	ZXXM1,
--	ZXXM2,
--	ZXXM3,
--	ZXXM1KF,
--	ZXXM2KF,
--	ZXXM3KF,
	JYW,
	KSCXH,
	KSZT)
  values(
	SEQU_BUZ_SUB2_RECORD_ID.nextval,aSubject,aExamNumber,aIdType,aIdNumber,aName,aExamReason,aDriverLicenseType,aPlaceCode,aExamSession,aLicensePlate,aOperatorName,
    aBranchAdministration,aSchoolCode,aSchoolName,aExamTimes,operatorLoginName,aExaminer1,aExaminer2,aScore,aExamStartTime,aExamEndTime,
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,2)='10'),
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,3)='201'),
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,3)='203'),
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,3)='204'),
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,3)='206'),
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,3)='207'),
	GenerateSHA1(aSubject||aExamNumber||aIdType||aIdNumber||aName||aExamReason||aDriverLicenseType||aPlaceCode||aExamSession||aLicensePlate||aOperatorName||
    aBranchAdministration||aSchoolCode||aSchoolName||aExamTimes||operatorLoginName||aExaminer1||aExaminer2||aScore||aExamStartTime||aExamEndTime||
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,2)='10')||
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,3)='201')||
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,3)='203')||
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,3)='204')||
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,3)='206')||
	(select sum(DEDUCT_SCORE) from BUZ_EXAM_PROCESS where EXAM_ID=examID and substr(DEDUCT_ITEM,1,3)='207')||
    aCarSequenceNumber||aExamStatus),
	aCarSequenceNumber,
	aExamStatus);
  message:='考试记录插入成功，身份证明号码：'||aIdNumber||' 考试状态：'||aExamStatus;
  AddLog(operatorLoginName, '考试管理', '增加', message, 1, hostIP, hostMAC);
  return 0;
end;
/
