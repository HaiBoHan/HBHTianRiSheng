using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFIDA.U9.SM.SO;
using HBH.DoNet.DevPlatform.EntityMapping;
using UFSoft.UBF.Business;
using U9.VOB.Cus.HBHTianRiSheng.HBHHelper;

namespace U9.VOB.Cus.HBHTianRiSheng.BEPlugIn
{
    public class SO_AfterValidate: UFSoft.UBF.Eventing.IEventSubscriber
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
                //UFIDA.UBF.MD.Business.Attribute attr; attr.MD_Class_ID;
                //UFIDA.UBF.MD.Business.Entity en; en.UID;
                // 校验 整单原始金额 与 折扣是否匹配
                if (entity != null
                    //&& entity.OriginalData != null
                    )
                {
                    List<SODiscount> listDis = entity.GetHeadDiscountLines();

                    if (listDis != null
                        && listDis.Count > 0
                        )
                    {
                        //decimal soMoney = 0;
                        //decimal disMoney = 0;
                        decimal totalMoneyOriginal = 0;

                        foreach (SOLine line in entity.SOLines)
                        {
                            if (line != null)
                            {
                                decimal price = line.OrderPriceTC >= 0 ? line.OrderPriceTC : line.FinallyPriceTC;

                                totalMoneyOriginal += price * line.OrderByQtyPU;
                                //soMoney += line.TotalMoneyTC;
                            }
                        }

                        foreach (SODiscount discount in listDis)
                        {
                            //disMoney = totalMoneyOrginal * discount.DiscountRate;
                            if (discount != null
                                && discount.Discount != null
                                && !PubClass.IsNull(discount.Discount.Memo)
                                )
                            {
                                //disMoney = totalMoneyOrginal * discount.DiscountRate;

                                //if (disMoney > 0)
                                if(totalMoneyOriginal>0)
                                {
                                    decimal minMoney = 0;
                                    decimal maxMoney = 0;

                                    U9.VOB.Cus.HBHTianRiSheng.HBHHelper.SODiscountHelper.GetMoneyLimit(discount.Discount.Memo, out minMoney, out maxMoney);

                                    ////if (minMoney > 0
                                    ////    && minMoney > totalMoneyOriginal
                                    ////    )
                                    //if (!SODiscountHelper.IsMinMoneyMatch(totalMoneyOriginal, minMoney))
                                    //{
                                    //    string msg = string.Format("订单(折扣前)金额[{0}]，不可小于折扣最小金额[{1}]！"
                                    //        , totalMoneyOriginal
                                    //        , minMoney
                                    //        );
                                    //    throw new BusinessException(msg);
                                    //}

                                    ////if (maxMoney > 0
                                    ////    && totalMoneyOriginal >= maxMoney
                                    ////    )
                                    //if (!SODiscountHelper.IsMaxMoneyMatch(totalMoneyOriginal, maxMoney))
                                    //{
                                    //    string msg = string.Format("订单(折扣前)金额[{0}]，不可大于等于折扣最大金额[{1}]！"
                                    //        , totalMoneyOriginal
                                    //        , maxMoney
                                    //        );
                                    //    throw new BusinessException(msg);
                                    //}
                                    if (!SODiscountHelper.IsMoneyMatch(totalMoneyOriginal,minMoney, maxMoney))
                                    {
                                        string msg = string.Format("折扣前订单金额[{0}]，与折扣金额范围不匹配(最小金额[{1},最大金额{[2]}])！"
                                            , totalMoneyOriginal
                                            , minMoney
                                            , maxMoney
                                            );
                                        throw new BusinessException(msg);
                                    }
                                }
                            }
                        }

                    }


                    // 因为可以选折扣，所以得可以有折扣。。。只是不允许手工修改最终价，改为用前台插件控制了；
                    //// 改为转生产后可改
                    //// 临时解决   SO03 和SO08 控制最终价必须要等于定价 否则不允许保存 也不允许修改；
                    //if (entity.DocumentType != null
                    //    //&& (entity.DocumentType.Code == "SO03"
                    //    //    || entity.DocumentType.Code == "SO08"
                    //    //    )
                    //    && entity.DocumentType.IsEditableAfterToMO

                    //    // 改为开立、审核中，都校验； 因为有旧数据，立应收时候报错了。。。
                    //    && (entity.Status == SODocStatusEnum.Open
                    //        || entity.Status == SODocStatusEnum.Approving
                    //        )
                    //    )
                    //{
                    //    foreach (SOLine line in entity.SOLines)
                    //    {
                    //        if (line != null)
                    //        {
                    //            if (line.OrderPriceTC != line.FinallyPriceTC)
                    //            {
                    //                string msg = string.Format("[{0}],单号[{1}],行[{2}] 定价[{3}]不等于最终价[{4}]，不允许保存！"
                    //                        , entity.DocumentType.Name
                    //                        , entity.DocNo
                    //                        , line.DocLineNo
                    //                        , line.OrderPriceTC.ToString("G0")
                    //                        , line.FinallyPriceTC.ToString("G0")
                    //                        );
                    //                throw new BusinessException(msg);
                    //            }
                    //        }
                    //    }
                    //}



                }
            }
        }

        //public static void GetMoneyLimit(string memo, out decimal minMoney, out decimal maxMoney)
        //{
        //    minMoney = 0;
        //    maxMoney = 0;
            
        //    if (!PubClass.IsNull(memo))
        //    {
        //        string[] arr = memo.Split(new string[] { "-","万" }, StringSplitOptions.RemoveEmptyEntries);

        //        if (arr != null
        //            && arr.Length > 0
        //            )
        //        {
        //            decimal.TryParse(arr[0], out minMoney);

        //            if (arr.Length > 1)
        //            {
        //                decimal.TryParse(arr[1], out maxMoney);
        //            }
        //        }
        //    }
        //}
    }
}
