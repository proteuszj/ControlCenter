create or replace function AddUpdateUser 
(
  message out varchar2,					--error message or loginName if no error
  operatorLoginName in varchar2,
  loginName in varchar2,				--do NOT changed
  userName in varchar2,
  gender in varchar2,
  idNo in varchar2,
  userFlag in varchar2,
  userNo in varchar2,
  fp1 in blob,
  maxFailureCount in varchar2,
  passwordModifyDate in varchar2,
  enableDate in varchar2,
  disableDate in varchar2,
  roleName in varchar2,
  qualifiedStartTime in varchar2,
  qualifiedEndTime in varchar2,
  qualifiedAddressList in varchar2
) return number as 
  n1 number;
  n2 number;
  n3 number;
  action SYS_LOG.ACTION%TYPE;
  newPassword SYS_USER.PASSWORD%TYPE;
  newUserName SYS_USER.USER_NAME%TYPE;
  newGender SYS_USER.GENDER%TYPE;
  newIDNumber SYS_USER.IDNUMBER%TYPE;
  newUserFlag SYS_USER.USER_FLAG%TYPE;
  newUserNumber SYS_USER.USERNUMBER%TYPE;
  newMaxFailureCount SYS_USER.MAX_FAILURE_COUNT%TYPE;
  newPasswordModifyDate SYS_USER.PASSWORD_MODIFY_DATE%TYPE;
  newEnableDate SYS_USER.ENABLE_DATE%TYPE;
  newDisableDate SYS_USER.DISABLE_DATE%TYPE;
  newRoleID SYS_USER.ROLE_ID%TYPE;
  newQualifiedStartTime SYS_USER.QUALIFIED_START_TIME%TYPE;
  newQualifiedEndTime SYS_USER.QUALIFIED_END_TIME%TYPE;
  newQualifiedAddressList SYS_USER.QUALIFIED_ADDRESS_LIST%TYPE;
  defaultPassword CFG_PARAM.PARAM_VALUE%TYPE;
  passwordSHA1 varchar2(40);
  result number;
begin
  select count(*) into n1 from SYS_USER where LOGIN_NAME=loginName;
  select count(*) into n2 from SYS_USER where IDNUMBER=idNo and LOGIN_NAME<>loginName and STATUS<>(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='已删除');
  select count(*) into n3 from SYS_USER where USER_FLAG=(select DICT_CODE from CFG_DICT where DICT_TYPE=1010 and DICT_NAME=userFlag) and USERNUMBER=userNo and LOGIN_NAME<>loginName and STATUS<>(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='已删除');
  
  if n1=0 then
    action:='增加';
  else
    select count(*) into n1 from SYS_USER where LOGIN_NAME=loginName and STATUS<>(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='已删除');
	if n1=0 then		--user with same LOGIN_NAME has been deleted
	  message:='用户已存在并且已删除，用户不可用：'||loginName;
	  result:=-5;
	  addLog(operatorLoginName, '用户管理', action, message, 0, null, null);
	  return result;
    end if;
    action:='修改';
  end if;
  if n2>0 then  --IDNUMBER duplicated
    message:='身份证号重复:'||loginName||'-'||idNo;
    if n1=0 then
      result:=-1;
    else
      result:=-2;
    end if;
    addLog(operatorLoginName, '用户管理', action, message, 0, null, null);
    return result;
  elsif n3>0 then  --USER_FLAG-USERNUMBER duplicated
    message:='员工/警员编号重复:'||loginName||'-'||userNo;
    if n1=0 then
      result:=-3;
    else
      result:=-4;
    end if;
    addLog(operatorLoginName, '用户管理', action, message, 0, null, null);
    return result;
  else
    if n1>0 then
	  select PASSWORD, USER_NAME, GENDER, IDNUMBER, USER_FLAG, USERNUMBER, MAX_FAILURE_COUNT, PASSWORD_MODIFY_DATE, ENABLE_DATE, DISABLE_DATE, ROLE_ID, QUALIFIED_START_TIME, QUALIFIED_END_TIME, QUALIFIED_ADDRESS_LIST
	  into newPassword, newUserName, newGender, newIDNumber, newUserFlag, newUserNumber, newMaxFailureCount, newPasswordModifyDate, newEnableDate, newDisableDate, newRoleID, newQualifiedStartTime, newQualifiedEndTime, newQualifiedAddressList
	  from SYS_USER where LOGIN_NAME=loginName;

	  if userName is not null then newUserName:=userName; end if;
	  if gender is not null then select DICT_CODE into newGender from CFG_DICT where DICT_TYPE=2001 and DICT_NAME=gender; end if;
	  if idNo is not null then newIDNumber:=idNo; end if;
	  if userFlag is not null then select DICT_CODE into newUserFlag from CFG_DICT where DICT_TYPE=1010 and DICT_NAME=userFlag; end if;
	  if userNo is not null then newUserNumber:=userNo; end if;
	  newMaxFailureCount:=maxFailureCount;
	  if passwordModifyDate is not null then newPasswordModifyDate:=passwordModifyDate; end if;
	  newEnableDate:=enableDate;
	  newDisableDate:=disableDate;
	  if roleName is not null then select ID into newRoleID from SYS_ROLE where NAME=roleName; end if;
	  newQualifiedStartTime:=qualifiedStartTime;
	  newQualifiedEndTime:=qualifiedEndTime;
	  newQualifiedAddressList:=qualifiedAddressList;
	  
	  passwordSHA1:=SUBSTR(DESDecrypt(newPassword), 1, 40);
	  
      update SYS_USER set
		PASSWORD=DESEncrypt(passwordSHA1||loginName||newUserName||newIDNumber),
		USER_NAME=newUserName,
		GENDER=newGender,
		IDNUMBER=newIDNumber,
		USER_FLAG=newUserFlag,
		USERNUMBER=newUserNumber,
		FINGERPRINT1=fp1,
		MAX_FAILURE_COUNT=newMaxFailureCount,
		PASSWORD_MODIFY_DATE=newPasswordModifyDate,
		ENABLE_DATE=newEnableDate,
		DISABLE_DATE=newDisableDate,
		ROLE_ID=newRoleID,
		QUALIFIED_START_TIME=newQualifiedStartTime,
		QUALIFIED_END_TIME=newQualifiedEndTime,
		QUALIFIED_ADDRESS_LIST=newQualifiedAddressList
	  where LOGIN_NAME=loginName;
	  
    else		--add user, PASSWORD = DEFAULT_USER_PASSWORD, PASSWORD_MODIFY_DATE = current_date - 1
	  newPasswordModifyDate:=case when passwordModifyDate is not null then passwordModifyDate else to_char(current_date-1, 'yyyymmdd') end;
	  select PARAM_VALUE into defaultPassword from CFG_PARAM where PARAM_NAME='DEFAULT_USER_PASSWORD';
      insert into SYS_USER(
		ID,
		LOGIN_NAME,
		PASSWORD,
		USER_NAME,
		GENDER,
		IDNUMBER,
		USER_FLAG,
		USERNUMBER,
		FINGERPRINT1,
		MAX_FAILURE_COUNT,
		PASSWORD_MODIFY_DATE,
		ENABLE_DATE,
		DISABLE_DATE,
		ROLE_ID,
		QUALIFIED_START_TIME,
		QUALIFIED_END_TIME,
		QUALIFIED_ADDRESS_LIST)
	  values(
		SEQU_SYS_USER_ID.nextval,
		loginName,
		DESEncrypt(GenerateSHA1(defaultPassword)||loginName||userName||idNo),
		userName,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=2001 and DICT_NAME=gender),
		idNo,
		(select DICT_CODE from CFG_DICT where DICT_TYPE=1010 and DICT_NAME=userFlag),
		userNo,
		fp1,
		newMaxFailureCount,
		newPasswordModifyDate,
		enableDate,
		disableDate,
		(select ID from SYS_ROLE where NAME=roleName),
		qualifiedStartTime,
		qualifiedEndTime,
		qualifiedAddressList);
    end if;    
    message:=loginName;
    addLog(operatorLoginName, '用户管理', action, message, 1, null, null);
    return 0;
  end if;
end AddUpdateUser;
/
