create or replace procedure AddUpdateExaminer
(
  message out varchar2,
  operatorLoginName in varchar2,
  idNo in varchar2,
  idTypeName in varchar2,
  examinerName in varchar2,
  examinerGender in varchar2,
  birth in varchar2,
  issuingAuthority in varchar2,
  issuingDate in varchar2,
  expireDate in varchar2,
  office in varchar2,
  operatorName in varchar2,
  issuingOffice in varchar2
) as
  n number;
  newIDType BAS_EXAMINER.IDTYPE%TYPE;
  newName BAS_EXAMINER.NAME%TYPE;
  newGender BAS_EXAMINER.GENDER%TYPE;
  newBirth BAS_EXAMINER.BIRTH_DATE%TYPE;
  newIssuingAuthority BAS_EXAMINER.ISSUING_AUTHORITY%TYPE;
  newIssuingDate BAS_EXAMINER.ISSUING_DATE%TYPE;
  newExpireDate BAS_EXAMINER.EXPIRE_DATE%TYPE;
  newOffice BAS_EXAMINER.WORK_OFFICE%TYPE;
  newOperatorName BAS_EXAMINER.OPERATOR_NAME%TYPE;
  newIssuingOffice BAS_EXAMINER.ISSUING_OFFICE%TYPE;
begin
  select count(*) into n from BAS_EXAMINER where IDNUMBER=idNo;
  if (n>0) then
	select IDTYPE, NAME, GENDER, BIRTH_DATE, ISSUING_AUTHORITY, ISSUING_DATE, EXPIRE_DATE, WORK_OFFICE, OPERATOR_NAME, ISSUING_OFFICE into newIDType, newName, newGender, newBirth, newIssuingAuthority, newIssuingDate, newExpireDate, newOffice, newOperatorName, newIssuingOffice from BAS_EXAMINER where IDNUMBER=idNo;
	if idTypeName is not null then select DICT_CODE into newIDType from CFG_DICT where DICT_TYPE=2002 and DICT_NAME=idTypeName; end if;
	if examinerName is not null then newName:=examinerName; end if;
	if examinerGender is not null then select DICT_CODE into newGender from CFG_DICT where DICT_TYPE=2001 and DICT_NAME=examinerGender; end if;
	if birth is not null then newBirth:=birth; end if;
	if issuingAuthority is not null then newIssuingAuthority:=issuingAuthority; end if;
	if issuingDate is not null then newIssuingDate:=issuingDate; end if;
	if expireDate is not null then newExpireDate:=expireDate; end if;
	if office is not null then newOffice:=office; end if;
	if operatorName is not null then newOperatorName:=operatorName; end if;
	if issuingOffice is not null then newIssuingOffice:=issuingOffice; end if;	
	update BAS_EXAMINER set IDTYPE=newIDType, NAME=newName, GENDER=newGender, BIRTH_DATE=newBirth, ISSUING_AUTHORITY=newIssuingAuthority, ISSUING_DATE=newIssuingDate, EXPIRE_DATE=newExpireDate, WORK_OFFICE=newOffice, OPERATOR_NAME=newOperatorName, ISSUING_OFFICE=newIssuingOffice, UPDATE_TIME=to_char(current_date, 'yyyymmddhh24miss') where IDNUMBER=idNo;
	message:='考试员：'||examinerName||idNo;
	AddLog(operatorLoginName, '备案信息管理', '修改', message, 1, null, null);
	commit;
  else
    insert into BAS_EXAMINER(
	  ID,
	  SEQUENCENUMBER,
	  IDNUMBER,
	  IDTYPE,
	  NAME,
	  GENDER,
	  BIRTH_DATE,
	  ISSUING_AUTHORITY,
	  QUALIFIED_CAR_TYPE,
	  ISSUING_DATE,
	  EXPIRE_DATE,
	  STATUS,
	  WORK_OFFICE,
	  OPERATOR_NAME,
	  ISSUING_OFFICE,
	  CREATE_TIME,
	  UPDATE_TIME)
	values(
	  SEQU_BAS_EXAMINER_ID.nextval,
	  NewExaminerSequenceNumber,
	  idNo,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2002 and DICT_NAME=idTypeName),
	  examinerName,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2001 and DICT_NAME=examinerGender),
	  birth,
	  issuingAuthority,	  
	  'C1C2',
	  issuingDate,
	  expireDate,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1015 and DICT_NAME='正常'),
	  office,
	  operatorName,
	  issuingOffice,
	  to_char(current_date, 'yyyymmddhh24miss'),
	  to_char(current_date, 'yyyymmddhh24miss'));
	message:='考试员：'||examinerName||idNo;
	AddLog(operatorLoginName, '备案信息管理', '增加', message, 1, null, null);
	commit;
  end if;
end AddUpdateExaminer;
/
