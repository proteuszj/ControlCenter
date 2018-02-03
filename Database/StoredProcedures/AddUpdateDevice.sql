create or replace procedure AddUpdateDevice
(
  message out varchar2,
  operatorLoginName in varchar2,
  deviceNo in varchar2,
  deviceDescription in varchar2,
  deviceManufacture in varchar2,
  deviceSerial in varchar2,
  examItemName in varchar2,
  placeCode in varchar2,
  acceptanceDate in varchar2,
  expireDate in varchar2
) as
  n number;
  newDescription BAS_DEVICE.DESCRIPTION%TYPE;
  newManufacture BAS_DEVICE.MANUFACTURER%TYPE;
  newSerial BAS_DEVICE.SERIALNUMBER%TYPE;
  newExamItemCode BAS_DEVICE.EXAM_ITEM%TYPE;
  newExamItemName BAS_DEVICE.EXAM_ITEM_NAME%TYPE;
  newPlace BAS_DEVICE.PLACE_ID%TYPE;
  newAcceptanceDate BAS_DEVICE.ACCEPTANCE_DATE%TYPE;
  newExpireDate BAS_DEVICE.EXPIRE_DATE%TYPE;
begin
  select count(*) into n from BAS_DEVICE where DEVICENUMBER=deviceNo;
  if (n>0) then
	select DESCRIPTION, MANUFACTURER, SERIALNUMBER, EXAM_ITEM, EXAM_ITEM_NAME, PLACE_ID, ACCEPTANCE_DATE, EXPIRE_DATE into newDescription, newManufacture, newSerial, newExamItemCode, newExamItemName, newPlace, newAcceptanceDate, newExpireDate from BAS_DEVICE where DEVICENUMBER=deviceNo;
	if deviceDescription is not null then newDescription:=deviceDescription; end if;
	if deviceManufacture is not null then newManufacture:=deviceManufacture; end if;
	if deviceSerial is not null then newSerial:=deviceSerial; end if;	
	if examItemName is not null then select ITEM_CODE into newExamItemCode from CFG_ITEMS where ITEM_NAME=examItemName; newExamItemName:=examItemName; end if;
	if placeCode is not null then select ID into newPlace from BAS_PLACE where CODE=placeCode; end if;
	if acceptanceDate is not null then newAcceptanceDate:=acceptanceDate; end if;
	if expireDate is not null then newExpireDate:=expireDate; end if;
	update BAS_DEVICE set DESCRIPTION=newDescription, MANUFACTURER=newManufacture, SERIALNUMBER=newSerial, EXAM_ITEM=newExamItemCode, EXAM_ITEM_NAME=newExamItemName, PLACE_ID=newPlace, ACCEPTANCE_DATE=newAcceptanceDate, EXPIRE_DATE=newExpireDate, UPDATE_TIME=to_char(current_date, 'yyyymmddhh24miss') where DEVICENUMBER=deviceNo;
	message:='设备:'||deviceNo||deviceDescription;
	AddLog(operatorLoginName, '备案信息管理', '修改', message, 1, null, null);
	commit;
  else
    insert into BAS_DEVICE(
	  ID,
	  SEQUENCENUMBER,
	  DEVICENUMBER,
	  DESCRIPTION,
	  MANUFACTURER,
	  SERIALNUMBER,
	  EXAM_ITEM,
	  EXAM_ITEM_NAME,
	  PLACE_ID,
	  QUALIFIED_CAR_TYPE,
	  ACCEPTANCE_DATE,
	  EXPIRE_DATE,
	  SINGLE_EXAM_TIMES,
	  HOURLY_EXAM_TIMES,
	  STATUS,
	  CREATE_TIME,
	  UPDATE_TIME)
	values(
	  SEQU_BAS_DEVICE_ID.nextval,
	  NewDeviceSequenceNumber,
	  deviceNo,
	  deviceDescription,
	  deviceManufacture,
	  deviceSerial,
	  (select ITEM_CODE from CFG_ITEMS where ITEM_NAME=examItemName),
	  examItemName,
	  (select ID from BAS_PLACE where CODE=placeCode),
	  'C1C2',
	  acceptanceDate,
	  expireDate,
	  0,	--temp
	  0,	--temp
	  (select DICT_CODE from CFG_DICT where DICT_TYPE=1022 and DICT_NAME='正常'),
	  to_char(current_date, 'yyyymmddhh24miss'),
	  to_char(current_date, 'yyyymmddhh24miss'));
	message:='设备:'||deviceNo||deviceDescription;
	AddLog(operatorLoginName, '备案信息管理', '增加', message, 1, null, null);
	commit;
  end if;
end AddUpdateDevice;
/
