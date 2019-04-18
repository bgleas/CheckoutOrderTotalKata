using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutOrderTotalKata;

namespace CheckoutOrderTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AcceptScannedItemAndHaveCorrectTotal()
        {
            CheckOutSystem checkOutSystem = new CheckOutSystem();
            checkOutSystem.AddItem("Candy", 0.75);

            checkOutSystem.Scan("Candy");

            Assert.AreEqual(0.75, checkOutSystem.GetTotal());
        }
    }
}
