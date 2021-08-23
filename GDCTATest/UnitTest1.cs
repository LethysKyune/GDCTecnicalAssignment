using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GDCTechnicalAssignment;

namespace GDCTATest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGoodEmail()
        {
            Assert.IsTrue(TAEmails.IsValidEmail("User@gmail.com"));
            Assert.IsFalse(TAEmails.IsValidEmail("User@gmail"));
        }
    }
}
