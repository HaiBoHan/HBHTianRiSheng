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



/***********************************************************************************************
 * Form ID: 
 * UIFactory Auto Generator 
 ***********************************************************************************************/
namespace FeedbackDocTypeUIModel
{
    public partial class FeedbackDocTypeUIFormWebPart
    {
        #region Custome eventBind
	
		 
				//BtnSave_Click...
		private void BtnSave_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnSave_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnCancel_Click...
		private void BtnCancel_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnCancel_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnAdd_Click...
		private void BtnAdd_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnAdd_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnDelete_Click...
		private void BtnDelete_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnDelete_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnCopy_Click...
		private void BtnCopy_Click_Extend(object sender, EventArgs  e)
		{
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnCopy_Click_DefaultImpl(sender, e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_AfterCopy(this.Model.FeedbackDocType);
		}	
		 
				//BtnSubmit_Click...
		private void BtnSubmit_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnSubmit_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.FeedbackDocType, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approving);
		}	
		 
				//BtnApprove_Click...
		private void BtnApprove_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnApprove_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.FeedbackDocType, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved);
		}	
		 
				//BtnRecovery_Click...
		private void BtnRecovery_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnRecovery_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.FeedbackDocType, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened);
		}	
		 
				//BtnUndoApprove_Click...
		private void BtnUndoApprove_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnUndoApprove_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.FeedbackDocType, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened);
		}	
		 
				//BtnFind_Click...
		private void BtnFind_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnFind_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnList_Click...
		private void BtnList_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnList_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_BtnList_Click(this);
		}	
		 
				//BtnFirstPage_Click...
		private void BtnFirstPage_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnFirstPage_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnPrevPage_Click...
		private void BtnPrevPage_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnPrevPage_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnNextPage_Click...
		private void BtnNextPage_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnNextPage_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnLastPage_Click...
		private void BtnLastPage_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnLastPage_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnAttachment_Click...
		private void BtnAttachment_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnAttachment_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnFlow_Click...
		private void BtnFlow_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnFlow_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnOutput_Click...
		private void BtnOutput_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnOutput_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnPrint_Click...
		private void BtnPrint_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnPrint_Click_DefaultImpl(sender,e);
		}	
		 
				//BtnOk_Click...
		private void BtnOk_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnOk_Click_DefaultImpl(sender,e);

            this.CloseDialog(false);
		}	
		 
				//BtnClose_Click...
		private void BtnClose_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnClose_Click_DefaultImpl(sender,e);

            this.CloseDialog(false);
        }

        #endregion
		

		
            
            
            

		#region 自定义数据初始化加载和数据收集
		private void OnLoadData_Extend(object sender)
		{	
			OnLoadData_DefaultImpl(sender);

            //if(this.Model.FeedbackDocType.PropertyEntityFullName.Value != this.Model.FeedbackDocType.PropertyEntityFullName.DefaultValue)
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
            //查找对话框。
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowConfirmDialog(this.Page, "30de9b50-dfba-4161-8c7d-2e823d5e0141", "580", "408", Title, wpFindID.ClientID, this.BtnFind, null);

            // 取得提示信息资源：是否删除当前记录
            string message = UFIDA.U9.UI.PDHelper.PDResource.GetDeleteConfirmInfo();
            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, message, "", this.BtnDelete);

            // 启用页面个性化 
            UFIDA.U9.UI.PDHelper.PersonalizationHelper.SetPersonalizationEnable(this, true);
            // 启用弹性域
            //UFIDA.U9.UI.PDHelper.FlexFieldHelper.SetDescFlexField(new UFIDA.U9.UI.PDHelper.DescFlexFieldParameter(this.FlexFieldPicker0, this.Model.DayCheckIn),
            //    new UFIDA.U9.UI.PDHelper.DescFlexFieldParameter(this.DataGrid5, UISceneHelper.GetSegColumnIndex(this.DataGrid5)));

            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认审核?", "确认审核", this.BtnApprove);

            this.DocHeaderSequence103.AddTypeParams("EntityFullName", "U9.VOB.Cus.HBHTianRiSheng.Feedback");

            this.PrintTemplate22.AddTypeParams("CatalogType", "U9.VOB.Cus.HBHTianRiSheng.Feedback");
        }
        
        public void AfterEventBind()
        {
        }
        
		public void BeforeUIModelBinding()
		{

		}

		public void AfterUIModelBinding()
        {
            FeedbackDocTypeRecord focusedHead = this.Model.FeedbackDocType.FocusedRecord;

            if (focusedHead == null)
                return;

            //U9.VOB.HBHCommon.HBHCommonUI.UISceneHelper.SetToolBarStatus(this.Toolbar2
            //    , status, focusedHead.DataRecordState, false, 0, 1, 2, 2);

            U9.VOB.HBHCommon.HBHCommonUI.UISceneHelper.SetToolBarStatus(this.Toolbar2
                , focusedHead.Status ?? (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Empty, focusedHead.DataRecordState, false, (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened, (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approving, (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved, 1);


            //this.BtnSave.Enabled = true;

            if (this.PartShowType != UFSoft.UBF.UI.IView.PartShowType.TitleLink)
            {
                this.BtnOk.Visible = false;
                this.BtnClose.Visible = false;
            }
            else
            {
                this.BtnOk.Visible = true;
                this.BtnClose.Visible = true;
            }
		}


        #endregion
    }
}