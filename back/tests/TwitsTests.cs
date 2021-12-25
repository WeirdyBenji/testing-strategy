using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TwitterApi.Controllers;
using TwitterApi.Models;

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

        [TestMethod]
        public void GetTwits_ShouldReturnArrayOfTwits()
        {
            TwitsController twitsController = new TwitsController();

            var actual = twitsController.Get();

            Assert.IsInstanceOfType(actual, typeof(IEnumerable<Twit>));

        }
    }
}
