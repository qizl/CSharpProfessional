using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProfessional.Tests.CSharp6.Chapter3
{
    [TestClass]
    public class PassingByValueAndReference
    {
        [TestMethod]
        public void TestRef()
        {
            var p = new Product();
            this.changeProduct(ref p);

            Assert.IsTrue(p.Name == "iPhoneXP");
        }
        private void changeProduct(ref Product p)
        {
            p.Name = "iPhone8";

            p = new Product();
            p.Name = "iPhoneXP";
            p.Price = 11000;
        }
        private class Product
        {
            public string Name { get; set; } = "iPhoneX";
            public int Price { get; set; } = 10000;
        }
    }
}
