create or replace procedure AddUpdateStudent
(
  message out varchar2,
  operatorLoginName in varchar2,
  idNo in varchar2,
  idTypeName in varchar2,
  studentName in varchar2,
  studentGender in varchar2,
  driverLicenseType in varchar2,
  schoolName in varchar2,
  pwd in varchar2,
  photoA in blob,
  photoB in blob,
  fingerPrintA in clob,
  fingerPrintB in clob,
  fingerPrintC in clob,
  fingerPrintD in clob
) as
  n number;
  newIDType BAS_STUDENT.IDTYPE%TYPE;
  newName BAS_STUDENT.NAME%TYPE;
  newGender BAS_STUDENT.GENDER%TYPE;
  newDriverLicenseType BAS_STUDENT.DRIVER_LICENSE_TYPE%TYPE;
  newSchoolName BAS_STUDENT.SCHOOL_NAME%TYPE;  
begin
  select count(*) into n from BAS_DRIVING_SCHOOL where NAME=schoolName;
  if n=0 then
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
		GRADE,
		AUDITOR,
		CREATE_TIME,
		UPDATE_TIME)
	values(
		SEQU_BAS_DRIVING_SCHOOL_ID.nextval,
		NewSchoolSequenceNumber,
		NewSchoolCode,
		schoolName,
		schoolName,
		'地址',
		'联系地址',
		'联系人',
		'法人代表',
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1020 and DICT_NAME='其他'),
		'审核人',
		to_char(current_date, 'yymmddhh24miss'),
		to_char(current_date, 'yymmddhh24miss'));
  end if;

  select count(*) into n from BAS_STUDENT where IDNUMBER=idNo;
  if (n>0) then
	select IDTYPE, NAME, GENDER, DRIVER_LICENSE_TYPE, SCHOOL_NAME into newIDType, newName, newGender, newDriverLicenseType, newSchoolName from BAS_STUDENT where IDNUMBER=idNo;
	if idTypeName is not null then select DICT_CODE into newIDType from CFG_DICT where DICT_TYPE=2002 and DICT_NAME=idTypeName; end if;
	if studentName is not null then newName:=studentName; end if;
	if studentGender is not null then select DICT_CODE into newGender from CFG_DICT where DICT_TYPE=2001 and DICT_NAME=studentGender; end if;
	if driverLicenseType is not null then newDriverLicenseType:=driverLicenseType; end if;
	if schoolName is not null then newSchoolName:=schoolName; end if;
	update BAS_STUDENT set IDTYPE=newIDType, NAME=newName, GENDER=newGender, DRIVER_LICENSE_TYPE=newDriverLicenseType, SCHOOL_NAME=newSchoolName, PASSWORD=pwd, UPDATE_TIME=to_char(current_date, 'yyyymmddhh24miss') where IDNUMBER=idNo;
	if photoA is not null then update BAS_STUDENT set PHOTO1=photoA where IDNUMBER=idNo; end if;
	if photoB is not null then update BAS_STUDENT set PHOTO2=photoB where IDNUMBER=idNo; end if;
	if fingerPrintA is not null then update BAS_STUDENT set FINGERPRINT1=fingerPrintA where IDNUMBER=idNo; end if;
	if fingerPrintB is not null then update BAS_STUDENT set FINGERPRINT2=fingerPrintB where IDNUMBER=idNo; end if;
	if fingerPrintC is not null then update BAS_STUDENT set FINGERPRINT3=fingerPrintC where IDNUMBER=idNo; end if;
	if fingerPrintD is not null then update BAS_STUDENT set FINGERPRINT4=fingerPrintD where IDNUMBER=idNo; end if;
	message:=newName||idNo;
	AddLog(operatorLoginName, '学员管理', '修改', message, 1, null, null);
	commit;
  else
    insert into BAS_STUDENT(
	  ID,
	  IDTYPE,
	  IDNUMBER,
	  NAME,
	  GENDER,
	  DRIVER_LICENSE_TYPE,
	  SCHOOL_NAME,
	  PASSWORD,
	  PHOTO1,
	  PHOTO2,
	  FINGERPRINT1,
	  FINGERPRINT2,
	  FINGERPRINT3,
	  FINGERPRINT4,
	  CREATE_TIME,
	  UPDATE_TIME)
	values(
	  SEQU_BAS_STUDENT_ID.nextval,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2002 and DICT_NAME=idTypeName),
	  idNo,
	  studentName,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2001 and DICT_NAME=studentGender),
	  driverLicenseType,
	  schoolName,	  
	  pwd,
	  photoA,
	  photoB,
	  fingerPrintA,
	  fingerPrintB,
	  fingerPrintC,
	  fingerPrintD,
	  to_char(current_date, 'yyyymmddhh24miss'),
	  to_char(current_date, 'yyyymmddhh24miss'));
	message:=studentName||idNo;
	AddLog(operatorLoginName, '学员管理', '增加', message, 1, null, null);
	commit;
  end if;
end AddUpdateStudent;
/
