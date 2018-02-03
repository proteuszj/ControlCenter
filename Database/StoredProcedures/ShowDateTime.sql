create or replace function ShowDateTime
(
	datetimeStr in varchar2
)return varchar2 as
begin
    case length(datetimeStr)
        when 14	then return to_char(to_date(datetimeStr, 'yyyymmddhh24miss'), 'yyyy-mm-dd hh24:mi:ss');
        when 8 then return to_char(to_date(datetimeStr, 'yyyymmdd'), 'yyyy-mm-dd');
        when 6 then return to_char(to_date(datetimeStr, 'hh24miss'), 'hh24:mi:ss');
        else return datetimeStr;
    end case;
end ShowDateTime;
/
