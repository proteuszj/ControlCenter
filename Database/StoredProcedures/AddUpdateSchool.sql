create or replace procedure AddUpdateSchool
(
  message out varchar2,
  operatorLoginName in varchar2,
  schoolCode in varchar2,
  schoolName in varchar2,
  shortName in varchar2,
  schoolAddress in varchar2,
  contactAddress in varchar2,
  contactName in varchar2,
  corporation in varchar2,
  schoolGrade in varchar2 
) as
  n number;
  newName BAS_DRIVING_SCHOOL.NAME%TYPE;
  newShortName BAS_DRIVING_SCHOOL.SHORT_NAME%TYPE;
  newAddress BAS_DRIVING_SCHOOL.ADDRESS%TYPE;
  newContactAddress BAS_DRIVING_SCHOOL.CONTACT_ADDRESS%TYPE;
  newContact BAS_DRIVING_SCHOOL.CONTACT%TYPE;
  newCorporation BAS_DRIVING_SCHOOL.CORPORATION%TYPE;
  newGrade BAS_DRIVING_SCHOOL.GRADE%TYPE;
begin
  select count(*) into n from BAS_DRIVING_SCHOOL where CODE=schoolCode;
  if (n>0) then
	select NAME, SHORT_NAME, ADDRESS, CONTACT_ADDRESS, CONTACT, CORPORATION, GRADE into newName, newShortName, newAddress, newContactAddress, newContact, newCorporation, newGrade from BAS_DRIVING_SCHOOL where CODE=schoolCode;
	if schoolName is not null then newName:=schoolName; end if;
	if shortName is not null then newShortName:=shortName; end if;
	if schoolAddress is not null then newAddress:=schoolAddress; end if;
	if contactAddress is not null then newContactAddress:=contactAddress; end if;
	if contactName is not null then newContact:=contactName; end if;
	if corporation is not null then newCorporation:=corporation; end if;
	if schoolGrade is not null then select DICT_CODE into newGrade from CFG_DICT where DICT_TYPE=1020 and DICT_NAME=schoolGrade; end if;
	update BAS_DRIVING_SCHOOL set NAME=newName, SHORT_NAME=newShortName, ADDRESS=newAddress, CONTACT_ADDRESS=newContactAddress, CONTACT=newContact, CORPORATION=newCorporation, GRADE=newGrade, UPDATE_TIME=to_char(current_date, 'yyyymmddhh24miss') where CODE=schoolCode;
	message:='驾校:'||schoolName||schoolCode;
	AddLog(operatorLoginName, '备案信息管理', '修改', message, 1, null, null);
	commit;
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
	  GRADE,
	  QUALIFIED_CAR_TYPE,
	  AUDITOR,
	  CREATE_TIME,
	  UPDATE_TIME)
	values(
	  SEQU_BAS_DRIVING_SCHOOL_ID.nextval,
	  NewSchoolSequenceNumber,
	  schoolCode,
	  schoolName,
	  shortName,
	  schoolAddress,
	  contactAddress,
	  contactName,
	  corporation,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1020 and DICT_NAME=schoolGrade),
	  'C1C2',
	  '审核人',
	  to_char(current_date, 'yyyymmddhh24miss'),
	  to_char(current_date, 'yyyymmddhh24miss'));
	message:='驾校:'||schoolName||schoolCode;
	AddLog(operatorLoginName, '备案信息管理', '增加', message, 1, null, null);
	commit;
  end if;
end AddUpdateSchool;
/
