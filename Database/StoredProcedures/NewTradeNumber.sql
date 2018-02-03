create or replace function NewTradeNumber
return varchar2 as
  n number;
begin
  select count(*) into n from BUZ_PAYMENT_DETAIL where TRADE_NO like 'DZ-%';
  if n=0 then return 'DZ-'||to_char(current_date, 'yyyymmddhh24miss')||'050047'||'100000000';
  else
	select max(substr(TRADE_NO, 24, 9)) into n from BUZ_PAYMENT_DETAIL where TRADE_NO like 'DZ-%';
	return 'DZ-'||to_char(current_date, 'yyyymmddhh24miss')||'050047'||to_number(n+1);
  end if;
end NewTradeNumber;
/
