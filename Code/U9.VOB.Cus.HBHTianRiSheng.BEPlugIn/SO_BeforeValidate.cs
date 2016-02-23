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
    public class SO_BeforeValidate : UFSoft.UBF.Eventing.IEventSubscriber
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
                    )
                {
                    foreach (SOLine soline in entity.SOLines)
                    {
                        // 券分摊金额 Pri 2 
                        // 原含税金额 Pri 3 

                        if (soline != null)
                        {
                            string strVouMoney = soline.DescFlexField.PrivateDescSeg2;
                            decimal dVouchers = PubClass.GetDecimal(strVouMoney);
                            if (soline.OrderByQtyTU != soline.OriginalData.OrderByQtyTU
                                && dVouchers > 0
                                )
                            {
                                //throw new BusinessException(string.Format("订单{0}行{1}已分摊抵用卷金额{2}，不允许修改行数量!"
                                //    , entity.DocNo
                                //    , soline.DocLineNo
                                //    , strVouMoney
                                //    ));
                            }

                            if (dVouchers == 0)
                            {
                                string newMoney = soline.TotalMoneyTC.ToString("G0");
                                if (soline.DescFlexField.PrivateDescSeg3 != newMoney)
                                {
                                    soline.DescFlexField.PrivateDescSeg3 = newMoney;
                                }
                            }

                            ////// 数量有变化，重新赋值、重新算金额、扣劵
                            ////if (soline.SysState == UFSoft.UBF.PL.Engine.ObjectState.Inserted
                            ////    || soline.OriginalData == null
                            ////    || soline.OrderByQtyTU != soline.OriginalData.OrderByQtyTU
                            ////    )
                            //{
                            //    //if (soline.DescFlexField.PrivateDescSeg2.IsNull())
                            //    //{
                            //    //    soline.DescFlexField.PrivateDescSeg3 = soline.TotalMoneyTC.ToString("G0");
                            //    //}
                            //    string newMoney = soline.TotalMoneyTC.ToString("G0");
                            //    if (soline.DescFlexField.PrivateDescSeg3 != newMoney)
                            //    {
                            //        soline.DescFlexField.PrivateDescSeg3 = newMoney;
                            //    }
                            //}
                            ////else
                            ////{ 
                                
                            ////}
                        }
                    }

                }
            }
        }
    }
}
