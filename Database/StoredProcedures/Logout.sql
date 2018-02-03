create or replace procedure Logout 
(
	loginName in varchar2,
	ip in varchar2,
	mac in varchar2
) as
	code CFG_DICT.DICT_CODE%TYPE;
begin
	select DICT_CODE into code from CFG_DICT where DICT_TYPE=1013 and DICT_NAME='Î´µÇÂ¼';
	update SYS_USER set STATUS=code where LOGIN_NAME=loginName;
    
	addLog(loginName, 'ÏµÍ³', 'Àë¿ª', NULL, 1, ip, mac);
end logout;
/
