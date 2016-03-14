

#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HBH.DoNet.DevPlatform.EntityMapping;
using UFIDA.U9.Base;
using UFSoft.UBF.Business;
using UFSoft.UBF.PL;
using UFIDA.U9.SM.Enums;

#endregion

namespace U9.VOB.Cus.HBHTianRiSheng {

	public partial class Vouchers{

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

            // 自动生成单号
            if (PubClass.IsNull(this.DocNo))
            { 
                // DyyyyMMdd***
                string strPrefix = string.Format("D{0}"
                    , Context.LoginDate.ToString("yyyyMMdd")
                    );

                /*
                
--select *
--from (
--	select 'D20160101001' as DocNo
--	union select 'D20160101002'
--	union select 'D20160101003'
--	union select 'D20160101011'
--	union select 'D20160101012'
--	union select 'D20160101012'
--	union select 'D20160101101'
--	union select 'D20160101102'
--	union select 'D20160101103'
	
--	union select 'D20160201001'
--	union select 'D20160201002'
--	union select 'D20160201003'
--	union select 'D20160202001'
--	union select 'D20160202002'
--	union select 'D20160202003'
--	union select 'D20160201001'
--	) as tmp

--order by 
--	DocNo desc 

                 */
                string opath = string.Format("DocNo like '{0}%' order by DocNo desc"
                    , strPrefix
                    );
                Vouchers vouMax = Vouchers.Finder.Find(opath);

                int flow = 0;
                if (vouMax != null
                    && vouMax.DocNo.Length >= 12
                    )
                {
                    flow = vouMax.DocNo.Substring(9, 3).GetInt();
                }

                this.DocNo = strPrefix + flow.ToString().PadLeft(3, '0');
            }
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
        protected override void OnValidate()
        {
            base.OnValidate();
            this.SelfEntityValidator();
            // TO DO: write your business code here...

            string msg = string.Empty;


            if (this.ActivityType != SMActivityEnum.ServiceUpd)
            {
                // 抵用券号重复校验
                StringBuilder sbVouNo = new StringBuilder();
                // ①本单重复
                Dictionary<string, List<long>> dicVouchersNo = new Dictionary<string, List<long>>();
                foreach (VouchersLine vline in this.VouchersLine)
                {
                    DateTime today = Context.LoginDate;
                    if (vline != null
                        && vline.IsEffectived
                        && today >= vline.EffectiveDate
                        && today <= vline.DisabledDate
                        )
                    {
                        string vouNo = vline.VouchersNo;
                        int doclineNo = vline.DocLineNo;

                        if (vouNo.IsNull())
                        {
                            msg = string.Format("单号[{0}]行[{1}]券号不允许为空!"
                                , vouNo
                                , doclineNo
                                );
                            throw new BusinessException(msg);
                        }
                        else
                        {
                            sbVouNo.Append("'").Append(vouNo).Append("',");

                            if (!dicVouchersNo.ContainsKey(vouNo))
                            {
                                dicVouchersNo.Add(vouNo, new List<long>() { doclineNo });
                            }
                            else
                            {
                                if (!dicVouchersNo[vouNo].Contains(doclineNo))
                                {
                                    dicVouchersNo[vouNo].Add(doclineNo);
                                }
                            }
                        }
                    }
                }

                if (dicVouchersNo.Count < this.VouchersLine.Count)
                {
                    StringBuilder sbErrorNo = new StringBuilder();
                    foreach (string strVouNo in dicVouchersNo.Keys)
                    {
                        List<long> list = dicVouchersNo[strVouNo];
                        if (list.Count > 1)
                        {
                            sbErrorNo.Append(string.Format("[券号{0},行号{1}]"
                                    , strVouNo
                                    , list.GetOpathFromList()
                                    )
                                );
                        }
                    }

                    if (sbErrorNo.Length > 0)
                    {
                        msg = string.Format("抵用券单{0}券号重复，重复信息:{1}"
                            , this.DocNo
                            , sbErrorNo.ToString()
                            );
                        throw new BusinessException(msg);
                    }
                }

                // ②与数据库其他有效期的抵用券重复
                if (sbVouNo.Length > 0)
                {
                    string opath = string.Format("IsEffectived = 1 and @Today between EffectiveDate and DisabledDate and Vouchers != @Vou and VouchersNo is not null and VouchersNo != '' and VouchersNo in ({0})"
                        , sbVouNo.GetStringRemoveLastSplit()
                        );
                    HBHTianRiSheng.VouchersLine.EntityList list = HBHTianRiSheng.VouchersLine.Finder.FindAll(opath
                        , new OqlParam(Context.LoginDate)
                        , new OqlParam(this.ID)
                        );

                    if (list != null
                        && list.Count > 0
                        )
                    {
                        StringBuilder sbRepeatVouNo = new StringBuilder();
                        foreach (VouchersLine line in list)
                        {
                            if (line != null
                                && line.Vouchers != null
                                )
                            {
                                sbRepeatVouNo.Append(string.Format("券号[{0}]已被单号[{1}]行号[{2}]使用! \r\n"
                                    , line.VouchersNo
                                    , line.Vouchers.DocNo
                                    , line.DocLineNo
                                    ));
                            }
                        }

                        if (sbRepeatVouNo.Length > 0)
                        {
                            throw new BusinessException(sbRepeatVouNo.ToString());
                        }
                    }
                }
            }
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
		private static Vouchers CreateDefault_Extend() {
			//TODO delete next code and add your custome code here
			throw new NotImplementedException () ;
		}
		/// <summary>
		/// Create DefaultComponent
		/// </summary>
		/// <returns>DefaultComponent Instance</returns>
		private  static Vouchers CreateDefaultComponent_Extend(){
			//TODO delete next code and add your custome code here
			throw new NotImplementedException () ;
		}
		
		#endregion 






		#region Model Methods
		#endregion		
	}
}
