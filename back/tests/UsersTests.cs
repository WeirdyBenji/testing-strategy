using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterApi.Controllers;

namespace ApiTests
{
    [TestClass]
    public class UsersTests
    {
        [TestMethod]
        public void GetUsers_ShouldReturnArray()
        {
            var usersController = new UsersController();
            
            var actual = usersController.Get();
            
            Assert.IsInstanceOfType(actual, typeof(Array));
        }
    }
}
