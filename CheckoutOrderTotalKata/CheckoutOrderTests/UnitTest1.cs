using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutOrderTotalKata;

namespace CheckoutOrderTests
{
    [TestClass]
    public class UnitTest1
    {
        CheckOutSystem checkOutSystem;

        [TestInitialize]
        public void InitalizeCatalogOfItems()
        {
            checkOutSystem = new CheckOutSystem();

            checkOutSystem.AddItem("Soup", 1.99);
            checkOutSystem.AddItem("Ice Cream", 4.50);
            checkOutSystem.AddItem("Candy", 0.75);

            checkOutSystem.AddItem("Apples", 1.25);
            checkOutSystem.AddItem("Pears", 1.50);
            checkOutSystem.AddItem("Oranges", 1.00);
        }

        [TestMethod]
        public void AcceptScannedItemAndHaveCorrectTotal()
        {
            checkOutSystem.ScanItem("Candy");

            Assert.AreEqual(0.75, checkOutSystem.GetTotal());
        }

        [TestMethod]
        public void AcceptMultipleScannedItemsAndHaveCorrectTotal()
        {
            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Ice Cream");
            checkOutSystem.ScanItem("Soup");

            Assert.AreEqual(7.99, checkOutSystem.GetTotal());
        }

        [TestMethod]
        public void BuyItemsByWeightAndByUnit()
        {
            checkOutSystem.ScanItem("Soup");
            checkOutSystem.ScanItem("Soup");
            checkOutSystem.ScanItem("Ice Cream");
            checkOutSystem.ScanItem("Candy");

            checkOutSystem.ScanItem("Apples", 2.23);
            checkOutSystem.ScanItem("Pears", 1.07);

            Assert.AreEqual(13.6225, checkOutSystem.GetTotal());

        }
    }
}
