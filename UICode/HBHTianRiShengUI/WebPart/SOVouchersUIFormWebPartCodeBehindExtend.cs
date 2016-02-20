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
namespace SOVouchersUIModel
{
    public partial class SOVouchersUIFormWebPart
    {
        #region Custome eventBind

				//BtnOk_Click...
		private void BtnOk_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
            //BtnOk_Click_DefaultImpl(sender, e);

            BtnClose_Click_DefaultImpl(sender, e);
		}	
		 
				//BtnClose_Click...
		private void BtnClose_Click_Extend(object sender, EventArgs  e)
		{
			//调用模版提供的默认实现.--默认实现可能会调用相应的Action.
			
		
			BtnClose_Click_DefaultImpl(sender,e);
		}

        #endregion
		
		
            
            
            

		#region 自定义数据初始化加载和数据收集
        private void OnLoadData_Extend(object sender)
        {
            object objSOID = this.NameValues["SOID"];
            object objSODocNo = this.NameValues["SODocNo"];

            if (objSOID != null)
            {
                this.Model.SOVouchers.CurrentFilter.OPath = string.Format("SO={0}"
                    , objSOID
                    );

                this.Action.CommonAction.Load(this.Model.SOVouchers);                
            }
            else
            {
                OnLoadData_DefaultImpl(sender);
            }

            if (objSODocNo != null)
            {
                lblSOInfo.Text = string.Format("订单号:{0} "
                    , objSODocNo
                    );
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
            ////查找对话框。
            //UFIDA.U9.UI.PDHelper.PDFormMessage.ShowConfirmDialog(this.Page, "5c4c763c-9c31-4c1c-a897-ff74385158b3", "580", "408", Title, wpFindID.ClientID, this.BtnFind, null);

            //// 取得提示信息资源：是否删除当前记录
            //string message = UFIDA.U9.UI.PDHelper.PDResource.GetDeleteConfirmInfo();
            //// 绑定注册弹出对话框到按钮 
            //UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, message, "", this.BtnDelete);

            // 启用页面个性化 
            UFIDA.U9.UI.PDHelper.PersonalizationHelper.SetPersonalizationEnable(this, true);
            //// 启用弹性域
            //UFIDA.U9.UI.PDHelper.FlexFieldHelper.SetDescFlexField(new UFIDA.U9.UI.PDHelper.DescFlexFieldParameter(this.FlexFieldPicker0, this.Model.Vouchers)
            //    );

            //// 绑定注册弹出对话框到按钮 
            //UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认审核?", "确认审核", this.BtnApprove);

            //// 绑定注册弹出对话框到按钮 
            //UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认转回报单?", "确认转回报单", this.BtnToFeeback);

            //// 绑定注册弹出对话框到按钮 
            //UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认关闭?", "确认关闭", this.BtnDocClose);

            //// 绑定注册弹出对话框到按钮 
            //UFIDA.U9.UI.PDHelper.PDFormMessage.ShowDelConfirmDialog(this.Page, "确认打开?", "确认打开", this.BtnDocOpen);
		
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