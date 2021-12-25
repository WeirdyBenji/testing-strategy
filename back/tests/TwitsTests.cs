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
        private TwitsController _twitsController;

        [TestInitialize]
        public void Initialize()
        {
            _twitsController = new();
        }

        [TestMethod]
        public void GetTwits_ShouldReturnArray()
        {
            var actual = _twitsController.Get();

            Assert.IsInstanceOfType(actual, typeof(Array));
        }

        [TestMethod]
        public void GetTwits_ShouldReturnArrayOfTwits()
        {
            var actual = _twitsController.Get();

            Assert.IsInstanceOfType(actual, typeof(IEnumerable<Twit>));
        }

        [TestMethod]
        public void PostTwit_ShouldReturnCreatedTwit()
        {
            var actual = _twitsController.Post("Bonjour");

            Assert.IsInstanceOfType(actual, typeof(Twit));
        }
    }
}
