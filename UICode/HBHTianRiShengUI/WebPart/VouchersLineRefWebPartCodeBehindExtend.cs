using System;
using System.Text;
using System.Collections;
using System.Xml;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Threading;

using Telerik.WebControls;
using UFSoft.UBF.UI.WebControls;
using UFSoft.UBF.UI.Controls;
using UFSoft.UBF.Util.Log;
using UFSoft.UBF.Util.Globalization;

using UFSoft.UBF.UI.IView;
using UFSoft.UBF.UI.Engine;
using UFSoft.UBF.UI.MD.Runtime;
using UFSoft.UBF.UI.ActionProcess;
using UFSoft.UBF.UI.WebControls.ClientCallBack;
using HBH.DoNet.DevPlatform.EntityMapping;



/***********************************************************************************************
 * Form ID: 
 * UIFactory Auto Generator 
 ***********************************************************************************************/
namespace VouchersLineRef
{
    public partial class VouchersLineRefWebPart
    {
        #region Custome eventBind
	
		 
				//FindButton_Click...
		private void FindButton_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			FindButton_Click_DefaultImpl(sender,e);
		}	
		 
				//QryButton_Click...
		private void QryButton_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			QryButton_Click_DefaultImpl(sender,e);
		}	
		 

			

		//DDLCase_TextChanged...
		private void DDLCase_TextChanged_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			DDLCase_TextChanged_DefaultImpl(sender,e);
		}	
		 
				//ConfirmButton_Click...
		private void ConfirmButton_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			ConfirmButton_Click_DefaultImpl(sender,e);
		}	
		 
				//CancelButton_Click...
		private void CancelButton_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			CancelButton_Click_DefaultImpl(sender,e);
		}	
		 
			
				

		//DataGrid_GridRowDbClicked...
		private void DataGrid_GridRowDbClicked_Extend(object sender, GridDBClickEventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			DataGrid_GridRowDbClicked_DefaultImpl(sender,e);
		}
		
        #endregion
		

		
            
            
            
            

		#region 自定义数据初始化加载和数据收集
		private void OnLoadData_Extend(object sender)
		{	
            //@VouchersType
            string strTypes = PubClass.GetString(this.NameValues["VouchersType"]);
            if (PubClass.IsNull(strTypes))
            {
                strTypes = "-1";
            }

            this.Model.cRef.CurrentFilter.OPath = string.Format("(IsUsed is null or IsUsed = 0) and VouchersType in (select attr.DefaultValue from UFIDA::UBF::MD::Business::Attribute attr where attr.ID in ({0}) )"
                , strTypes
                );

			OnLoadData_DefaultImpl(sender);
		}
		private void OnDataCollect_Extend(object sender)
		{	
			OnDataCollect_DefaultImpl(sender);
		}
		#endregion  

        #region 自己扩展 Extended Event handler 

		public void AfterOnLoad()
		{

		}

        public void AfterCreateChildControls()
        {
	
        }
        
        public void AfterEventBind()
        {
        }
        
		public void BeforeUIModelBinding()
		{

		}

		public void AfterUIModelBinding()
        {
            this.DataGrid.Columns["Money"].Point = 0;
            //this.DataGrid.Columns["EffectiveDate"].DisplayFormat = "yyyy-MM-dd";
            //this.DataGrid.Columns["DisabledDate"].DisplayFormat = "yyyy-MM-dd";
            //this.DataGrid.Columns["EffectiveDate"].DataType = (int)DataType.DATATYPE_DATE;
            //((IUFDatePickerColumn)column).DateTimeType = DateTimeType.DateTime;
            //((IUFDatePickerColumn)column).DateTimeFormat = CurrentState._I18N._DateTimeFormatInfo;
            ((UFSoft.UBF.UI.ControlModel.IUFDatePickerColumn)this.DataGrid.Columns["EffectiveDate"]).DateTimeType = DateTimeType.Date;
            ((UFSoft.UBF.UI.ControlModel.IUFDatePickerColumn)this.DataGrid.Columns["DisabledDate"]).DateTimeType = DateTimeType.Date;
		}


        #endregion
    }
}