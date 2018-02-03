create or replace function GenerateSHA1
(
  message in varchar2
) return raw as
begin
  return dbms_crypto.hash(utl_i18n.string_to_raw(message,'al32utf8'), dbms_crypto.HASH_SH1);
end GenerateSHA1;
/
