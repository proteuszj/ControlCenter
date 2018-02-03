create or replace function DESDecrypt
(
  secret in raw
) return varchar2 as
begin
  return utl_i18n.raw_to_char(dbms_crypto.decrypt(secret, dbms_crypto.encrypt_des+dbms_crypto.chain_cbc+dbms_crypto.pad_pkcs5, utl_i18n.string_to_raw('12345678', 'al32utf8')), 'al32utf8');
end DESDecrypt;
/
