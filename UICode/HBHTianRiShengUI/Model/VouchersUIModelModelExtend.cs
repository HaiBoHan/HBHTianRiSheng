#region Using directives

using System;
using System.Collections;
using System.Data;
using UFSoft.UBF.UI.MD.Runtime;
using UFSoft.UBF.UI.MD.Runtime.Implement;

#endregion

namespace VouchersUIModel
{	public partial class VouchersUIModelModel 
	{
        //初始化UIMODEL之后的方法
        public override  void AfterInitModel()
        {
            //this.Views[0].Fields[0].DefaultValue = thsi.co

            this.Vouchers.FieldContainUsed.DefaultValue = true;
            //this.Vouchers_VouchersLine.FieldEffectiveDate.DefaultValue = new DateTime(2000, 1, 1);
            this.Vouchers_VouchersLine.FieldEffectiveDate.DefaultValue = UFIDA.U9.UI.PDHelper.PDContext.Current.LoginDate;
            this.Vouchers_VouchersLine.FieldDisabledDate.DefaultValue = new DateTime(9999, 12, 31);
            this.Vouchers_VouchersLine.FieldIsEffectived.DefaultValue = true;
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