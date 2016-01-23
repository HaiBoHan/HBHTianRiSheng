using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFSoft.UBF.UI.MD.Runtime;
using UFIDA.U9.Cust.HBH.Common.CommonLibary;
using U9.VOB.Cus.HBHTianRiSheng.HBHHelper;

namespace U9.VOB.Cus.HBHTianRiSheng.UIPlugin
{
    public class SOSaleDiscountRef_UIPlugin : UFSoft.UBF.UI.Custom.ExtendedPartBase
    {
        UFSoft.UBF.UI.IView.IPart part;
        SOSaleDiscountRef.SOSaleDiscountRefWebPart _strongPart;

        //public const string Const_SaleDeptID = "SaleDept259";
        //IUFDataGrid DataGrid10;
        //IUFFldReferenceColumn itemRef;
        public override void AfterInit(UFSoft.UBF.UI.IView.IPart Part, EventArgs args)
        {
            base.AfterInit(Part, args);

            _strongPart = Part as SOSaleDiscountRef.SOSaleDiscountRefWebPart;

        }


        public override void BeforeDataLoad(UFSoft.UBF.UI.IView.IPart Part, out bool executeDefault)
        {
            base.BeforeDataLoad(Part, out executeDefault);

            _strongPart = Part as SOSaleDiscountRef.SOSaleDiscountRefWebPart;
        }

        public override void AfterDataLoad(UFSoft.UBF.UI.IView.IPart Part)
        {
            base.AfterDataLoad(Part);

            _strongPart = Part as SOSaleDiscountRef.SOSaleDiscountRefWebPart;


            if (_strongPart.Model.cRef.Records != null
                && _strongPart.Model.cRef.Records.Count > 0
                )
            {
                UFIDA.U9.SCM.SM.SOUIModel.SOUIModelModel soModel = _strongPart.CurrentState[_strongPart.ParentTaskID] as UFIDA.U9.SCM.SM.SOUIModel.SOUIModelModel;

                if (soModel != null)
                {
                    //string opath = GetDiscountOpath(soModel);

                    //if (!PubClass.IsNull(opath))
                    //{
                    //    IUIView view = _strongPart.Model.cRef;
                    //    // 设置过滤条件
                    //    if (PubClass.IsNull(view.CurrentFilter.OriginalOPath))
                    //    {
                    //        view.CurrentFilter.OPath = opath;
                    //    }
                    //    else
                    //    {
                    //        view.CurrentFilter.OPath = string.Format("({0}) and ({1})", view.CurrentFilter.OriginalOPath, opath);
                    //    }
                    //}

                    decimal totalMoneyOriginal = GetTotalMoneyOriginal(soModel);


                    if (totalMoneyOriginal > 0)
                    {
                        //foreach (SOSaleDiscountRef.cRefRecord record in _strongPart.Model.cRef.Records)
                        for (int i = _strongPart.Model.cRef.Records.Count - 1; i >= 0; i--)
                        {
                            SOSaleDiscountRef.cRefRecord record = _strongPart.Model.cRef.Records[i] as SOSaleDiscountRef.cRefRecord;
                            if (record != null)
                            {
                                decimal minMoney = 0;
                                decimal maxMoney = 0;
                                U9.VOB.Cus.HBHTianRiSheng.HBHHelper.SODiscountHelper.GetMoneyLimit(record.Memo, out minMoney, out maxMoney);


                                //if (minMoney > 0
                                //    && minMoney > totalMoneyOriginal
                                //    )
                                if (!SODiscountHelper.IsMoneyMatch(totalMoneyOriginal, minMoney, maxMoney)
                                    )
                                {
                                    _strongPart.Model.cRef.Records.Remove(record);
                                }
                            }
                        }
                    }
                }
            }
        }

        //private string GetDiscountOpath(UFIDA.U9.SCM.SM.SOUIModel.SOUIModelModel soModel)
        //{
        //    decimal totalMoneyOrginal = GetTotalMoneyOriginal(soModel);

        //    if (totalMoneyOrginal > 0)
        //    { 
                
        //    }

        //    return string.Empty;
        //}

        private static decimal GetTotalMoneyOriginal(UFIDA.U9.SCM.SM.SOUIModel.SOUIModelModel soModel)
        {
            decimal totalMoneyOrginal = 0;

            if (soModel != null)
            {
                UFIDA.U9.SCM.SM.SOUIModel.SORecord soHead = soModel.SO.FocusedRecord;

                if (soHead != null)
                {
                    IUIRecord[] arrSOLine = soHead.GetChildRecords(soModel.SO_SOLines);

                    if (arrSOLine != null
                        && arrSOLine.Length > 0
                        )
                    {

                        foreach (UFIDA.U9.SCM.SM.SOUIModel.SO_SOLinesRecord soline in arrSOLine)
                        {
                            if (soline != null)
                            {
                                decimal price = soline.OrderPriceTC >= 0 ? soline.OrderPriceTC : soline.FinallyPriceTC;

                                totalMoneyOrginal += price * soline.OrderByQtyPU;
                            }
                        }
                    }
                }
            }
            return totalMoneyOrginal;
        }



    }
}
