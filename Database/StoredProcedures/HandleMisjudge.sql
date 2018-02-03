create or replace procedure HandleMisjudge
(
  message out varchar2,
  operatorLoginName in varchar2,
  description in varchar2,
  hostIP in varchar2,					--host ip
  hostMAC in varchar2					--host mac
) as
begin
  message:='误判：'||description;
  AddLog(operatorLoginName, '考试管理', '增加', message, 1, hostIP, hostMAC);
end;
/
