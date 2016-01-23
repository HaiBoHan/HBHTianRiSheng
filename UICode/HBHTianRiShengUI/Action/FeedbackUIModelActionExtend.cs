/**************************************************************
 * Description:
 * FeedbackUIModelAction.cs
 * Product: U9
 * Co.    : UFSoft Group
 * Author : Auto Generated 
 * version: 1.0
 **************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UFSoft.UBF.Util.Log;
using UFSoft.UBF.UI.MD.Runtime;
using UFSoft.UBF.UI.ActionProcess;
using UFSoft.UBF.ExportService;
using UFIDA.U9.UI.PDHelper;




namespace FeedbackUIModel
{
	public partial class FeedbackUIModelAction 
	{
		public override void OnInitAction()
		{
			base.OnInitAction();
			//提示:可注册你自己的方法到相应的事件中,如下.
			//this.CommonAction.BeforeLoad += new ActionLoadDelegate(CommonAction_BeforeLoad);
		}
		private void SaveClick_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.SaveClick_DefaultImpl(sender,e);								
        } 
		private void CancelClick_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.CancelClick_DefaultImpl(sender,e);								
        } 
		private void NewClick_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.NewClick_DefaultImpl(sender,e);								
        } 
		private void DeleteClick_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.DeleteClick_DefaultImpl(sender,e);								
        } 
		private void CopyClick_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.CopyClick_DefaultImpl(sender,e);								
        } 
		private void SubmitClick_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.SubmitClick_DefaultImpl(sender,e);								
        } 
		private void ApproveClick_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.ApproveClick_DefaultImpl(sender,e);								
        } 
		private void FindClick_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.FindClick_DefaultImpl(sender,e);								
        } 
		private void ListClick_Extend(object sender, UIActionEventArgs e)
		{
			//List Click Code Demo...
			//this.CurrentPart.NavigatePage("TestList", null);
			//this.ListClick_DefaultImpl(sender,e) ;	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.ListClick_DefaultImpl(sender,e);								
        } 
		private void FirstPage_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.FirstPage_DefaultImpl(sender,e);								
        } 
		private void PrevPage_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.PrevPage_DefaultImpl(sender,e);								
        } 
		private void NextPage_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.NextPage_DefaultImpl(sender,e);								
        } 
		private void LastPage_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.LastPage_DefaultImpl(sender,e);								
        } 
		private void AttachmentClick_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.AttachmentClick_DefaultImpl(sender,e);								
        } 
		private void FlowClick_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.FlowClick_DefaultImpl(sender,e);								
        } 
		private void OutputClick_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.OutputClick_DefaultImpl(sender,e);								
        } 
		private void PrintClick_Extend(object sender, UIActionEventArgs e)
		{
			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            //this.PrintClick_DefaultImpl(sender,e);
            
            this.CurrentModel.ClearErrorMessage();
            this.CurrentPart.ShowWindowStatus("");
            if (this.IsCanBePrintByStatus(this.CurrentModel.Feedback.FocusedRecord))
            {
                IExportSettings exportSettings = PDPrintHelper.GetExportSettings(this.CurrentModel.Feedback.FocusedRecord);
                if (exportSettings != null)
                {
                    //exportSettings.PrintTemplateCatalogType = "U9.SCM.SD.ShipPlan";
                    exportSettings.PrintTemplateCatalogType = this.CurrentModel.Feedback.EntityFullName;
                    //exportSettings.UserDataCallBack = new DataCallBackHandle(this.GetPrintData);
                    //exportSettings.OnFinished = new FinishCallBackHandle(this.OnPrintFinished_EX);
                    //exportSettings.AfterLoadPrintTemplate = new PrintTemplateLoadedHandle(this.PrintTemplateLoadedHandle);
                    e.Tag = exportSettings;
                    this.PrintClick_DefaultImpl(sender, e);
                }
            }
        } 
		private void OnOk_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.OnOk_DefaultImpl(sender,e);								
        } 
		private void OnClose_Extend(object sender, UIActionEventArgs e)
		{
	
			

			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
this.OnClose_DefaultImpl(sender,e);								
        } 
		
		#region UBF 内置两数据处理Action
		//数据加载的扩展
		private void OnLoadData_Extend(object sender, UIActionEventArgs e)
		{
this.OnLoadData_DefaultImpl(sender,e);			
		}

		//数据收集的扩展
		private void OnDataCollect_Extend(object sender, UIActionEventArgs e)
		{
			this.OnDataCollect_DefaultImpl(sender,e);
		}
		#endregion 
		


        #region Customer Method

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
