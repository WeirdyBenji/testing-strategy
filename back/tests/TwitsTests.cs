using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TwitterApi.Controllers;

namespace ApiTests
{
    [TestClass]
    public class TwitsTests
    {
        [TestMethod]
        public void GetTwits_ShouldReturnArray()
        {
            TwitsController twitsController = new TwitsController();
            var actual = twitsController.Get();
            Assert.IsInstanceOfType(actual, typeof(Array));
        }
    }
}
