using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFIDA.U9.SM.Ship;
using UFSoft.UBF.PL;
using UFSoft.UBF.Business;
using UFIDA.U9.Base.FlexField.ValueSet;

namespace U9.VOB.Cus.HBHTianRiSheng.BEPlugIn
{
    public class Ship_AfterUpdated: UFSoft.UBF.Eventing.IEventSubscriber
    {
        //private const string Const_DeliveryTypeCode = "Z06";

        public void Notify(params object[] args)
        {
            if (args == null || args.Length == 0 || !(args[0] is UFSoft.UBF.Business.EntityEvent))
            {
                return;
            }
            UFSoft.UBF.Business.BusinessEntity.EntityKey key = ((UFSoft.UBF.Business.EntityEvent)args[0]).EntityKey;
            if (key != null)
            {
                Ship entity = key.GetEntity() as Ship;

                if (entity != null
                    && entity.OriginalData != null
                    )
                {
                    bool isApprove = false;
                    bool isUnApprove = false;

                    if (entity.Status == ShipStateEnum.Approved
                        && entity.OriginalData.Status != ShipStateEnum.Approved
                        )
                    {
                        isApprove = true;
                    }
                    else if(entity.Status != ShipStateEnum.Approved
                        && entity.OriginalData.Status == ShipStateEnum.Approved
                        )
                    {
                        isUnApprove = true;
                    }

                    if (isApprove)
                    {
                        CreateFollowService(entity);
                    }
                    else if (isUnApprove)
                    {
                        DeleteFollowService(entity);
                    }
                }
            }
        }

        private void CreateFollowService(Ship entity)
        {
            DeleteFollowService(entity);
            
            using (ISession session = Session.Open())
            {
                FollowService fs = FollowService.Create();

                fs.DocumentType = FollowServiceDocType.Finder.Find("DocHeaderSequenceStyle=@SeqStyle"
                    , new OqlParam((int)UFIDA.U9.Base.Doc.DocHeaderSequenceStyleEnumData.Auto)
                    );
                if (fs.DocumentType == null)
                {
                    throw new BusinessException("没有找到自动编号的 售后任务单单据类型。");
                }

                fs.SrcDoc = entity;
                fs.SrcDocNo = entity.DocNo;

                fs.BusinessDate = DateTime.Today;
                if (entity.OrderBy != null)
                {
                    fs.CustomerKey = entity.OrderBy.CustomerKey;
                }
                fs.Address = entity.DescFlexField.PubDescSeg2;
                fs.Contracts = entity.DescFlexField.PubDescSeg3;
                fs.Phone = entity.DescFlexField.PubDescSeg4;

                fs.PayMoney = GetTotalMoney(entity);

                // 发运方式
                fs.DeliveryType = DefineValue.Finder.Find("ValueSetDef.Code=@SetDefCode and Code=@Code"
                    , new OqlParam(U9.VOB.Cus.HBHTianRiSheng.HBHHelper.DescFlexFieldHelper.Const_DeliveryTypeCode)
                    , new OqlParam(entity.DescFlexField.PrivateDescSeg1)
                    );
                fs.DeliveryTime = DateTime.Today;
                
                session.Commit();
            }
        }

        private decimal GetTotalMoney(Ship entity)
        {
            decimal total = 0;

            if (entity != null
                && entity.ShipLines != null
                && entity.ShipLines.Count > 0
                )
            {
                foreach (ShipLine line in entity.ShipLines)
                {
                    if (line != null)
                    {
                        total += line.TotalMoneyTC;
                    }
                }
            }
            return total;
        }

        private void DeleteFollowService(Ship entity)
        {
            long shipID = entity.ID;

            FollowService.EntityList lstFs = FollowService.Finder.FindAll("SrcDoc=@SrcID"
                    , new OqlParam(shipID)
                    );

            if (lstFs != null
                && lstFs.Count > 0
                )
            {
                using (ISession session = Session.Open())
                {
                    foreach (FollowService fs in lstFs)
                    {
                        if (fs != null)
                        {
                            fs.Remove();
                        }
                    }

                    session.Commit();
                }
            }
        }
    }
}
