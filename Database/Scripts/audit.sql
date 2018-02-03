
audit all on BAS_STUDENT;
audit all on BUZ_EXAM_INFO;
audit all on BUZ_EXAM_PROCESS;
audit all on BUZ_SUB2_RECORD;
audit all on CFG_ITEMS;
audit all on CFG_PARAM;
audit all on CFG_DICT;
audit all on CFG_MAPS;
audit all on SYS_LOG;
audit all on SYS_PERMISSION;
audit all on SYS_ROLE;
audit all on SYS_ROLE_PERMISSION;
audit all on SYS_TERMINAL_LIST;
audit all on SYS_USER;

AUDIT
    ALTER TABLE,
    DELETE TABLE,
    EXECUTE PROCEDURE,
    INSERT TABLE,
    NETWORK,
    PROCEDURE,
    SELECT TABLE,
    TABLE,
    TABLESPACE,
    UPDATE TABLE,
    USER,
    VIEW
BY "TNZC"
BY ACCESS;

AUDIT
    ALL STATEMENTS
BY "TNZC";
