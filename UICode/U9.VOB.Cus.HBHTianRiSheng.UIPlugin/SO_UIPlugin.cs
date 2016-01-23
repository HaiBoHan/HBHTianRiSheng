using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFSoft.UBF.UI.ControlModel;

namespace U9.VOB.Cus.HBHTianRiSheng.UIPlugin
{
    public class SO_UIPlugin  : UFSoft.UBF.UI.Custom.ExtendedPartBase
    {
        UFSoft.UBF.UI.IView.IPart part;
        UFIDA.U9.SCM.SM.SOUIModel.StandardSOMainUIFormWebPart _strongPart;
        IUFDataGrid dgLine;
        List<IUFControl> lstPriceCtrl = new List<IUFControl>();

        //public const string Const_SaleDeptID = "SaleDept259";
        //IUFDataGrid DataGrid10;
        //IUFFldReferenceColumn itemRef;
        public override void AfterInit(UFSoft.UBF.UI.IView.IPart Part, EventArgs args)
        {
            base.AfterInit(Part, args);

            part = Part;
            _strongPart = Part as UFIDA.U9.SCM.SM.SOUIModel.StandardSOMainUIFormWebPart;

            //_strongPart.Cust_Discount01_TextChanged
            // Cust_Discount01
            //this.ChangedBeforeDept58.AddTypeParams("ParentTaskID", this.TaskId);
            
            // Card3    TabControl0     TabPageBase    Cust_Discount01
            string cardName = "Card3";
            string tabCtrlName = "TabControl0";
            string tabPgName = "TabPageBusiness";
            string refName = "Cust_Discount01";

            string dgTabCtrlName = "TabControl1";
            string dgTabPageName = "TabPageLine";
            string datagridName = "DataGrid4";

            string dgTabTranName = "TabPageTran";
            //string finallyPriceCtrlName = "FinallyPriceTC140";
            //string discountRateCtrlName = "DiscountRate40";
            //string totalMoneyTCCtrlName = "TotalMoneyTC01";
            //string netMoneyTCCtrlName = "NetMoneyTC179";
            //string taxMoneyTCCtrlName = "TaxMoneyTC163";
            List<string> lstPriceCtrlName = new List<string>();
            lstPriceCtrlName.Add("FinallyPriceTC140");
            lstPriceCtrlName.Add("DiscountRate40");
            lstPriceCtrlName.Add("TotalMoneyTC01");
            lstPriceCtrlName.Add("NetMoneyTC179");
            lstPriceCtrlName.Add("TaxMoneyTC163");

            IUFCard card3 = (IUFCard)part.GetUFControlByName(part.TopLevelContainer, cardName);
            if (card3 != null)
            {
                IUFTabControl tc0 = (IUFTabControl)part.GetUFControlByName(card3, tabCtrlName);
                if (tc0 != null
                    && tc0.TabPages != null
                    && tc0.TabPages.Count > 0
                    )
                {
                    IUFTabPage tp1 = null;

                    foreach (IUFTabPage page in tc0.TabPages)
                    {
                        if (page != null
                            && page.ID == tabPgName
                            )
                        {
                            tp1 = page;
                            break;
                        }
                    }

                    if (tp1 != null)
                    {
                        IUFFldReference refDiscount = (IUFFldReference)part.GetUFControlByName(tp1, refName);

                        if (refDiscount != null)
                        {
                            refDiscount.AddTypeParams("ParentTaskID", _strongPart.TaskId);
                        }
                    }
                }


                IUFTabControl tc1 = (IUFTabControl)part.GetUFControlByName(card3, dgTabCtrlName);
                if (tc1 != null
                    && tc1.TabPages != null
                    && tc1.TabPages.Count > 0
                    )
                {
                    IUFTabPage tpline = null;

                    foreach (IUFTabPage page in tc1.TabPages)
                    {
                        if (page != null
                            && page.ID == dgTabPageName
                            )
                        {
                            tpline = page;
                            break;
                        }
                    }

                    if (tpline != null)
                    {
                        dgLine = (IUFDataGrid)part.GetUFControlByName(tpline, datagridName);
                    }


                    IUFTabPage tpTran = null;

                    foreach (IUFTabPage page in tc1.TabPages)
                    {
                        if (page != null
                            && page.ID == dgTabTranName
                            )
                        {
                            tpTran = page;
                            break;
                        }
                    }

                    if (tpTran != null)
                    {
                        foreach (string ctrlName in lstPriceCtrlName)
                        {
                            IUFControl ctrl = part.GetUFControlByName(tpTran, ctrlName);

                            if (ctrl != null)
                            {
                                lstPriceCtrl.Add(ctrl);
                            }
                        }
                    }
                }


            }
        }


        public override void AfterRender(UFSoft.UBF.UI.IView.IPart Part, EventArgs args)
        {
            base.AfterRender(Part, args);

            UFIDA.U9.SCM.SM.SOUIModel.SORecord head = _strongPart.Model.SO.FocusedRecord;

            if (head != null
                )
            {
                if (IsUnchangeFinallyPrice(head.DocumentType_Code))
                {
                    SetPriceControlStatus(false);
                }
                else
                {
                    SetPriceControlStatus(true);
                }

            }
        }

        private void SetPriceControlStatus(bool bl)
        {
            if (dgLine != null)
            {
                List<string> lstColumn = new List<string>();
                lstColumn.Add("FinallyPriceTC");
                lstColumn.Add("DiscountRate");
                lstColumn.Add("TotalMoneyTC");
                lstColumn.Add("NetMoneyTC");
                lstColumn.Add("TaxMoneyTC");

                //IUFDataGridColumn col = dgLine.Columns["FinallyPriceTC"];
                foreach (string str in lstColumn)
                {
                    IUFDataGridColumn col = dgLine.Columns[str];

                    if (col != null)
                    {
                        col.Enabled = bl;
                    }
                }
            }

            if (lstPriceCtrl != null
                && lstPriceCtrl.Count > 0
                )
            {
                foreach (IUFControl ctrl in lstPriceCtrl)
                {
                    if (ctrl != null)
                    {
                        ctrl.Enabled = bl;
                    }
                }
            }
        }

        private bool IsUnchangeFinallyPrice(string str)
        {
            if (!string.IsNullOrWhiteSpace(str)
                && (str == "SO03"
                    || str == "SO08"
                    || str.StartsWith("KZ")
                    )
                )
            {
                return true;
            }

            return false;
        }


    }
}
