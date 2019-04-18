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
            else
            {
                throw new System.ArgumentException("Item Is Already In System", strItemName);
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
        // Buy N Items Get M At X Off Special
        // </Summary>
        public void AddBuyNItemsGetMAtXOffSpecial(string strItemName, int nBuyN, int ngetM, double dDiscount, double dLimit = 0)
        {
            Special special = new BuyNItemsGetMAtXOffSpecial(strItemName, nBuyN, ngetM, dDiscount, dLimit);
            CurrentSpecials.Add(special);
        }

        // <Summary>
        // Buy N For X Special
        // </Summary>
        public void AddNForXSpecial(string strItemName, int nBuyN, double dCostX, double dLimit = 0)
        {
            Special special = new BuyNForXSpecial(strItemName, nBuyN, dCostX, dLimit);
            CurrentSpecials.Add(special);
        }

        // <Summary>
        // Buy N get M Of Equal Or Lesser Value for X Off
        // </Summary>
        public void AddSpecialBuyNgetMOfEqualOrLesserValueforXOff(string itemNName, double itemNAmount, string itemMName, double itemMDiscount)
        {
            Special special = new BuyNgetMOfEqualOrLesserValueforXOff(itemNName, itemNAmount, itemMName, itemMDiscount);
            CurrentSpecials.Add(special);
        }

        public void RemoveScannedItem(string strItemName, double dAmount = 1)
        {
            if (CartItems.ContainsKey(strItemName))
            {
                CartItems[strItemName].dAmount -= dAmount;
            }
        }
    }
}
