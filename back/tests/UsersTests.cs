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
        private UsersController _usersController;

        [TestInitialize]
        public void Initialize()
        {
            _usersController = new();
        }
     
        [TestMethod]
        public void GetUsers_ShouldReturnArray()
        {
            var actual = _usersController.Get();
            
            Assert.IsInstanceOfType(actual, typeof(Array));
        }

        [TestMethod]
        public void GetUsers_ShouldReturnArrayOfUsers()
        {
            var actual = _usersController.Get();

            Assert.IsInstanceOfType(actual, typeof(IEnumerable<User>));
        }

        [TestMethod]
        public void GetUsers_GivenUserId_ShouldReturnUser()
        {
            var actual = _usersController.Get(0);

            Assert.IsInstanceOfType(actual, typeof(User));
        }
    }
}
