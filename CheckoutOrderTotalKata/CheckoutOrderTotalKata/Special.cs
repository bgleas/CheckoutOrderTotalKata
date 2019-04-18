
using System.Collections.Generic;


namespace CheckoutOrderTotalKata
{
    internal abstract class Special
    {

        public abstract double calculate_savings(Dictionary<string, CheckOutItem> availableItems);

    }

    internal class BuyNItemsGetMAtXOffSpecial : Special
    {
        string strItemName;
        double dCriteria_Amount;
        double dDiscount_item_amount;
        double dDiscount_amount;

        public BuyNItemsGetMAtXOffSpecial(string itemName, int buyN, int getM, double discount)
        {
            strItemName = itemName;
            dCriteria_Amount = buyN;
            dDiscount_item_amount = getM;
            dDiscount_amount = discount;
        }

        public override double calculate_savings(Dictionary<string, CheckOutItem> availableItems)
        {
            //No savings if item is not in store
            if (!availableItems.ContainsKey(strItemName))
            {
                return 0.0;
            }

            double savings = 0.0;
            CheckOutItem item = availableItems[strItemName];
            double amountOfItem = item.dAmount;

            //while having enough of item to satisfy criteria
            while (amountOfItem >= dCriteria_Amount)
            {
                amountOfItem -= dCriteria_Amount;

                //if can take full advantage of discount
                if (amountOfItem >= dDiscount_item_amount)
                {
                    amountOfItem -= dDiscount_item_amount;
                    savings += (dDiscount_item_amount * item.dCost * dDiscount_amount);
                }
                //if only taking partial advantage of discount
                else
                {
                    savings += (amountOfItem * item.dCost * dDiscount_amount);

                    amountOfItem -= amountOfItem;
                }
            }

            return savings;
        }
    }

    internal class BuyNForXSpecial : Special
    {
        string strItemName;
        int nBuyAmount;
        double dSpecialCost;

        public BuyNForXSpecial(string itemNm, int buyN, double costX)
        {
            strItemName = itemNm;
            nBuyAmount = buyN;
            dSpecialCost = costX;
        }

        public override double calculate_savings(Dictionary<string, CheckOutItem> availableItems)
        {
            //No savings if item is not in store
            if (!availableItems.ContainsKey(strItemName))
            {
                return 0.0;
            }

            double savings = 0.0;

            CheckOutItem item = availableItems[strItemName];
            double amountOfItem = item.dAmount;

            while (amountOfItem >= nBuyAmount)
            {
                amountOfItem -= nBuyAmount;
                savings += ((nBuyAmount * item.dCost) - dSpecialCost);
            }

            return savings;
        }

    }

}