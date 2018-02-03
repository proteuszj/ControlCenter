create or replace function login 
(
  message out varchar2,                 --error message or USER_FLAG||ROLE_NAME if no error
  loginName in varchar2,
  passwordSHA1 in varchar2,
  hostIP in varchar2,					--host ip
  hostMAC in varchar2					--host mac
) return number as
  n integer;
  userID SYS_USER.ID%TYPE;
  passwd SYS_USER.PASSWORD%TYPE;
  userName SYS_USER.USER_NAME%TYPE;
  idNo SYS_USER.IDNUMBER%TYPE;
  userFlag SYS_USER.USER_FLAG%TYPE;
  userFailureTimes SYS_USER.FAILURE_TIMES%TYPE;
  userStatus SYS_USER.STATUS%TYPE;
  passwordModifyDate SYS_USER.PASSWORD_MODIFY_DATE%TYPE;
  enableDate SYS_USER.ENABLE_DATE%TYPE;
  disableDate SYS_USER.DISABLE_DATE%TYPE;
  roleID SYS_USER.ROLE_ID%TYPE;
  qualifiedStartTime SYS_USER.QUALIFIED_START_TIME%TYPE;
  qualifiedEndTime SYS_USER.QUALIFIED_END_TIME%TYPE;
  qualifiedAddressList SYS_USER.QUALIFIED_ADDRESS_LIST%TYPE;
  userMaxFailureCount SYS_USER.MAX_FAILURE_COUNT%TYPE;
  terminalFailureTimes SYS_TERMINAL_LIST.FAILURE_TIMES%TYPE;
  lockTime SYS_TERMINAL_LIST.LOCK_TIME%TYPE;
  terminalMaxFailureCount SYS_TERMINAL_LIST.MAX_FAILURE_COUNT%TYPE;
  terminalLockDuration SYS_TERMINAL_LIST.LOCK_DURATION%TYPE;
  lastLoginTime SYS_LOG.TIME%TYPE;
  lastLoginIP SYS_LOG.IP%TYPE;
  lastLoginMAC SYS_LOG.MAC%TYPE;
begin
  --check user existance
  select count(*) into n from SYS_USER where LOGIN_NAME=loginName and STATUS<>(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='已删除');
  if n=0 then
    message:='用户不存在: '||loginName;
    addLog(loginName, '系统', '登录', message, 0, hostIP, hostMAC);
    return -1;
  end if;

  select ID, PASSWORD, USER_NAME, IDNUMBER, USER_FLAG, FAILURE_TIMES, MAX_FAILURE_COUNT, STATUS, PASSWORD_MODIFY_DATE, ENABLE_DATE, DISABLE_DATE, ROLE_ID, QUALIFIED_START_TIME, QUALIFIED_END_TIME, QUALIFIED_ADDRESS_LIST
  into userID, passwd, userName, idNo, userFlag, userFailureTimes, userMaxFailureCount, userStatus, passwordModifyDate, enableDate, disableDate, roleID, qualifiedStartTime, qualifiedEndTime, qualifiedAddressList
  from SYS_USER where LOGIN_NAME=loginName;

  --check lock flag
  if userMaxFailureCount is null then
    select to_number(PARAM_VALUE) into userMaxFailureCount from CFG_PARAM where PARAM_NAME='DEFAULT_USER_MAX_FAILURE_COUNT';
  end if;
  if userFailureTimes>=userMaxFailureCount then
    message:='用户已锁定';
    addLog(loginName, '系统', '登录', message, 0, hostIP, hostMAC);
    return -2;
  end if;
  
  --check terminal lock flag
  select count(*) into n from SYS_TERMINAL_LIST where MAC=hostMAC;
  if n>0 then
	select FAILURE_TIMES, LOCK_TIME, MAX_FAILURE_COUNT, LOCK_DURATION into terminalFailureTimes, lockTime, terminalMaxFailureCount, terminalLockDuration from SYS_TERMINAL_LIST where MAC=hostMAC;
	if lockTime is not null then
      if terminalLockDuration is null then
        select to_number(PARAM_VALUE) into terminalLockDuration from CFG_PARAM where PARAM_NAME='TERMINAL_LOCK_DURATION';
      end if;
	  if current_date<to_date(lockTime, 'yyyymmddhh24miss')+numtodsinterval(terminalLockDuration, 'minute') then
		message:='终端已锁定';
		addLog(loginName, '系统', '登录', message, 0, hostIP, hostMAC);
		return -3;
	  else--unlock automatically
        update SYS_TERMINAL_LIST set FAILURE_TIMES=0, LOCK_TIME=NULL where MAC=hostMAC;
		terminalFailureTimes:=0;
        lockTime:=null;
	  end if;
	end if;
  else
    insert into SYS_TERMINAL_LIST(MAC, IP, FAILURE_TIMES) values(hostMAC, hostIP, 0);
	terminalFailureTimes:=0;
  end if;

  --verify password
  if passwd <> DESEncrypt(passwordSHA1||loginName||userName||idNo) then
    userFailureTimes:=userFailureTimes+1;
	terminalFailureTimes:=terminalFailureTimes+1;
	
    update SYS_USER set FAILURE_TIMES=userFailureTimes where LOGIN_NAME=loginName;
    
    if terminalMaxFailureCount is null then
      select to_number(PARAM_VALUE) into terminalMaxFailureCount from CFG_PARAM where PARAM_NAME='DEFAULT_TERMINAL_MAX_FAILURE_COUNT';
    end if;
    if terminalFailureTimes>=terminalMaxFailureCount then
      lockTime:=to_char(current_date, 'yyyymmddhh24miss');
    end if;
    update SYS_TERMINAL_LIST set FAILURE_TIMES=terminalFailureTimes, LOCK_TIME=lockTime where MAC=hostMAC;
    
    message:='密码连续错误'||userFailureTimes||'次';
    addLog(loginName, '系统', '登录', message, '0', hostIP, hostMAC);
    return -4;
  end if;

  --check login status
  if userStatus=1 then
    message:='用户已登录';
    addLog(loginName, '系统', '登录', message, '0', hostIP, hostMAC);
    return -5;
  end if;

  --check enable status
  if enableDate is not null and trunc(current_date,'dd')<to_date(enableDate,'yyyymmdd') or disableDate is not null and trunc(current_date, 'dd')>to_date(disableDate,'yyyymmdd') then
    message:='用户不在登录有效期内'||enableDate||' - '||disableDate;
    addLog(loginName, '系统', '登录', message, '0', hostIP, hostMAC);
    return -6;
  end if;

  --check qualified login time
  if qualifiedStartTime is not null and current_date<to_date(to_char(current_date, 'yyyymmdd')||qualifiedStartTime, 'yyyymmddhh24miss') or qualifiedEndTime is not null and current_date>to_date(to_char(current_date,'yyyymmdd')||qualifiedEndTime,'yyyymmddhh24miss') then
    message:='用户不在授权登录时间内'||qualifiedStartTime||' - '||qualifiedEndTime;
    addLog(loginName, '系统', '登录', message, '0', hostIP, hostMAC);
    return -7;
  end if;

  --check address list
  if qualifiedAddressList is not null and instr(qualifiedAddressList, hostMAC)=0 then
	message:='终端不在授权列表'||hostMAC;
	addLog(loginName, '系统', '登录', message, '0', hostIP, hostMAC);
    return -8;
  end if;

  --login successfully
  update SYS_USER set STATUS=(select DICT_CODE from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='已登录'), FAILURE_TIMES=0 where LOGIN_NAME=loginName;
  update SYS_TERMINAL_LIST set FAILURE_TIMES=0, LOCK_TIME=null where MAC=hostMAC;
  if roleID is not null then
    select NAME into message from SYS_ROLE where ID=roleID;  
  else
    message:='';
  end if;
  
  select count(*) into n from SYS_LOG where USER_ID=userID and RESULT='1' and ACTION=(select DICT_CODE from CFG_DICT where DICT_TYPE='1028' and DICT_NAME='登录');
  if n>0 then
	select TIME, IP, MAC into lastLoginTime, lastLoginIP, lastLoginMAC from SYS_LOG where USER_ID=userID and RESULT='1' and ACTION=(select DICT_CODE from CFG_DICT where DICT_TYPE='1028' and DICT_NAME='登录') and rownum<=1 order by ID desc;
	message:=message||'，上次登录时间：'||lastLoginTime||'；上次登录地点：'||lastLoginIP||'（'||lastLoginMAC||'）';
  end if;
  if userFailureTimes>0 then
    message:=message||'，上次成功登录后失败'||userFailureTimes||'次';
  end if;
  if disableDate is not null then
	message:=message||'，用户距离到期'||to_number(to_date(disableDate, 'yyyymmdd')-trunc(current_date, 'dd'))||'天';
  end if;
  
  if to_char(current_date, 'yyyymmdd')>passwordModifyDate then
	message:=message||'，密码已过期，请修改密码';
	addLog(loginName, '系统', '登录', message, 1, hostIP, hostMAC);
	return 1;
  else
	message:=message||'，密码距离到期'||to_number(to_date(passwordModifyDate, 'yyyymmdd')-trunc(current_date, 'dd'))||'天';
	addLog(loginName, '系统', '登录', message, 1, hostIP, hostMAC);
	return 0;
  end if;
end login;
/
