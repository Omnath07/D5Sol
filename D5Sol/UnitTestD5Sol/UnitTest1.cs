using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestD5Sol;

namespace UnitTestD5Sol
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testProducts = GetJobs();
            var controller = new SimpleProductController(testProducts);

            var result = controller.GetJobs() as List<Jobs>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }
    }
}
