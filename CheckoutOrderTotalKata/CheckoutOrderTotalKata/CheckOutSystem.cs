using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutOrderTotalKata
{
    public class CheckOutSystem
    {
        Dictionary<string, double> AvailableItems = new Dictionary<string, double>();
        Dictionary<string, CheckOutItem> CartItems = new Dictionary<string, CheckOutItem>();
        List<Special> CurrentSpecials = new List<Special>();

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
                if (AvailableItems.ContainsKey(strItemName))
                {
                    //Add first item to cart
                    CheckOutItem checkOutItem = new CheckOutItem(strItemName, dAmount, AvailableItems[strItemName]);
                    CartItems.Add(strItemName, checkOutItem);
                }
                else
                {
                    throw new System.ArgumentException("Invalid Scan - Item not in system", strItemName);
                }
            }
        }

        public double GetTotal()
        {
            double total = 0.0;

            //Total inital cost of all items
            foreach (KeyValuePair<string, CheckOutItem> objItem in CartItems)
            {
                total += objItem.Value.Cost();
            }

            //Subtract savings from each special
            foreach (Special special in CurrentSpecials)
            {
                total -= special.calculate_savings(CartItems);
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

        // <Summary>
        // BuyNItemsGetMAtXOffSpecial
        // </Summary>
        public void AddBuyNItemsGetMAtXOffSpecial(string itemName, int buyN, int getM, double discount, double limit = 0)
        {
            Special special = new BuyNItemsGetMAtXOffSpecial(itemName, buyN, getM, discount, limit);
            CurrentSpecials.Add(special);
        }

        // <Summary>
        // BuyNForXSpecial
        // </Summary>
        public void AddNForXSpecial(string itemName, int buyN, double costX, double limit = 0)
        {
            Special special = new BuyNForXSpecial(itemName, buyN, costX, limit);
            CurrentSpecials.Add(special);
        }
    }
}
