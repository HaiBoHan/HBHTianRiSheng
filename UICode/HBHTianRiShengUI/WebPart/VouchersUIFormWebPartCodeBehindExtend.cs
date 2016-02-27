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
using System.Collections.Generic;
using UFSoft.UBF.UI.WebControls.Association;
using UFSoft.UBF.UI.WebControls.Association.Adapter;
using UFSoft.UBF.UI.ControlModel;



/***********************************************************************************************
 * Form ID: 
 * UIFactory Auto Generator 
 ***********************************************************************************************/
namespace VouchersUIModel
{
    public partial class VouchersUIFormWebPart
    {
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
        }

        //BtnSubmit_Click...
        private void BtnSubmit_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnSubmit_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.Vouchers, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approving);
        }

        //BtnApprove_Click...
        private void BtnApprove_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnApprove_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.Vouchers, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved);
        }

        //BtnRecovery_Click...
        private void BtnRecovery_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnRecovery_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.Vouchers, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened);
        }

        //BtnUndoApprove_Click...
        private void BtnUndoApprove_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnUndoApprove_Click_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIForm_UpdateStatus(this, this.Model.Vouchers, U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened);
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
            //BtnList_Click_DefaultImpl(sender, e);

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

        public void ContainUsed125_TextChanged_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //ContainUsed125_TextChanged_DefaultImpl(sender,e);

            //HideLineByIsUsed();
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
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowConfirmDialog(this.Page, "5c4c763c-9c31-4c1c-a897-ff74385158b3", "580", "408", Title, wpFindID.ClientID, this.BtnFind, null);

            // 取得提示信息资源：是否删除当前记录
            string message = UFIDA.U9.UI.PDHelper.PDResource.GetDeleteConfirmInfo();
            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, message, "", this.BtnDelete);

            // 启用页面个性化 
            UFIDA.U9.UI.PDHelper.PersonalizationHelper.SetPersonalizationEnable(this, true);
            //// 启用弹性域
            //UFIDA.U9.UI.PDHelper.FlexFieldHelper.SetDescFlexField(new UFIDA.U9.UI.PDHelper.DescFlexFieldParameter(this.FlexFieldPicker0, this.Model.Vouchers)
            //    );

            // 绑定注册弹出对话框到按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认审核?", "确认审核", this.BtnApprove);

            //// 绑定注册弹出对话框到按钮 
            //UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认转回报单?", "确认转回报单", this.BtnToFeeback);

            //// 绑定注册弹出对话框到按钮 
            //UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认关闭?", "确认关闭", this.BtnDocClose);

            //// 绑定注册弹出对话框到按钮 
            //UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认打开?", "确认打开", this.BtnDocOpen);

            CellEditEnabledAssoControl();
        }

        public void AfterEventBind()
        {
        }

        public void BeforeUIModelBinding()
        {
            HideLineByIsUsed();
        }

        public void AfterUIModelBinding()
        {
            VouchersRecord focusedHead = this.Model.Vouchers.FocusedRecord;

            if (focusedHead == null)
                return;

            //U9.VOB.HBHCommon.HBHCommonUI.UISceneHelper.SetToolBarStatus(this.Toolbar2
            //    , status, focusedHead.DataRecordState, false, 0, 1, 2, 2);

            U9.VOB.HBHCommon.HBHCommonUI.UISceneHelper.SetToolBarStatus(this.Toolbar2
                , focusedHead.Status ?? (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Empty, focusedHead.DataRecordState, false, (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Opened, (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approving, (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved, 1
                , (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Closed
                , new List<int>() { (int)U9.VOB.HBHCommon.U9CommonBE.DocStatusData.Approved }
                );


            //this.BtnSave.Enabled = true;

            this.BtnOk.Visible = false;
            this.BtnClose.Visible = false;

            this.Status89.Enabled = false;

            IUFDataGridColumn isUsedColumn = this.DataGrid5.Columns[this.Model.Vouchers_VouchersLine.FieldIsUsed.Name];
            //.Enabled = false;
            if (isUsedColumn != null)
            {
                isUsedColumn.Enabled = false;
            }
        }


        #endregion



        private void HideLineByIsUsed()
        {
            VouchersRecord head = this.Model.Vouchers.FocusedRecord;

            if (head != null
                )
            {
                if (!head.ContainUsed.GetValueOrDefault(true))
                {
                    foreach (Vouchers_VouchersLineRecord line in head.GetChildRecords(this.Model.Vouchers_VouchersLine))
                    {
                        if (line != null)
                        {
                            if (line.IsUsed.GetValueOrDefault(false))
                            {
                                line.Hidden = true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Vouchers_VouchersLineRecord line in head.GetChildRecords(this.Model.Vouchers_VouchersLine))
                    {
                        if (line != null)
                        {
                            if (line.IsUsed.GetValueOrDefault(false))
                            {
                                line.Hidden = false;
                            }
                        }
                    }
                }
            }
        }

        private void CellEditEnabledAssoControl()
        {
            AssociationControl associationControl = new AssociationControl();
            associationControl.SourceServerControl = this.DataGrid5;
            associationControl.SourceControl.EventName = "OnBeforeCellFocusEnter";
            // 触发列名
            //((UFWebClientGridAdapter)associationControl.SourceControl).FireEventCols.Add(this.Model.Vouchers_VouchersLine.FieldMoney.Name);
            //((UFWebClientGridAdapter)associationControl.SourceControl).FireEventCols.Add(this.Model.Vouchers_VouchersLine.FieldEffectiveDate.Name);
            CodeBlock codeBlock = new CodeBlock();
            StringBuilder stringBuilder = new StringBuilder(256);
            stringBuilder.AppendFormat("var currentrow = $find('{0}').get_CurrentRowIndex(); \n", this.DataGrid5.ClientID);
            //stringBuilder.AppendFormat("var custid     = $find('{0}').GetCellValueByFieldAndRow('Customer',currentrow).Value; \n", this.DataGrid5.ClientID);
            //stringBuilder.AppendFormat("var custsiteid = $find('{0}').GetCellValueByFieldAndRow('CustomerSite',currentrow).Value; \n", this.DataGrid5.ClientID);
            //stringBuilder.AppendFormat("var custcateid = $find('{0}').GetCellValueByFieldAndRow('CustomerCategory',currentrow).Value; \n", this.DataGrid5.ClientID);
            //stringBuilder.AppendFormat("var itemid     = $find('{0}').GetCellValueByFieldAndRow('ItemInfo_ItemID',currentrow).Value; \n", this.DataGrid5.ClientID);
            //stringBuilder.AppendFormat("var itemcateid = $find('{0}').GetCellValueByFieldAndRow('MaterialCategory',currentrow).Value; \n", this.DataGrid5.ClientID);
            //stringBuilder.AppendFormat("var itemdepid  = $find('{0}').GetCellValueByFieldAndRow('ItemDepended',currentrow).Value; \n", this.DataGrid5.ClientID);
            //stringBuilder.Append("if(custid == -1) \n custid = ''; \n");
            //stringBuilder.Append("if(custsiteid == -1) \n custsiteid = ''; \n");
            //stringBuilder.Append("if(custcateid == -1) \n custcateid = ''; \n");
            //stringBuilder.Append("if(itemid == -1) \n itemid = ''; \n");
            //stringBuilder.Append("if(itemcateid == -1) \n itemcateid = ''; \n");
            //stringBuilder.Append("if(itemdepid == -1) \n itemdepid = ''; \n");
            //stringBuilder.Append("switch(args.arg.ColField)\n");
            //stringBuilder.Append("{ \n");
            //stringBuilder.Append("   case 'Customer':\n");
            //stringBuilder.Append("      if(custcateid != '') \n {args.arg.CellEditEnabled = false;} \n");
            //stringBuilder.Append("      break; \n");
            //stringBuilder.Append("   case 'CustomerSite':");
            //stringBuilder.Append("      if(custid == '')    \n {args.arg.CellEditEnabled = false;} \n");
            //stringBuilder.Append("      break; \n");
            //stringBuilder.Append("   case 'CustomerCategory':");
            //stringBuilder.Append("      if(custid != '')    \n {args.arg.CellEditEnabled = false;} \n");
            //stringBuilder.Append("      break; \n");
            //stringBuilder.Append("   case 'ItemInfo_ItemID':");
            //stringBuilder.Append("      if(itemcateid != '') \n {args.arg.CellEditEnabled = false;} \n");
            //stringBuilder.Append("      break; \n");
            //stringBuilder.Append("   case 'MaterialCategory':");
            //stringBuilder.Append("      if(itemid != '')    \n {args.arg.CellEditEnabled = false;} \n");
            //stringBuilder.Append("      break; \n");
            //stringBuilder.Append("   case 'Price':");
            //stringBuilder.Append("      if(itemdepid != '')  \n {args.arg.CellEditEnabled = false;} \n");
            //stringBuilder.Append("      break; \n");
            //stringBuilder.Append("} \n");

            stringBuilder.AppendFormat("var isUsed     = $find('{0}').GetCellValueByFieldAndRow('" + this.Model.Vouchers_VouchersLine.FieldIsUsed.Name + "',currentrow).Value; \n", this.DataGrid5.ClientID);

            stringBuilder.Append("      if(isUsed == 'true') \n {args.arg.CellEditEnabled = false;} \n");

            codeBlock.Condition = stringBuilder.ToString();
            associationControl.addBlock(codeBlock);
        }

    }
}