create or replace function GenerateHMAC
(
  message in varchar2
) return raw as
begin
  return dbms_crypto.mac(utl_i18n.string_to_raw(message,'al32utf8'), dbms_crypto.hmac_sh1, utl_i18n.string_to_raw('12345678', 'al32utf8'));
end GenerateHMAC;
/
