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
using U9.VOB.HBHCommon.HBHCommonUI;



/***********************************************************************************************
 * Form ID: 
 * UIFactory Auto Generator 
 ***********************************************************************************************/
namespace MultiOperatorRef
{
    public partial class MultiOperatorRefWebPart
    {
        public const string Const_IsSingleReturn = "IsSingleReturn";
        public const string Const_RefType = "Const_RefType";

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
        private void ConfirmButton_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //ConfirmButton_Click_DefaultImpl(sender,e);

            clsMultiSelect multiSel = new clsMultiSelect(this, MultiSelect_IDModel.RandomID);
            //multiSel.Code_Field = this.Model.cRef.FieldCode.Name;
            //multiSel.Name_Field = this.Model.cRef.FieldName.Name;

            object objType = this.NameValues[Const_RefType];

            if (objType != null
                && objType.ToString() == Const_IsSingleReturn
                )
            {
                clsMultiSelect.RegistScript((Control)this.TopLevelContainer, base.GetType(), "ReferenceReturn", multiSel.GetScript_ToOneLine(), false);
            }
            else
            {
                clsMultiSelect.RegistScript((Control)this.TopLevelContainer, base.GetType(), "ReferenceReturn", multiSel.GetScript_ToMultiLineNew(), false);
            }
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
            //DataGrid_GridRowDbClicked_DefaultImpl(sender, e);

            //clsMultiSelect multiSel = new clsMultiSelect(this, MultiSelect_IDModel.RandomID);
            ////multiSel.Code_Field = this.Model.cRef.FieldCode.Name;
            ////multiSel.Name_Field = this.Model.cRef.FieldName.Name;

            //clsMultiSelect.RegistScript((Control)this.TopLevelContainer, base.GetType(), "ReferenceReturn", multiSel.GetScriptNew(), false);

            ConfirmButton_Click_Extend(sender, e);
        }

        #endregion

		
            
            
            
            

		#region 自定义数据初始化加载和数据收集
		private void OnLoadData_Extend(object sender)
		{	
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


		}


        #endregion


        public override bool UseQueryCase
        {
            get
            {
                //return base.UseQueryCase;

                #region Base.UseQueryCase

                //public virtual bool UseQueryCase
                //{
                //    get
                //    {
                //        UFCard uFCard = this.GetUFControlByName(this.TopLevelContainer, "CardForRefQueryCase") as UFCard;
                //        bool flag = uFCard != null && uFCard.Display;
                //        bool result;
                //        if (flag)
                //        {
                //            flag = this.GetUseQueryCaseFromRequestParam();
                //            bool flag2 = false;
                //            bool.TryParse(this.NameValues["IsMultiRefTag"] as string, out flag2);
                //            if (flag2)
                //            {
                //                result = false;
                //                return result;
                //            }
                //            UFSoft.UBF.UI.ControlModel.IUFDataGrid iUFDataGrid = this.GetUFControlByName(this.TopLevelContainer, "DataGrid") as UFSoft.UBF.UI.ControlModel.IUFDataGrid;
                //            if (iUFDataGrid != null)
                //            {
                //                if (iUFDataGrid.IsMultiSelect)
                //                {
                //                    result = false;
                //                    return result;
                //                }
                //            }
                //        }
                //        result = flag;
                //        return result;
                //    }
                //}

                #endregion

                return true;
            }
        }
    }
}