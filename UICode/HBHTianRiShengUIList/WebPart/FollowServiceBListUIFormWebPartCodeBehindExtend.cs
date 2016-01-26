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
using U9.VOB.Cus.HBHTianRiSheng.Proxy;
using System.Collections.Specialized;



/***********************************************************************************************
 * Form ID: 
 * UIFactory Auto Generator 
 ***********************************************************************************************/
namespace FollowServiceBListUIModel
{
    public partial class FollowServiceBListUIFormWebPart
    {
        #region Custome eventBind


        //BtnNew_Click...
        private void BtnNew_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnNew_Click_DefaultImpl(sender, e);
            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIList_BtnNew_Click(this);
        }

        //BtnDelete_Click...
        private void BtnDelete_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnDelete_Click_DefaultImpl(sender, e);
        }

        //BtnOutPut_Click...
        private void BtnOutPut_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnOutPut_Click_DefaultImpl(sender, e);
        }

        //BtnPrint_Click...
        private void BtnPrint_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            BtnPrint_Click_DefaultImpl(sender, e);
        }




        //DDLCase_TextChanged...
        private void DDLCase_TextChanged_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            DDLCase_TextChanged_DefaultImpl(sender, e);
        }

        //OnLookCase_Click...
        private void OnLookCase_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.


            OnLookCase_Click_DefaultImpl(sender, e);
        }




        //DataGrid1_GridRowDbClicked...
        private void DataGrid1_GridRowDbClicked_Extend(object sender, GridDBClickEventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //DataGrid1_GridRowDbClicked_DefaultImpl(sender,e);

            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIList_GridRowDbClicked(this);
        }

        //BtnToFeedback_Click...
        private void BtnToFeedback_Click_Extend(object sender, EventArgs e)
        {
            //调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnToFeedback_Click_DefaultImpl(sender, e);

            this.CurrentState[FeedbackBListUIModel.FeedbackBListUIFormWebPart.Const_Feedbacks] = null;

            long[] selIDs = this.Model.FollowService.GetSelectedRecordIDs();

            if (selIDs != null
                && selIDs.Length > 0
                )
            {
                List<long> lstSelected = new List<long>();

                foreach (long id in selIDs)
                {
                    lstSelected.Add(id);
                }

                Follow2FeedbackSVProxy proxy = new Follow2FeedbackSVProxy();

                proxy.FollowIDs = lstSelected;

                List<long> lstFeedback = proxy.Do();

                if (lstFeedback != null
                    && lstFeedback.Count > 0
                    )
                {
                    this.CurrentState[FeedbackBListUIModel.FeedbackBListUIFormWebPart.Const_Feedbacks] = lstFeedback;
                    
                    NameValueCollection nv = new NameValueCollection();
                    //nv.Add("SrcDoc", focused.ID.ToString());
                    //nv.Add("HBHListType", "PullFollowService");
                    this.ShowModalDialog("910f434c-9933-4910-9f03-d4502cae2285", "售后回报单结果", "992", "504", string.Empty
                            , nv);


                    // 如果是弹出式的列表，则关闭弹出窗口
                    if (this.PartShowType == UFSoft.UBF.UI.IView.PartShowType.TitleLink
                        || this.PartShowType == UFSoft.UBF.UI.IView.PartShowType.ShowModal
                        )
                    {
                        this.CloseDialog(false);
                    }
                }
            }
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

            AfterOnLoad_Qry_DefaultImpl();//BE列表自动产生的代码

        }

        public void AfterCreateChildControls()
        {

            AfterCreateChildControls_Qry_DefaultImpl();//BE列表自动产生的代码


            // 取得提示信息资源：是否删除当前记录
            string message = UFIDA.U9.UI.PDHelper.PDResource.GetDeleteConfirmInfo();
            // 绑定注册弹出对话框到删除按钮 
            UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, message, "", this.BtnDelete);

            // 启用页面个性化 
            UFIDA.U9.UI.PDHelper.PersonalizationHelper.SetPersonalizationEnable(this, true);

        }

        public void AfterEventBind()
        {
        }

        public void BeforeUIModelBinding()
        {

        }

        public void AfterUIModelBinding()
        {

            AfterUIModelBinding_Qry_DefaultImpl();//BE列表自动产生的代码


            U9.VOB.HBHCommon.HBHCommonUI.HBHUIHelper.UIList_SetDocNoTitleClick(this, this.DataGrid1
                //, "ID"
                , "MainID"
                , "DocNo"
                , "096e1e2a-8249-4512-a1dd-51128a0865c1"
                , "售后服务单"
                // , param
                );

        }


        #endregion
    }
}