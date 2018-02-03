cd D:\ControlCenter\Database\

cd Tables
@CreateTable
@Script_Insert_CFG_DICT
@Script_Insert_CFG_DRIVER_LICENSE_ITEMS
@Script_Insert_CFG_ITEMS
@Script_Insert_CFG_PARAM

cd ..\StoredProcedures
@GenerateSHA1
@GenerateHMAC

cd ..\Views
@BAS_BOOKING_VIEW
@BAS_CAR_VIEW
@BAS_DEVICE_VIEW
@BAS_DRIVING_SCHOOL_VIEW
@BAS_EXAMINER_VIEW
@BAS_GROUPING_DETAIL_VIEW
@BAS_GROUPING_VIEW
@BAS_PLACE_VIEW
@BAS_STUDENT_VIEW
@BUZ_EXAM_INFO_VIEW
@BUZ_EXAM_PROCESS_VIEW
@BUZ_PAYMENT_DETAIL_VIEW
@BUZ_SUB2_RECORD_VIEW
@CFG_PRICING_STRATEGY_VIEW
--start DBA_AUDIT_TRAIL
@STUDENT_EXAM_VIEW
@STUDENT_SCORE_VIEW
@SYS_LOG_VIEW
@SYS_ROLE_PERMISSION_VIEW
@SYS_USER_ROLE_PERMISSION_VIEW
@SYS_USER_VIEW

cd ..\StoredProcedures
@AddLog

--cd ..\Functions
@DESDecrypt
@DESEncrypt
@GetPriceByTimes
@NewBookSequenceNumber
@NewCarSequenceNumber
@NewDeviceSequenceNumber
@NewExaminerSequenceNumber
@NewExamNumber
@NewPlaceSequenceNumber
@NewSchoolCode
@NewSchoolSequenceNumber
@NewTradeNumber
@AddRole
@AddUpdatePricingStrategy
@AddUpdateUser
@BookFromManagement
@BookFromVehicle
@BookFromVehicleNoPassword
@ChangePassword
@GenerateSUB2
@GrantRolePermission
@Login
@RemoveUser
@RevokeRolePermission
@SetParameter
@ShowDateTime
@UnblockUser

--cd ..\Procedures
@AddUpdateCar
@AddUpdateDevice
@AddUpdateExaminer
@AddUpdatePlace
@AddUpdateSchool
@AddUpdateStudent
@GetRolePermissions
@HandleMisjudge
@Logout
@Query17C01Place
@Query17C02Device
@Query17C03Car
@Query17C04Examinator
@Query17C05School
@Query17C06Group
@Query17C07GroupDetail
@Query17C08Book
