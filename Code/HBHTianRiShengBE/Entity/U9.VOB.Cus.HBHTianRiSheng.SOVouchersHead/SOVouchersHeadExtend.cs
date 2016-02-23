

#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UFIDA.U9.SM.SO;
using UFSoft.UBF.Business;
using HBH.DoNet.DevPlatform.EntityMapping;
using UFIDA.U9.SM.Enums;
using UFIDA.U9.SPR.SalePriceList;
using UFIDA.U9.Base.Profile;
using UFSoft.UBF.PL;

#endregion

namespace U9.VOB.Cus.HBHTianRiSheng {

	public partial class SOVouchersHead{

		#region Custom Constructor

		#endregion

		#region before & after CUD V 
		/*	实体提交的事件顺序示例(QHELP) 主实体A 组合 非主实体B .
		/ (新增A和B两个实例)A.OnSetDefaultValue->B.OnSetDefaultValue-> B.OnValidate ->A.OnValidate ->A.OnInserting ->B.OnInserting ->产生提交SQL ->B.OnInserted ->A.OnInserted
		/ (仅修改B,A也会被修改))A.OnSetDefaultValue->B.OnSetDefaultValue-> B.OnValidate ->A.OnValidate ->A.OnUpdating ->B.OnUpdating ->产生提交SQL ->B.OnUpdated ->A.OnUpdated
		/ (删除A,B会被级联删除))A.OnDeleting ->B.OnDeleting ->产生提交SQL ->B.OnDeleted ->A.OnDeleted
		/	产生提交SQL顺序则看其外键，增修一对多先A后B，一对一先B后A。　删除一对多先B后A，一对一先A后B .
		*/	
		/// <summary>
		/// 设置默认值
		/// </summary>
		protected override void OnSetDefaultValue()
		{
			base.OnSetDefaultValue();
		}
		/// <summary>
		/// before Insert
		/// </summary>
		protected override void OnInserting() {
			base.OnInserting();
            // TO DO: write your business code here...

            UpdateSrcVouchers();
		}

		/// <summary>
		/// after Insert
		/// </summary>
		protected override void OnInserted() {
			base.OnInserted();
			// TO DO: write your business code here...

            UpdateSOMoney();
		}

		/// <summary>
		/// before Update
		/// </summary>
		protected override void OnUpdating() {
			base.OnUpdating();
            // TO DO: write your business code here...

            UpdateSrcVouchers();
		}

		/// <summary>
		/// after Update
		/// </summary>
		protected override void OnUpdated() {
			base.OnUpdated();
			// TO DO: write your business code here...

            UpdateSOMoney();
		}

		/// <summary>
		/// before Delete
		/// </summary>
		protected override void OnDeleting() {
			base.OnDeleting();
			// TO DO: write your business code here...

            UpdateSrcVouchers();
		}

		/// <summary>
		/// after Delete
		/// </summary>
		protected override void OnDeleted() {
			base.OnDeleted();
			// TO DO: write your business code here...

            UpdateSOMoney();
		}

		/// <summary>
		/// on Validate
		/// </summary>
		protected override void OnValidate() {
			base.OnValidate();
			this.SelfEntityValidator();
			// TO DO: write your business code here...

            if (this.SO == null)
            {
                throw new BusinessException("销售订单不可为空!");
            }

            CheckSOVouchers();
		}

        private void CheckSOVouchers()
        {
            /*
            抵用券使用控制未按照开发要求设置：1、满额抵用券只能在满额后限用一张；2、每满额抵用券的抵用张数不能大于订单原价总金额除以满额标准后的向下取整数值；3、家博会抵用券使用张数不能大于扣除爆款及配件外的订单总数量
             */
            if (this.SO != null
                && this.SO.SOLines != null
                && this.SO.SOLines.Count > 0
                )
            {
                string msg = string.Empty;

                decimal soSumQty = 0;
                decimal soOrginalMoney = 0;
                decimal soHomeExpoTotalQty = 0;
                StringBuilder sbItems = new StringBuilder();
                Dictionary<long, decimal> dicItemQty = new Dictionary<long, decimal>();
                bool isAllPart = true;
                foreach (SOLine soline in this.SO.SOLines)
                {
                    decimal qtyOrder = soline.OrderByQtyTU;
                    long itemID = soline.ItemInfo.ItemIDKey.ID;
                    decimal moneyOrder = GetSOLineMoney(soline);

                    soSumQty += qtyOrder;
                    soOrginalMoney += moneyOrder;
                    sbItems.Append(itemID).Append(",");

                    if (!dicItemQty.ContainsKey(itemID))
                    {
                        dicItemQty.Add(itemID, qtyOrder);
                    }
                    else
                    {
                        dicItemQty[itemID] += qtyOrder;
                    }
                }

                int countFulfilQuota = 0;
                int countPreFulfilQuota = 0;
                int countHomeExpo = 0;
                int countNewPromotion = 0;
                foreach (SOVouchersLine sovouline in this.SOVouchersLine)
                {
                    if (sovouline != null
                        && sovouline.VouchersLine != null
                        )
                    {
                        switch (sovouline.VouchersLine.VouchersType.Value)
                        {
                            case (int)VouchersTypeEnumData.FulfilQuota:
                                {
                                    countFulfilQuota++;
                                }
                                break;
                            case (int)VouchersTypeEnumData.PreFulfilQuota:
                                {
                                    countPreFulfilQuota++;
                                }
                                break;
                            case (int)VouchersTypeEnumData.HomeExpo:
                                {
                                    countHomeExpo++;
                                }
                                break;
                            case (int)VouchersTypeEnumData.NewPromotion:
                                {
                                    countNewPromotion++;
                                }
                                break;
                            default:
                                break;
                        }

                    }
                }

                // 1、满额抵用券只能在满额后限用一张；
                if (countFulfilQuota > 0)
                {
                    // 抵用券满额额度
                    decimal dFulFilQuota = 0;

                    Profile prof = Profile.Finder.Find("Application = @App and Code=@Code"
                        , new OqlParam(3015)
                        , new OqlParam("TianRiSheng_Vouchers_FulFilQuota")
                        );

                    if (prof != null
                        && prof.ProfileValues != null
                        && prof.ProfileValues.Count > 0
                        )
                    {
                        string profKey = prof.Code;
                        ProfileValue profValue = prof.ProfileValues[0];
                        if (profValue != null
                            )
                        {
                            string strValue = profValue.Value;

                            decimal.TryParse(strValue, out dFulFilQuota);
                        }
                    }

                    if (dFulFilQuota <= 0)
                    {
                        dFulFilQuota = 3000;
                    }

                    if (soOrginalMoney < dFulFilQuota)
                    {
                        msg = string.Format("订单汇总金额[{0}]不能小于券需满额金额[{1}]，不能使用满额抵用券！"
                            , soOrginalMoney.ToString("G0")
                            , dFulFilQuota.ToString("G0")
                            );
                        throw new BusinessException(msg);
                    }                    
                }

                // 2、每满额抵用券的抵用张数不能大于订单原价总金额除以满额标准后的向下取整数值；
                if (countPreFulfilQuota > 0)
                {
                    // 满额标准 = 私有段4
                    decimal dSOPreFulFil = this.SO.DescFlexField.PrivateDescSeg4.GetDecimal();

                    if (dSOPreFulFil <= 0)
                    {
                        msg = string.Format("满额标准为空，不可使用每满额抵用券！");
                        throw new BusinessException(msg);
                    }
                    else
                    {
                        decimal vouMaxCount = Math.Floor(soOrginalMoney / dSOPreFulFil);

                        if (countPreFulfilQuota > vouMaxCount)
                        {
                            msg = string.Format("订单实际用券数量[{0}]，不能大于本单允许用券数量[{1}] (计算:{2}/{3} )！"
                                , countPreFulfilQuota.ToString("G0")
                                , vouMaxCount.ToString("G0")
                                , soOrginalMoney.ToString("G0")
                                , dSOPreFulFil.ToString("G0")
                                );
                            throw new BusinessException(msg);
                        }
                    }
                }

                //if (countHomeExpo > 0
                //    || countNewPromotion > 0
                //    )
                //{
                //    // 爆款 = 私有段1 ， 配件 = 私有段2
                //    string priceOpath = string.Format("(DescFlexField.PrivateDescSeg1 = 'true' or DescFlexField.PrivateDescSeg2 = 'true') and ItemInfo.ItemID in ({0})"
                //        , sbItems.GetStringRemoveLastSplit()
                //        );
                //    SalePriceLine.EntityList priceList = SalePriceLine.Finder.FindAll(priceOpath);

                //    if (priceList != null
                //        && priceList.Count > 0
                //        )
                //    {
                //        foreach (SalePriceLine pLine in priceList)
                //        {
                //            if (pLine != null
                //                && pLine.ItemInfo != null
                //                && pLine.ItemInfo.ItemIDKey != null
                //                )
                //            {
                //                long itemID = pLine.ItemInfo.ItemIDKey.ID;

                //                if (dicItemQty.ContainsKey(itemID))
                //                {
                //                    dicItemQty.Remove(itemID);
                //                }
                //            }
                //        }
                //    }
                //}


                // 3、家博会抵用券使用张数不能大于扣除爆款及配件外的订单总数量
                if(countHomeExpo > 0)
                {
                    // 爆款 = 私有段1 ， 配件 = 私有段2
                    string priceOpath = string.Format("(DescFlexField.PrivateDescSeg1 = 'true' or DescFlexField.PrivateDescSeg2 = 'true') and ItemInfo.ItemID in ({0})"
                        , sbItems.GetStringRemoveLastSplit()
                        );
                    SalePriceLine.EntityList priceList = SalePriceLine.Finder.FindAll(priceOpath);

                    if (priceList != null
                        && priceList.Count > 0
                        )
                    {
                        foreach (SalePriceLine pLine in priceList)
                        {
                            if (pLine != null
                                && pLine.ItemInfo != null
                                && pLine.ItemInfo.ItemIDKey != null
                                )
                            {
                                long itemID = pLine.ItemInfo.ItemIDKey.ID;

                                if (dicItemQty.ContainsKey(itemID))
                                {
                                    dicItemQty.Remove(itemID);
                                }
                            }
                        }
                    }

                    if (dicItemQty.Count > 0)
                    {
                        foreach (decimal qty in dicItemQty.Values)
                        {
                            soHomeExpoTotalQty += qty;
                        }
                    }

                    decimal dHomeExpoQty = GetHomeExpoQty();

                    if (dHomeExpoQty > soHomeExpoTotalQty )
                    {
                        msg = string.Format("家博会抵用券数量[{0}]不可多于订单非爆款非配件商品数量[{1}]!"
                            , dHomeExpoQty
                            , soHomeExpoTotalQty
                            );
                        throw new BusinessException(msg);
                    }
                }

                // （4）	新品促销抵用券：例如水槽，销售订单发券在一定时间范围内下次购买可用，除配件什么都可以买。使用时只认券号不认人。可以配合家博会券一起使用。面值不确定。目前是500。
                if (countNewPromotion > 0)
                {
                    // 爆款 = 私有段1 ， 配件 = 私有段2
                    string priceOpath = string.Format("(DescFlexField.PrivateDescSeg2 = 'true') and ItemInfo.ItemID in ({0})"
                        , sbItems.GetStringRemoveLastSplit()
                        );
                    SalePriceLine.EntityList priceList = SalePriceLine.Finder.FindAll(priceOpath);


                    foreach (SOLine soline in this.SO.SOLines)
                    {
                        bool isPart = false;
                        if (priceList != null
                            && priceList.Count > 0
                            )
                        {
                            foreach (SalePriceLine spline in priceList)
                            {
                                if (soline.ItemInfo.ItemIDKey.ID == spline.ItemInfo.ItemIDKey.ID)
                                {
                                    isPart = true;
                                    break;
                                }
                            }
                        }

                        if (!isPart)
                        {
                            isAllPart = false;
                        }
                    }

                    if (isAllPart)
                    {
                        msg = string.Format("新品促销抵用券不可用于配件购买!"
                            );
                        throw new BusinessException(msg);
                    }
                }
            }
        }

        private decimal GetSOLineMoney(SOLine soline)
        {
            decimal money = 0;

            if (soline != null)
            { 
                // 券分摊金额 = 私有段2
                money = soline.TotalMoneyTC + soline.DescFlexField.PrivateDescSeg2.GetDecimal();
            }

            return money;
        }
        

        private decimal GetHomeExpoQty()
        {
            decimal qty = 0;
            if (this.SOVouchersLine != null
                && this.SOVouchersLine.Count > 0
                )
            {
                foreach (SOVouchersLine line in this.SOVouchersLine)
                {
                    if (line != null
                        && line.VouchersLine != null
                        && line.VouchersLine.VouchersType == VouchersTypeEnum.HomeExpo
                        )
                    {
                        qty++;
                    }
                }
            }
            return qty;
        }

		#endregion
		
		#region 异常处理，开发人员可以重新封装异常
		public override void  DealException(Exception e)
        	{
          		base.DealException(e);
          		throw e;
        	}
		#endregion

		#region  扩展属性代码区
		
		#endregion

		#region CreateDefault
		private static SOVouchersHead CreateDefault_Extend() {
			//TODO delete next code and add your custome code here
			throw new NotImplementedException () ;
		}
		/// <summary>
		/// Create DefaultComponent
		/// </summary>
		/// <returns>DefaultComponent Instance</returns>
		private  static SOVouchersHead CreateDefaultComponent_Extend(){
			//TODO delete next code and add your custome code here
			throw new NotImplementedException () ;
		}
		
		#endregion 






		#region Model Methods


        public void UpdateSrcVouchers()
        {
            using (ISession session = Session.Open())
            {
                foreach (SOVouchersLine sovouline in this.SOVouchersLine)
                {
                    VouchersLine vouLine = null;
                    if (sovouline != null
                        && sovouline.VouchersLine != null
                        )
                    {
                        vouLine = sovouline.VouchersLine;
                        if (sovouline.SysState == UFSoft.UBF.PL.Engine.ObjectState.Deleted)
                        {
                            if (sovouline.OriginalData != null)
                            {
                                vouLine = sovouline.OriginalData.VouchersLine;
                                if (vouLine != null
                                    && vouLine.IsUsed
                                    )
                                {
                                    vouLine.IsUsed = false;
                                }
                            }
                        }
                        else
                        {
                            if (vouLine != null
                                && !vouLine.IsUsed
                                )
                            {
                                vouLine.IsUsed = true;
                            }
                        }

                        // 如果换 抵用券，则删除旧抵用券的 已被使用；
                        if (sovouline.OriginalData != null
                            && sovouline.OriginalData.VouchersLine != sovouline.VouchersLine
                            )
                        {
                            vouLine = sovouline.OriginalData.VouchersLine;
                            if (vouLine != null
                                && vouLine.IsUsed
                                )
                            {
                                vouLine.IsUsed = false;
                            }
                        }
                    }


                }

                foreach (SOVouchersLine sovouline in this.SOVouchersLine.DelLists)
                {
                    if (sovouline != null
                        && sovouline.OriginalData != null
                        && sovouline.OriginalData.VouchersLine != null
                        )
                    {
                        VouchersLine vouLine = sovouline.OriginalData.VouchersLine;
                        if (vouLine != null
                            && vouLine.IsUsed
                            )
                        {
                            vouLine.IsUsed = false;
                        }
                    }
                }

                session.Commit();
            }
        }

        private void UpdateSOMoney()
        {
            decimal oldVouchersMoney = GetOldVouchersMoney();
            decimal newVouchersMoney = GetNewVouchersMoney();

            if (oldVouchersMoney != newVouchersMoney)
            {
                RecalcSOLineMoney(newVouchersMoney);
            }
        }

        private void RecalcSOLineMoney(decimal newVouMoney)
        {
            SO so = this.SO;

            if (so != null
                && so.SOLines != null
                && so.SOLines.Count > 0

                && so.TC != null
                && so.TC.MoneyRound != null
                )
            {
                using (ISession session = Session.Open())
                {
                    // 是否用券 Pub 13 
                    // 抵用劵总金额 Pub 14 
                    // 用券类型 Pub 15 
                    // 满额标准 Pri 4
                    if (newVouMoney != 0)
                    {
                        so.DescFlexField.PubDescSeg13 = true.ToString();
                    }
                    else
                    {
                        so.DescFlexField.PubDescSeg13 = false.ToString();
                    }
                    so.DescFlexField.PubDescSeg14 = newVouMoney.ToString("G0");
                    so.DescFlexField.PubDescSeg15 = this.VouchersTypeNames;

                    decimal soTotalMoney = GetSOTotalMoney(so);
                    decimal soVouTotalMoney = GetVouTotalMoney();

                    //if (soVouTotalMoney > soTotalMoney)
                    //{
                    //    foreach (SOLine soline in so.SOLines)
                    //    {
                    //        if (soline != null)
                    //        {
                    //        }
                    //    }
                    //}
                    //else
                    {
                        int lineCount = so.SOLines.Count;
                        decimal averageMoney = so.TC.MoneyRound.GetRoundValue(newVouMoney / lineCount);
                        decimal remainMoney = newVouMoney - averageMoney * lineCount;

                        SOLine maxMoneyLine = null;
                        foreach (SOLine soline in so.SOLines)
                        {
                            if (soline != null)
                            {
                                // 券分摊金额 Pri 2 
                                // 原含税金额 Pri 3 

                                decimal lineTotalMoney = 0;
                                if (!soline.DescFlexField.PrivateDescSeg3.IsNull())
                                {
                                    lineTotalMoney = PubClass.GetDecimal(soline.DescFlexField.PrivateDescSeg3);
                                }
                                else
                                {
                                    lineTotalMoney = soline.TotalMoneyTC;
                                    soline.DescFlexField.PrivateDescSeg3 = lineTotalMoney.ToString("G0");
                                }

                                if (maxMoneyLine == null
                                    || soline.TotalMoneyTC > maxMoneyLine.TotalMoneyTC
                                    )
                                {
                                    maxMoneyLine = soline;
                                }

                                //decimal line
                                SetSOLineMoney(soline, lineTotalMoney, averageMoney, ref remainMoney);
                            }
                        }

                        if (remainMoney != 0
                            && maxMoneyLine != null
                            )
                        {
                            SetSOLineMoney(maxMoneyLine
                                , PubClass.GetDecimal(maxMoneyLine.DescFlexField.PrivateDescSeg3)
                                , averageMoney + remainMoney
                                , ref remainMoney
                                );
                        }

                        so.ActionSrc = SMActivityEnum.OBAUpdate;

                        session.Commit();
                    }
                }
            }
        }

        private decimal GetVouTotalMoney()
        {
            decimal totalMoney = 0;

            if (this.SOVouchersLine != null
                && this.SOVouchersLine.Count > 0
                )
            {
                foreach (SOVouchersLine line in this.SOVouchersLine)
                {
                    if (line != null
                        && line.VouchersLine != null
                        )
                    {
                        totalMoney += line.VouchersLine.Money;
                    }
                }
            }

            return totalMoney;
        }

        private decimal GetSOTotalMoney(SO so)
        {
            decimal soTotalMoney = 0;

            if (so != null
                && so.SOLines != null
                && so.SOLines.Count > 0
                )
            {
                foreach (SOLine soline in so.SOLines)
                {
                    if (soline != null)
                    {
                        // 券分摊金额 Pri 2 
                        // 原含税金额 Pri 3 

                        decimal lineMoney = 0;
                        if (!soline.DescFlexField.PrivateDescSeg3.IsNull())
                        {
                            lineMoney = PubClass.GetDecimal(soline.DescFlexField.PrivateDescSeg3);
                        }
                        else
                        {
                            lineMoney = soline.TotalMoneyTC;
                        }

                        soTotalMoney += lineMoney;
                    }
                } 
            }
            return soTotalMoney;
        }

        private static void SetSOLineMoney(SOLine soline, decimal lineTotalMoney, decimal vouchersMoney, ref decimal remainMoney)
        {
            string strVouMoney = vouchersMoney.ToString("G0");
            if (soline.DescFlexField.PrivateDescSeg2 != strVouMoney)
            {
                soline.DescFlexField.PrivateDescSeg2 = strVouMoney;
            }

            decimal finallyMoney = lineTotalMoney - vouchersMoney;

            if (finallyMoney > 0)
            {
                if (soline.TotalMoneyTC != finallyMoney)
                {
                    soline.TotalMoneyTC = finallyMoney;
                    soline.TotalMoneyFC = soline.TotalMoneyTC;
                    soline.TotalMoneyCC = soline.TotalMoneyTC;
                    soline.TotalMoneyAC = soline.TotalMoneyTC;

                    //soline.FinallyPriceTC = 0;
                    //soline.PriceCalField = "TotalMoneyTC";
                }
            }
            else
            {
                remainMoney += finallyMoney * -1;

                soline.FreeType = UFIDA.U9.CBO.SCM.Enums.FreeTypeEnum.Present;
            }
        }

        private decimal GetOldVouchersMoney()
        {
            decimal money = 0;

            if (this.SOVouchersLine != null
                && this.SOVouchersLine.Count > 0
                )
            { 
                foreach(SOVouchersLine line in this.SOVouchersLine)
                {
                    if(line != null
                        && line.OriginalData != null
                        && line.OriginalData.VouchersLine != null
                        && line.OriginalData.VouchersLine.Money > 0
                        )
                    {
                        money += line.OriginalData.VouchersLine.Money;
                    }
                }
            }

            if (this.SOVouchersLine.DelLists != null
                && this.SOVouchersLine.DelLists.Count > 0
                )
            {
                foreach (SOVouchersLine line in this.SOVouchersLine.DelLists)
                {
                    if (line != null
                        && line.OriginalData != null
                        && line.OriginalData.VouchersLine != null
                        && line.OriginalData.VouchersLine.Money > 0
                        )
                    {
                        money -= line.OriginalData.VouchersLine.Money;
                    }
                }
            }

            return money;
        }

        private decimal GetNewVouchersMoney()
        {
            decimal money = 0;

            if (this.SOVouchersLine != null
                && this.SOVouchersLine.Count > 0
                )
            {
                foreach (SOVouchersLine line in this.SOVouchersLine)
                {
                    if (line != null
                        && line.VouchersLine != null
                        && line.VouchersLine.Money > 0
                        )
                    {
                        money += line.VouchersLine.Money;
                    }
                }
            }

            return money;
        }


		#endregion		
	}
}
