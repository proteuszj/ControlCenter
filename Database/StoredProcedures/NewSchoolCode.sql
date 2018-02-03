create or replace function NewSchoolCode
return varchar2 as
  n number;
begin
  select count(*) into n from BAS_DRIVING_SCHOOL where CODE like '1%';
  if n=0 then return '10000000';
  else
	select max(CODE) into n from BAS_DRIVING_SCHOOL where CODE like '1%';
	return n+1;
  end if;
end NewSchoolCode;
/
