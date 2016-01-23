using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U9.VOB.Cus.HBHTianRiSheng.HBHHelper
{
    // 订单折扣公共类
    /// <summary>
    /// 订单折扣公共类
    /// </summary>
    public class SODiscountHelper
    {
        // 获取折扣备注 的 最小、最大金额
        /// <summary>
        /// 获取折扣备注 的 最小、最大金额
        /// </summary>
        /// <param name="memo"></param>
        /// <param name="minMoney"></param>
        /// <param name="maxMoney"></param>
        public static void GetMoneyLimit(string memo, out decimal minMoney, out decimal maxMoney)
        {
            minMoney = 0;
            maxMoney = 0;

            if (!string.IsNullOrEmpty(memo))
            {
                string[] arr = memo.Split(new string[] { "-", "—", "万", "(", "（" }, StringSplitOptions.RemoveEmptyEntries);

                if (arr != null
                    && arr.Length > 0
                    )
                {
                    decimal.TryParse(arr[0], out minMoney);

                    if (arr.Length > 1)
                    {
                        decimal.TryParse(arr[1], out maxMoney);
                    }
                }
            }

            // 单位是万
            decimal unit = 10000;
            minMoney *= unit;
            maxMoney *= unit;
        }

        //// 最小金额是否匹配
        ///// <summary>
        ///// 最小金额是否匹配
        ///// </summary>
        ///// <param name="totalMoneyOriginal"></param>
        ///// <param name="minMoney"></param>
        ///// <returns></returns>
        //public static bool IsMinMoneyMatch(decimal totalMoneyOriginal, decimal minMoney)
        //{
        //    if (minMoney > 0
        //        && minMoney > totalMoneyOriginal
        //        )
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //// 最大金额是否匹配
        ///// <summary>
        ///// 最大金额是否匹配
        ///// </summary>
        ///// <param name="totalMoneyOriginal"></param>
        ///// <param name="maxMoney"></param>
        ///// <returns></returns>
        //public static bool IsMaxMoneyMatch(decimal totalMoneyOriginal, decimal maxMoney)
        //{
        //    if (maxMoney > 0
        //        && totalMoneyOriginal >= maxMoney
        //        )
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        // 金额是否匹配
        /// <summary>
        /// 金额是否匹配
        /// </summary>
        /// <param name="totalMoneyOriginal"></param>
        /// <param name="minMoney"></param>
        /// <param name="maxMoney"></param>
        /// <returns></returns>
        public static bool IsMoneyMatch(decimal totalMoneyOriginal, decimal minMoney, decimal maxMoney)
        {
            if (minMoney > 0
                && minMoney > totalMoneyOriginal
                )
            {
                return false;
            }

            if (maxMoney > 0
                && totalMoneyOriginal >= maxMoney
                )
            {
                return false;
            }

            return true;            
        }
    }
}
