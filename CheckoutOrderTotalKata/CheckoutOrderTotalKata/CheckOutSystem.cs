using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutOrderTotalKata
{
    public class CheckOutSystem
    {
        Dictionary<string, double> AvailableItems = new Dictionary<string, double>();
        Dictionary<string, CheckOutItem> CartItems = new Dictionary<string, CheckOutItem>();
        
        public void AddItem(string strItemName, double dItemCost)
        {
            if (!AvailableItems.ContainsKey(strItemName))
            {
                AvailableItems.Add(strItemName, dItemCost);
            }
        }

        public void ScanItem(string strItemName, double dAmount = 1)
        {
            if (CartItems.ContainsKey(strItemName))
            {
                //Increment number of items
                CartItems[strItemName].dAmount += dAmount;
            }
            else
            {
                //Add first item to cart
                CheckOutItem checkOutItem = new CheckOutItem(strItemName, dAmount, AvailableItems[strItemName]);
                CartItems.Add(strItemName, checkOutItem);
            }
        }

        public double GetTotal()
        {
            double total = 0.0;

            foreach (KeyValuePair<string, CheckOutItem> objItem in CartItems)
            {
                total += objItem.Value.Cost();
            }

            return total;
        }

        public void ApplyMarkDown(string strItemName, double dDiscount)
        {
            if (AvailableItems.ContainsKey(strItemName))
            {
                AvailableItems[strItemName] -= dDiscount;

                if (CartItems.ContainsKey(strItemName))
                {
                    CartItems[strItemName].dCost -= dDiscount;
                }
            }
        }
    }
}
