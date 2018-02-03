create or replace procedure addLog
(
  loginName in varchar2, 
  module in varchar2,
  action in varchar2,
  content in varchar2,
  result in varchar2,
  ip in varchar2,
  mac in varchar2
) as
  n number;
  userID number;
  sha1 varchar2(40);
  actionDictCode varchar2(200);
  currentTime varchar2(14);
begin
  select count(*) into n from SYS_USER where LOGIN_NAME=loginName;
  if n=1 then
    select ID into userID from SYS_USER where LOGIN_NAME=loginName;
  else
    userID:=0;  --invalid userID
  end if;

  select count(*) into n from CFG_DICT where DICT_TYPE='1028' and DICT_NAME=action;
  if n=1 then
    select DICT_CODE into actionDictCode from CFG_DICT where DICT_TYPE='1028' and DICT_NAME=action;
  else
	actionDictCode:=action;
  end if;
  --calc hash into sha1
  currentTime:=to_char(current_date, 'yyyymmddhh24miss');
  sha1:=GenerateHMAC('hash'||userID||currentTime||module||actionDictCode||content||result||ip||mac);

  insert into SYS_LOG(ID, USER_ID, TIME, SOURCE, ACTION, CONTENT, RESULT, IP, MAC, HASH)
  values (SEQU_SYS_LOG_ID.NEXTVAL, userID, currentTime, module, actionDictCode, content, result, ip, mac, sha1);
end addLog;
/
