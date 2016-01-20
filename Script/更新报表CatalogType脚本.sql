

update UBF_Print_Templates
set CatalogType = 'U9.VOB.Cus.HBHTianRiSheng.FollowService'
where 
	TemplateName = 'FollowService'





 SELECT  CatalogType,A.[ID] as [ID], A.[TemplateName] as [TemplateName], A.[TemplateID] as [TemplateID], A.[Culture] as [Culture], A.[IsDefault] as [IsDefault], A.[SysVersion] as [SysVersion], A.[ID] as [MainID] , ROW_NUMBER() OVER(ORDER BY A.[ID] asc, (A.[ID] + 17) asc ) AS rownum  
	
 FROM  UBF_Print_Templates as A 
 
 --WHERE  
	--A.[CatalogType] = 'U9.VOB.Cus.HBHTianRiSheng.FollowService'

order by
	CreatedOn desc
