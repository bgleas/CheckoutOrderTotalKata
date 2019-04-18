
using System.Collections.Generic;


namespace CheckoutOrderTotalKata
{
    internal class Special
    {
        string strItemName;
        double dCriteria_Amount;
        double dDiscount_item_amount;
        double dDiscount_amount;

        public Special(string itemName, int buyN, int getM, double discount)
        {
            strItemName = itemName;
            dCriteria_Amount = buyN;
            dDiscount_item_amount = getM;
            dDiscount_amount = discount;
        }

        public double calculate_savings(Dictionary<string, CheckOutItem> availableItems)
        {
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
}