create or replace procedure AddUpdateCar
(
  message out varchar2,
  operatorLoginName in varchar2,
  licenseNo in varchar2,
  subjectName in varchar2,
  carNo in varchar2,
  qualifiedLicenseTypes in varchar2,
  carBrand in varchar2,
  ip in varchar2,
  expireDate in varchar2,
  carMap blob
) as
  n number;
  newSubject BAS_CAR.SUBJECT%TYPE;
  newCarNumber BAS_CAR.CARNUMBER%TYPE;
  newQualifiedLicenseType BAS_CAR.QUALIFIED_CAR_TYPE%TYPE;
  newBrand BAS_CAR.BRAND%TYPE;
  newExpireDate BAS_CAR.SCRAP_DATE%TYPE;
  newIP BAS_CAR.CAR_IP%TYPE;
begin
  select count(*) into n from BAS_CAR where LICENSE_PLATE=licenseNo;
  if n>0 then
    select SUBJECT, CARNUMBER, QUALIFIED_CAR_TYPE, BRAND, SCRAP_DATE, CAR_IP into newSubject, newCarNumber, newQualifiedLicenseType, newBrand, newExpireDate, newIP from BAS_CAR where LICENSE_PLATE=licenseNo;
	if subjectName is not null then select DICT_CODE into newSubject from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName; end if;
	if carNo is not null then newCarNumber:=carNo; end if;
	if qualifiedLicenseTypes is not null then newQualifiedLicenseType:=qualifiedLicenseTypes; end if;
	if carBrand is not null then newBrand:=carBrand; end if;
	if ip is not null then newIP:=ip; end if;
	if expireDate is not null then newExpireDate:=expireDate; end if;
	update BAS_CAR set SUBJECT=newSubject, CARNUMBER=newCarNumber, QUALIFIED_CAR_TYPE=newQualifiedLicenseType, BRAND=newBrand, SCRAP_DATE=newExpireDate, CAR_IP=newIP, UPDATE_TIME=to_char(current_date, 'yyyymmddhh24miss') where LICENSE_PLATE=licenseNo;
	if carMap is not null then update BAS_CAR set CAR_MAP=carMap where LICENSE_PLATE=licenseNo; end if;
	message:='车辆'||licenseNo;
	AddLog(operatorLoginName, '备案信息管理', '修改', message, 1, null, null);
	commit;
  else
    insert into BAS_CAR(
	  ID,
	  SEQUENCENUMBER,
	  SUBJECT,
	  LICENSE_PLATE_TYPE,
	  CARNUMBER,
	  LICENSE_PLATE,
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
	  CAR_MAP,
	  CREATE_TIME,
	  UPDATE_TIME)
	values(
	  SEQU_BAS_CAR_ID.nextval,
	  NewCarSequenceNumber,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1006 and DICT_NAME=subjectName),
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2006 and DICT_NAME='小型汽车'),
	  carNo,
	  licenseNo,
	  qualifiedLicenseTypes,
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2004 and DICT_NAME='小型轿车'),
	  carBrand,
	  to_char(current_date, 'yyyymmdd'),
	  expireDate,
	  '发证',
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=2005 and DICT_NAME='正常'),
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1016 and DICT_NAME='正常'),
	  '审核人',
	  ip,
	  carMap,
	  to_char(current_date, 'yyyymmddhh24miss'),
	  to_char(current_date, 'yyyymmddhh24miss')
	);
	message:='车辆'||licenseNo;
    AddLog(operatorLoginName, '备案信息管理', '增加', message, 1, null, null);
	commit;
  end if;
end addUpdateCar;
/
