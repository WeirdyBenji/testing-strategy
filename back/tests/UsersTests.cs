using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterApi.Controllers;
using TwitterApi.Models;

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

        [TestMethod]
        public void GetUsers_ShouldReturnArrayOfUsers()
        {
            var usersController = new UsersController();

            var actual = usersController.Get();

            Assert.IsInstanceOfType(actual, typeof(IEnumerable<User>));
        }
    }
}
