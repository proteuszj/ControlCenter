create or replace function NewCarSequenceNumber
return varchar2 as
  n number;
begin
  select count(*) into n from BAS_CAR where SEQUENCENUMBER like '1%';
  if n=0 then return '10000000';
  else
	select max(SEQUENCENUMBER) into n from BAS_CAR where SEQUENCENUMBER like '1%';
	return n+1;
  end if;
end NewCarSequenceNumber;
/
