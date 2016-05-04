using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFIDA.U9.SM.SO;
using HBH.DoNet.DevPlatform.EntityMapping;
using UFSoft.UBF.Business;
using U9.VOB.Cus.HBHTianRiSheng.HBHHelper;
using UFIDA.U9.SM.Enums;
using UFIDA.U9.CBO.SCM.Enums;
using UFIDA.U9.SM;
using UFSoft.UBF.PL.ObjectAccess;
using UFIDA.U9.PriceCal.PriceCalSV;
using UFIDA.U9.PriceCal.PriceCalSV.Proxy;
using UFSoft.UBF.PL.Engine;
using UFIDA.U9.CBO.TradePath;
using System.Reflection;

namespace U9.VOB.Cus.HBHTianRiSheng.BEPlugIn
{
    public class SO_BeforeDefaultValue : UFSoft.UBF.Eventing.IEventSubscriber
    {
        public void Notify(params object[] args)
        {
            if (args == null || args.Length == 0 || !(args[0] is UFSoft.UBF.Business.EntityEvent))
            {
                return;
            }
            UFSoft.UBF.Business.BusinessEntity.EntityKey key = ((UFSoft.UBF.Business.EntityEvent)args[0]).EntityKey;
            if (key != null)
            {
                SO entity = key.GetEntity() as SO;

                if (entity != null
                    && entity.OriginalData != null
                    && entity.OriginalData.Status == SODocStatusEnum.Open
                    && entity.Status == SODocStatusEnum.Open
                    )
                {
                    // UI 更新修改变动了金额
                    if (entity.SysState != UFSoft.UBF.PL.Engine.ObjectState.Inserted
                        && entity.Status == SODocStatusEnum.Open

                        //&& entity.ActionSrc == SMActivityEnum.FOUIUpd
                        && entity.ActionSrc != SMActivityEnum.OBAUpdate
                        )
                    {
                        List<UIChangeInfoData> list = new List<UIChangeInfoData>();
                        int num = 0;
                        //bool isRecalcByVouchers = false;
                        foreach (SOLine line in entity.SOLines)
                        {
                            // 券分摊金额 Pri 2 
                            // 原含税金额 Pri 3 

                            if (line != null
                                && line.OriginalData != null
                                && line.OriginalData.TotalMoneyTC != line.TotalMoneyTC
                                )
                            {
                                // 重新分摊 抵用卷金额

                                line.DescFlexField.PrivateDescSeg3 = line.TotalMoneyTC.ToString("G0");
                                string strVouMoney = line.DescFlexField.PrivateDescSeg2;
                                decimal dVouchers = PubClass.GetDecimal(strVouMoney);

                                // 有抵用券金额，重新分摊
                                if (dVouchers != 0)
                                {
                                    line.TotalMoneyTC -= dVouchers;
                                    line.PriceCalField = "TotalMoneyTC";
                                    //line.OriginalData.TotalMoneyTC = 
                                    //isRecalcByVouchers = true;

                                    UIChangeInfoData uIChangeInfoData = new UIChangeInfoData
                                                        {
                                                            ActionEnum = 2,
                                                            ID = line.ID,
                                                            ObjectName = 1,
                                                            Sequence = num++
                                                        };
                                    if (entity.IsPriceIncludeTax)
                                    {
                                        uIChangeInfoData.FieldName = "TotalMoneyIncludeTax";
                                        uIChangeInfoData.OldValue = line.NetMoneyTC != 0 ? 0 : 1;
                                        uIChangeInfoData.NewValue = line.TotalMoneyTC;
                                    }
                                    else
                                    {
                                        uIChangeInfoData.FieldName = "TotalMoneyExcludeTax";
                                        uIChangeInfoData.OldValue = line.NetMoneyTC != 0 ? 0 : 1;
                                        uIChangeInfoData.NewValue = line.NetMoneyTC;
                                    }
                                    if (line.ApportionPriceTC == 1M)
                                    {
                                        line.ApportionPriceTC = 0M;
                                    }

                                    if (uIChangeInfoData != null)
                                    {
                                        list.Add(uIChangeInfoData);
                                    }
                                }
                            }
                        }

                        //if (isRecalcByVouchers)
                        {
                            //new SOPriceCal(entity).DealPriceCal(BusinessOperatorTypeEnumData.NewCreate);
                            
                            //entity.IsQuickCreate = true;

                            //entity.ActionSrc = SMActivityEnum.OBAUpdate;

                            if (SMTools.IsNotNull<UIChangeInfoData>(list))
                            {
                                //priceCalc.DealPriceCal(list, true);
                                DealPriceCal(new SOPriceCal(entity), list, true);
                            }
                        }
                    }
                }
            }
        }


        #region SO PriceCal

        public void DealPriceCal(BusinessOperatorTypeEnumData action, SO so, SOPriceCal priceCalc
            , List<UIChangeInfoData> list
            )
        {
            if (!SMTools.IsNull((ObjectList)so.SOLines))
            {
                //List<UIChangeInfoData> list = new List<UIChangeInfoData>();
                int num = 0;
                foreach (SOLine line in so.SOLines)
                {
                    UIChangeInfoData uIChangeInfoData = null;
                    //if ((so.ActionSrc == SMActivityEnum.OBAUpdate) && !so.IsQuickCreate)
                    //{
                    //    uIChangeInfoData = new UIChangeInfoData
                    //    {
                    //        ActionEnum = 2
                    //    };
                    //    if ((line.FinallyPriceTC > 0M) && (line.OrderPriceTC == 0M))
                    //    {
                    //        line.OrderPriceTC = line.FinallyPriceTC;
                    //    }
                    //    if (((line.OrderPriceTC == 0M) && (line.FinallyPriceTC == 0M)) && SMConstant.IsDiscountItemMaster(line.ItemInfo.ItemID))
                    //    {
                    //        line.FinallyPriceTC = -1M;
                    //        line.OrderPriceTC = -1M;
                    //        line.SrcDocPrice = -1M;
                    //        line.PriceSource = PriceSourceEnum.SourceDoc;
                    //    }
                    //    if (!string.IsNullOrEmpty(line.PriceCalField))
                    //    {
                    //        priceCalc.SetChangeInfoData(line, uIChangeInfoData);
                    //    }
                    //    else if (((ObjectState)line.get_SysState()).Equals((ObjectState)2))
                    //    {
                    //        if (line.PriceSource == PriceSourceEnum.PriceList)
                    //        {
                    //            uIChangeInfoData.FieldName = "QtyPriceUOM";
                    //        }
                    //        else if ((((line.TotalMoneyTC > 0M) || (line.NetMoneyTC > 0M)) || (line.FinallyPriceTC > 0M)) || (line.OrderPriceTC > 0M))
                    //        {
                    //            if ((line.PriceSource == PriceSourceEnum.Empty) && (so.ActionSrc == SMActivityEnum.OBAUpdate))
                    //            {
                    //                line.PriceSource = PriceSourceEnum.Custom;
                    //            }
                    //            if ((line.TotalMoneyTC > 0M) || (line.NetMoneyTC > 0M))
                    //            {
                    //                if (so.IsPriceIncludeTax && (line.TotalMoneyTC > 0M))
                    //                {
                    //                    uIChangeInfoData.FieldName = "TotalMoneyIncludeTax";
                    //                    uIChangeInfoData.OldValue = line.TotalMoneyTC;
                    //                    uIChangeInfoData.NewValue = line.TotalMoneyTC;
                    //                }
                    //                else if (!(so.IsPriceIncludeTax || (line.NetMoneyTC <= 0M)))
                    //                {
                    //                    uIChangeInfoData.FieldName = "TotalMoneyExcludeTax";
                    //                    uIChangeInfoData.OldValue = line.NetMoneyTC;
                    //                    uIChangeInfoData.NewValue = line.NetMoneyTC;
                    //                }
                    //                else if (line.TotalMoneyTC > 0M)
                    //                {
                    //                    uIChangeInfoData.FieldName = "TotalMoneyIncludeTax";
                    //                    uIChangeInfoData.OldValue = line.TotalMoneyTC;
                    //                    uIChangeInfoData.NewValue = line.TotalMoneyTC;
                    //                }
                    //                else
                    //                {
                    //                    uIChangeInfoData.FieldName = "TotalMoneyExcludeTax";
                    //                    uIChangeInfoData.OldValue = line.NetMoneyTC;
                    //                    uIChangeInfoData.NewValue = line.NetMoneyTC;
                    //                }
                    //            }
                    //            else if (line.FinallyPriceTC > 0M)
                    //            {
                    //                if (line.OrderPriceTC == 0M)
                    //                {
                    //                    line.OrderPriceTC = line.FinallyPriceTC;
                    //                    uIChangeInfoData.FieldName = "OrderPrice";
                    //                }
                    //                else
                    //                {
                    //                    uIChangeInfoData.FieldName = "FinallyPrice";
                    //                    uIChangeInfoData.OldValue = line.OriginalData.FinallyPriceTC;
                    //                    uIChangeInfoData.NewValue = line.FinallyPriceTC;
                    //                }
                    //            }
                    //            else if (line.OrderPriceTC > 0M)
                    //            {
                    //                uIChangeInfoData.FieldName = "OrderPrice";
                    //                uIChangeInfoData.OldValue = line.OrderPriceTC;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            uIChangeInfoData.ActionEnum = 0;
                    //        }
                    //    }
                    //    else if (!string.IsNullOrEmpty(line.PriceCalField))
                    //    {
                    //        priceCalc.SetChangeInfoData(line, uIChangeInfoData);
                    //    }
                    //    else if (line.PriceListID != line.OriginalData.PriceListID)
                    //    {
                    //        line.PriceSource = PriceSourceEnum.Empty;
                    //        uIChangeInfoData.FieldName = "PriceList";
                    //    }
                    //    else if ((((line.TotalMoneyTC > 0M) || (line.NetMoneyTC > 0M)) || (line.FinallyPriceTC > 0M)) || (line.OrderPriceTC > 0M))
                    //    {
                    //        if (line.OrderByQtyPU != line.OriginalData.OrderByQtyPU)
                    //        {
                    //            uIChangeInfoData.FieldName = "FinallyPrice";
                    //            uIChangeInfoData.OldValue = line.OriginalData.FinallyPriceTC;
                    //            uIChangeInfoData.NewValue = line.FinallyPriceTC;
                    //        }
                    //        else if (((line.TotalMoneyTC > 0M) && (line.TotalMoneyTC != line.OriginalData.TotalMoneyTC)) || ((line.NetMoneyTC > 0M) && (line.NetMoneyTC != line.OriginalData.NetMoneyTC)))
                    //        {
                    //            if (so.IsPriceIncludeTax && (line.TotalMoneyTC > 0M))
                    //            {
                    //                uIChangeInfoData.FieldName = "TotalMoneyIncludeTax";
                    //                uIChangeInfoData.OldValue = line.OriginalData.TotalMoneyTC;
                    //                uIChangeInfoData.NewValue = line.TotalMoneyTC;
                    //            }
                    //            else if (!(so.IsPriceIncludeTax || (line.NetMoneyTC <= 0M)))
                    //            {
                    //                uIChangeInfoData.FieldName = "TotalMoneyExcludeTax";
                    //                uIChangeInfoData.OldValue = line.OriginalData.NetMoneyTC;
                    //                uIChangeInfoData.NewValue = line.NetMoneyTC;
                    //            }
                    //            else if (line.TotalMoneyTC > 0M)
                    //            {
                    //                uIChangeInfoData.FieldName = "TotalMoneyIncludeTax";
                    //                uIChangeInfoData.OldValue = line.OriginalData.TotalMoneyTC;
                    //                uIChangeInfoData.NewValue = line.TotalMoneyTC;
                    //            }
                    //            else
                    //            {
                    //                uIChangeInfoData.FieldName = "TotalMoneyExcludeTax";
                    //                uIChangeInfoData.OldValue = line.OriginalData.NetMoneyTC;
                    //                uIChangeInfoData.NewValue = line.NetMoneyTC;
                    //            }
                    //        }
                    //        else if ((line.FinallyPriceTC > 0M) && (line.FinallyPriceTC != line.OriginalData.FinallyPriceTC))
                    //        {
                    //            if (line.OrderPriceTC == 0M)
                    //            {
                    //                line.OrderPriceTC = line.FinallyPriceTC;
                    //                uIChangeInfoData.FieldName = "OrderPrice";
                    //            }
                    //            else
                    //            {
                    //                uIChangeInfoData.FieldName = "FinallyPrice";
                    //                uIChangeInfoData.OldValue = line.OriginalData.FinallyPriceTC;
                    //                uIChangeInfoData.NewValue = line.FinallyPriceTC;
                    //            }
                    //        }
                    //        else if ((line.OrderPriceTC > 0M) && (line.OrderPriceTC != line.OriginalData.OrderPriceTC))
                    //        {
                    //            uIChangeInfoData.FieldName = "OrderPrice";
                    //            uIChangeInfoData.OldValue = line.OrderPriceTC;
                    //        }
                    //        else
                    //        {
                    //            uIChangeInfoData.ActionEnum = 3;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        uIChangeInfoData.ActionEnum = 0;
                    //    }
                    //    uIChangeInfoData.ID = line.ID;
                    //    uIChangeInfoData.ObjectName = 1;
                    //    uIChangeInfoData.Sequence = num++;
                    //}
                    //else
                    {
                        if (line.IsSrcPO() && line.IsFreeSOLine())
                        {
                            continue;
                        }
                        if (line.IsSrcLoanToSale() && ((ObjectState)so.SysState).Equals((ObjectState)2))
                        {
                            uIChangeInfoData = new UIChangeInfoData();
                            if (line.PriceSource == PriceSourceEnum.Empty)
                            {
                                uIChangeInfoData.FieldName = "PriceList";
                                uIChangeInfoData.OldValue = line.PriceListID;
                            }
                            else if (line.PriceSource == PriceSourceEnum.Custom)
                            {
                                uIChangeInfoData.FieldName = "OrderPrice";
                                uIChangeInfoData.OldValue = line.OrderPriceTC;
                            }
                            uIChangeInfoData.ActionEnum = 0;
                            uIChangeInfoData.ID = line.ID;
                            uIChangeInfoData.ObjectName = 1;
                            uIChangeInfoData.Sequence = num++;
                        }
                        else if ((!line.IsSrcQuotation() || (line.IsSrcQuotation() && (line.ApportionPriceTC != 1M))) && ((ObjectState)line.SysState).Equals((ObjectState)2))
                        {
                            uIChangeInfoData = new UIChangeInfoData();
                            if (line.IsSrcPO() || line.IsSrcDSO())
                            {
                                uIChangeInfoData.ActionEnum = 2;
                            }
                            else
                            {
                                uIChangeInfoData.ActionEnum = 0;
                            }
                            uIChangeInfoData.ID = line.ID;
                            uIChangeInfoData.ObjectName = 1;
                            uIChangeInfoData.Sequence = num++;
                            if ((line.TotalMoneyTC > 0M) || (line.NetMoneyTC > 0M))
                            {
                                if (line.IsSrcPO())
                                {
                                    //line.IsPriceCalDoingForPO = true;
                                    SetSOLine_IsPriceCalDoingForPO(line,true);
                                    if (line.TradePathControlMoney.Equals(ControlMoneyEnum.PriceTaxTotal))
                                    {
                                        uIChangeInfoData.FieldName = "TotalMoneyIncludeTax";
                                        uIChangeInfoData.OldValue = 0;
                                        uIChangeInfoData.NewValue = line.TotalMoneyTC;
                                    }
                                    else
                                    {
                                        uIChangeInfoData.FieldName = "TotalMoneyExcludeTax";
                                        uIChangeInfoData.OldValue = 0;
                                        uIChangeInfoData.NewValue = line.NetMoneyTC;
                                    }
                                }
                                else if (so.IsPriceIncludeTax || (line.NetMoneyTC == 0M))
                                {
                                    uIChangeInfoData.FieldName = "TotalMoneyIncludeTax";
                                    uIChangeInfoData.OldValue = line.TotalMoneyTC;
                                    uIChangeInfoData.NewValue = line.TotalMoneyTC;
                                    uIChangeInfoData.ActionEnum = 2;
                                }
                                else
                                {
                                    uIChangeInfoData.FieldName = "TotalMoneyExcludeTax";
                                    uIChangeInfoData.OldValue = line.NetMoneyTC;
                                    uIChangeInfoData.NewValue = line.NetMoneyTC;
                                    uIChangeInfoData.ActionEnum = 2;
                                }
                            }
                            else if (line.FinallyPriceTC > 0M)
                            {
                                uIChangeInfoData.FieldName = "FinallyPrice";
                                uIChangeInfoData.OldValue = line.FinallyPriceTC;
                                uIChangeInfoData.NewValue = line.FinallyPriceTC;
                            }
                            else if (line.OrderPriceTC > 0M)
                            {
                                uIChangeInfoData.FieldName = "OrderPrice";
                                uIChangeInfoData.OldValue = line.OrderPriceTC;
                            }
                            else
                            {
                                uIChangeInfoData.FieldName = "QtyPriceUOM";
                            }
                        }
                        else
                        {
                            if (((line.IsSrcPO() || ((line.TradePathKey != null) && line.TradePath.FirstSetRange.Equals(FirstSetRangeEnum.SOPositive))) && (line.NetMoneyTC == line.OriginalData.NetMoneyTC)) && (line.TotalMoneyTC == line.OriginalData.TotalMoneyTC))
                            {
                                continue;
                            }
                            uIChangeInfoData = new UIChangeInfoData
                            {
                                ActionEnum = 2,
                                ID = line.ID,
                                ObjectName = 1,
                                Sequence = num++
                            };
                            if (line.IsSrcPO())
                            {
                                //line.IsPriceCalDoingForPO = true;
                                SetSOLine_IsPriceCalDoingForPO(line, true);
                                if (line.TradePathControlMoney.Equals(ControlMoneyEnum.PriceTaxTotal))
                                {
                                    uIChangeInfoData.FieldName = "TotalMoneyIncludeTax";
                                    uIChangeInfoData.OldValue = 0;
                                    uIChangeInfoData.NewValue = line.TotalMoneyTC;
                                }
                                else
                                {
                                    uIChangeInfoData.FieldName = "TotalMoneyExcludeTax";
                                    uIChangeInfoData.OldValue = 0;
                                    uIChangeInfoData.NewValue = line.NetMoneyTC;
                                }
                            }
                            else if ((line.TradePathKey != null) && line.TradePath.FirstSetRange.Equals(FirstSetRangeEnum.SOPositive))
                            {
                                if (line.TradePathControlMoney.Equals(ControlMoneyEnum.PriceTaxTotal))
                                {
                                    uIChangeInfoData.FieldName = "TotalMoneyIncludeTax";
                                    uIChangeInfoData.OldValue = line.OriginalData.TotalMoneyTC;
                                    uIChangeInfoData.NewValue = line.TotalMoneyTC;
                                }
                                else
                                {
                                    uIChangeInfoData.FieldName = "TotalMoneyExcludeTax";
                                    uIChangeInfoData.OldValue = line.OriginalData.NetMoneyTC;
                                    uIChangeInfoData.NewValue = line.NetMoneyTC;
                                }
                            }
                            else if (so.IsPriceIncludeTax)
                            {
                                uIChangeInfoData.FieldName = "TotalMoneyIncludeTax";
                                uIChangeInfoData.OldValue = line.OriginalData.TotalMoneyTC;
                                uIChangeInfoData.NewValue = line.TotalMoneyTC;
                            }
                            else
                            {
                                uIChangeInfoData.FieldName = "TotalMoneyExcludeTax";
                                uIChangeInfoData.OldValue = line.OriginalData.NetMoneyTC;
                                uIChangeInfoData.NewValue = line.NetMoneyTC;
                            }
                            if (line.ApportionPriceTC == 1M)
                            {
                                line.ApportionPriceTC = 0M;
                            }
                        }
                    }
                    if (uIChangeInfoData != null)
                    {
                        list.Add(uIChangeInfoData);
                    }
                }
                if (SMTools.IsNotNull<UIChangeInfoData>(list))
                {
                    //priceCalc.DealPriceCal(list, true);
                    DealPriceCal(priceCalc, list, true);
                }
            }
        }

        private void SetSOLine_IsPriceCalDoingForPO(SOLine line, bool value)
        {
            //line.IsPriceCalDoingForPO = true;

            Type tp = typeof(SOLine);


            foreach (PropertyInfo rInfo in tp.GetProperties())
            {
                if (rInfo.Name == "IsPriceCalDoingForPO")
                {
                    if (rInfo.CanWrite)
                    {
                        rInfo.SetValue(line, value, null);
                    }
                }
            }

        }

        internal static void DealPriceCal(SOPriceCal priceCalc, List<UIChangeInfoData> changeList, bool isReCalFeeAfterBaseChange)
        {
            Type type = typeof(SOPriceCal);
            MethodInfo method = type.GetMethod("DealPriceCal"
                //, new Type[2] { typeof(List<UIChangeInfoData>), typeof(bool) }
                , BindingFlags.Instance | BindingFlags.NonPublic
                );

            object[] param = new object[2] { changeList , isReCalFeeAfterBaseChange };
            try
            {
                method.Invoke(priceCalc, param);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
            //return result;
        }

        //internal static void DealPriceCal(this SOPriceCal priceCalc, List<UIChangeInfoData> changeList, bool isReCalFeeAfterBaseChange)
        //{
        //    if ((changeList != null) && (changeList.Count != 0))
        //    {
        //        SDCalculatePriceProxy proxy = new SDCalculatePriceProxy
        //        {
        //            Ctx = new PriceCalContextData()
        //        };
        //        proxy.Ctx.DiscountDiffTo = priceCalc.GetDiffToSOLineOfDiscount();
        //        proxy.Ctx.FeeDiffTo = proxy.Ctx.DiscountDiffTo;
        //        proxy.Ctx.IsReCalFeeAfterBaseChange = isReCalFeeAfterBaseChange;
        //        proxy.Ctx.TaxDiffTo = 0;
        //        proxy.Doc = priceCalc.ToDocPriceInfo();
        //        proxy.Changes = changeList;
        //        DocPriceInfoData docPriceInfoData = proxy.Do();
        //        if (docPriceInfoData != null)
        //        {
        //            this.SetPriceInfo(docPriceInfoData);
        //        }
        //    }
        //}
        
        #endregion
    }
}
