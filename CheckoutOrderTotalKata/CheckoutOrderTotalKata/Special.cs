
using System.Collections.Generic;


namespace CheckoutOrderTotalKata
{
    internal abstract class Special
    {
        public double dLimit = 0.0;

        public abstract double calculate_savings(Dictionary<string, CheckOutItem> availableItems);

        public double get_limited_amount (double dAmount)
        {
            //max amount at limit, if there is a limit provided
            if (dLimit > 0 && dAmount > dLimit)
            {
                return dLimit;
            }

            return dAmount;
        }

    }

    internal class BuyNItemsGetMAtXOffSpecial : Special
    {
        string strItemName;
        double dCriteria_Amount;
        double dDiscount_item_amount;
        double dDiscount_amount;

        public BuyNItemsGetMAtXOffSpecial(string itemName, int buyN, int getM, double discount, double limit = 0)
        {
            strItemName = itemName;
            dCriteria_Amount = buyN;
            dDiscount_item_amount = getM;
            dDiscount_amount = discount;
            this.dLimit = limit;
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
            double dAmountOfItem = get_limited_amount(item.dAmount);

            //while having enough of item to satisfy criteria
            while (dAmountOfItem >= dCriteria_Amount)
            {
                dAmountOfItem -= dCriteria_Amount;

                //if can take full advantage of discount
                if (dAmountOfItem >= dDiscount_item_amount)
                {
                    dAmountOfItem -= dDiscount_item_amount;
                    savings += (dDiscount_item_amount * item.dCost * dDiscount_amount);
                }
                //if only taking partial advantage of discount
                else
                {
                    savings += (dAmountOfItem * item.dCost * dDiscount_amount);

                    dAmountOfItem -= dAmountOfItem;
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

        public BuyNForXSpecial(string itemNm, int buyN, double costX, double limit = 0)
        {
            strItemName = itemNm;
            nBuyAmount = buyN;
            dSpecialCost = costX;
            this.dLimit = limit;
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
            double dAmountOfItem = get_limited_amount(item.dAmount);

            while (dAmountOfItem >= nBuyAmount)
            {
                dAmountOfItem -= nBuyAmount;
                savings += ((nBuyAmount * item.dCost) - dSpecialCost);
            }

            return savings;
        }

    }

}