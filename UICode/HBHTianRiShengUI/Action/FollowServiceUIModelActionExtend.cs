/**************************************************************
 * Description:
 * FollowServiceUIModelAction.cs
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
using UFIDA.U9.UI.PDHelper;
using UFSoft.UBF.ExportService;
using System.Data;




namespace FollowServiceUIModel
{
	public partial class FollowServiceUIModelAction 
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
            //this.OutputClick_DefaultImpl(sender,e);								

            IExportSettings settings = ExportServiceFactory.GetInstance().CreateExportSettingsObject();
            settings.PrintTemplateCatalogType = this.CurrentModel.FollowService.EntityFullName;
            //settings.DefaultPrintTemplateID = "6bb70641-a2e2-4e16-87f0-88594cecb86c";
            FollowServiceRecord focusedRecord = this.CurrentModel.FollowService.FocusedRecord;
            if (!((focusedRecord == null) || string.IsNullOrEmpty(focusedRecord.DocumentType_PrintTemplate_TemplateID)))
            {
                settings.DefaultPrintTemplateID = focusedRecord.DocumentType_PrintTemplate_TemplateID;
                // settings.PrintTemplateCatalogType = this.CurrentModel.FollowService.EntityFullName;
            }
            // 有需要可去参考： UFIDA.U9.SCM.SD.ShipUIModel.ShipUIModelAction.GetPrintShipDataSet();
            //settings.UserDataCallBack(new DataCallBackHandle(this, (IntPtr)this.GetPrintData));
            //settings.get_ReportContext().Add("CurrencySymbol", "SAY " + this.CurrentModel.Branching.FocusedRecord.TC_Symbol + " ");
            settings.UserDataCallBack = new DataCallBackHandle(this.GetPrintData);
            e.Tag = settings;

            this.OutputClick_DefaultImpl(sender, e);		
        } 
		private void PrintClick_Extend(object sender, UIActionEventArgs e)
		{
			//调用模版定义的默认实现方法.如需扩展,请直接在此编程.			
            //this.PrintClick_DefaultImpl(sender,e);

            this.CurrentModel.ClearErrorMessage();
            this.CurrentPart.ShowWindowStatus("");
            if (this.IsCanBePrintByStatus(this.CurrentModel.FollowService.FocusedRecord))
            {
                IExportSettings exportSettings = PDPrintHelper.GetExportSettings(this.CurrentModel.FollowService.FocusedRecord);
                if (exportSettings != null)
                {
                    //exportSettings.PrintTemplateCatalogType = "U9.SCM.SD.ShipPlan";
                    exportSettings.PrintTemplateCatalogType = this.CurrentModel.FollowService.EntityFullName;
                    //exportSettings.UserDataCallBack += new DataCallBackHandle(this.GetPrintData);
                    //exportSettings.OnFinished += new FinishCallBackHandle(this.OnPrintFinished_EX);
                    //exportSettings.AfterLoadPrintTemplate = new PrintTemplateLoadedHandle(this.PrintTemplateLoadedHandle);
                    e.Tag = exportSettings;
                    this.PrintClick_DefaultImpl(sender, e);
                }

                //IExportSettings settings = ExportServiceFactory.GetInstance().CreateExportSettingsObject();
                ////settings.PrintTemplateCatalogType = "U9.SCM.SD.OrderDoc";
                //settings.PrintTemplateCatalogType = this.CurrentModel.FollowService.EntityFullName;
                //settings.UserDataCallBack += new DataCallBackHandle(this.GetPrintData);
                //e.Tag = settings;
                //this.PrintClick_DefaultImpl(sender, e);
            }
        }

        /// 打印模板产生
        /// </summary>
        /// <param name="tempalteID"></param>
        /// <returns></returns>
        /// <summary>
        /// 根据模版准备打印数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void GetPrintData(object sender, UFSoft.UBF.ExportService.DataCallBackEventArgs args)
        {
            System.Data.DataSet returnDataSet = null;
            switch (args.PrintTemplateID)
            {
                //相应的打印模版编号（模型元数据里的打印参照）
                //fe7b5751-31cb-435a-8e41-98e546831c6c
                //5826e162-8f6b-4ca0-9846-fffbfdee18b4
                case "5826e162-8f6b-4ca0-9846-fffbfdee18b4":
                    //returnDataSet = this.GetMOSegmentData();
                    break;
                default:
                    break;
            }
            returnDataSet = GetPrintDataset();
            args.ReturnData = returnDataSet;
        }

        // UFIDA.U9.SCM.SM.ShipPlanUIModel.ShipPlanUIModelAction
        public DataSet GetPrintDataset()
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            //dataTable.Columns.Add("ShipPlan_DocNo");
            //dataTable.Columns.Add("ShipPlan_BusinessDate");
            //dataTable.Columns.Add("ShipPlan_Planer_Name");
            //dataTable.Columns.Add("ShipPlan_ShipOrg_Name");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_WH_Name");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_OrderBy_Name");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_ItemInfo_ItemName");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_ShipToSite_Name");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_DocLineNo");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_InvUom_Name");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_PlanDate");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_PlanQtyIU");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_InvUom_Round_Precision");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_RequireDate");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_DeliveryDate");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_InvBaseUom_Round_Precision");
            //dataTable.Columns.Add("ShipPlan_ShipPlanLines_SrcDocNo");

            ////foreach (IUIField field in this.CurrentModel.FollowService.Fields)
            ////{
            ////    dataTable.Columns.Add(field.Name);
            ////}

            //FollowServiceRecord focusedRecord = this.CurrentModel.FollowService.FocusedRecord;
            //int num = 0;
            //using (IEnumerator<UFSoft.UBF.UI.MD.Runtime.IUIRecord> enumerator = this.CurrentModel.ShipPlan_ShipPlanLines.Records.GetEnumerator())
            //{
            //    while (enumerator.MoveNext())
            //    {
            //        ShipPlan_ShipPlanLinesRecord shipPlan_ShipPlanLinesRecord = (ShipPlan_ShipPlanLinesRecord)enumerator.Current;
            //        if (shipPlan_ShipPlanLinesRecord.InvUom_Round_Precision > num)
            //        {
            //            num = shipPlan_ShipPlanLinesRecord.InvUom_Round_Precision;
            //        }
            //    }
            //}
            //string value = focusedRecord.BusinessDate.ToShortDateString().ToString().Replace("-", ".");
            //using (IEnumerator<UFSoft.UBF.UI.MD.Runtime.IUIRecord> enumerator = this.CurrentModel.ShipPlan_ShipPlanLines.Records.GetEnumerator())
            //{
            //    while (enumerator.MoveNext())
            //    {
            //        ShipPlan_ShipPlanLinesRecord shipPlan_ShipPlanLinesRecord = (ShipPlan_ShipPlanLinesRecord)enumerator.Current;
            //        DataRow dataRow = dataTable.NewRow();
            //        dataRow["ShipPlan_DocNo"] = focusedRecord.DocNo;
            //        dataRow["ShipPlan_BusinessDate"] = value;
            //        dataRow["ShipPlan_Planer_Name"] = focusedRecord.Planer_Name;
            //        dataRow["ShipPlan_ShipOrg_Name"] = focusedRecord.ShipOrg_Name;
            //        dataRow["ShipPlan_ShipPlanLines_WH_Name"] = shipPlan_ShipPlanLinesRecord.WH_Name;
            //        dataRow["ShipPlan_ShipPlanLines_OrderBy_Name"] = shipPlan_ShipPlanLinesRecord.OrderBy_Name;
            //        dataRow["ShipPlan_ShipPlanLines_ItemInfo_ItemName"] = shipPlan_ShipPlanLinesRecord.ItemInfo_ItemName;
            //        dataRow["ShipPlan_ShipPlanLines_ShipToSite_Name"] = shipPlan_ShipPlanLinesRecord.ShipToSite_CustomerSite_Name;
            //        dataRow["ShipPlan_ShipPlanLines_DocLineNo"] = shipPlan_ShipPlanLinesRecord.DocLineNo;
            //        dataRow["ShipPlan_ShipPlanLines_InvUom_Name"] = shipPlan_ShipPlanLinesRecord.TradeBaseUom_Name;
            //        dataRow["ShipPlan_ShipPlanLines_PlanDate"] = shipPlan_ShipPlanLinesRecord.PlanDate.ToShortDateString().ToString().Replace("-", ".");
            //        dataRow["ShipPlan_ShipPlanLines_PlanQtyIU"] = shipPlan_ShipPlanLinesRecord.PlanQtyTU;
            //        dataRow["ShipPlan_ShipPlanLines_InvUom_Round_Precision"] = shipPlan_ShipPlanLinesRecord.InvUom_Round_Precision;
            //        dataRow["ShipPlan_ShipPlanLines_RequireDate"] = shipPlan_ShipPlanLinesRecord.RequireDate.ToShortDateString().ToString().Replace("-", ".");
            //        dataRow["ShipPlan_ShipPlanLines_DeliveryDate"] = shipPlan_ShipPlanLinesRecord.DeliveryDate.ToShortDateString().ToString().Replace("-", ".");
            //        dataRow["ShipPlan_ShipPlanLines_InvBaseUom_Round_Precision"] = num;
            //        dataRow["ShipPlan_ShipPlanLines_SrcDocNo"] = shipPlan_ShipPlanLinesRecord.SrcDocNo;
            //        dataTable.Rows.Add(dataRow);
            //    }
            //}

            foreach (IUIField field in this.CurrentModel.FollowService.Fields)
            {
                dataTable.Columns.Add(field.Name);
            }

            //FollowServiceRecord focusedRecord = this.CurrentModel.FollowService.FocusedRecord;

            foreach (IUIRecord record in this.CurrentModel.FollowService.Records)
            {
                if (record != null)
                {
                    DataRow dataRow = dataTable.NewRow();

                    foreach (IUIField field in this.CurrentModel.FollowService.Fields)
                    {
                        dataRow[field.Name] = record[field];
                    }
                }
            }

            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        private void OnPrintFinished_EX(object sender, FinishCallEventArgs args)
        {
            PDPrintHelper.OnPrintFinish(this, args, this.CurrentModel.FollowService.FocusedRecord);
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
        
        public bool IsCanBePrintByStatus(FollowServiceRecord record)
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
