using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace UnitTestD4Sol
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testJob = GetJobs();
            var controller = new SimpleProductController(testProducts);

            var result = controller.GetJobs() as List<Jobs>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }
    }
}
