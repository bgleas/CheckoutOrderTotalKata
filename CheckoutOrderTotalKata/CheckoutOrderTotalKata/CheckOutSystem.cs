using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutOrderTotalKata
{
    public class CheckOutSystem
    {
        Dictionary<string, double> AvailableItems = new Dictionary<string, double>();
        List<string> CartItems = new List<string>();

        
        public void AddItem(string strItemName, double dItemCost)
        {
            if (!AvailableItems.ContainsKey(strItemName))
            {
                AvailableItems.Add(strItemName, dItemCost);
            }
        }

        public void Scan(string strItemName)
        {
            CartItems.Add(strItemName);
        }

        public double GetTotal()
        {
            double total = 0.0;

            foreach (string strItem in CartItems)
            {
                total += AvailableItems[strItem];
            }

            return total;
        }
    }
}
