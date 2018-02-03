
/*
 * ���壺������
 * �����ƣ�BAS_PLACE
 * ��ռ䣺TNZC_DATA  
 * ����𣺻������
 * ���ܣ����ڼ�¼�ɹ��������صĿ�����Ϣ��CODE��Ϊ����ΨһԼ��
 */
--��ģ����ѵ��ģʽʱ���ô�����;����ʱȡ���ص���ż���
CREATE SEQUENCE SEQU_BAS_PLACE_ID INCREMENT BY 1  START  WITH  1;  
create table BAS_PLACE
(
  ID                        integer        NOT NULL,              --(����)���
  SEQUENCENUMBER            varchar2(8)    NOT NULL,      --�������
  CODE                      varchar2(64)   NOT NULL,              --��������
  NAME                      varchar2(128)  NOT NULL,              --��������
  SUBJECT                   varchar2(1)    NOT NULL,              --���Կ�Ŀ(�ֵ䡾1006��)
  QUALIFIED_CAR_TYPE         varchar2(24)   NOT NULL,              --����׼�ݳ��ͷ�Χ
  ISSUING_AUTHORITY         varchar2(10)   NOT NULL,              --��֤���� 
  BRANCH_ADMINISTRATION     varchar2(12)   NOT NULL,              --������
  BUSINESS_TYPE             varchar2(10),                         --����ҵ�����ͷ�Χ
  ACCEPTANCE_DATE           varchar2(8)    NOT NULL,              --�ܶ���������(��ʽ:yyyymmdd)
  ACCEPTER                  varchar2(32),                         --������
  RESERVATION_MODE          varchar2(1)    NOT NULL,              --[��Ŀ��]ԤԼģʽ(�ֵ䡾1017��)
  GROUPING_MODE             varchar2(1)    NOT NULL,              --����ģʽ(�ֵ䡾1018��)
  CAPACITY                  integer        DEFAULT 0 NOT NULL,    --������������
  PILE_EXAM_CAPACITY        integer        DEFAULT 0 NOT NULL,    --��Ŀ��׮����������
  PLACE_EXAM_CAPACITY       integer        DEFAULT 0 NOT NULL,    --��Ŀ��������������
  PILE_EXAM_JUDGING         varchar2(1)    DEFAULT '1' NOT NULL,  --׮�����з�ʽ(�ֵ䡾1019��)
  PLACE_EXAM_JUDGING        varchar2(1)    DEFAULT '1' NOT NULL,  --�������з�ʽ(�ֵ䡾1019��)
  PILE_EXAM_NETWORK_TIME    varchar2(14),                         --׮����ʼ����ʱ��(��ʽ��yyyymmddhhmmss)
  PLACE_EXAM_NETWORK_TIME   varchar2(14),                         --������ʼ����ʱ��(��ʽ��yyyymmddhhmmss)
  STATUS                    varchar2(1)    DEFAULT 'A' NOT NULL,  --����ʹ��״̬(�ֵ䡾1016��) 
  PILE_EXAM_DEVICE_COUNT    integer        DEFAULT 0,             --׮���豸��
  PLACE_EXAM_DEVICE_COUNT   integer        DEFAULT 0,             --�����豸��
  EXAM_CAR_TOTAL_COUNT      integer        DEFAULT 0,             --�������Գ�����
  PLACE_AREA                integer        DEFAULT 0,             --�������
  ROADWAY_LENGTH            integer        DEFAULT 0,             --���������ܳ���
  EXAM_CAR_COUNT            integer        DEFAULT 0,             --����ͬʱ���Գ�����
  CREATE_TIME               varchar2(14)   NOT NULL,              --����ʱ��(��ʽ��yyyymmddhhmmss) 
  UPDATE_TIME               varchar2(14)   NOT NULL,              --����ʱ��(��ʽ��yyyymmddhhmmss)  
  UNIQUE(CODE),
  primary key(ID)
);

/*
 * ���壺�豸��
 * �����ƣ�BAS_DEVICE
 * ��ռ䣺TNZC_DATA  
 * ����𣺻������
 * ���ܣ����ڼ�¼�ɹ��������صĿ����豸��Ϣ��DEVICENUMBER��Ϊ����ΨһԼ��
 */
--��ģ����ѵ��ģʽʱ���ô�����;����ʱȡ���ص���ż���
CREATE SEQUENCE SEQU_BAS_DEVICE_ID INCREMENT BY 1  START  WITH  1;  
create table BAS_DEVICE
(
  ID                     integer  NOT NULL,              --(����)���
  SEQUENCENUMBER         varchar2(8)    NOT NULL,              --�豸���
  DEVICENUMBER           varchar2(10)   NOT NULL,              --�豸���
  DESCRIPTION            varchar2(512)  NOT NULL,              --�豸����
  MANUFACTURER           varchar2(512)  NOT NULL,              --���쳧��
  SERIALNUMBER           varchar2(512)  NOT NULL,              --�豸�ͺ�  
  EXAM_ITEM              varchar2(5)    NOT NULL,              --������Ŀ�������CFG_ITEMS��ITEM_CODE������GRADE=2  
  EXAM_ITEM_NAME         varchar2(256)  NOT NULL,              --������Ŀ˵��
  JUDGING_TYPE           varchar2(1)    DEFAULT '0' NOT NULL,  --���з�ʽ(���ֵ䡾1019�������෴0-�Զ���1-�˹�)
  PLACE_ID               integer        NOT NULL,              --������ţ������BAS_PLACE��ID
  QUALIFIED_CAR_TYPE      varchar2(30)   NOT NULL,              --����׼�ݳ��ͷ�Χ
  ACCEPTANCE_DATE        varchar2(8)    NOT NULL,              --��������(��ʽ:yyyymmdd)
  EXPIRE_DATE            varchar2(8)    NOT NULL,              --��Ч��ֹ����(��ʽ��yyyymmdd) 
  SINGLE_EXAM_TIMES      integer        NOT NULL,              --�������ο���ʱ��
  HOURLY_EXAM_TIMES      integer,                              --����ÿСʱ�����˴�
  STATUS                 varchar2(1)    NOT NULL,              --ʹ��״̬(�ֵ䡾1022��)
  CREATE_TIME            varchar2(14)   NOT NULL,              --����ʱ��(��ʽ��yyyymmddhhmmss)
  UPDATE_TIME            varchar2(14)   NOT NULL,              --����ʱ��(��ʽ��yyyymmddhhmmss) 
  UNIQUE(DEVICENUMBER),
  primary key(ID)
);

/*
 * ���壺������
 * �����ƣ�BAS_CAR
 * ��ռ䣺TNZC_DATA  
 * ����𣺻������
 * ���ܣ����ڼ�¼�ɹ��������صĿ��Գ�����Ϣ��LICENSE_PLATE��Ϊ����ΨһԼ��
 */
--��ģ����ѵ��ģʽʱ���ô�����;����ʱȡ���ص���ż��� 
CREATE SEQUENCE SEQU_BAS_CAR_ID INCREMENT BY 1  START  WITH  1;  
create table BAS_CAR
(
  ID                      integer   NOT NULL,      --(����)���
  SEQUENCENUMBER    varchar2(8)    NOT NULL,      --�������
  LICENSE_PLATE           varchar2(15)   NOT NULL,      --�������ƺ���
  SUBJECT                 varchar2(1)    NOT NULL,      --���Կ�Ŀ(�ֵ䡾1006��)
  LICENSE_PLATE_TYPE      varchar2(2)    NOT NULL,      --��������(�ֵ䡾2006��)
  CARNUMBER               varchar2(3),                  --�������(��Ҫ�����Ŷӽк�Ͷ���ã�Ҳ���ó��ƺ��룬�ɸ��ݿͻ��������)
  QUALIFIED_CAR_TYPE       varchar2(15)   NOT NULL,      --����׼�ݳ��ͷ�Χ
  CAR_TYPE                varchar2(3)    NOT NULL,      --��������(�ֵ䡾2004��)
  BRAND                   varchar2(32)   NOT NULL,      --����Ʒ��
  REGISTER_DATE           varchar2(8)    NOT NULL,      --���εǼ�����(��ʽ:yyyymmdd)
  SCRAP_DATE              varchar2(8)    NOT NULL,      --ǿ�Ʊ�����ֹ(��ʽ:yyyymmdd)
  ISSUING_AUTHORITY       varchar2(10)   NOT NULL,      --��֤����
  CAR_STATUS              varchar2(1)    NOT NULL,      --����������״̬(�ֵ䡾2005��)  
  USE_STATUS              varchar2(1)    NOT NULL,      --����ʹ��״̬(�ֵ䡾1016��) 
  AUDITOR                 varchar2(30),                 --�����
  CAR_IP                  varchar2(15)   NOT NULL,      --����IP  
  CAR_MAP                 BLOB,                         --����������ͼ  
  CREATE_TIME             varchar2(14)   NOT NULL,      --����ʱ��(��ʽ��yyyymmddhhmmss)
  UPDATE_TIME             varchar2(14)   NOT NULL,      --����ʱ��(��ʽ��yyyymmddhhmmss) 
  UNIQUE(LICENSE_PLATE),
  UNIQUE(CAR_IP),
  primary key(ID)
);

/*
 * ���壺����Ա��
 * �����ƣ�BAS_EXAMINER
 * ��ռ䣺TNZC_DATA  
 * ����𣺻������
 * ���ܣ����ڼ�¼�ɹ��������صĿ���Ա��Ϣ��IDNUMBER��Ϊ����ΨһԼ��
 */
--��ģ����ѵ��ģʽʱ���ô�����;����ʱȡ���ص���ż��� 
CREATE SEQUENCE SEQU_BAS_EXAMINER_ID INCREMENT BY 1  START  WITH  1; 
create table BAS_EXAMINER
(
  ID                        integer        NOT NULL,              --(����)���
  SEQUENCENUMBER      varchar2(8)    NOT NULL,      --����Ա���
  IDNUMBER                  varchar2(18)   NOT NULL,              --����Ա���֤������
  IDTYPE                    varchar2(1)    NOT NULL,              --����Ա���֤������(�ֵ䡾2002��)
  NAME                      varchar2(30)   NOT NULL,              --����Ա����
  GENDER                    varchar2(1)    DEFAULT '9' NOT NULL,  --����Ա�Ա�(�ֵ䡾2001��)
  BIRTH_DATE                varchar2(8)    NOT NULL,              --��������(��ʽ��yyyymmdd)
  ISSUING_AUTHORITY         varchar2(10)   NOT NULL,              --������֤����
  BRANCH_ADMINISTRATION     varchar2(12),                         --������
  ARCHIVESNUMBER            varchar2(12),                         --��ʻ֤�������(����GA/T 16.21)
  QUALIFIED_CAR_TYPE         varchar2(32)   NOT NULL,              --����׼�ݳ��ͷ�Χ
  ISSUING_DATE              varchar2(8)    NOT NULL,              --��֤����(��ʽ��yyyymmdd)
  EXPIRE_DATE               varchar2(8)    NOT NULL,              --��Ч��ֹ����(��ʽ��yyyymmdd) 
  STATUS                    varchar2(1)    NOT NULL,              --����Ա״̬(�ֵ䡾1015��)
  WORK_OFFICE               varchar2(128),                        --������λ
  OPERATOR_NAME             varchar2(30)   NOT NULL,              --������
  ISSUING_OFFICE            varchar2(64)   NOT NULL,              --����Ա֤��֤��λ
  CREATE_TIME               varchar2(14)   NOT NULL,              --����ʱ��(��ʽ��yyyymmddhhmmss)
  UPDATE_TIME               varchar2(14)   NOT NULL,              --����ʱ��(��ʽ��yyyymmddhhmmss) 
  UNIQUE(IDNUMBER),
  primary key(ID)
);

/*
 * ���壺��У��
 * �����ƣ�BAS_DRIVING_SCHOOL
 * ��ռ䣺TNZC_DATA  
 * ����𣺻������
 * ���ܣ����ڼ�¼�ɹ��������صļ�У��Ϣ��CODE��Ϊ����ΨһԼ��
 */
--��ģ����ѵ��ģʽʱ���ô�����;����ʱȡ���ص���ż���
CREATE SEQUENCE SEQU_BAS_DRIVING_SCHOOL_ID INCREMENT BY 1  START  WITH  1;  
create table BAS_DRIVING_SCHOOL
(
  ID                     integer      NOT NULL,              --(����)���
  SEQUENCENUMBER         varchar2(8)    NOT NULL,                --��У��� 
  CODE                   varchar2(8)    NOT NULL,              --��У����
  NAME                   varchar2(256),                        --��У����
  SHORT_NAME             varchar2(64)   NOT NULL,              --��У���
  ADDRESS                varchar2(256)  NOT NULL,              --��У��ַ
  CONTACT_ADDRESS        varchar2(20)   NOT NULL,              --��ϵ��ַ
  CONTACT                varchar2(30)   NOT NULL,              --��ϵ��
  CORPORATION            varchar2(30)   NOT NULL,              --���˴���
  REGISTERED_CAPITAL     integer,                              --ע���ʽ�
  GRADE                  varchar2(1)    NOT NULL,              --��У����(�ֵ䡾1020��)
  QUALIFIED_CAR_TYPE      varchar2(30),                         --��ѵ׼�ݳ���
  ISSUING_AUTHORITY      varchar2(10),                         --������֤����
  STATUS                 varchar2(1)    DEFAULT 'A' NOT NULL,  --��У״̬(�ֵ䡾1021��)  
  AUDITOR                varchar2(30)   NOT NULL,              --����� 
  CREATE_TIME            varchar2(14)   NOT NULL,    --����ʱ��(��ʽ��yyyymmddhhmmss)
  UPDATE_TIME            varchar2(14)   NOT NULL,    --����ʱ��(��ʽ��yyyymmddhhmmss) 
  UNIQUE(CODE),
  primary key(ID)
);

/*
 * ���壺�ƻ������
 * �����ƣ�BAS_GROUPING
 * ��ռ䣺TNZC_DATA  
 * ����𣺻������
 * ���ܣ����ڼ�¼�ɹ��������صĿ��Լƻ�������Ϣ
 */
--��ģ����ѵ��ģʽʱ���ô�����;����ʱȡ���ص���ż���
CREATE SEQUENCE SEQU_BAS_GROUPING_ID INCREMENT BY 1  START  WITH  1;  
create table BAS_GROUPING
(
  ID                        integer                  NOT NULL,    --(����)
  SEQUENCENUMBER      varchar2(11)             NOT NULL,    --�������
  SUBJECT                   varchar2(1)              NOT NULL,    --���Կ�Ŀ(�ֵ䡾1006��)
  EXAM_DATE                 varchar2(8),                          --��������(��ʽ:yyyymmdd)
  PLACE_ID                  integer                  NOT NULL,    --�������,�����BAS_PLACE��ID
  DRIVER_LICENSE_TYPE       varchar2(2)              NOT NULL,    --��ʻ֤����/���Գ���(�ֵ䡾2003��) 
  EXAM_SESSION              integer        DEFAULT 0 NOT NULL,    --���Գ���(�ֵ䡾1014��)
  CAR_ID        integer,                --����,�����BAS_CAR��ID
  EXAMINER_ID 	              integer         NOT NULL,    --����Ա,�����BAS_EXAMINER��ID
  BRANCH_ADMINISTRATION     varchar2(12)             NOT NULL,    --������
  EXAM_ITEM                 varchar2(256),                        --������Ŀ
  CIRCUITRY                 varchar2(10),                         --������·
  primary key(ID)
);

/*
 * ���壺�ƻ�������ϸ��
 * �����ƣ�BAS_GROUPING_DETAIL
 * ��ռ䣺TNZC_DATA  
 * ����𣺻������
 * ���ܣ����ڼ�¼�ɹ��������صĿ��Լƻ�������ϸ��Ϣ,��ƻ��������һ�Զ�Ĺ�ϵ,STUDENT_ID��Ϊ����ΨһԼ��
 */
create table BAS_GROUPING_DETAIL
(
  GROUPING_ID         integer      NOT NULL,    --�������,�����BAS_GROUPING��ID
  STUDENT_ID          integer      NOT NULL,    --ѧԱ��Ϣ��ʶ��,�����BAS_STUDENT��ID
  SCHOOL_ID           integer,       --������/��У����,�����BAS_DRIVING_SCHOOL��ID
  CAR_ID              integer,       --����,�����BAS_CAR��ID
  QUEUE_ORDER         integer,       --�Ŷ�˳���(�������Ŷӽк�)
  QUEUE_STATUS        varchar2(1),   --�Ŷ�״̬(�ֵ䡾1023��)
  UNIQUE(STUDENT_ID)
);

/*
 * ���壺ѧԱ��
 * �����ƣ�BAS_STUDENT
 * ��ռ䣺TNZC_DATA  
 * ����𣺻������
 * ���ܣ�����ѧԱ������Ϣά����IDNUMBER��Ϊ����ΨһԼ��
 */
CREATE SEQUENCE SEQU_BAS_STUDENT_ID INCREMENT BY 1  START  WITH  1;
create table BAS_STUDENT
(
  ID             integer        NOT NULL,       --(����)ѧԱ��Ϣ��ʶ��
  IDTYPE         varchar2(1)    NOT NULL,       --ѧԱ���֤������(�ֵ䡾2002��)
  IDNUMBER       varchar2(18)   NOT NULL,       --ѧԱ���֤������
  NAME           varchar2(30)   NOT NULL,       --ѧԱ����
  GENDER         varchar2(1)    DEFAULT '9',    --ѧԱ�Ա�(�ֵ䡾2001��)
  DRIVER_LICENSE_TYPE varchar2(2),              --��ʻ֤����/���Գ���(�ֵ䡾2003��) ����������ѵ��������BAS_BOOKING.DRIVER_LICENSE_TYPEΪ׼
  STATUS         varchar2(1)   DEFAULT '0',     --ѧԱ״̬(�ֵ䡾1036)����0����ѧϰ��1��ѧϰ��ֹ��2:ѧϰ��ͣ)
  SCHOOL_NAME    varchar2(200),                 --��У���ƣ���������ѵ�������뿼��
  PASSWORD       varchar2(40),                  --ѧԱ����ʶ��
  PHOTO1         BLOB,                          --ѧԱ��Ƭ-��(�ӿ����ص���Ƭ)
  PHOTO2         BLOB,                          --ѧԱ��Ƭ-��(ǩ��ʱ�ɼ�����Ƭ�������ĺ�һ������Ƭ��ʾ�ıȶ�)
  FINGERPRINT1   CLOB,                          --ѧԱָ��1ʶ��
  FINGERPRINT2   CLOB,                          --ѧԱָ��2ʶ��
  FINGERPRINT3   CLOB,                          --ѧԱָ��3ʶ��
  FINGERPRINT4   CLOB,                          --ѧԱָ��4ʶ��
  CREATE_TIME    varchar2(14)   NOT NULL, --����ʱ��(��ʽ��yyyymmddhhmmss)
  UPDATE_TIME    varchar2(14)   NOT NULL, --����ʱ��(��ʽ��yyyymmddhhmmss)      
  UNIQUE(IDNUMBER),
  primary key(ID)
);

/*
 * ���壺ԤԼ��
 * �����ƣ�BAS_BOOKING
 * ��ռ䣺TNZC_DATA  
 * ����𣺻������
 * ���ܣ����ڿ���ʱ��¼�ɹ��������صĿ���ԤԼ��Ϣ����ѧԱ����һ�Զ�Ĺ�ϵ(ԤԼ��ϢӦ���ǵ�����)��ID,STUDENT_ID��Ϊ����ΨһԼ��
 */
CREATE SEQUENCE SEQU_BAS_BOOKING_ID INCREMENT BY 1  START  WITH  1; 
create table BAS_BOOKING
(  
  ID                       integer        NOT NULL,              --(����)���
  STATUS					integer,							--1��ʾ��ȡ����0��null��ʾ��Ч
  SEQUENCENUMBER           varchar2(13)   NOT NULL,              --��ˮ��
  SUBJECT                  varchar2(1)    NOT NULL,              --���Կ�Ŀ(�ֵ䡾1006��)
  EXAMNUMBER               varchar2(12)   NOT NULL,              --ѧԱ׼��֤����
  STUDENT_ID               integer        NOT NULL,              --ѧԱ��Ϣ��ʶ���������BAS_STUDENT��ID
  EXAM_REASON              varchar2(1)    DEFAULT 'A' NOT NULL,  --����ԭ��(�ֵ䡾1007��)
  STUDY_TIME               integer        DEFAULT 0,             --ѧϰʱ�䣬��Ϊ0��ʾԤԼ��ʱѵ������λ����
  BOOKING_DATETIME         varchar2(14)   NOT NULL,              --ԤԼ����ʱ��(��ʽ:yyyymmddhhmmss)��hhmmssΪԤԼʱ��Ƭ��ʼʱ��
  BOOKING_TIMES            integer        DEFAULT 0,             --ԤԼ��������ʱѵ���̶�Ϊ0
  BOOKING_EXAM_DATE        varchar2(8)    NOT NULL,              --Լ������(��ʽ:yyyymmdd)
  DRIVER_LICENSE_TYPE      varchar2(2)    NOT NULL,              --��ʻ֤����/���Գ���(�ֵ䡾2003��) ������ģʽ��д��BAS_STUDENT.DRIVER_LICENSE_TYPE��ʵ��ʹ����BAS_STUDENT.DRIVER_LICENSE_TYPEΪ׼
  PLACE_ID                 integer       NOT NULL,              --���Եص㣬�����BAS_PLACE��ID
  EXAM_SESSION             integer        DEFAULT 0 NOT NULL,    --���Գ���(�ֵ䡾1014��)
  CAR_ID       integer,         --���Գ���,�����BAS_CAR��ID
  OPERATOR_NAME            varchar2(30)   NOT NULL,              --������
  BRANCH_ADMINISTRATION    varchar2(12)   NOT NULL,              --������
  SCHOOL_ID                integer,                              --������/��У���룬�����BAS_DRIVING_SCHOOL��ID
  EXAM_DATE                varchar2(8),                          --��������(��ʽ:yyyymmdd)
  EXAM_TIMES               integer        DEFAULT 0,             --���Դ���
  EXAMINER1_ID             integer,                            --����Ա1,�����BAS_EXAMINER��ID
  EXAMINER2_ID             integer,                     --����Ա2,�����BAS_EXAMINER��ID
  EXAM_STATUS              integer        DEFAULT 0 NOT NULL,    --����״̬(�ֵ䡾1008��)
  TRAINING_AUDIT_DATE      varchar2(8),                          --��ѵ�������(��ʽ:yyyymmdd)
  IS_NIGHT_EXAM            integer        DEFAULT 0,             --�Ƿ�ҹ��(0��1��)
  PILE_EXAM_BOOKING_DATE   varchar2(8),                          --׮��Լ������(��ʽ:yyyymmdd)
  PILE_EXAM_STATUS         integer        DEFAULT 0,             --׮���Ƿ�ϸ�(�ֵ䡾1008��)
  CAR_BREED                varchar2(10),                         --��������
  COACH                    varchar2(30),                         --����Ա
  PILE_EXAM_DEDUCT_SCORE   integer        DEFAULT 0,             --׮���۷�
  IS_PLACE_EXAM            integer        DEFAULT 0  NOT NULL,   --�����Ƿ���Լ(�ֵ䡾1009����0δԤԼ��1��ԤԼ)
  BRANCH_BUSINESS          varchar2(12)   NOT NULL,              --ҵ�������
  SIGN_STATUS              varchar2(1)    DEFAULT '0',           --ǩ��״̬(�ֵ䡾1031����0δǩ����1��ǩ��)
  UPDATE_TIME              varchar2(14),                         --����ʱ��(��ʽ:yyyymmddhhmmss)      
  UNIQUE(SEQUENCENUMBER,STUDENT_ID),
  primary key(ID)
);

/*
 * ���壺������Ϣ��
 * �����ƣ�BUZ_EXAM_INFO
 * ��ռ䣺TNZC_DATA  
 * �����ҵ�����
 * ���ܣ����ڼ�¼ѧԱ������Ϣ
 */
CREATE SEQUENCE SEQU_BUZ_EXAM_INFO_ID INCREMENT BY 1  START  WITH  1;
create table BUZ_EXAM_INFO
(
  ID                    integer        NOT NULL,    --(����)������Ϣ��ʶ��
  SUBJECT               varchar2(1)    NOT NULL,    --���Կ�Ŀ(�ֵ䡾1006��)������ɾ������BAS_BOOKING��Ϊ׼
  BOOKING_ID               integer        NOT NULL, --��ˮ�ţ������BAS_BOOKING��ID
  CAR_ID                integer        NOT NULL,    --���Գ����������,�����BAS_CAR��ID�����������Գ������ܺ�ԤԼ��������
  EXAM_START_TIME       varchar2(14),               --���Կ�ʼʱ��(��ʽ:yyyymmddhhmmss)
  EXAM_END_TIME         varchar2(14),               --���Խ���ʱ��(��ʽ:yyyymmddhhmmss)
  CURRENT_EXAM_TIMES    integer,                    --��ǰ���Դ���
  CURRENT_EXAM_SCORE    integer,                    --��ǰ���Է���
  EXAM_STATUS           integer   DEFAULT 0 NOT NULL, --����״̬(�ֵ䡾1008��)
  CONTRAIL_PATH         varchar2(256),               --���й켣�����ļ�����·��
  VIDEO_PATH            varchar2(256),               --��Ƶ�����ļ�����·��
  HASH                  varchar2(40)    NOT NULL,    --У��λ(sha1���ܣ���֤��Ϣ������)
  primary key(ID)
); 

/*
 * ���壺���Թ��̱�
 * �����ƣ�BUZ_EXAM_PROCESS
 * ��ռ䣺TNZC_DATA  
 * �����ҵ�����
 * ���ܣ����ڼ�¼ѧԱ���Թ�����ϸ��Ϣ���뿼����Ϣ����һ�Զ�Ĺ�ϵ
 */
CREATE SEQUENCE SEQU_BUZ_EXAM_PROCESS_ID INCREMENT BY 1  START  WITH  1;
create table BUZ_EXAM_PROCESS
(
  ID                integer          NOT NULL,    --(����)��� 
  EXAM_ID           integer          NOT NULL,    --������Ϣ��ʶ��,�����BUZ_EXAM_INFO��ID
  PROCESS_FLAG      varchar2(2)      NOT NULL,    --���Թ��̱�ʶ(�ֵ䡾1024��)
  PROCESS_TYPE      varchar2(3)      NOT NULL,    --���Թ�������(�ֵ䡾1025��)
  EXAM_ITEM         varchar2(5),                  --������Ŀ�������CFG_ITEMS��ITEM_CODE������GRADE=2���ֵ䡾1024��ֵΪPPʱ����Ϊ��  
  DEDUCT_ITEM       varchar2(5),                  --�۷���Ŀ�������CFG_ITEMS��ITEM_CODE������GRADE=3  
  DEDUCT_SCORE      integer,                      --�۳�������(���ҽ����ֵ䡾1025��ֵ����C53ʱд������) 
  DEVICE_ID         integer,                      --�豸��ţ������BAS_DEVICE��ID(���ҽ����ֵ䡾1025��ֵ����C52ʱд������)
  PROCESS_PHOTO     BLOB,                         --����ͼƬ��(���ҽ����ֵ䡾1025��ֵ����C51\C54\C56ʱд������)  
  SPEED             integer         DEFAULT 0,    --����
  RECORD_TYPE       varchar2(1)     DEFAULT '1',  --������¼����(�ֵ䡾1026��)(���ҽ����ֵ䡾1025��ֵ����C55ʱд������) 
  PROCESS_TIME      varchar2(14)     NOT NULL,    --���̴���ʱ��(��ʽ:yyyymmddhhmmss)
  VIDEO_PATH        varchar2(256),                 --[����]��Ƶ�����ļ�����·��
  PROCESS_STATUS    varchar2(2),                  --����(�ӿ�)����״̬(���PROCESS_TYPE���Թ������ͣ���ѯ�ֵ䡾3001~3006��)
  HASH              varchar2(40)     NOT NULL,    --У��λ(sha1���ܣ���֤��Ϣ������)
  primary key(ID)
); 

CREATE SEQUENCE SEQU_BUZ_SUB2_RECORD_ID INCREMENT BY 1  START  WITH  1;

CREATE TABLE BUZ_SUB2_RECORD
(
	ID NUMBER NOT NULL ENABLE, 
	JDCJSZKSKMDM VARCHAR2(1 BYTE) NOT NULL ENABLE, 
	JDCJSJNZKZMBH VARCHAR2(12 BYTE), 
	XXJSZMBH VARCHAR2(12 BYTE), 
	JTGLYWDXSFZMDM VARCHAR2(3 BYTE) NOT NULL ENABLE, 
	JTGLYWDXSFZMHM VARCHAR2(18 BYTE) NOT NULL ENABLE, 
	XM VARCHAR2(50 BYTE) NOT NULL ENABLE, 
	KSYY VARCHAR2(1 BYTE) DEFAULT 'A' NOT NULL ENABLE, 
	JDCJSZZJCXDM VARCHAR2(2 BYTE) NOT NULL ENABLE, 
	JDCJSZKSKCDM VARCHAR2(64 BYTE) NOT NULL ENABLE, 
	KSCCBH NUMBER(2,0), 
	JDCHPHM VARCHAR2(15 BYTE), 
	JBR VARCHAR2(30 BYTE) NOT NULL ENABLE, 
	GLBM VARCHAR2(2010 BYTE) NOT NULL ENABLE, 
	DLR VARCHAR2(64 BYTE), 
	JDCJSRPXXXDM VARCHAR2(64 BYTE), 
	KSCS NUMBER(2,0), 
	CZY VARCHAR2(30 BYTE), 
	KSY1 VARCHAR2(30 BYTE), 
	KSY2 VARCHAR2(30 BYTE), 
	KSCJ NUMBER(3,0), 
	KSQSSJ VARCHAR2(14 BYTE), 
	KSJSSJ VARCHAR2(14 BYTE), 
	XKXM VARCHAR2(64 BYTE), 
	ZHPPKF NUMBER(3,0), 
	ZKKF NUMBER(3,0), 
	PDDDKF NUMBER(3,0), 
	CFTCKF NUMBER(3,0), 
	DBQKF NUMBER(3,0), 
	QXXSKF NUMBER(3,0), 
	ZJZWKF NUMBER(3,0), 
	XKMKF NUMBER(3,0), 
	LXZAKF NUMBER(3,0), 
	QFLKF NUMBER(3,0), 
	ZLDTKF NUMBER(3,0), 
	GSKF NUMBER(3,0), 
	LXJWKF NUMBER(3,0), 
	SDKF NUMBER(3,0), 
	YWKF NUMBER(3,0), 
	SHKF NUMBER(3,0), 
	JJQKF NUMBER(3,0), 
	ZXXM1 VARCHAR2(30 BYTE), 
	ZXXM2 VARCHAR2(30 BYTE), 
	ZXXM3 VARCHAR2(30 BYTE), 
	ZXXM1KF NUMBER(3,0), 
	ZXXM2KF NUMBER(3,0), 
	ZXXM3KF NUMBER(3,0), 
	JYW VARCHAR2(256 BYTE) NOT NULL ENABLE, 
	KSCXH VARCHAR2(8 BYTE) NOT NULL ENABLE, 
	KSZT VARCHAR2(1 BYTE), 
	PRIMARY KEY (ID)
);
COMMENT ON COLUMN BUZ_SUB2_RECORD.ID is '����';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCJSZKSKMDM is '���Կ�Ŀ(�ֵ䡾1006��)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCJSJNZKZMBH is '׼��֤�����';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.XXJSZMBH is 'ѧϰ��ʻ֤�����';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JTGLYWDXSFZMDM is 'ѧԱ���֤������(�ֵ䡾2002��)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JTGLYWDXSFZMHM is '���֤������';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.XM is '����';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSYY is '����ԭ��(�ֵ䡾1007��)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCJSZZJCXDM is '��ʻ֤����/���Գ���(�ֵ䡾2003��)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCJSZKSKCDM is '��������';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSCCBH is '���Գ���(�ֵ䡾1014��)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCHPHM is '���Գ������ƺ���';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JBR is '������';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.GLBM is '������';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.DLR is '�����ˣ���У���룩';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCJSRPXXXDM is '��У����';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSCS is '���Դ���';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.CZY is '����Ա';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSY1 is '����Ա1';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSY2 is '����Ա2';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSCJ is '���Գɼ�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSQSSJ is '������ʼʱ��(��ʽ:yyyymmddhhmmss)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSJSSJ is '���Խ���ʱ��(��ʽ:yyyymmddhhmmss)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.XKXM is 'ѡ����Ŀ';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZHPPKF is '�ۺ����п۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZKKF is '��������׮���۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.PDDDKF is '�µ�����ͣ�����𲽿۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.CFTCKF is '�෽ͣ���۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.DBQKF is 'ͨ�������ſ۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.QXXSKF is '������ʻ�۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZJZWKF is 'ֱ��ת��۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.XKMKF is 'ͨ���޿��ſ۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.LXZAKF is 'ͨ�������ϰ��۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.QFLKF is '���·��ʻ�۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZLDTKF is 'խ·��ͷ�۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.GSKF is 'ģ����ٹ�·��ʻ�۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.LXJWKF is 'ģ����������ɽ��·��ʻ�۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.SDKF is 'ģ�������ʻ�۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.YWKF is 'ģ����(������ʻ�۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.SHKF is 'ģ��ʪ��·��ʻ�۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JJQKF is 'ģ�����������ÿ۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM1 is '�ط���ѡ��Ŀ1';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM2 is '�ط���ѡ��Ŀ2';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM3 is '�ط���ѡ��Ŀ3';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM1KF is '�ط���ѡ��Ŀ1�۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM2KF is '�ط���ѡ��Ŀ2�۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM3KF is '�ط���ѡ��Ŀ3�۷�';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JYW is 'Ч��λ';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSCXH is '���Գ����������';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSZT is '����״̬(�ֵ䡾1008��)';
 

/*
 * ���壺֧����ˮ��
 * �����ƣ�BUZ_PAYMENT_DETAIL
 * ��ռ䣺TNZC_DATA  
 * �����ҵ�����5
 * ���ܣ����ڼ�¼ѧԱ��ģ�⿼����ϰ��ѵ��ʱ����ϸ֧����Ϣ,TRADE_NO��Ϊ����ΨһԼ��
 */
CREATE SEQUENCE SEQU_BUZ_PAYMENT_DETAIL_ID INCREMENT BY 1  START  WITH  1;
create table BUZ_PAYMENT_DETAIL
(
	ID					integer			NOT NULL,			--(����)���к�
	TRADE_NO			varchar2(32)	NOT NULL,			--�̻�������
	PAY_TIME			varchar2(14)	NOT NULL,			--֧��ʱ��(��ʽ:yyyymmddhhmmss��֧���ɹ����¼)  
	OPERATOR_NAME		varchar2(20)	NOT NULL,			--����������
	OPERATOR_IDNUMBER	varchar2(18)	NOT NULL,			--���������֤������
	STUDENT_IDNUMBER	varchar2(18)	NOT NULL,			--ѧԱ���֤������
	SUBJECT				varchar2(1)		NOT NULL,			--���Կ�Ŀ-�ֵ䡾1006��
	FEE_TYPE			varchar2(8)		NOT NULL,			--�Ʒ�����(�ֵ䡾1002��)
	TIMES				integer			NOT NULL,			--ԤԼ����/ʱ�䣨���ӣ�
	AMOUNT				number(8,2)		NOT NULL,			--���
	PAYMENT_WAY			varchar2(8)		NOT NULL,			--֧����ʽ(�ֵ䡾1001��WXPAY-΢��֧����ALIPAY-֧����֧����UNIONPAY-������֧����OTHERPAY-����֧��)
	BOOKING_ID			number			NOT NULL,			--ԤԼ��¼�������BAS_BOOKING��ID
	PRICING_STRATEGY	varchar2(200)	NOT NULL,			--���۲���
	HASH				varchar2(40)	NOT NULL,			--У��λ(sha1���ܣ���֤��Ϣ������)
	UNIQUE(TRADE_NO),
	primary key(ID)             
);


/*
 * ���壺�����쳣���̴����
 * �����ƣ�BUZ_ABNORMAL_PROCESS
 * ��ռ䣺TNZC_DATA  
 * �����ҵ�����
 * ���ܣ����ڼ�¼ѧԱ���Թ����쳣������ϸ��Ϣ
 */
CREATE SEQUENCE SEQU_BUZ_ABNORMAL_PROCESS_ID INCREMENT BY 1  START  WITH  1;
create table BUZ_ABNORMAL_PROCESS
(
  ID                integer          NOT NULL,    --(����)��� 
  PROCESS_ID		integer          NOT NULL,    --���Թ��̣������BUZ_EXAM_PROCESS��ID
  ABNORMAL_TYPE     varchar2(1)      NOT NULL,    --�쳣����(�ֵ䡾1034��=1ʱ��ȡ�ֵ䡾1032����=2ʱ��ȡ�ֵ䡾1033��)
  OCCURRENCE_TIME	varchar2(6)      NOT NULL,    --����ʱ��(��ʽ��hhmmss)
  EXAMINER_ID		integer,                      --����Ա�������BAS_EXAMINER��ID
  USER_ID           integer,                      --����Ա�������SYS_USER��ID
  PROCESS_TYPE      varchar2(1)      NOT NULL,    --�쳣���̴�������(�ֵ䡾1034��)
  MEMO              varchar2(200),                --ԭ��
  CREATE_TIME       varchar2(14)     NOT NULL,    --����ʱ��(��ʽ��yyyymmddhhmmss)
  HASH              varchar2(40)     NOT NULL,    --У��λ(sha1���ܣ���֤��Ϣ������)
  primary key(ID)
); 

CREATE SEQUENCE SEQU_CFG_DICT_ID INCREMENT BY 1  START  WITH  1; 
create table CFG_DICT
(
	ID					integer			NOT NULL,			--(����)���к�
	DICT_TYPE			integer			NOT NULL,			--�ֵ�����
	DICT_CODE			varchar2(20)	NOT NULL,			--�ֵ����
	DICT_NAME			varchar2(100)	NOT NULL,			--�ֵ�����
	VIEW_INDEX			integer,							--��ʾ˳��
	DICT_MEMO			varchar2(100),						--��ע
	UNIQUE(DICT_TYPE, DICT_CODE),
	primary key(ID)
);

/*
 * ���壺������
 * �����ƣ�CFG_PARAM
 * ��ռ䣺TNZC_DATA  
 * ������������
 * ���ܣ�����ϵͳ�����Ĺ鼯��SUBSYS_ID,PARAM_NAME��Ϊ����ΨһԼ��
 */
CREATE SEQUENCE SEQU_CFG_PARAM_ID INCREMENT BY 1  START  WITH  1;
create table CFG_PARAM
(
  ID              integer        NOT NULL,            --(����)���к�
  SUBSYS_ID       integer        DEFAULT 0 NOT NULL,  --������ϵͳ��1-������ϵͳ��2-��̨������ϵͳ��3-����Ƶ�����ϵͳ....��
  PARAM_GRADE     varchar2(1)    DEFAULT 0 NOT NULL,  --���������ֵ䡾1003����0����������1��̨������2���ز�����
  PARAM_NAME      varchar2(100)   NOT NULL,            --��������
  DISPLAY_NAME    varchar2(50)   NOT NULL,            --��ʾ����
  PARAM_TYPE      varchar2(8)    NOT NULL,            --��������, CHAR,INT,BOOL
  PARAM_VALUE     varchar2(256),                      --����ֵ
  IS_ADMIN_PARAM  integer        DEFAULT 0,           --�Ƿ����Ա����(0��1��)
  MEMO            varchar2(200), --��ע
  UNIQUE(SUBSYS_ID,PARAM_NAME),
  primary key(ID)
);  


/*
*	���ܣ����۲���
*	������ͬһʱ����Ч�Ĳ��Կ����ж�����ɰ����ȼ��Ӹߵ��͵��ӣ�����Ч��ͬһ���ȼ����Բ��ܶ���1�����������޷�Ԥ��
*/
CREATE SEQUENCE SEQU_CFG_PRICING_STRATEGY_ID INCREMENT BY 1  START  WITH  1;
create table CFG_PRICING_STRATEGY
(
	ID					integer			NOT NULL,			--����
	FEE_TYPE			varchar2(8)		NOT NULL,			--�Ʒ�����(�ֵ䡾1002��)
	PRIORITY			integer			NOT NULL,			--���ȼ�����0��ʼ��0���ȼ����
	ACTION				varchar2(3)		NOT NULL,			--������Ϊ��(�ֵ䡾1037����set, add, sub, mul, div)
	AMOUNT				number(8,2)		NOT NULL,			--���
	EFFECTIVE_DATE		varchar2(8)		NULL,				--���۲�����Ч���ڣ�NULL��ʾ������Ч
	EXPIRED_DATE		varchar2(8)		NULL,				--���۲���ʧЧ���ڣ�NULL��ʾ����ʧЧ
	START_DATE			varchar2(8)		NULL,				--��ʼ���ڣ�NULL��ʾ������ʼ
	END_DATE			varchar2(8)		NULL,				--�������ڣ�NULL��ʾ��������
	START_TIME			varchar2(6)		NULL,				--��ʼʱ�䣬NULL��ʾ00:00:00
	END_TIME			varchar2(6)		NULL,				--����ʱ�䣬NULL��ʾ23:59:59
	SCHOOL_NAME			varchar2(256)	NULL,				--��У����
	STUDENT_IDNUMBER	varchar2(18)	NULL,				--ѧԱ����
	REFERENCE_METHOD1	varchar2(2)		NULL,				--�ο�������(�ֵ䡾1038����>, =, <, >=, <=, <>)
	REFERENCE_AMOUNT1	number(8,2)		NULL,				--�ο����
	REFERENCE_RELATION	varchar2(2)		NULL,				--����ο�֮��Ĺ�ϵ��&&, ||
	REFERENCE_METHOD2	varchar2(2)		NULL,				--�ο�������(�ֵ䡾1038����>, =, <, >=, <=, <>)
	REFERENCE_AMOUNT2	number(8,2)		NULL,				--�ο����
	primary key(ID)
);

/*
 * ���壺��Ŀ��
 * �����ƣ�CFG_ITEMS
 * ��ռ䣺TNZC_DATA  
 * ������������
 * ���ܣ����ڹ鼯��Ŀ�۷ִ��룬ITEM_CODE��Ϊ����ΨһԼ��
 */
CREATE SEQUENCE SEQU_CFG_ITEMS_ID INCREMENT BY 1  START  WITH  1;
create table CFG_ITEMS
(
  ID              integer        NOT NULL,               --(����)���к�
  SUBJECT         varchar2(1)    NOT NULL,               --���Կ�Ŀ-�ֵ䡾1006��
  PARENT_CODE     varchar2(5),                           --��Դ����
  ITEM_CODE       varchar2(5)    NOT NULL,               --��Ŀ����
  ITEM_NAME       varchar2(200)  NOT NULL,               --��Ŀ����
  DEDUCT_SCORE    integer,                               --�۳�����
  GRADE           integer        DEFAULT 1 NOT NULL,     --����(1��-��Ŀ�ۺ�/ר�2��-ר�3��-�۷�)
  UNIQUE(ITEM_CODE),
  primary key(ID)
); 

/*
 * ���壺��ͼ��
 * �����ƣ�CFG_MAPS
 * ��ռ䣺TNZC_DATA  
 * ������������
 * ���ܣ����ڹ鼯���ص�ͼ��Ϣ��EXAM_ITEM,MAPNUMBER��Ϊ����ΨһԼ��
 */
CREATE SEQUENCE SEQU_CFG_MAPS_ID INCREMENT BY 1  START  WITH  1;
create table CFG_MAPS
(
  ID                       integer        NOT NULL,    --(����)���к�  
  SUBJECT                  varchar2(1)    NOT NULL,    --���Կ�Ŀ(�ֵ䡾1006��)      
  EXAM_ITEM                varchar2(5)            ,    --������Ŀ����Ŀ��ʱ������Ϊ�գ������CFG_ITEMS��ITEM_CODE������GRADE=2  
  DRIVER_LICENSE_TYPE      varchar2(2)            ,    --��ʻ֤����(�ֵ䡾2003��)
  MAPNUMBER                varchar2(2)    NOT NULL,    --��ͼ���
  NAME                     varchar2(8)    NOT NULL,    --��ͼ����(�����������1���������2���������3��....)
  MAP                      BLOB,                       --��ͼ  
  MEMO                     varchar2(200),  --��ע
  UNIQUE(EXAM_ITEM,MAPNUMBER),
  primary key(ID)
); 

/*
 * ���壺��Ƶ��
 * �����ƣ�CFG_VIDEO
 * ��ռ䣺TNZC_DATA  
 * ������������
 * ���ܣ��������ó������ͼ��Ӧ����Ƶ�豸��Ϣ��IP��Ϊ����ΨһԼ��
 */
CREATE SEQUENCE SEQU_CFG_VIDEO_ID INCREMENT BY 1  START  WITH  1;
create table CFG_VIDEO
(
  ID            integer        NOT NULL,    --(����)���к�
  IP            varchar2(15)   NOT NULL,    --��Ƶ�豸IP
  VUSER         varchar2(30)   NOT NULL,    --��Ƶ�豸��¼�û�
  PASSWORD      varchar2(50)   NOT NULL,    --��Ƶ�豸��¼����(DES����)
  PORT          varchar2(8),                --��Ƶ�豸�˿�
  ASCRIPTION    varchar2(2)    NOT NULL,    --�豸��������(�ֵ䡾1030��)
  SUBJECT       varchar2(1)    NOT NULL,    --���Կ�Ŀ(�ֵ䡾1006��)      
  ITEM          integer        NOT NULL,    --������Ŀ(�ֵ䡾1030��ΪCʱ�������BAS_CAR��ID;ΪMʱ�������CFG_MAPS��ID) 
  DEVICE_ID     integer,    --�����豸���,�����BAS_DEVICE��ID  
  UNIQUE(IP),
  primary key(ID)
);

/*
 * ���壺FTP��
 * �����ƣ�CFG_FTP
 * ��ռ䣺TNZC_DATA  
 * ������������
 * ���ܣ���������FTP������Ϣ��IP��Ϊ����ΨһԼ��
 */
create table CFG_FTP
(
  IP           varchar2(15)   NOT NULL,    --FTP��ַIP
  FUSER        varchar2(30)   NOT NULL,    --FTP��¼�û�
  PASSWORD     varchar2(50)   NOT NULL,    --FTP��¼����(DES��/����)
  PORT         varchar2(8),                --FTP�˿�
  ROOTPATH     varchar2(100),              --��Ŀ¼
  VIDEOPATH    varchar2(100),              --��Ƶ��Ŀ¼      
  DOCUMENTPATH varchar2(100),              --�ĵ���Ŀ¼
  UNIQUE(IP)
);

/*
 * ���壺׼�ݳ����뿼����Ŀ��Ӧ��
 * �����ƣ�CFG_DRIVER_LICENSE_ITEMS
 * ��ռ䣺TNZC_DATA  
 * ������������
 * ���ܣ����ڶ�ÿ�����Գ���(��ʻ֤����)�������Ŀ�����Ŀ��DRIVER_LICENSE_TYPE,EXAM_ITEM��Ϊ����ΨһԼ��
 */
CREATE SEQUENCE SEQU_CFG_DRIV_LICENSE_ITEMS_ID INCREMENT BY 1  START  WITH  1;
create table CFG_DRIVER_LICENSE_ITEMS
(
  ID                       integer        NOT NULL,      --(����)���к�
  DRIVER_LICENSE_TYPE      varchar2(2)    NOT NULL,      --��ʻ֤����(�ֵ䡾2003��)     
  EXAM_ITEM                varchar2(5)    NOT NULL,      --������Ŀ�������CFG_ITEMS��ITEM_CODE������GRADE=2
  UNIQUE(DRIVER_LICENSE_TYPE,EXAM_ITEM),
  primary key(ID)
);

create table SYS_TERMINAL_LIST
(
  MAC			varchar2(20)	NOT NULL,		--MAC��ַ
  IP			varchar2(15),					--IP��ַ
  FAILURE_TIMES	number(2,0) DEFAULT 0 NOT NULL,	--�ն˵�¼����ʧ�ܴ���(����CFG_PARAM��������ݼ��������ֵ����,������ֵ���û�����)
  LOCK_TIME		varchar2(14),					--����ʱ��
  MAX_FAILURE_COUNT number(2,0),				--�ն˵�¼����ʧ�ܴ������ޣ���Ϊ�գ�ʹ��CFG_PARAM�е�DEFAULT_TERMINAL_MAX_FAILURE_COUNT
  LOCK_DURATION	number,							--�ն�����ʱ�䣨���ӣ�����Ϊ�գ�ʹ��CFG_PARAM��TERMINAL_LOCK_DURATION
  primary key(MAC)
);

/*
 * ���壺�û���
 * �����ƣ�SYS_USER
 * ��ռ䣺TNZC_DATA  
 * �����ϵͳ���
 * ���ܣ��Ǽ�ϵͳʹ���ߣ�LOGIN_NAME��IDNUMBER�ֱ���Ϊ����ΨһԼ��
 */
CREATE SEQUENCE SEQU_SYS_USER_ID INCREMENT BY 1 START WITH 1;
create table SYS_USER
(
	ID						integer,						--(����)�û���ʶ��ID
	LOGIN_NAME				varchar2(20) NOT NULL,			--�û���¼��
	PASSWORD				varchar2(200),					--�û���¼���룺DES(SHA1(PASSWORD_PLAIN_TEXT)||LOGIN_NAME||USER_NAME||IDNUMBER)
	USER_NAME				varchar2(20) NOT NULL,			--�û�����
	GENDER					varchar2(1) DEFAULT '9',		--�û��Ա�(�ֵ䡾2001��)
	IDNUMBER				varchar2(18) NOT NULL,			--�û����֤����  
	USER_FLAG				varchar2(1) DEFAULT 0,			--�û���ʶ(�ֵ䡾1010����0�Ǿ�Ա��1��Ա) 
	USERNUMBER				varchar2(8) NOT NULL,			--�û����(��Ա/Ա�����)  
	FINGERPRINT1			BLOB,							--ѧԱָ��1ʶ��
	ROLE_ID					integer,						--��ɫID�������SYS_ROLE��ROLE_ID  
	FAILURE_TIMES			number(2,0) DEFAULT 0 NOT NULL,	--�û���¼����ʧ�ܴ���(����CFG_PARAM��������ݼ��������ֵ����,������ֵ���û�����)
	MAX_FAILURE_COUNT		number(2,0),					--�û���¼����ʧ�ܴ������ޣ���Ϊ�գ�ʹ��CFG_PARAM�е�DEFAULT_USER_MAX_FAILURE_COUNT
	STATUS					varchar2(1) DEFAULT 0,			--�û���¼״̬��ʶ(�ֵ䡾1013�� 0δ��¼��1�ѵ�¼),����һ���û���ص�¼���ƣ����δ�˳��ͻ�������¼���������ǩ�ˡ�
	PASSWORD_MODIFY_DATE	varchar2(8) NOT NULL,			--�����޸�����(��ʽ:yyyymmdd,����CFG_PARAM������������Ч����ֵ����,������ֵ��ǿ�Ƹ�������)  
	ENABLE_DATE				varchar2(8),					--�û���������(��ʽ:yyyymmdd)
	DISABLE_DATE			varchar2(8),					--�û�ͣ������(��ʽ:yyyymmdd)
	QUALIFIED_START_TIME	varchar2(6),					--�����¼��ʼʱ��(��ʽ:hhmmss)
	QUALIFIED_END_TIME		varchar2(6),					--�����¼����ʱ��(��ʽ:hhmmss)  
	QUALIFIED_ADDRESS_LIST	varchar2(256),					--�����¼��IP/MAC��ַ�б�:192.168.1.100(10:20:30:40:50:60)
	UNIQUE(LOGIN_NAME),
	UNIQUE(IDNUMBER),
	UNIQUE(USER_FLAG,USERNUMBER),
	primary key(ID)    
);
 
CREATE SEQUENCE SEQU_SYS_ROLE_ID INCREMENT BY 1 START WITH 1;
create table SYS_ROLE
(
	ID					integer,							--(����)��ɫ��ʶ��ID
	NAME				varchar2(30)	NOT NULL,			--��ɫ����
	CATEGORY			varchar2(20)	DEFAULT 'BUSINESS' NOT NULL,	--���(�ֵ䡾1039��)
	UNIQUE(NAME),
	primary key(ID)
);

create table SYS_PERMISSION
(
	CODE 				varchar2(4) 	NOT NULL,			--(����)Ȩ�޴���,Ŀǰ�ݶ�4λ,ǰ��λ��ʾִ�в�����ģ�����,ÿ��ģ�����Ԥ����2λ������
	NAME				varchar2(50),						--Ȩ������
	CATEGORY			varchar2(10)	DEFAULT 'BUSINESS',	--���(�ֵ䡾1039��)
	IS_ADMIN			integer			DEFAULT 0 NOT NULL,	--�Ƿ��Ϊ����Աר��Ȩ��(0��1��)
	IS_POLICE			integer			DEFAULT 0 NOT NULL,	--�Ƿ�Ϊ��Աר��Ȩ��(0��1��)
	UNIQUE(NAME),
	primary key(CODE)
);

/*
 * ���壺��ɫ��Ȩ�޶�Ӧ��
 * �����ƣ�SYS_ROLE_PERMISSION
 * ��ռ䣺TNZC_DATA  
 * �����ϵͳ��� 
 * ���ܣ����ڶ�ÿ����ɫ�������Ȩ�ޣ�һ�Զ�Ĺ�ϵ��ROLE_ID,PERMISSION_CODE��Ϊ����ΨһԼ��
 */
create table SYS_ROLE_PERMISSION
(
  ROLE_ID          integer      NOT NULL,  --��ɫID�������SYS_ROLE��ID
  PERMISSION_CODE  varchar2(4)  NOT NULL,  --Ȩ�޴��룬�����SYS_PERMISSION��CODE
  UNIQUE(ROLE_ID,PERMISSION_CODE)
); 

/*
 * ���壺��־��
 * �����ƣ�SYS_LOG
 * ��ռ䣺TNZC_DATA  
 * �����ϵͳ���
 * ���ܣ�������ϸ������־��¼
 */
CREATE SEQUENCE SEQU_SYS_LOG_ID INCREMENT BY 1  START  WITH  1;   
create table SYS_LOG
(
  ID                   integer        NOT NULL,    --(����)��־id  
  USER_ID              integer        NOT NULL,    --�û���ʶ��ID,�����SYS_USER��ID
  TIME       		   varchar2(14)   NOT NULL,    --����ʱ��
  SOURCE               varchar2(30)   NOT NULL,    --����ģ��(��Դ)  
  ACTION               varchar2(14)   NOT NULL,    --������Ϊ(�ֵ䡾1028����¼�����롢�뿪�����ӡ�ɾ�����޸ġ��鿴)
  CONTENT              varchar2(500),              --��������
  RESULT               varchar2(1)    NOT NULL,    --�������(0ʧ�ܣ�1�ɹ�)  
  IP                   varchar2(15),               --����IP
  MAC                  varchar2(50),               --����MAC
  HASH                 varchar2(40)   NOT NULL,    --У��λ(sha1���ܣ���֤��Ϣ������)
  primary key(ID)
);
