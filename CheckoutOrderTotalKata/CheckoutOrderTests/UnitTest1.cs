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
            checkOutSystem.Scan("Candy");

            Assert.AreEqual(0.75, checkOutSystem.GetTotal());
        }

        [TestMethod]
        public void AcceptMultipleScannedItemsAndHaveCorrectTotal()
        {
            checkOutSystem.Scan("Candy");
            checkOutSystem.Scan("Candy");
            checkOutSystem.Scan("Ice Cream");
            checkOutSystem.Scan("Soup");

            Assert.AreEqual(7.99, checkOutSystem.GetTotal());
        }
    }
}
