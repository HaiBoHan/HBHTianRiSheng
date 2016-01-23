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
using System.Collections.Specialized;
using UFSoft.UBF.UI.ControlModel;
using UFIDA.U9.UI.PDHelper;
using UFSoft.UBF.ExportService;
using System.Collections.Generic;
using U9.VOB.HBHCommon.HBHCommonUI;



/***********************************************************************************************
 * Form ID: 
 * UIFactory Auto Generator 
 ***********************************************************************************************/
namespace FeedbackUIModel
{
    public partial class FeedbackUIFormWebPart
    {
        public string WorkTypeValueSetCode_Follow = string.Empty;
        public string WorkTypeValueSetCode_Feedback = string.Empty;
        public string DeliveryTypeValueSetCode = string.Empty;

        #region Custome eventBind



        //BtnSave_Click...
        private void BtnSave_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnSave_Click_DefaultImpl(sender, e);
        }

        //BtnCancel_Click...
        private void BtnCancel_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnCancel_Click_DefaultImpl(sender, e);
        }

        //BtnAdd_Click...
        private void BtnAdd_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnAdd_Click_DefaultImpl(sender, e);
        }

        //BtnDelete_Click...
        private void BtnDelete_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnDelete_Click_DefaultImpl(sender, e);
        }

        //BtnCopy_Click...
        private void BtnCopy_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            BtnCopy_Click_DefaultImpl(sender, e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_AfterCopy(this.Model.Feedback);
        }

        //BtnSubmit_Click...
        private void BtnSubmit_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnSubmit_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.Feedback, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approving);
        }

        //BtnApprove_Click...
        private void BtnApprove_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnApprove_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.Feedback, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved);
        }

        //BtnRecovery_Click...
        private void BtnRecovery_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnRecovery_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.Feedback, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened);
        }

        //BtnUndoApprove_Click...
        private void BtnUndoApprove_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnUndoApprove_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.Feedback, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened);
        }

        //BtnFind_Click...
        private void BtnFind_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnFind_Click_DefaultImpl(sender, e);
        }

        //BtnList_Click...
        private void BtnList_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnList_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_BtnList_Click(this);
        }

        //BtnFirstPage_Click...
        private void BtnFirstPage_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnFirstPage_Click_DefaultImpl(sender, e);
        }

        //BtnPrevPage_Click...
        private void BtnPrevPage_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnPrevPage_Click_DefaultImpl(sender, e);
        }

        //BtnNextPage_Click...
        private void BtnNextPage_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnNextPage_Click_DefaultImpl(sender, e);
        }

        //BtnLastPage_Click...
        private void BtnLastPage_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnLastPage_Click_DefaultImpl(sender, e);
        }

        //BtnAttachment_Click...
        private void BtnAttachment_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnAttachment_Click_DefaultImpl(sender, e);
        }

        //BtnFlow_Click...
        private void BtnFlow_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnFlow_Click_DefaultImpl(sender, e);
        }

        //BtnOutput_Click...
        private void BtnOutput_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnOutput_Click_DefaultImpl(sender, e);
        }

        //BtnPrint_Click...
        private void BtnPrint_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnPrint_Click_DefaultImpl(sender, e);
        }

        //BtnOk_Click...
        private void BtnOk_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnOk_Click_DefaultImpl(sender,e);

            this.CloseDialog(true);
        }

        //BtnClose_Click...
        private void BtnClose_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnClose_Click_DefaultImpl(sender,e);

            this.CloseDialog(false);
        }
				//BtnPullDoc_Click...
		private void BtnPullDoc_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnPullDoc_Click_DefaultImpl(sender,e);

            // b717b974-1628-4eef-b9da-f71e7279773c
            NameValueCollection nv = new NameValueCollection();
            //nv.Add("SrcDoc", focused.ID.ToString());
            nv.Add("HBHListType", "PullFollowService");
            this.ShowModalDialog("b717b974-1628-4eef-b9da-f71e7279773c", "售后任务单列表", "992", "504", string.Empty
                    , nv);
		}


        //BtnToRec_Click...
        private void BtnToRec_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnToRec_Click_DefaultImpl(sender,e);

            //this.CloseDialog(false);
            NameValueCollection nv = new NameValueCollection();
            //nv.Add("SrcDoc", focused.ID.ToString());
            // FI.AR.Process.Receival.RecBill
            this.ShowModalDialog("DF156A43-3CAB-4398-89A1-607689A3EB4B", "收款单", "992", "504", string.Empty
                    , nv);
        }
		
        #endregion
		

		
            
            
            

		#region 自定义数据初始化加载和数据收集
        private void OnLoadData_Extend(object sender)
        {
            object objSrcDoc = this.NameValues["SrcDoc"];

            if (objSrcDoc != null)
            {
                this.Model.Feedback.CurrentFilter.OPath = string.Format("SrcDoc={0}"
                    , objSrcDoc
                    );

                this.Action.CommonAction.Load(this.Model);
            }
            else
            {
                OnLoadData_DefaultImpl(sender);
            }
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
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowConfirmDialog(this.Page, "0edc6f1f-6a6e-4217-9bde-91372f5c2f9d", "580", "408", Title, wpFindID.ClientID, this.BtnFind, null);

            // 取得提示信息资源：是否删除当前记录
            string message = UFIDA.U9.UI.PDHelper.PDResource.GetDeleteConfirmInfo();
            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, message, "", this.BtnDelete);

            // 启用页面个性化 
            UFIDA.U9.UI.PDHelper.PersonalizationHelper.SetPersonalizationEnable(this, true);
            // 启用弹性域
            UFIDA.U9.UI.PDHelper.FlexFieldHelper.SetDescFlexField(new UFIDA.U9.UI.PDHelper.DescFlexFieldParameter(this.FlexFieldPicker0, this.Model.Feedback)
                , new UFIDA.U9.UI.PDHelper.DescFlexFieldParameter(this.DataGrid1, UISceneHelper.GetSegColumnIndex(this.DataGrid1))
                , new UFIDA.U9.UI.PDHelper.DescFlexFieldParameter(this.DataGrid2, UISceneHelper.GetSegColumnIndex(this.DataGrid2))
                    );

            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认审核?", "确认审核", this.BtnApprove);

            //this.DeliveryType241.AddTypeParams("DefCode", U9.VOB.Cus.HBHTianRiSheng.HBHHelper.DescFlexFieldHelper.Const_DeliveryTypeCode);
            if (string.IsNullOrEmpty(DeliveryTypeValueSetCode))
            {
                DeliveryTypeValueSetCode = U9.VOB.HBHCommon.HBHCommonUI.UICommonHelper.GetValueSetCode("TianRiSheng_DeliveryTypeCode_Follow");
            }

            // 发运方式
            this.DeliveryType241.AddTypeParams("DefCode"
                // , U9.VOB.Cus.HBHTianRiSheng.HBHHelper.DescFlexFieldHelper.Const_DeliveryTypeCode
                , DeliveryTypeValueSetCode
                );


            //U9.VOB.HBHCommon.HBHCommonUI.MultiRefHelper.MultiRefAsso(this.DataGrid5
            //    , this.Model.ImportTax_ImportTaxLine.FieldTransInLine.Name
            //    , this.Model.ImportTax_ImportTaxLine.FieldTransOutLine.Name
            //    );

            if (string.IsNullOrEmpty(WorkTypeValueSetCode_Follow))
            {
                WorkTypeValueSetCode_Follow = U9.VOB.HBHCommon.HBHCommonUI.UICommonHelper.GetValueSetCode("TianRiSheng_WorkTypeCode_Follow");
            }

            WorkType70.CustomInParams = string.Format("DefCode={0}"
                , WorkTypeValueSetCode_Follow);

            if (string.IsNullOrEmpty(WorkTypeValueSetCode_Feedback))
            {
                WorkTypeValueSetCode_Feedback = U9.VOB.HBHCommon.HBHCommonUI.UICommonHelper.GetValueSetCode("TianRiSheng_WorkTypeCode_Feedback");
            }

            //this.DeliveryType241.RefTitle = FeedbackUIModel.FeedbackUIFormWebPart.Const_ParamTitle;
            //this.WorkType70.RefTitle = FeedbackUIModel.FeedbackUIFormWebPart.Const_ParamTitle;
            UFSoft.UBF.UI.Engine.Builder.UIControlBuilder.SetLabelFormReference(this.lblDeliveryType241, U9.VOB.Cus.HBHTianRiSheng.HBHTianRiShengUI.UIHelper.Const_ParamTitle, true, 992, 504);
            UFSoft.UBF.UI.Engine.Builder.UIControlBuilder.SetLabelFormReference(this.lblWorkType70, U9.VOB.Cus.HBHTianRiSheng.HBHTianRiShengUI.UIHelper.Const_ParamTitle, true, 992, 504);

            IUFDataGridColumn colFeeItem = U9.VOB.HBHCommon.HBHCommonUI.UICommonHelper.FindGridColumn(this.DataGrid1, "FeeItem");
            if (colFeeItem != null)
            {
                ((IUFFldReferenceColumn)colFeeItem).CustomInParams = string.Format("DefCode={0}"
                                        , WorkTypeValueSetCode_Feedback);
            }

            UFSoft.UBF.UI.Engine.Builder.GridControlBuilder.BuildGridColumnFormReference(colFeeItem, U9.VOB.Cus.HBHTianRiSheng.HBHTianRiShengUI.UIHelper.Const_ParamTitle, true, 992, 504);

            U9.VOB.HBHCommon.HBHCommonUI.MultiRefHelper.MultiRefAsso(this.DataGrid2
                , this.Model.Feedback_FeedbackDeductLines.FieldDeductMan.Name
                );
        }
        
        public void AfterEventBind()
        {
        }
        
		public void BeforeUIModelBinding()
		{

		}

		public void AfterUIModelBinding()
        {
            FeedbackRecord focusedHead = this.Model.Feedback.FocusedRecord;

            if (focusedHead == null)
                return;

            //U9.VOB.HBHCommon.HBHCommonUI.UISceneHelper.SetToolBarStatus(this.Toolbar2
            //    , status, focusedHead.DataRecordState, false, 0, 1, 2, 2);

            U9.VOB.HBHCommon.HBHCommonUI.UISceneHelper.SetToolBarStatus(this.Toolbar2
                , focusedHead.Status ?? (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Empty, focusedHead.DataRecordState, false, (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened, (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approving, (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved, 1
                , (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Closed
                , new List<int>() { (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved  }
                );


            //this.BtnSave.Enabled = true;

            this.BtnOk.Visible = false;
            this.BtnClose.Visible = false;


            this.SrcDoc581.Enabled = false;

            this.DocumentType118.Enabled = false;
            if (focusedHead.ID > 0)
            {
                if (focusedHead.Status == (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approving
                    || focusedHead.Status == (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved
                    || focusedHead.Status == (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Closed
                    )
                {
                    this.DocumentType118.Enabled = false;
                }
            }

            this.RegisterClientPrintScript();
		}


        #endregion

        #region Customer Method

        public bool IsCurrentPrintable(FeedbackRecord record)
        {
            return record != null && (record.DocumentType_PrintStyle == 0 || (record.Status == (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved && record.DocumentType_PrintStyle == 1));
        }

        private void RegisterClientPrintScript()
        {
            string ufDefaultPrintTemplateID = null;
            if (this.Model.Feedback.FocusedRecord != null)
            {
                ufDefaultPrintTemplateID = this.Model.Feedback.FocusedRecord.DocumentType_PrintTemplate_TemplateID;
            }
            ExportServiceFactory.RegisterClientExportScript(this, this.BtnOutput, "U9.VOB.Cus.HBHTianRiSheng.Feedback");
            FeedbackRecord focusedRecord = this.Model.Feedback.FocusedRecord;
            UFPrintStyle printStyle = PDPrintHelper.TransPrintMode(focusedRecord.DocumentType_PrintStyle);
            ExportServiceFactory.RegisterClientPrintScript(this, this.BtnPrint, "U9.VOB.Cus.HBHTianRiSheng.Feedback", ufDefaultPrintTemplateID, null, false, printStyle);
            //if (this.Action.IsCanBePrintByStatus(this.Model.Feedback.FocusedRecord))
            if (this.IsCanBePrintByStatus(this.Model.Feedback.FocusedRecord))
            {
                PDPrintHelper.SetBtnPrintStatus(this.Model.Feedback, new UFSoft.UBF.UI.ControlModel.IUFButton[]
				{
					this.BtnPrint
				});
                //PDPrintHelper.SetBtnPrintStatus(this.Model.Feedback, new UFSoft.UBF.UI.ControlModel.IUFButton[]
                //{
                //    this.BtnFastPrint
                //});
            }
            else
            {
                this.BtnPrint.Enabled = false;
                //this.BtnFastPrint.Enabled = false;
            }
        }

        public bool IsCanBePrintByStatus(FeedbackRecord record)
        {
            bool result = false;
            if (record != null && record.ID > 0L)
            {
                if (record.DocumentType_PrintStyle == 2)
                {
                    result = false;
                }
                else if (record.DocumentType_PrintStyle == 0)
                {
                    result = true;
                }
                else if (record.DocumentType_PrintStyle == 1 && record.Status == (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved)
                {
                    result = true;
                }
            }
            return result;
        }


        #endregion
    }
}