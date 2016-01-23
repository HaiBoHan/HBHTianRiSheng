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
using U9.VOB.Cus.HBHTianRiSheng.Proxy;
using System.Collections.Specialized;
using UFIDA.U9.UI.PDHelper;
using UFSoft.UBF.ExportService;
using System.Collections.Generic;



/***********************************************************************************************
 * Form ID: 
 * UIFactory Auto Generator 
 ***********************************************************************************************/
namespace FollowServiceUIModel
{
    public partial class FollowServiceUIFormWebPart
    {
        public string WorkTypeValueSetCode = string.Empty;
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

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_AfterCopy(this.Model.FollowService);
        }

        //BtnSubmit_Click...
        private void BtnSubmit_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnSubmit_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.FollowService, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approving);
        }

        //BtnApprove_Click...
        private void BtnApprove_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnApprove_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.FollowService, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved);
        }

        //BtnRecovery_Click...
        private void BtnRecovery_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnRecovery_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.FollowService, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened);
        }

        //BtnUndoApprove_Click...
        private void BtnUndoApprove_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnUndoApprove_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.FollowService, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened);
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
		 
				//BtnReview_Click...
		private void BtnReview_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnReview_Click_DefaultImpl(sender,e);
            
            FollowServiceRecord focused = this.Model.FollowService.FocusedRecord;

            if (focused != null
                && focused.ID > 0
                )
            {
                NameValueCollection nv = new NameValueCollection();
                nv.Add("SrcDoc", focused.ID.ToString());
                // 列表   910f434c-9933-4910-9f03-d4502cae2285
                this.ShowModalDialog("d5d270d8-ba8a-4a9d-98c3-c3e7cac03135", "售后回报单结果", "992", "504", string.Empty
                        , nv);
            }
		}	
		 
				//BtnToFeeback_Click...
        private void BtnToFeeback_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnToFeeback_Click_DefaultImpl(sender,e);

            FollowServiceRecord focused = this.Model.FollowService.FocusedRecord;

            if (focused != null
                && focused.ID > 0
                )
            {
                Follow2FeedbackSVProxy proxy = new Follow2FeedbackSVProxy();

                proxy.FollowIDs = new System.Collections.Generic.List<long>();
                proxy.FollowIDs.Add(focused.ID);

                proxy.Do();

                BtnReview_Click_Extend(sender, e);
            }
        }

        //BtnDocClose_Click...
        private void BtnDocClose_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnDocClose_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.FollowService, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Closed);
        }

        //BtnDocOpen_Click...
        private void BtnDocOpen_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnDocOpen_Click_DefaultImpl(sender,e);
            
            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.FollowService, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened);
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
            //查找对话框。
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowConfirmDialog(this.Page, "5d9958c0-1a8f-49ca-97cc-8c2e1b30e8d1", "580", "408", Title, wpFindID.ClientID, this.BtnFind, null);

            // 取得提示信息资源：是否删除当前记录
            string message = UFIDA.U9.UI.PDHelper.PDResource.GetDeleteConfirmInfo();
            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, message, "", this.BtnDelete);

            // 启用页面个性化 
            UFIDA.U9.UI.PDHelper.PersonalizationHelper.SetPersonalizationEnable(this, true);
            // 启用弹性域
            UFIDA.U9.UI.PDHelper.FlexFieldHelper.SetDescFlexField(new UFIDA.U9.UI.PDHelper.DescFlexFieldParameter(this.FlexFieldPicker0, this.Model.FollowService)
                );

            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认审核?", "确认审核", this.BtnApprove);

            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认转回报单?", "确认转回报单", this.BtnToFeeback);

            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认关闭?", "确认关闭", this.BtnDocClose);

            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认打开?", "确认打开", this.BtnDocOpen);

            if (string.IsNullOrEmpty(DeliveryTypeValueSetCode))
            {
                DeliveryTypeValueSetCode = U9.VOB.HBHCommon.HBHCommonUI.UICommonHelper.GetValueSetCode("TianRiSheng_DeliveryTypeCode_Follow");
            }

            // 发运方式
            this.DeliveryType195.AddTypeParams("DefCode"
                // , U9.VOB.Cus.HBHTianRiSheng.HBHHelper.DescFlexFieldHelper.Const_DeliveryTypeCode
                , DeliveryTypeValueSetCode
                );

            if (string.IsNullOrEmpty(WorkTypeValueSetCode))
            {
                WorkTypeValueSetCode = U9.VOB.HBHCommon.HBHCommonUI.UICommonHelper.GetValueSetCode("TianRiSheng_WorkTypeCode_Follow");
            }

            WorkType118.CustomInParams = string.Format("DefCode={0}"
                , WorkTypeValueSetCode
                );

            //UIControlBuilder.SetLabelFormReference(this.lblDocumentType67, "4723b733-117e-424d-a25d-e42f54d720d9", true, 992, 504);
            //this.lblDeliveryType195.WinTitle = Const_ParamTitle;
            //this.lblWorkType118.WinTitle = Const_ParamTitle;
            UFSoft.UBF.UI.Engine.Builder.UIControlBuilder.SetLabelFormReference(this.lblDeliveryType195, U9.VOB.Cus.HBHTianRiSheng.HBHTianRiShengUI.UIHelper.Const_ParamTitle, true, 992, 504);
            UFSoft.UBF.UI.Engine.Builder.UIControlBuilder.SetLabelFormReference(this.lblWorkType118, U9.VOB.Cus.HBHTianRiSheng.HBHTianRiShengUI.UIHelper.Const_ParamTitle, true, 992, 504);

            this.PageItem_Operators85.CustomInParams = string.Format("{0}={1}"
                , MultiOperatorRef.MultiOperatorRefWebPart.Const_RefType
                , MultiOperatorRef.MultiOperatorRefWebPart.Const_IsSingleReturn
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
            FollowServiceRecord focusedHead = this.Model.FollowService.FocusedRecord;

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


            this.SrcDoc118.Enabled = false;


            bool isButtonEnabled = this.IsCurrentPrintable(focusedHead);
            ButtonManger.SetButtonStatus(this, "BtnPrint", isButtonEnabled);

            this.DocumentType67.Enabled = true;
            if (focusedHead.ID > 0)
            {
                if (focusedHead.Status == (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approving
                    || focusedHead.Status == (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved
                    || focusedHead.Status == (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Closed
                    )
                {
                    this.DocumentType67.Enabled = false;
                }
            }
            
            this.RegisterClientPrintScript();
		}


        #endregion


        #region Customer Method

        public bool IsCurrentPrintable(FollowServiceRecord record)
        {
            return record != null && (record.DocumentType_PrintStyle == 0 || (record.Status == (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved && record.DocumentType_PrintStyle == 1));
        }

        private void RegisterClientPrintScript()
        {
            string ufDefaultPrintTemplateID = null;
            if (this.Model.FollowService.FocusedRecord != null)
            {
                ufDefaultPrintTemplateID = this.Model.FollowService.FocusedRecord.DocumentType_PrintTemplate_TemplateID;
            }
            ExportServiceFactory.RegisterClientExportScript(this, this.BtnOutput, "U9.VOB.Cus.HBHTianRiSheng.FollowService");
            FollowServiceRecord focusedRecord = this.Model.FollowService.FocusedRecord;
            UFPrintStyle printStyle = PDPrintHelper.TransPrintMode(focusedRecord.DocumentType_PrintStyle);
            ExportServiceFactory.RegisterClientPrintScript(this, this.BtnPrint, "U9.VOB.Cus.HBHTianRiSheng.FollowService", ufDefaultPrintTemplateID, null, false, printStyle);
            //if (this.Action.IsCanBePrintByStatus(this.Model.FollowService.FocusedRecord))
            if (this.Action.IsCanBePrintByStatus(this.Model.FollowService.FocusedRecord))
            {
                PDPrintHelper.SetBtnPrintStatus(this.Model.FollowService, new UFSoft.UBF.UI.ControlModel.IUFButton[]
				{
					this.BtnPrint
				});
                //PDPrintHelper.SetBtnPrintStatus(this.Model.FollowService, new UFSoft.UBF.UI.ControlModel.IUFButton[]
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


        #endregion
    }
}