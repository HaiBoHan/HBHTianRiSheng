using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U9.VOB.Cus.HBHTianRiSheng.HBHHelper.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal minMoney = 0;
            decimal maxMoney = 0;
            string memo = "2-4万（不含4万）";

            memo = "0—2万（不含2万）";
            memo = "4-6万（不含6万）";
            memo = "50万以上";

            SODiscountHelper.GetMoneyLimit(memo, out minMoney, out maxMoney);

            Console.WriteLine(" ;最小:" + minMoney.ToString());
            Console.WriteLine(" ;最大:" + maxMoney.ToString());

            Console.ReadLine();
        }
    }
}
