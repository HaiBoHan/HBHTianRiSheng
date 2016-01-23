#region Using directives

using System;
using System.Collections;
using System.Data;
using UFSoft.UBF.UI.MD.Runtime;
using UFSoft.UBF.UI.MD.Runtime.Implement;

#endregion

namespace FollowServiceUIModel
{	public partial class FollowServiceUIModelModel 
	{
        //初始化UIMODEL之后的方法
        public override  void AfterInitModel()
        {
            //this.Views[0].Fields[0].DefaultValue = thsi.co
            this.FollowService.FieldBusinessDate.DefaultValue = UFIDA.U9.UI.PDHelper.PDContext.Current.LoginDate;

            this.FollowService.PropertySHIP_Type.DefaultValue = "SM6010";
            this.FollowService.PropertySHIP_Type.Value = "SM6010";
        }
        
        //UIModel提交保存之前的校验操作.
        public override void OnValidate()
        {
        		base.OnValidate() ;
            OnValidate_DefualtImpl();
            //your coustom code ...
        }
	}
}