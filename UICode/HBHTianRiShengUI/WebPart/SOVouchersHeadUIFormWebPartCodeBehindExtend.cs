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
namespace SOVouchersHeadUIModel
{
    public partial class SOVouchersHeadUIFormWebPart
    {
        #region Custome eventBind

        //BtnSave_Click...
        private void BtnSave_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnSave_Click_DefaultImpl(sender, e);
        }


        //BtnOk_Click...
        private void BtnOk_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnOk_Click_DefaultImpl(sender, e);

            this.Model.ClearErrorMessage();

            BtnSave_Click(sender, e);

            if (!this.Model.ErrorMessage.hasErrorMessage)
            {
                this.CloseDialog(true);
            }
        }
		 
				//BtnClose_Click...
		private void BtnClose_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnClose_Click_DefaultImpl(sender,e);

            this.CloseDialog(false);
		}


        //BtnClearLine_Click...
        private void BtnClearLine_Click_Extend(object sender, EventArgs e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnClearLine_Click_DefaultImpl(sender,e);

            this.Model.ClearErrorMessage();

            SOVouchersHeadRecord head = this.Model.SOVouchersHead.FocusedRecord;

            if (head != null)
            {
                IUIRecord[] arrLines = head.GetChildRecords(this.Model.SOVouchersHead_SOVouchersLine);

                if (arrLines != null
                    && arrLines.Length > 0
                    )
                {
                    foreach (IUIRecord line in arrLines)
                    {
                        if (line != null)
                        {
                            line.DataRecordState = DataRowState.Deleted;
                        }
                    }
                }

                BtnSave_Click(sender, e);
            }
		}

        //BtnRecalcMoney_Click...
        private void BtnRecalcMoney_Click_Extend(object sender, EventArgs e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnRecalcMoney_Click_DefaultImpl(sender,e);


            this.Model.ClearErrorMessage();

            SOVouchersHeadRecord head = this.Model.SOVouchersHead.FocusedRecord;

            if (head != null)
            {
                head.IsRecalcSOMoney = true;

                BtnSave_Click(sender, e);

                this.Action.NavigateAction.Refresh(null);
            }
		}
		


        #endregion

		
            
            
            

		#region 自定义数据初始化加载和数据收集
		private void OnLoadData_Extend(object sender)
        {
            object objSOID = this.NameValues["SOID"];
            object objSODocNo = this.NameValues["SODocNo"];

            if (objSOID != null)
            {
                this.Model.SOVouchersHead.CurrentFilter.OPath = string.Format("SO={0}"
                    , objSOID
                    );

                this.Action.CommonAction.Load(this.Model);
            }
            else
            {
                OnLoadData_DefaultImpl(sender);
            }

            //if (objSODocNo != null)
            //{
            //    lblSOInfo.Text = string.Format("订单号:{0} "
            //        , objSODocNo
            //        );
            //}

            if (this.Model.SOVouchersHead.FocusedRecord == null)
            {
                if (this.Model.SOVouchersHead.RecordCount > 0)
                {
                    this.Model.SOVouchersHead.FocusedRecord = this.Model.SOVouchersHead.Records[0] as SOVouchersHeadRecord;
                }
                else
                {
                    this.Model.SOVouchersHead.FocusedRecord = this.Model.SOVouchersHead.AddNewUIRecord();

                    if (objSOID != null)
                    {
                        this.Model.SOVouchersHead.FocusedRecord.SO = PubClass.GetLong(objSOID);
                        this.Model.SOVouchersHead.FocusedRecord.SO_DocNo = PubClass.GetString(objSODocNo);
                    }
                }
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
            // 启用页面个性化 
            UFIDA.U9.UI.PDHelper.PersonalizationHelper.SetPersonalizationEnable(this, true);

            this.VouchersTypeRef87.CustomInParams = string.Format("{0}={1}&{2}={3}",
                    BaseAction.Symbol_AddCustomFilter
                    , "MD_Class_ID in (select cls.UID from UFIDA::UBF::MD::Business::Entity cls where cls.FullName = 'U9.VOB.Cus.HBHTianRiSheng.VouchersTypeEnum')"
                    , "Const_RefType"
                    , "IsSingleReturn"
                    );


            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认清空订单抵用券行?", "", this.BtnClearLine);

            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认抵用券订单金额重算?", "", this.BtnRecalcMoney);
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
		
    }
}