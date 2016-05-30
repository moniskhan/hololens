using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicCrud;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string model = BasicCrud.Program.getModel("1");
            Assert.AreEqual(model, "bob");
        }
    }
}
