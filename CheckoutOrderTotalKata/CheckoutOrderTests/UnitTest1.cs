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
        public void BuyItemsByWeightAndByUnitAndHaveCorrectTotal()
        {
            checkOutSystem.ScanItem("Soup");
            checkOutSystem.ScanItem("Soup");
            checkOutSystem.ScanItem("Ice Cream");
            checkOutSystem.ScanItem("Candy");

            checkOutSystem.ScanItem("Apples", 2.23);
            checkOutSystem.ScanItem("Pears", 1.07);

            Assert.AreEqual(13.6225, checkOutSystem.GetTotal());

        }

        [TestMethod]
        public void BuyItemsWithMarkDownAndHaveCorrectTotal()
        {
            checkOutSystem.ScanItem("Soup");
            checkOutSystem.ScanItem("Candy");

            checkOutSystem.ScanItem("Apples", 2.23);
            checkOutSystem.ScanItem("Pears", 1.07);

            checkOutSystem.ApplyMarkDown("Soup", 0.25);
            checkOutSystem.ApplyMarkDown("Apples", 0.15);

            Assert.AreEqual(6.548, checkOutSystem.GetTotal());
        }

        [TestMethod]
        public void BuyItemsWithInvalidMarkDownAndHaveCorrectTotal()
        {
            checkOutSystem.ScanItem("Soup");
            checkOutSystem.ScanItem("Candy");

            checkOutSystem.ScanItem("Apples", 2.23);
            checkOutSystem.ScanItem("Pears", 1.07);

            checkOutSystem.ApplyMarkDown("Soup", 0.25);
            checkOutSystem.ApplyMarkDown("Apples", 0.15);
            checkOutSystem.ApplyMarkDown("Apsples", 0.15);

            Assert.AreEqual(6.548, checkOutSystem.GetTotal());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException),
        "Invalid Scan - Item not in system")]
        public void ScanInvalidItemAndThrowError()
        {
            checkOutSystem.ScanItem("Soup");
            checkOutSystem.ScanItem("Cadny");
            
        }

        [TestMethod]
        public void BuySpecialBuyNItemsGetMAtXOff()
        {
            checkOutSystem.AddBuyNItemsGetMAtXOffSpecial("Candy", 1, 1, 0.50);

            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Candy");

            Assert.AreEqual(1.875, checkOutSystem.GetTotal());
        }

        [TestMethod]
        public void Buy2IceCreamsGet1Free()
        {
            checkOutSystem.AddBuyNItemsGetMAtXOffSpecial("Ice Cream", 2, 1, 1.00);

            checkOutSystem.ScanItem("Ice Cream");
            checkOutSystem.ScanItem("Ice Cream");
            checkOutSystem.ScanItem("Ice Cream");

            Assert.AreEqual(9.00, checkOutSystem.GetTotal());
        }

        [TestMethod]
        public void AddSpecialButDoNotMeetRequirements()
        {
            checkOutSystem.AddBuyNItemsGetMAtXOffSpecial("Ice Cream", 2, 1, 1.00);

            checkOutSystem.ScanItem("Ice Cream");
            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Ice Cream");

            Assert.AreEqual(9.75, checkOutSystem.GetTotal());
        }

        [TestMethod]
        public void BuySpecialNForX()
        {
            checkOutSystem.AddNForXSpecial("Candy", 4, 2.00);

            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Candy");

            Assert.AreEqual(2.75, checkOutSystem.GetTotal());
        }

        [TestMethod]
        public void BuySpecialNForXForItemNotYetAvailable()
        {
            //Do not fail in case that item is eventually added to store
            checkOutSystem.AddNForXSpecial("Reeses PB Cup", 4, 2.00);

            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Candy");
            checkOutSystem.ScanItem("Candy");

            Assert.AreEqual(3.75, checkOutSystem.GetTotal());
        }
    }
}
