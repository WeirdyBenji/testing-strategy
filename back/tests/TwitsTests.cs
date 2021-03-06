using Microsoft.AspNetCore.Mvc;
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

        [TestMethod]
        public void GetTwit_GivenTwitId_ShouldReturnTwit()
        {
            var actual = _twitsController.Get(0);

            Assert.IsInstanceOfType(actual, typeof(Twit));
        }

        [TestMethod]
        public void PutLike_GivenTwitId_ShouldReturnNotFound()
        {
            var actual = _twitsController.PutLike(-1);

            Assert.AreEqual(404, actual.StatusCode);
        }

        [TestMethod]
        public void PutLike_GivenTwitId_ShouldReturnOk()
        {
            var actual = _twitsController.PutLike(0);

            Assert.AreEqual(200, actual.StatusCode);
        }

        [TestMethod]
        public void PostRt_GivenTwitId_ShouldReturnNotFound()
        {
            var actual = _twitsController.PostRt(-1);

            Assert.AreEqual(404, actual.StatusCode);
        }

        [TestMethod]
        public void PostRt_GivenTwitId_ShouldReturnOk()
        {
            var actual = _twitsController.PostRt(0);

            Assert.AreEqual(200, actual.StatusCode);
        }

        [TestMethod]
        public void PostReply_GivenTwitId_ShouldReturnOk()
        {
            var actual = _twitsController.PostReply(0);

            Assert.AreEqual(200, actual.StatusCode);
        }
    }
}
