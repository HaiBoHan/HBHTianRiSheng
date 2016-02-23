
/*
delete from Base_Profile
-- where ID in (2015122300100001,2015122300100002,2015122300100003,2015122300100004,2015122300100005)
where ID between 2015122300100001 and 2015122300100099
delete from Base_Profile_Trl
-- where ID in (2015122300100001,2015122300100002,2015122300100003,2015122300100004,2015122300100005)
where ID between 2015122300100001 and 2015122300100099
*/

/*
select *
from Base_Profile
*/

declare @ID bigint = 2015122300100001

-- CBO.Base.Profile.Profile&ApplicationId=3015

set @ID = 2015122300100001
if not exists(select 1 from Base_Profile where ID = @ID)
begin
	insert into Base_Profile
	(ID,SysVersion,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy
	,Code,ShortName,ProfileValueType,SubTypeName,DefaultValue
	,Application,ControlScope,SensitiveType,Sort
	,ValidateSV,CanBeUpdatedSV,UpdatedProcessSV,ReferenceID,Hidden,ShowPecent,IsSend,IsModify
	)values(
	@ID,1,'2015-12-23','hbh','2015-12-23','hbh'
	,'TianRiSheng_WorkTypeCode_Follow','工作类型值集编码(任务单)',0,'string',''
	,3015,1,0,0
	,null,null,null,null,0,0,0,0
	)

	insert into Base_Profile_Trl
	(ID,SysMLFlag,ProfileGroup,Name,Description
	)values(
	@ID,'zh-CN','值集编码定义','工作类型值集编码(任务单)','工作类型值集编码(任务单)'
	)
end ;

set @ID = 2015122300100002
if not exists(select 1 from Base_Profile where ID = @ID)
begin
	insert into Base_Profile
	(ID,SysVersion,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy
	,Code,ShortName,ProfileValueType,SubTypeName,DefaultValue
	,Application,ControlScope,SensitiveType,Sort
	,ValidateSV,CanBeUpdatedSV,UpdatedProcessSV,ReferenceID,Hidden,ShowPecent,IsSend,IsModify
	)values(
	@ID,1,'2015-12-23','hbh','2015-12-23','hbh'
	,'TianRiSheng_WorkTypeCode_Feedback','工作类型值集编码(回报单行)',0,'string',''
	,3015,1,0,0
	,null,null,null,null,0,0,0,0
	)

	insert into Base_Profile_Trl
	(ID,SysMLFlag,ProfileGroup,Name,Description
	)values(
	@ID,'zh-CN','值集编码定义','工作类型值集编码(回报单行)','工作类型值集编码(回报单行)'
	)
end ;

set @ID = 2015122300100003
if not exists(select 1 from Base_Profile where ID = @ID)
begin
	insert into Base_Profile
	(ID,SysVersion,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy
	,Code,ShortName,ProfileValueType,SubTypeName,DefaultValue
	,Application,ControlScope,SensitiveType,Sort
	,ValidateSV,CanBeUpdatedSV,UpdatedProcessSV,ReferenceID,Hidden,ShowPecent,IsSend,IsModify
	)values(
	@ID,1,'2015-12-23','hbh','2015-12-23','hbh'
	,'TianRiSheng_DeliveryTypeCode_Follow','发运方式值集编码(任务单)',0,'string','Z06'
	,3015,1,0,0
	,null,null,null,null,0,0,0,0
	)

	insert into Base_Profile_Trl
	(ID,SysMLFlag,ProfileGroup,Name,Description
	)values(
	@ID,'zh-CN','值集编码定义','发运方式值集编码(任务单)','发运方式值集编码(任务单)'
	)
end ;

set @ID = 2016022300100001
if not exists(select 1 from Base_Profile where ID = @ID)
begin
	insert into Base_Profile
	(ID,SysVersion,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy
	,Code,ShortName,ProfileValueType,SubTypeName,DefaultValue
	,Application,ControlScope,SensitiveType,Sort
	,ValidateSV,CanBeUpdatedSV,UpdatedProcessSV,ReferenceID,Hidden,ShowPecent,IsSend,IsModify
	)values(
	@ID,1,'2015-12-23','hbh','2015-12-23','hbh'
	,'TianRiSheng_Vouchers_FulFilQuota','抵用券满额额度',0,'int','3000'
	,3015,1,0,0
	,null,null,null,null,0,0,0,0
	)

	insert into Base_Profile_Trl
	(ID,SysMLFlag,ProfileGroup,Name,Description
	)values(
	@ID,'zh-CN','抵用券参数','抵用券满额额度','抵用券满额额度'
	)
end ;





