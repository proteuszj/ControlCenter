
/*
 * 表定义：考场表
 * 表名称：BAS_PLACE
 * 表空间：TNZC_DATA  
 * 表类别：基础类表
 * 功能：用于记录由公安网下载的考场信息，CODE作为单列唯一约束
 */
--当模拟与训练模式时，用此序列;考试时取下载的序号即可
CREATE SEQUENCE SEQU_BAS_PLACE_ID INCREMENT BY 1  START  WITH  1;  
create table BAS_PLACE
(
  ID                        integer        NOT NULL,              --(主键)序号
  SEQUENCENUMBER            varchar2(8)    NOT NULL,      --场地序号
  CODE                      varchar2(64)   NOT NULL,              --考场代码
  NAME                      varchar2(128)  NOT NULL,              --考场名称
  SUBJECT                   varchar2(1)    NOT NULL,              --考试科目(字典【1006】)
  QUALIFIED_CAR_TYPE         varchar2(24)   NOT NULL,              --适用准驾车型范围
  ISSUING_AUTHORITY         varchar2(10)   NOT NULL,              --发证机关 
  BRANCH_ADMINISTRATION     varchar2(12)   NOT NULL,              --管理部门
  BUSINESS_TYPE             varchar2(10),                         --适用业务类型范围
  ACCEPTANCE_DATE           varchar2(8)    NOT NULL,              --总队验收日期(格式:yyyymmdd)
  ACCEPTER                  varchar2(32),                         --验收人
  RESERVATION_MODE          varchar2(1)    NOT NULL,              --[科目二]预约模式(字典【1017】)
  GROUPING_MODE             varchar2(1)    NOT NULL,              --分组模式(字典【1018】)
  CAPACITY                  integer        DEFAULT 0 NOT NULL,    --考试人数限制
  PILE_EXAM_CAPACITY        integer        DEFAULT 0 NOT NULL,    --科目二桩考人数限制
  PLACE_EXAM_CAPACITY       integer        DEFAULT 0 NOT NULL,    --科目二场考人数限制
  PILE_EXAM_JUDGING         varchar2(1)    DEFAULT '1' NOT NULL,  --桩考评判方式(字典【1019】)
  PLACE_EXAM_JUDGING        varchar2(1)    DEFAULT '1' NOT NULL,  --场考评判方式(字典【1019】)
  PILE_EXAM_NETWORK_TIME    varchar2(14),                         --桩考开始联网时间(格式：yyyymmddhhmmss)
  PLACE_EXAM_NETWORK_TIME   varchar2(14),                         --场考开始联网时间(格式：yyyymmddhhmmss)
  STATUS                    varchar2(1)    DEFAULT 'A' NOT NULL,  --场地使用状态(字典【1016】) 
  PILE_EXAM_DEVICE_COUNT    integer        DEFAULT 0,             --桩考设备数
  PLACE_EXAM_DEVICE_COUNT   integer        DEFAULT 0,             --场考设备数
  EXAM_CAR_TOTAL_COUNT      integer        DEFAULT 0,             --考场考试车辆数
  PLACE_AREA                integer        DEFAULT 0,             --考场面积
  ROADWAY_LENGTH            integer        DEFAULT 0,             --考场车道总长度
  EXAM_CAR_COUNT            integer        DEFAULT 0,             --考场同时考试车辆数
  CREATE_TIME               varchar2(14)   NOT NULL,              --创建时间(格式：yyyymmddhhmmss) 
  UPDATE_TIME               varchar2(14)   NOT NULL,              --更新时间(格式：yyyymmddhhmmss)  
  UNIQUE(CODE),
  primary key(ID)
);

/*
 * 表定义：设备表
 * 表名称：BAS_DEVICE
 * 表空间：TNZC_DATA  
 * 表类别：基础类表
 * 功能：用于记录由公安网下载的考试设备信息，DEVICENUMBER作为单列唯一约束
 */
--当模拟与训练模式时，用此序列;考试时取下载的序号即可
CREATE SEQUENCE SEQU_BAS_DEVICE_ID INCREMENT BY 1  START  WITH  1;  
create table BAS_DEVICE
(
  ID                     integer  NOT NULL,              --(主键)序号
  SEQUENCENUMBER         varchar2(8)    NOT NULL,              --设备序号
  DEVICENUMBER           varchar2(10)   NOT NULL,              --设备编号
  DESCRIPTION            varchar2(512)  NOT NULL,              --设备描述
  MANUFACTURER           varchar2(512)  NOT NULL,              --制造厂商
  SERIALNUMBER           varchar2(512)  NOT NULL,              --设备型号  
  EXAM_ITEM              varchar2(5)    NOT NULL,              --考试项目，外键与CFG_ITEMS表ITEM_CODE，条件GRADE=2  
  EXAM_ITEM_NAME         varchar2(256)  NOT NULL,              --考试项目说明
  JUDGING_TYPE           varchar2(1)    DEFAULT '0' NOT NULL,  --评判方式(与字典【1019】正好相反0-自动；1-人工)
  PLACE_ID               integer        NOT NULL,              --考场序号，外键与BAS_PLACE表ID
  QUALIFIED_CAR_TYPE      varchar2(30)   NOT NULL,              --适用准驾车型范围
  ACCEPTANCE_DATE        varchar2(8)    NOT NULL,              --验收日期(格式:yyyymmdd)
  EXPIRE_DATE            varchar2(8)    NOT NULL,              --有效截止日期(格式：yyyymmdd) 
  SINGLE_EXAM_TIMES      integer        NOT NULL,              --备案单次考试时间
  HOURLY_EXAM_TIMES      integer,                              --备案每小时考试人次
  STATUS                 varchar2(1)    NOT NULL,              --使用状态(字典【1022】)
  CREATE_TIME            varchar2(14)   NOT NULL,              --创建时间(格式：yyyymmddhhmmss)
  UPDATE_TIME            varchar2(14)   NOT NULL,              --更新时间(格式：yyyymmddhhmmss) 
  UNIQUE(DEVICENUMBER),
  primary key(ID)
);

/*
 * 表定义：车辆表
 * 表名称：BAS_CAR
 * 表空间：TNZC_DATA  
 * 表类别：基础类表
 * 功能：用于记录由公安网下载的考试车辆信息，LICENSE_PLATE作为单列唯一约束
 */
--当模拟与训练模式时，用此序列;考试时取下载的序号即可 
CREATE SEQUENCE SEQU_BAS_CAR_ID INCREMENT BY 1  START  WITH  1;  
create table BAS_CAR
(
  ID                      integer   NOT NULL,      --(主键)序号
  SEQUENCENUMBER    varchar2(8)    NOT NULL,      --车辆序号
  LICENSE_PLATE           varchar2(15)   NOT NULL,      --车辆号牌号码
  SUBJECT                 varchar2(1)    NOT NULL,      --考试科目(字典【1006】)
  LICENSE_PLATE_TYPE      varchar2(2)    NOT NULL,      --号牌种类(字典【2006】)
  CARNUMBER               varchar2(3),                  --车辆编号(主要用于排队叫号投显用，也可用车牌号码，可根据客户需求调整)
  QUALIFIED_CAR_TYPE       varchar2(15)   NOT NULL,      --适用准驾车型范围
  CAR_TYPE                varchar2(3)    NOT NULL,      --车辆类型(字典【2004】)
  BRAND                   varchar2(32)   NOT NULL,      --车辆品牌
  REGISTER_DATE           varchar2(8)    NOT NULL,      --初次登记日期(格式:yyyymmdd)
  SCRAP_DATE              varchar2(8)    NOT NULL,      --强制报废期止(格式:yyyymmdd)
  ISSUING_AUTHORITY       varchar2(10)   NOT NULL,      --发证机关
  CAR_STATUS              varchar2(1)    NOT NULL,      --机动车车辆状态(字典【2005】)  
  USE_STATUS              varchar2(1)    NOT NULL,      --车辆使用状态(字典【1016】) 
  AUDITOR                 varchar2(30),                 --审核人
  CAR_IP                  varchar2(15)   NOT NULL,      --车载IP  
  CAR_MAP                 BLOB,                         --车辆轮廓地图  
  CREATE_TIME             varchar2(14)   NOT NULL,      --创建时间(格式：yyyymmddhhmmss)
  UPDATE_TIME             varchar2(14)   NOT NULL,      --更新时间(格式：yyyymmddhhmmss) 
  UNIQUE(LICENSE_PLATE),
  UNIQUE(CAR_IP),
  primary key(ID)
);

/*
 * 表定义：考试员表
 * 表名称：BAS_EXAMINER
 * 表空间：TNZC_DATA  
 * 表类别：基础类表
 * 功能：用于记录由公安网下载的考试员信息，IDNUMBER作为单列唯一约束
 */
--当模拟与训练模式时，用此序列;考试时取下载的序号即可 
CREATE SEQUENCE SEQU_BAS_EXAMINER_ID INCREMENT BY 1  START  WITH  1; 
create table BAS_EXAMINER
(
  ID                        integer        NOT NULL,              --(主键)序号
  SEQUENCENUMBER      varchar2(8)    NOT NULL,      --考试员序号
  IDNUMBER                  varchar2(18)   NOT NULL,              --考试员身份证明号码
  IDTYPE                    varchar2(1)    NOT NULL,              --考试员身份证明类型(字典【2002】)
  NAME                      varchar2(30)   NOT NULL,              --考试员姓名
  GENDER                    varchar2(1)    DEFAULT '9' NOT NULL,  --考试员性别(字典【2001】)
  BIRTH_DATE                varchar2(8)    NOT NULL,              --出生日期(格式：yyyymmdd)
  ISSUING_AUTHORITY         varchar2(10)   NOT NULL,              --所属发证机关
  BRANCH_ADMINISTRATION     varchar2(12),                         --管理部门
  ARCHIVESNUMBER            varchar2(12),                         --驾驶证档案编号(符合GA/T 16.21)
  QUALIFIED_CAR_TYPE         varchar2(32)   NOT NULL,              --考试准驾车型范围
  ISSUING_DATE              varchar2(8)    NOT NULL,              --发证日期(格式：yyyymmdd)
  EXPIRE_DATE               varchar2(8)    NOT NULL,              --有效截止日期(格式：yyyymmdd) 
  STATUS                    varchar2(1)    NOT NULL,              --考试员状态(字典【1015】)
  WORK_OFFICE               varchar2(128),                        --工作单位
  OPERATOR_NAME             varchar2(30)   NOT NULL,              --经办人
  ISSUING_OFFICE            varchar2(64)   NOT NULL,              --考试员证发证单位
  CREATE_TIME               varchar2(14)   NOT NULL,              --创建时间(格式：yyyymmddhhmmss)
  UPDATE_TIME               varchar2(14)   NOT NULL,              --更新时间(格式：yyyymmddhhmmss) 
  UNIQUE(IDNUMBER),
  primary key(ID)
);

/*
 * 表定义：驾校表
 * 表名称：BAS_DRIVING_SCHOOL
 * 表空间：TNZC_DATA  
 * 表类别：基础类表
 * 功能：用于记录由公安网下载的驾校信息，CODE作为单列唯一约束
 */
--当模拟与训练模式时，用此序列;考试时取下载的序号即可
CREATE SEQUENCE SEQU_BAS_DRIVING_SCHOOL_ID INCREMENT BY 1  START  WITH  1;  
create table BAS_DRIVING_SCHOOL
(
  ID                     integer      NOT NULL,              --(主键)序号
  SEQUENCENUMBER         varchar2(8)    NOT NULL,                --驾校序号 
  CODE                   varchar2(8)    NOT NULL,              --驾校代码
  NAME                   varchar2(256),                        --驾校名称
  SHORT_NAME             varchar2(64)   NOT NULL,              --驾校简称
  ADDRESS                varchar2(256)  NOT NULL,              --驾校地址
  CONTACT_ADDRESS        varchar2(20)   NOT NULL,              --联系地址
  CONTACT                varchar2(30)   NOT NULL,              --联系人
  CORPORATION            varchar2(30)   NOT NULL,              --法人代表
  REGISTERED_CAPITAL     integer,                              --注册资金
  GRADE                  varchar2(1)    NOT NULL,              --驾校级别(字典【1020】)
  QUALIFIED_CAR_TYPE      varchar2(30),                         --培训准驾车型
  ISSUING_AUTHORITY      varchar2(10),                         --所属发证机关
  STATUS                 varchar2(1)    DEFAULT 'A' NOT NULL,  --驾校状态(字典【1021】)  
  AUDITOR                varchar2(30)   NOT NULL,              --审核人 
  CREATE_TIME            varchar2(14)   NOT NULL,    --创建时间(格式：yyyymmddhhmmss)
  UPDATE_TIME            varchar2(14)   NOT NULL,    --更新时间(格式：yyyymmddhhmmss) 
  UNIQUE(CODE),
  primary key(ID)
);

/*
 * 表定义：计划分组表
 * 表名称：BAS_GROUPING
 * 表空间：TNZC_DATA  
 * 表类别：基础类表
 * 功能：用于记录由公安网下载的考试计划分组信息
 */
--当模拟与训练模式时，用此序列;考试时取下载的序号即可
CREATE SEQUENCE SEQU_BAS_GROUPING_ID INCREMENT BY 1  START  WITH  1;  
create table BAS_GROUPING
(
  ID                        integer                  NOT NULL,    --(主键)
  SEQUENCENUMBER      varchar2(11)             NOT NULL,    --分组序号
  SUBJECT                   varchar2(1)              NOT NULL,    --考试科目(字典【1006】)
  EXAM_DATE                 varchar2(8),                          --考试日期(格式:yyyymmdd)
  PLACE_ID                  integer                  NOT NULL,    --考场序号,外键于BAS_PLACE表ID
  DRIVER_LICENSE_TYPE       varchar2(2)              NOT NULL,    --驾驶证类型/考试车型(字典【2003】) 
  EXAM_SESSION              integer        DEFAULT 0 NOT NULL,    --考试场次(字典【1014】)
  CAR_ID        integer,                --车辆,外键于BAS_CAR表ID
  EXAMINER_ID 	              integer         NOT NULL,    --考试员,外键于BAS_EXAMINER表ID
  BRANCH_ADMINISTRATION     varchar2(12)             NOT NULL,    --管理部门
  EXAM_ITEM                 varchar2(256),                        --考试项目
  CIRCUITRY                 varchar2(10),                         --考试线路
  primary key(ID)
);

/*
 * 表定义：计划分组明细表
 * 表名称：BAS_GROUPING_DETAIL
 * 表空间：TNZC_DATA  
 * 表类别：基础类表
 * 功能：用于记录由公安网下载的考试计划分组明细信息,与计划分组表是一对多的关系,STUDENT_ID作为单列唯一约束
 */
create table BAS_GROUPING_DETAIL
(
  GROUPING_ID         integer      NOT NULL,    --分组序号,外键于BAS_GROUPING表ID
  STUDENT_ID          integer      NOT NULL,    --学员信息标识符,外键于BAS_STUDENT表ID
  SCHOOL_ID           integer,       --代理人/驾校代码,外键于BAS_DRIVING_SCHOOL表ID
  CAR_ID              integer,       --车辆,外键于BAS_CAR表ID
  QUEUE_ORDER         integer,       --排队顺序号(备用于排队叫号)
  QUEUE_STATUS        varchar2(1),   --排队状态(字典【1023】)
  UNIQUE(STUDENT_ID)
);

/*
 * 表定义：学员表
 * 表名称：BAS_STUDENT
 * 表空间：TNZC_DATA  
 * 表类别：基础类表
 * 功能：用于学员基础信息维护，IDNUMBER作为单列唯一约束
 */
CREATE SEQUENCE SEQU_BAS_STUDENT_ID INCREMENT BY 1  START  WITH  1;
create table BAS_STUDENT
(
  ID             integer        NOT NULL,       --(主键)学员信息标识符
  IDTYPE         varchar2(1)    NOT NULL,       --学员身份证明类型(字典【2002】)
  IDNUMBER       varchar2(18)   NOT NULL,       --学员身份证明号码
  NAME           varchar2(30)   NOT NULL,       --学员姓名
  GENDER         varchar2(1)    DEFAULT '9',    --学员性别(字典【2001】)
  DRIVER_LICENSE_TYPE varchar2(2),              --驾驶证类型/考试车型(字典【2003】) ，仅用于培训，考试以BAS_BOOKING.DRIVER_LICENSE_TYPE为准
  STATUS         varchar2(1)   DEFAULT '0',     --学员状态(字典【1036)】，0：在学习；1：学习终止；2:学习暂停)
  SCHOOL_NAME    varchar2(200),                 --驾校名称，仅用于培训，不参与考试
  PASSWORD       varchar2(40),                  --学员密码识别
  PHOTO1         BLOB,                          --学员照片-老(接口下载的照片)
  PHOTO2         BLOB,                          --学员照片-新(签到时采集的照片，用于四合一新老照片显示的比对)
  FINGERPRINT1   CLOB,                          --学员指纹1识别
  FINGERPRINT2   CLOB,                          --学员指纹2识别
  FINGERPRINT3   CLOB,                          --学员指纹3识别
  FINGERPRINT4   CLOB,                          --学员指纹4识别
  CREATE_TIME    varchar2(14)   NOT NULL, --创建时间(格式：yyyymmddhhmmss)
  UPDATE_TIME    varchar2(14)   NOT NULL, --更新时间(格式：yyyymmddhhmmss)      
  UNIQUE(IDNUMBER),
  primary key(ID)
);

/*
 * 表定义：预约表
 * 表名称：BAS_BOOKING
 * 表空间：TNZC_DATA  
 * 表类别：基础类表
 * 功能：用于考试时记录由公安网下载的考试预约信息，与学员表是一对多的关系(预约信息应该是递增的)，ID,STUDENT_ID作为多列唯一约束
 */
CREATE SEQUENCE SEQU_BAS_BOOKING_ID INCREMENT BY 1  START  WITH  1; 
create table BAS_BOOKING
(  
  ID                       integer        NOT NULL,              --(主键)序号
  STATUS					integer,							--1表示已取消，0或null表示有效
  SEQUENCENUMBER           varchar2(13)   NOT NULL,              --流水号
  SUBJECT                  varchar2(1)    NOT NULL,              --考试科目(字典【1006】)
  EXAMNUMBER               varchar2(12)   NOT NULL,              --学员准考证号码
  STUDENT_ID               integer        NOT NULL,              --学员信息标识符，外键于BAS_STUDENT表ID
  EXAM_REASON              varchar2(1)    DEFAULT 'A' NOT NULL,  --考试原因(字典【1007】)
  STUDY_TIME               integer        DEFAULT 0,             --学习时间，不为0表示预约计时训练，单位分钟
  BOOKING_DATETIME         varchar2(14)   NOT NULL,              --预约日期时间(格式:yyyymmddhhmmss)，hhmmss为预约时间片开始时间
  BOOKING_TIMES            integer        DEFAULT 0,             --预约次数，计时训练固定为0
  BOOKING_EXAM_DATE        varchar2(8)    NOT NULL,              --约考日期(格式:yyyymmdd)
  DRIVER_LICENSE_TYPE      varchar2(2)    NOT NULL,              --驾驶证类型/考试车型(字典【2003】) ，考试模式下写入BAS_STUDENT.DRIVER_LICENSE_TYPE，实际使用以BAS_STUDENT.DRIVER_LICENSE_TYPE为准
  PLACE_ID                 integer       NOT NULL,              --考试地点，外键于BAS_PLACE表ID
  EXAM_SESSION             integer        DEFAULT 0 NOT NULL,    --考试场次(字典【1014】)
  CAR_ID       integer,         --考试车辆,外键于BAS_CAR表ID
  OPERATOR_NAME            varchar2(30)   NOT NULL,              --经办人
  BRANCH_ADMINISTRATION    varchar2(12)   NOT NULL,              --管理部门
  SCHOOL_ID                integer,                              --代理人/驾校代码，外键于BAS_DRIVING_SCHOOL表ID
  EXAM_DATE                varchar2(8),                          --考试日期(格式:yyyymmdd)
  EXAM_TIMES               integer        DEFAULT 0,             --考试次数
  EXAMINER1_ID             integer,                            --考试员1,外键于BAS_EXAMINER表ID
  EXAMINER2_ID             integer,                     --考试员2,外键于BAS_EXAMINER表ID
  EXAM_STATUS              integer        DEFAULT 0 NOT NULL,    --考试状态(字典【1008】)
  TRAINING_AUDIT_DATE      varchar2(8),                          --培训审核日期(格式:yyyymmdd)
  IS_NIGHT_EXAM            integer        DEFAULT 0,             --是否夜考(0否、1是)
  PILE_EXAM_BOOKING_DATE   varchar2(8),                          --桩考约考日期(格式:yyyymmdd)
  PILE_EXAM_STATUS         integer        DEFAULT 0,             --桩考是否合格(字典【1008】)
  CAR_BREED                varchar2(10),                         --车辆种类
  COACH                    varchar2(30),                         --教练员
  PILE_EXAM_DEDUCT_SCORE   integer        DEFAULT 0,             --桩考扣分
  IS_PLACE_EXAM            integer        DEFAULT 0  NOT NULL,   --场考是否已约(字典【1009】：0未预约；1已预约)
  BRANCH_BUSINESS          varchar2(12)   NOT NULL,              --业务办理部门
  SIGN_STATUS              varchar2(1)    DEFAULT '0',           --签到状态(字典【1031】：0未签到；1已签到)
  UPDATE_TIME              varchar2(14),                         --更新时间(格式:yyyymmddhhmmss)      
  UNIQUE(SEQUENCENUMBER,STUDENT_ID),
  primary key(ID)
);

/*
 * 表定义：考试信息表
 * 表名称：BUZ_EXAM_INFO
 * 表空间：TNZC_DATA  
 * 表类别：业务类表
 * 功能：用于记录学员考试信息
 */
CREATE SEQUENCE SEQU_BUZ_EXAM_INFO_ID INCREMENT BY 1  START  WITH  1;
create table BUZ_EXAM_INFO
(
  ID                    integer        NOT NULL,    --(主键)考试信息标识符
  SUBJECT               varchar2(1)    NOT NULL,    --考试科目(字典【1006】)，可以删掉，以BAS_BOOKING表为准
  BOOKING_ID               integer        NOT NULL, --流水号，外键于BAS_BOOKING表ID
  CAR_ID                integer        NOT NULL,    --考试车辆备案序号,外键于BAS_CAR表ID，保留，考试车辆可能和预约车辆不符
  EXAM_START_TIME       varchar2(14),               --考试开始时间(格式:yyyymmddhhmmss)
  EXAM_END_TIME         varchar2(14),               --考试结束时间(格式:yyyymmddhhmmss)
  CURRENT_EXAM_TIMES    integer,                    --当前考试次数
  CURRENT_EXAM_SCORE    integer,                    --当前考试分数
  EXAM_STATUS           integer   DEFAULT 0 NOT NULL, --考试状态(字典【1008】)
  CONTRAIL_PATH         varchar2(256),               --运行轨迹数据文件索引路径
  VIDEO_PATH            varchar2(256),               --视频数据文件索引路径
  HASH                  varchar2(40)    NOT NULL,    --校验位(sha1加密，保证信息完整性)
  primary key(ID)
); 

/*
 * 表定义：考试过程表
 * 表名称：BUZ_EXAM_PROCESS
 * 表空间：TNZC_DATA  
 * 表类别：业务类表
 * 功能：用于记录学员考试过程详细信息，与考试信息表是一对多的关系
 */
CREATE SEQUENCE SEQU_BUZ_EXAM_PROCESS_ID INCREMENT BY 1  START  WITH  1;
create table BUZ_EXAM_PROCESS
(
  ID                integer          NOT NULL,    --(主键)序号 
  EXAM_ID           integer          NOT NULL,    --考试信息标识符,外键于BUZ_EXAM_INFO表ID
  PROCESS_FLAG      varchar2(2)      NOT NULL,    --考试过程标识(字典【1024】)
  PROCESS_TYPE      varchar2(3)      NOT NULL,    --考试过程类型(字典【1025】)
  EXAM_ITEM         varchar2(5),                  --考试项目，外键与CFG_ITEMS表ITEM_CODE，条件GRADE=2，字典【1024】值为PP时不能为空  
  DEDUCT_ITEM       varchar2(5),                  --扣分项目，外键与CFG_ITEMS表ITEM_CODE，条件GRADE=3  
  DEDUCT_SCORE      integer,                      --扣除分数，(当且仅当字典【1025】值等于C53时写入数据) 
  DEVICE_ID         integer,                      --设备序号，外键于BAS_DEVICE表ID(当且仅当字典【1025】值等于C52时写入数据)
  PROCESS_PHOTO     BLOB,                         --过程图片，(当且仅当字典【1025】值等于C51\C54\C56时写入数据)  
  SPEED             integer         DEFAULT 0,    --车速
  RECORD_TYPE       varchar2(1)     DEFAULT '1',  --操作记录类型(字典【1026】)(当且仅当字典【1025】值等于C55时写入数据) 
  PROCESS_TIME      varchar2(14)     NOT NULL,    --过程触发时间(格式:yyyymmddhhmmss)
  VIDEO_PATH        varchar2(256),                 --[场地]视频数据文件索引路径
  PROCESS_STATUS    varchar2(2),                  --过程(接口)返回状态(结合PROCESS_TYPE考试过程类型，查询字典【3001~3006】)
  HASH              varchar2(40)     NOT NULL,    --校验位(sha1加密，保证信息完整性)
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
COMMENT ON COLUMN BUZ_SUB2_RECORD.ID is '主键';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCJSZKSKMDM is '考试科目(字典【1006】)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCJSJNZKZMBH is '准考证明编号';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.XXJSZMBH is '学习驾驶证明编号';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JTGLYWDXSFZMDM is '学员身份证明类型(字典【2002】)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JTGLYWDXSFZMHM is '身份证明号码';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.XM is '姓名';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSYY is '考试原因(字典【1007】)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCJSZZJCXDM is '驾驶证类型/考试车型(字典【2003】)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCJSZKSKCDM is '考场代码';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSCCBH is '考试场次(字典【1014】)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCHPHM is '考试车辆号牌号码';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JBR is '经办人';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.GLBM is '管理部门';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.DLR is '代理人（驾校代码）';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JDCJSRPXXXDM is '驾校名称';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSCS is '考试次数';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.CZY is '操作员';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSY1 is '考试员1';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSY2 is '考试员2';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSCJ is '考试成绩';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSQSSJ is '考试起始时间(格式:yyyymmddhhmmss)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSJSSJ is '考试结束时间(格式:yyyymmddhhmmss)';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.XKXM is '选考项目';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZHPPKF is '综合评判扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZKKF is '倒车入库或桩考扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.PDDDKF is '坡道定点停车和起步扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.CFTCKF is '侧方停车扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.DBQKF is '通过单边桥扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.QXXSKF is '曲线行驶扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZJZWKF is '直角转弯扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.XKMKF is '通过限宽门扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.LXZAKF is '通过连续障碍扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.QFLKF is '起伏路行驶扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZLDTKF is '窄路调头扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.GSKF is '模拟高速公路行驶扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.LXJWKF is '模拟连续急弯山区路行驶扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.SDKF is '模拟隧道行驶扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.YWKF is '模拟雨(雾）天行驶扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.SHKF is '模拟湿滑路行驶扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JJQKF is '模拟紧急情况处置扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM1 is '地方自选项目1';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM2 is '地方自选项目2';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM3 is '地方自选项目3';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM1KF is '地方自选项目1扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM2KF is '地方自选项目2扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.ZXXM3KF is '地方自选项目3扣分';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.JYW is '效验位';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSCXH is '考试车辆备案序号';
 
COMMENT ON COLUMN BUZ_SUB2_RECORD.KSZT is '考试状态(字典【1008】)';
 

/*
 * 表定义：支付流水表
 * 表名称：BUZ_PAYMENT_DETAIL
 * 表空间：TNZC_DATA  
 * 表类别：业务类表5
 * 功能：用于记录学员在模拟考试练习或训练时的详细支付信息,TRADE_NO作为单列唯一约束
 */
CREATE SEQUENCE SEQU_BUZ_PAYMENT_DETAIL_ID INCREMENT BY 1  START  WITH  1;
create table BUZ_PAYMENT_DETAIL
(
	ID					integer			NOT NULL,			--(主键)序列号
	TRADE_NO			varchar2(32)	NOT NULL,			--商户订单号
	PAY_TIME			varchar2(14)	NOT NULL,			--支付时间(格式:yyyymmddhhmmss，支付成功后记录)  
	OPERATOR_NAME		varchar2(20)	NOT NULL,			--经手人姓名
	OPERATOR_IDNUMBER	varchar2(18)	NOT NULL,			--经手人身份证明号码
	STUDENT_IDNUMBER	varchar2(18)	NOT NULL,			--学员身份证明号码
	SUBJECT				varchar2(1)		NOT NULL,			--考试科目-字典【1006】
	FEE_TYPE			varchar2(8)		NOT NULL,			--计费类型(字典【1002】)
	TIMES				integer			NOT NULL,			--预约次数/时间（分钟）
	AMOUNT				number(8,2)		NOT NULL,			--金额
	PAYMENT_WAY			varchar2(8)		NOT NULL,			--支付方式(字典【1001】WXPAY-微信支付；ALIPAY-支付宝支付；UNIONPAY-银联卡支付；OTHERPAY-其他支付)
	BOOKING_ID			number			NOT NULL,			--预约记录，外键于BAS_BOOKING表ID
	PRICING_STRATEGY	varchar2(200)	NOT NULL,			--定价策略
	HASH				varchar2(40)	NOT NULL,			--校验位(sha1加密，保证信息完整性)
	UNIQUE(TRADE_NO),
	primary key(ID)             
);


/*
 * 表定义：考试异常过程处理表
 * 表名称：BUZ_ABNORMAL_PROCESS
 * 表空间：TNZC_DATA  
 * 表类别：业务类表
 * 功能：用于记录学员考试过程异常处理详细信息
 */
CREATE SEQUENCE SEQU_BUZ_ABNORMAL_PROCESS_ID INCREMENT BY 1  START  WITH  1;
create table BUZ_ABNORMAL_PROCESS
(
  ID                integer          NOT NULL,    --(主键)序号 
  PROCESS_ID		integer          NOT NULL,    --考试过程，外键于BUZ_EXAM_PROCESS表ID
  ABNORMAL_TYPE     varchar2(1)      NOT NULL,    --异常类型(字典【1034】=1时，取字典【1032】；=2时，取字典【1033】)
  OCCURRENCE_TIME	varchar2(6)      NOT NULL,    --发生时间(格式：hhmmss)
  EXAMINER_ID		integer,                      --考试员，外键于BAS_EXAMINER表ID
  USER_ID           integer,                      --操作员，外键于SYS_USER表ID
  PROCESS_TYPE      varchar2(1)      NOT NULL,    --异常过程处理类型(字典【1034】)
  MEMO              varchar2(200),                --原因
  CREATE_TIME       varchar2(14)     NOT NULL,    --创建时间(格式：yyyymmddhhmmss)
  HASH              varchar2(40)     NOT NULL,    --校验位(sha1加密，保证信息完整性)
  primary key(ID)
); 

CREATE SEQUENCE SEQU_CFG_DICT_ID INCREMENT BY 1  START  WITH  1; 
create table CFG_DICT
(
	ID					integer			NOT NULL,			--(主键)序列号
	DICT_TYPE			integer			NOT NULL,			--字典类型
	DICT_CODE			varchar2(20)	NOT NULL,			--字典代码
	DICT_NAME			varchar2(100)	NOT NULL,			--字典名称
	VIEW_INDEX			integer,							--显示顺序
	DICT_MEMO			varchar2(100),						--备注
	UNIQUE(DICT_TYPE, DICT_CODE),
	primary key(ID)
);

/*
 * 表定义：参数表
 * 表名称：CFG_PARAM
 * 表空间：TNZC_DATA  
 * 表类别：配置类表
 * 功能：用于系统参数的归集，SUBSYS_ID,PARAM_NAME作为多列唯一约束
 */
CREATE SEQUENCE SEQU_CFG_PARAM_ID INCREMENT BY 1  START  WITH  1;
create table CFG_PARAM
(
  ID              integer        NOT NULL,            --(主键)序列号
  SUBSYS_ID       integer        DEFAULT 0 NOT NULL,  --所属子系统（1-车载子系统；2-后台管理子系统；3-音视频监控子系统....）
  PARAM_GRADE     varchar2(1)    DEFAULT 0 NOT NULL,  --参数级别（字典【1003】：0公共参数、1后台参数、2车载参数）
  PARAM_NAME      varchar2(100)   NOT NULL,            --参数名称
  DISPLAY_NAME    varchar2(50)   NOT NULL,            --显示名称
  PARAM_TYPE      varchar2(8)    NOT NULL,            --参数类型, CHAR,INT,BOOL
  PARAM_VALUE     varchar2(256),                      --参数值
  IS_ADMIN_PARAM  integer        DEFAULT 0,           --是否管理员参数(0否、1是)
  MEMO            varchar2(200), --备注
  UNIQUE(SUBSYS_ID,PARAM_NAME),
  primary key(ID)
);  


/*
*	功能：定价策略
*	描述：同一时刻有效的策略可以有多个，可按优先级从高到低叠加，但生效的同一优先级策略不能多于1个，否则结果无法预测
*/
CREATE SEQUENCE SEQU_CFG_PRICING_STRATEGY_ID INCREMENT BY 1  START  WITH  1;
create table CFG_PRICING_STRATEGY
(
	ID					integer			NOT NULL,			--主键
	FEE_TYPE			varchar2(8)		NOT NULL,			--计费类型(字典【1002】)
	PRIORITY			integer			NOT NULL,			--优先级，从0开始，0优先级最高
	ACTION				varchar2(3)		NOT NULL,			--定价行为，(字典【1037】：set, add, sub, mul, div)
	AMOUNT				number(8,2)		NOT NULL,			--金额
	EFFECTIVE_DATE		varchar2(8)		NULL,				--定价策略生效日期，NULL表示立即生效
	EXPIRED_DATE		varchar2(8)		NULL,				--定价策略失效日期，NULL表示永不失效
	START_DATE			varchar2(8)		NULL,				--开始日期，NULL表示立即开始
	END_DATE			varchar2(8)		NULL,				--结束日期，NULL表示永不结束
	START_TIME			varchar2(6)		NULL,				--开始时间，NULL表示00:00:00
	END_TIME			varchar2(6)		NULL,				--结束时间，NULL表示23:59:59
	SCHOOL_NAME			varchar2(256)	NULL,				--驾校名称
	STUDENT_IDNUMBER	varchar2(18)	NULL,				--学员姓名
	REFERENCE_METHOD1	varchar2(2)		NULL,				--参考方法，(字典【1038】：>, =, <, >=, <=, <>)
	REFERENCE_AMOUNT1	number(8,2)		NULL,				--参考金额
	REFERENCE_RELATION	varchar2(2)		NULL,				--两组参考之间的关系，&&, ||
	REFERENCE_METHOD2	varchar2(2)		NULL,				--参考方法，(字典【1038】：>, =, <, >=, <=, <>)
	REFERENCE_AMOUNT2	number(8,2)		NULL,				--参考金额
	primary key(ID)
);

/*
 * 表定义：项目表
 * 表名称：CFG_ITEMS
 * 表空间：TNZC_DATA  
 * 表类别：配置类表
 * 功能：用于归集项目扣分代码，ITEM_CODE作为单列唯一约束
 */
CREATE SEQUENCE SEQU_CFG_ITEMS_ID INCREMENT BY 1  START  WITH  1;
create table CFG_ITEMS
(
  ID              integer        NOT NULL,               --(主键)序列号
  SUBJECT         varchar2(1)    NOT NULL,               --考试科目-字典【1006】
  PARENT_CODE     varchar2(5),                           --起源代码
  ITEM_CODE       varchar2(5)    NOT NULL,               --项目代码
  ITEM_NAME       varchar2(200)  NOT NULL,               --项目名称
  DEDUCT_SCORE    integer,                               --扣除分数
  GRADE           integer        DEFAULT 1 NOT NULL,     --级别(1级-科目综合/专项、2级-专项、3级-扣分)
  UNIQUE(ITEM_CODE),
  primary key(ID)
); 

/*
 * 表定义：地图表
 * 表名称：CFG_MAPS
 * 表空间：TNZC_DATA  
 * 表类别：配置类表
 * 功能：用于归集场地地图信息，EXAM_ITEM,MAPNUMBER作为多列唯一约束
 */
CREATE SEQUENCE SEQU_CFG_MAPS_ID INCREMENT BY 1  START  WITH  1;
create table CFG_MAPS
(
  ID                       integer        NOT NULL,    --(主键)序列号  
  SUBJECT                  varchar2(1)    NOT NULL,    --考试科目(字典【1006】)      
  EXAM_ITEM                varchar2(5)            ,    --考试项目，科目二时不允许为空，外键与CFG_ITEMS表ITEM_CODE，条件GRADE=2  
  DRIVER_LICENSE_TYPE      varchar2(2)            ,    --驾驶证类型(字典【2003】)
  MAPNUMBER                varchar2(2)    NOT NULL,    --地图编号
  NAME                     varchar2(8)    NOT NULL,    --地图名称(例：倒车入库1、倒车入库2、倒车入库3、....)
  MAP                      BLOB,                       --地图  
  MEMO                     varchar2(200),  --备注
  UNIQUE(EXAM_ITEM,MAPNUMBER),
  primary key(ID)
); 

/*
 * 表定义：视频表
 * 表名称：CFG_VIDEO
 * 表空间：TNZC_DATA  
 * 表类别：配置类表
 * 功能：用于配置车辆或地图对应的视频设备信息，IP作为单列唯一约束
 */
CREATE SEQUENCE SEQU_CFG_VIDEO_ID INCREMENT BY 1  START  WITH  1;
create table CFG_VIDEO
(
  ID            integer        NOT NULL,    --(主键)序列号
  IP            varchar2(15)   NOT NULL,    --视频设备IP
  VUSER         varchar2(30)   NOT NULL,    --视频设备登录用户
  PASSWORD      varchar2(50)   NOT NULL,    --视频设备登录密码(DES加密)
  PORT          varchar2(8),                --视频设备端口
  ASCRIPTION    varchar2(2)    NOT NULL,    --设备归属类型(字典【1030】)
  SUBJECT       varchar2(1)    NOT NULL,    --考试科目(字典【1006】)      
  ITEM          integer        NOT NULL,    --参数项目(字典【1030】为C时，外键于BAS_CAR表ID;为M时，外键于CFG_MAPS表ID) 
  DEVICE_ID     integer,    --场地设备序号,外键于BAS_DEVICE表ID  
  UNIQUE(IP),
  primary key(ID)
);

/*
 * 表定义：FTP表
 * 表名称：CFG_FTP
 * 表空间：TNZC_DATA  
 * 表类别：配置类表
 * 功能：用于配置FTP基本信息，IP作为单列唯一约束
 */
create table CFG_FTP
(
  IP           varchar2(15)   NOT NULL,    --FTP地址IP
  FUSER        varchar2(30)   NOT NULL,    --FTP登录用户
  PASSWORD     varchar2(50)   NOT NULL,    --FTP登录密码(DES加/解密)
  PORT         varchar2(8),                --FTP端口
  ROOTPATH     varchar2(100),              --根目录
  VIDEOPATH    varchar2(100),              --视频子目录      
  DOCUMENTPATH varchar2(100),              --文档子目录
  UNIQUE(IP)
);

/*
 * 表定义：准驾车型与考试项目对应表
 * 表名称：CFG_DRIVER_LICENSE_ITEMS
 * 表空间：TNZC_DATA  
 * 表类别：配置类表
 * 功能：用于对每个考试车型(驾驶证类型)分配具体的考试项目，DRIVER_LICENSE_TYPE,EXAM_ITEM作为多列唯一约束
 */
CREATE SEQUENCE SEQU_CFG_DRIV_LICENSE_ITEMS_ID INCREMENT BY 1  START  WITH  1;
create table CFG_DRIVER_LICENSE_ITEMS
(
  ID                       integer        NOT NULL,      --(主键)序列号
  DRIVER_LICENSE_TYPE      varchar2(2)    NOT NULL,      --驾驶证类型(字典【2003】)     
  EXAM_ITEM                varchar2(5)    NOT NULL,      --考试项目，外键于CFG_ITEMS表ITEM_CODE，条件GRADE=2
  UNIQUE(DRIVER_LICENSE_TYPE,EXAM_ITEM),
  primary key(ID)
);

create table SYS_TERMINAL_LIST
(
  MAC			varchar2(20)	NOT NULL,		--MAC地址
  IP			varchar2(15),					--IP地址
  FAILURE_TIMES	number(2,0) DEFAULT 0 NOT NULL,	--终端登录鉴别失败次数(用于CFG_PARAM表增加身份鉴别次数阈值参数,到达阈值后用户锁定)
  LOCK_TIME		varchar2(14),					--锁定时间
  MAX_FAILURE_COUNT number(2,0),				--终端登录鉴别失败次数上限，如为空，使用CFG_PARAM中的DEFAULT_TERMINAL_MAX_FAILURE_COUNT
  LOCK_DURATION	number,							--终端锁定时间（分钟），如为空，使用CFG_PARAM中TERMINAL_LOCK_DURATION
  primary key(MAC)
);

/*
 * 表定义：用户表
 * 表名称：SYS_USER
 * 表空间：TNZC_DATA  
 * 表类别：系统类表
 * 功能：登记系统使用者，LOGIN_NAME，IDNUMBER分别作为单列唯一约束
 */
CREATE SEQUENCE SEQU_SYS_USER_ID INCREMENT BY 1 START WITH 1;
create table SYS_USER
(
	ID						integer,						--(主键)用户标识符ID
	LOGIN_NAME				varchar2(20) NOT NULL,			--用户登录名
	PASSWORD				varchar2(200),					--用户登录密码：DES(SHA1(PASSWORD_PLAIN_TEXT)||LOGIN_NAME||USER_NAME||IDNUMBER)
	USER_NAME				varchar2(20) NOT NULL,			--用户姓名
	GENDER					varchar2(1) DEFAULT '9',		--用户性别(字典【2001】)
	IDNUMBER				varchar2(18) NOT NULL,			--用户身份证号码  
	USER_FLAG				varchar2(1) DEFAULT 0,			--用户标识(字典【1010】：0非警员、1警员) 
	USERNUMBER				varchar2(8) NOT NULL,			--用户编号(警员/员工编号)  
	FINGERPRINT1			BLOB,							--学员指纹1识别
	ROLE_ID					integer,						--角色ID，外键于SYS_ROLE表ROLE_ID  
	FAILURE_TIMES			number(2,0) DEFAULT 0 NOT NULL,	--用户登录鉴别失败次数(用于CFG_PARAM表增加身份鉴别次数阈值参数,到达阈值后用户锁定)
	MAX_FAILURE_COUNT		number(2,0),					--用户登录鉴别失败次数上限，如为空，使用CFG_PARAM中的DEFAULT_USER_MAX_FAILURE_COUNT
	STATUS					varchar2(1) DEFAULT 0,			--用户登录状态标识(字典【1013】 0未登录、1已登录),用于一个用户多地登录控制，如果未退出就换机器登录，则必须先签退。
	PASSWORD_MODIFY_DATE	varchar2(8) NOT NULL,			--密码修改日期(格式:yyyymmdd,用于CFG_PARAM表增加密码有效期阈值参数,到达阈值后强制更改密码)  
	ENABLE_DATE				varchar2(8),					--用户启用日期(格式:yyyymmdd)
	DISABLE_DATE			varchar2(8),					--用户停用日期(格式:yyyymmdd)
	QUALIFIED_START_TIME	varchar2(6),					--允许登录开始时间(格式:hhmmss)
	QUALIFIED_END_TIME		varchar2(6),					--允许登录结束时间(格式:hhmmss)  
	QUALIFIED_ADDRESS_LIST	varchar2(256),					--允许登录的IP/MAC地址列表:192.168.1.100(10:20:30:40:50:60)
	UNIQUE(LOGIN_NAME),
	UNIQUE(IDNUMBER),
	UNIQUE(USER_FLAG,USERNUMBER),
	primary key(ID)    
);
 
CREATE SEQUENCE SEQU_SYS_ROLE_ID INCREMENT BY 1 START WITH 1;
create table SYS_ROLE
(
	ID					integer,							--(主键)角色标识符ID
	NAME				varchar2(30)	NOT NULL,			--角色名称
	CATEGORY			varchar2(20)	DEFAULT 'BUSINESS' NOT NULL,	--类别(字典【1039】)
	UNIQUE(NAME),
	primary key(ID)
);

create table SYS_PERMISSION
(
	CODE 				varchar2(4) 	NOT NULL,			--(主键)权限代码,目前暂定4位,前两位表示执行操作的模块或功能,每个模块或功能预留后2位操作号
	NAME				varchar2(50),						--权限名称
	CATEGORY			varchar2(10)	DEFAULT 'BUSINESS',	--类别(字典【1039】)
	IS_ADMIN			integer			DEFAULT 0 NOT NULL,	--是否仅为管理员专用权限(0否、1是)
	IS_POLICE			integer			DEFAULT 0 NOT NULL,	--是否为警员专用权限(0否、1是)
	UNIQUE(NAME),
	primary key(CODE)
);

/*
 * 表定义：角色与权限对应表
 * 表名称：SYS_ROLE_PERMISSION
 * 表空间：TNZC_DATA  
 * 表类别：系统类表 
 * 功能：用于对每个角色分配具体权限，一对多的关系，ROLE_ID,PERMISSION_CODE作为多列唯一约束
 */
create table SYS_ROLE_PERMISSION
(
  ROLE_ID          integer      NOT NULL,  --角色ID，外键于SYS_ROLE表ID
  PERMISSION_CODE  varchar2(4)  NOT NULL,  --权限代码，外键于SYS_PERMISSION表CODE
  UNIQUE(ROLE_ID,PERMISSION_CODE)
); 

/*
 * 表定义：日志表
 * 表名称：SYS_LOG
 * 表空间：TNZC_DATA  
 * 表类别：系统类表
 * 功能：用于详细操作日志记录
 */
CREATE SEQUENCE SEQU_SYS_LOG_ID INCREMENT BY 1  START  WITH  1;   
create table SYS_LOG
(
  ID                   integer        NOT NULL,    --(主键)日志id  
  USER_ID              integer        NOT NULL,    --用户标识符ID,外键于SYS_USER表ID
  TIME       		   varchar2(14)   NOT NULL,    --操作时间
  SOURCE               varchar2(30)   NOT NULL,    --操作模块(来源)  
  ACTION               varchar2(14)   NOT NULL,    --操作行为(字典【1028】登录、进入、离开、增加、删除、修改、查看)
  CONTENT              varchar2(500),              --操作内容
  RESULT               varchar2(1)    NOT NULL,    --操作结果(0失败，1成功)  
  IP                   varchar2(15),               --主机IP
  MAC                  varchar2(50),               --主机MAC
  HASH                 varchar2(40)   NOT NULL,    --校验位(sha1加密，保证信息完整性)
  primary key(ID)
);
