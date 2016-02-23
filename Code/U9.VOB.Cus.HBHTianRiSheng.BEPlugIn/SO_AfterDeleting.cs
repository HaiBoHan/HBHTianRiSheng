using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFIDA.U9.SM.SO;
using HBH.DoNet.DevPlatform.EntityMapping;
using UFSoft.UBF.Business;
using U9.VOB.Cus.HBHTianRiSheng.HBHHelper;
using UFSoft.UBF.PL;

namespace U9.VOB.Cus.HBHTianRiSheng.BEPlugIn
{
    public class SO_AfterDeleting: UFSoft.UBF.Eventing.IEventSubscriber
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
                    //&& entity.OriginalData != null
                    )
                {
                    SOVouchersHead.EntityList list = SOVouchersHead.Finder.FindAll("SO=@SO", new OqlParam(entity.ID));

                    if (list != null
                        && list.Count > 0
                        )
                    {
                        using (ISession session = Session.Open())
                        {
                            foreach (SOVouchersHead soVou in list)
                            {
                                if (soVou != null
                                    )
                                {
                                    soVou.Remove();
                                }
                            }

                            session.Commit();
                        }
                    }
                }
            }
        }


    }
}
