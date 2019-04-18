using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutOrderTotalKata
{
    public class CheckOutItem
    {
        public string strName;
        public double dAmount;
        public double dCost;

        public CheckOutItem(string strNm, double dAmt, double dCst)
        {
            strName = strNm;
            dAmount = dAmt;
            dCost = dCst;
        }

        public virtual double Cost()
        {
            double total_cost = (dAmount * dCost);

            return total_cost;
        }

    }
}
