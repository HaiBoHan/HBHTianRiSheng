namespace U9.VOB.Cus.HBHTianRiSheng
{
	using System;
	using System.Collections.Generic;
	using System.Text; 
	using UFSoft.UBF.AopFrame;	
	using UFSoft.UBF.Util.Context;
    using UFSoft.UBF.Business;
    using UFSoft.UBF.PL;
    using U9.VOB.HBHCommon.U9CommonBE;

	/// <summary>
	/// Follow2FeedbackSV partial 
	/// </summary>	
	public partial class Follow2FeedbackSV 
	{	
		internal BaseStrategy Select()
		{
			return new Follow2FeedbackSVImpementStrategy();	
		}		
	}
	
    //#region  implement strategy	
	/// <summary>
	/// Impement Implement
	/// 
	/// </summary>	
	internal partial class Follow2FeedbackSVImpementStrategy : BaseStrategy
	{
		public Follow2FeedbackSVImpementStrategy() { }

		public override object Do(object obj)
		{						
			Follow2FeedbackSV bpObj = (Follow2FeedbackSV)obj;
			
			//get business operation context is as follows
			//IContext context = ContextManager.Context	
			
			//auto generating code end,underside is user custom code
			//and if you Implement replace this Exception Code...
            //throw new NotImplementedException();

            if (bpObj.FollowIDs != null
                && bpObj.FollowIDs.Count > 0
                )
            {
                using (ISession session = Session.Open())
                {
                    foreach (FollowService.EntityKey key in bpObj.FollowIDs)
                    {
                        if (key != null)
                        {
                            FollowService entity = key.GetEntity();

                            if (entity != null)
                            {
                                if (entity.Status == DocStatus.Approved)
                                {
                                    Feedback feedback = Feedback.Create();

                                    feedback.DocumentType = FeedbackDocType.Finder.Find("DocHeaderSequenceStyle=@SeqStyle"
                                        , new OqlParam((int)UFIDA.U9.Base.Doc.DocHeaderSequenceStyleEnumData.Auto)
                                        );
                                    if (feedback.DocumentType == null)
                                    {
                                        throw new BusinessException("没有找到自动编号的 售后回报单单据类型。");
                                    }

                                    feedback.Address = entity.Address;
                                    feedback.Contracts = entity.Contracts;
                                    feedback.CustomerKey = entity.CustomerKey;
                                    feedback.DeliveryTypeKey = entity.DeliveryTypeKey;
                                    //feedback.ExecuteMan = entity.DeliveryMan;
                                    feedback.ExecuteTime = entity.DeliveryTime;
                                    feedback.PayMoney = entity.PayMoney;
                                    feedback.PayType = entity.PayType;
                                    feedback.Phone = entity.Phone;
                                    feedback.SettlementDeptKey = entity.SettlementDeptKey;
                                    feedback.SrcDoc = entity;
                                    feedback.SrcDocNo = entity.DocNo;

                                    feedback.DeliveryMan = entity.DeliveryMan;
                                    feedback.DeliveryMan_Code = entity.DeliveryMan_Code;
                                    feedback.DeliveryMan_Name = entity.DeliveryMan_Name;
                                    feedback.WorkType = entity.WorkType;
                                    feedback.RequireTime = entity.RequireTime;
                                    feedback.SO = entity.SO;
                                    feedback.Item1Key = entity.Item1Key;
                                    feedback.Item2Key = entity.Item2Key;
                                    feedback.Item3Key = entity.Item3Key;
                                    
                                    feedback.Memo = entity.Memo;


                                }
                                else
                                {
                                    string msg = string.Format("单据[{0}]状态[{1}] 非审核，无法生成回报单！"
                                        , entity.DocNo
                                        , U9.VOB.HBHCommon.U9CommonBE.DocStatus.EnumRes.GetResourceByValue(entity.Status.Value)
                                        );
                                    throw new BusinessException(msg);
                                }
                            }
                        }
                    }

                    session.Commit();
                }
            }


            return null;
		}		
	}

    //#endregion
	
	
}