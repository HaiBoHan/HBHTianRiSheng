

#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UFIDA.U9.SM.SO;
using UFSoft.UBF.Business;
using HBH.DoNet.DevPlatform.EntityMapping;
using UFIDA.U9.SM.Enums;

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
		}

		/// <summary>
		/// after Insert
		/// </summary>
		protected override void OnInserted() {
			base.OnInserted();
			// TO DO: write your business code here...
		}

		/// <summary>
		/// before Update
		/// </summary>
		protected override void OnUpdating() {
			base.OnUpdating();
			// TO DO: write your business code here...
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
		}

		/// <summary>
		/// after Delete
		/// </summary>
		protected override void OnDeleted() {
			base.OnDeleted();
			// TO DO: write your business code here...
		}

		/// <summary>
		/// on Validate
		/// </summary>
		protected override void OnValidate() {
			base.OnValidate();
			this.SelfEntityValidator();
			// TO DO: write your business code here...
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
                    so.DescFlexField.PubDescSeg13 = true.ToString();
                    so.DescFlexField.PubDescSeg14 = newVouMoney.ToString("G0");
                    so.DescFlexField.PubDescSeg15 = this.VouchersTypeNames;

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
                            SetSOLineMoney(soline,lineTotalMoney, averageMoney);
                        }
                    }

                    if (remainMoney != 0
                        && maxMoneyLine != null
                        )
                    {
                        SetSOLineMoney(maxMoneyLine
                            , PubClass.GetDecimal(maxMoneyLine.DescFlexField.PrivateDescSeg3)
                            , averageMoney + remainMoney
                            );
                    }

                    so.ActionSrc = SMActivityEnum.OBAUpdate;

                    session.Commit();
                }
            }
        }

        private static void SetSOLineMoney(SOLine soline, decimal lineTotalMoney, decimal vouchersMoney)
        {
            string strVouMoney = vouchersMoney.ToString("G0");
            if (soline.DescFlexField.PrivateDescSeg2 != strVouMoney)
            {
                soline.DescFlexField.PrivateDescSeg2 = strVouMoney;
            }

            decimal finallyMoney = lineTotalMoney - vouchersMoney;
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

        private decimal GetOldVouchersMoney()
        {
            decimal money = 0;

            if (this.OriginalData.SOVouchersLine != null
                && this.OriginalData.SOVouchersLine.Count > 0
                )
            { 
                foreach(SOVouchersLine line in this.OriginalData.SOVouchersLine)
                {
                    if(line != null
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
