

#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HBH.DoNet.DevPlatform.EntityMapping;
using UFSoft.UBF.Business;
using UFSoft.UBF.PL;

#endregion

namespace U9.VOB.Cus.HBHTianRiSheng {

	public partial class VouchersLine{

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
		}


		/// <summary>
		/// before Delete
		/// </summary>
		protected override void OnDeleting() {
			base.OnDeleting();
			// TO DO: write your business code here...

            DeleteValidate();
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

            //if (this.OriginalData != null)
            //{
            //    if (this.IsUsed)
            //    {

            //    }
            //}

            string msg = string.Empty;

            if (this.Vouchers == null)
            {
                msg = string.Format("行[{1}]抵用券头不允许为空!"
                    , this.DocLineNo
                    );
                throw new BusinessException(msg);
            }

            if (this.VouchersNo.IsNull())
            {
                msg = string.Format("单号[{0}]行[{1}]券号不允许为空!"
                    , this.Vouchers.DocNo
                    , this.DocLineNo  
                    );
                throw new BusinessException(msg);
            }

            DeleteValidate();
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
		
		private  static VouchersLine CreateDefault_Extend(U9.VOB.Cus.HBHTianRiSheng.Vouchers parentEntity) {
			//TODO delete next code and add your custome code here
			throw new NotImplementedException () ;
		}
	    		
		#endregion 






		#region Model Methods


        private void DeleteValidate()
        {
            if (this.SysState == UFSoft.UBF.PL.Engine.ObjectState.Deleted)
            {
                string msg = string.Empty;

                string opath = string.Format("VouchersLine=@VouLine");
                SOVouchersLine.EntityList lstSOVou = SOVouchersLine.Finder.FindAll(opath
                    , new OqlParam(this.ID)
                    );

                if (lstSOVou != null
                    && lstSOVou.Count > 0
                    )
                {
                    StringBuilder sbVou = new StringBuilder();
                    foreach (SOVouchersLine sovouLine in lstSOVou)
                    {
                        if (sovouLine != null)
                        {
                            sbVou.Append(string.Format("订单[{0}]抵用券行号[{1}],"
                                , sovouLine.SOVouchersHead.SO != null ? sovouLine.SOVouchersHead.SO.DocNo : string.Empty
                                , sovouLine.DocLineNo
                                ));
                        }
                    }

                    if (sbVou.Length > 0)
                    {
                        msg = string.Format("抵用券[{0}]已被引用，无法删除!引用信息:  \r\n {1}"
                            , this.VouchersNo
                            , sbVou.GetStringRemoveLastSplit()
                            );
                        throw new BusinessException(msg);
                    }
                }
            }
        }


		#endregion		
	}
}
