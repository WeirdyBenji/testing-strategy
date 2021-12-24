using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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

        [TestMethod]
        public void CreateUser_GivenNullBody_ShouldReturnUEErr()
        {
            var actual = _usersController.Post(null);

            Assert.IsInstanceOfType(actual, typeof(UnprocessableEntityResult));
        }

        [TestMethod]
        public void CreateUser_GivenEmptyUser_ShouldReturnUEErr()
        {
            var actual = _usersController.Post(new User {});

            Assert.IsInstanceOfType(actual, typeof(UnprocessableEntityResult));
        }
    }
}
