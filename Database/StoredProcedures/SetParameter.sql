create or replace function SetParameter
(
  message out varchar2,
  operatorLoginName in varchar2,
  parameterName in varchar2,
  parameterValue in varchar2,
  hostIP in varchar2,
  hostMAC in varchar2
) return number as
  n number;
  oldParameterValue CFG_PARAM.PARAM_VALUE%TYPE;
begin
  select count(*) into n from CFG_PARAM where PARAM_NAME=parameterName;
  if n=0 then
	message:='参数不存在：'||parameterName||' 值：'||parameterValue;
    addLog(operatorLoginName, '系统', '修改', message, 0, hostIP, hostMAC);
	return -1;
  end if;
  
  select PARAM_VALUE into oldParameterValue from CFG_PARAM where PARAM_NAME=parameterName;
  
  if oldParameterValue=parameterValue then
	message:='';
	return 1;
  end if;
  
  update CFG_PARAM set
	PARAM_VALUE=parameterValue
  where PARAM_NAME=parameterName;

  message:='设置参数成功：'||parameterName||' 值：'||parameterValue;
  addLog(operatorLoginName, '系统', '修改', message, 1, hostIP, hostMAC);
  return 0;
end SetParameter;
/
