create or replace function DESEncrypt
(
  message in varchar2
) return raw as
begin
  return dbms_crypto.encrypt(utl_i18n.string_to_raw(message, 'al32utf8'), dbms_crypto.encrypt_des+dbms_crypto.chain_cbc+dbms_crypto.pad_pkcs5, utl_i18n.string_to_raw('12345678', 'al32utf8'));
end DESEncrypt;
/
