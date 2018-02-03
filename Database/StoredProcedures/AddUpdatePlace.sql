create or replace procedure AddUpdatePlace
(
  message out varchar2,
  operatorLoginName in varchar2,
  placeCode in varchar2,
  placeName in varchar2,
  subjectName in varchar2,
  issuingAuthority in varchar2,
  branch in varchar2,
  acceptanceDate in varchar2,
  accepterName in varchar2
) as
  n number;
  newName BAS_PLACE.NAME%TYPE;
  newSubject BAS_PLACE.SUBJECT%TYPE;
  newIssuingAuthority BAS_PLACE.ISSUING_AUTHORITY%TYPE;
  newBranch BAS_PLACE.BRANCH_ADMINISTRATION%TYPE;
  newAcceptanceDate BAS_PLACE.ACCEPTANCE_DATE%TYPE;
  newAccepter BAS_PLACE.ACCEPTER%TYPE;
begin
  select count(*) into n from BAS_PLACE where CODE=placeCode;
  if (n>0) then
	select NAME, SUBJECT, ISSUING_AUTHORITY, BRANCH_ADMINISTRATION, ACCEPTANCE_DATE, ACCEPTER into newName, newSubject, newIssuingAuthority, newBranch, newAcceptanceDate, newAccepter from BAS_PLACE where CODE=placeCode;
	if placeName is not null then newName:=placeName; end if;
	if subjectName is not null then select DICT_CODE into newSubject from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName; end if;
	if issuingAuthority is not null then newIssuingAuthority:=issuingAuthority; end if;
	if branch is not null then newBranch:=branch; end if;
	if acceptanceDate is not null then newAcceptanceDate:=acceptanceDate; end if;
	if accepterName is not null then newAccepter:=accepterName; end if;
	update BAS_PLACE set NAME=newName, SUBJECT=newSubject, ISSUING_AUTHORITY=newIssuingAuthority, BRANCH_ADMINISTRATION=newBranch, ACCEPTANCE_DATE=newAcceptanceDate, ACCEPTER=newAccepter, UPDATE_TIME=to_char(current_date, 'yyyymmddhh24miss') where CODE=placeCode;
	message:='场地:'||placeName||placeCode;
	AddLog(operatorLoginName, '备案信息管理', '修改', message, 1, null, null);
	commit;
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
	  ACCEPTANCE_DATE,
	  ACCEPTER,
	  RESERVATION_MODE,
	  GROUPING_MODE,
	  PILE_EXAM_NETWORK_TIME,
	  PLACE_EXAM_NETWORK_TIME,
	  CREATE_TIME,
	  UPDATE_TIME)
	values(
	  SEQU_BAS_PLACE_ID.nextval,
	  NewPlaceSequenceNumber,
	  placeCode,
	  placeName,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName),
	  'C1C2',
	  issuingAuthority,
	  branch,
	  acceptanceDate,
	  accepterName,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1017 and DICT_NAME='一次预约'),
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1018 and DICT_NAME='按学员分组'),
	  to_char(current_date, 'yyyymmddhh24miss'),
	  to_char(current_date, 'yyyymmddhh24miss'),
	  to_char(current_date, 'yyyymmddhh24miss'),
	  to_char(current_date, 'yyyymmddhh24miss'));
	message:='场地:'||placeName||placeCode;
	AddLog(operatorLoginName, '备案信息管理', '增加', message, 1, null, null);
	commit;
  end if;
end AddUpdatePlace;
/
