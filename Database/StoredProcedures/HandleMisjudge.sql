create or replace procedure HandleMisjudge
(
  message out varchar2,
  operatorLoginName in varchar2,
  description in varchar2,
  hostIP in varchar2,					--host ip
  hostMAC in varchar2					--host mac
) as
begin
  message:='���У�'||description;
  AddLog(operatorLoginName, '���Թ���', '����', message, 1, hostIP, hostMAC);
end;
/
