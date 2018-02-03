create or replace function NewExamNumber
return varchar2 as
  n number;
begin
  select count(*) into n from BAS_BOOKING where EXAMNUMBER like '1%';
  if n=0 then return '100000000000';
  else
	select max(EXAMNUMBER) into n from BAS_BOOKING where EXAMNUMBER like '1%';
	return n+1;
  end if;
end NewExamNumber;
/
