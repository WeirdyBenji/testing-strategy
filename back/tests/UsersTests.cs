using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterApi.Controllers;
using TwitterApi.Data;
using TwitterApi.Models;

namespace ApiTests
{

    [TestClass]
    public class UsersTests
    {
        private UsersController _usersController;
        private ApiContext _ctx;
        
        [TestInitialize]
        public void Initialize()
        {
            var conOpt = new DbContextOptionsBuilder<ApiContext>()
                .UseSqlite("Data Source=My.db").Options;

            _ctx = new ApiContext(conOpt);
            _ctx.Database.OpenConnection();
            _ctx.Database.Migrate();

            _ctx.Users.Add(new User()
            {
                Name = "John",
                Password = "123",
                Email = "john@doe.com"
            });
            _ctx.SaveChanges();

            _usersController = new(_ctx);
        }

        [TestCleanup]
        public void Teardown()
        {
            _ctx.Database.CloseConnection();
        }

        [TestMethod]
        public void GetUsers_ShouldReturnArray()
        {
            var actual = _usersController.Index();
            
            Assert.IsInstanceOfType(actual, typeof(Array));
        }

        [TestMethod]
        public void GetUsers_ShouldReturnArrayOfUsers()
        {
            var actual = _usersController.Index();

            Assert.IsInstanceOfType(actual, typeof(IEnumerable<User>));
        }

        [TestMethod]
        public async Task GetUser_GivenUserId_ShouldReturnOkObjectResult()
        {
            var actual = await _usersController.Show(1);

            Assert.IsInstanceOfType(actual, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetUser_GivenUserId_ShouldReturnOkObjWithUser()
        {
            var actual = await _usersController.Show(1) as OkObjectResult;

            Assert.IsInstanceOfType(actual.Value, typeof(User));
        }

        [TestMethod]
        public async Task GetUser_GivenUserId_ShouldReturnErrNotFound()
        {
            var actual = await _usersController.Show(0);

            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task CreateUser_GivenFullUser_ShouldReturnUser()
        { 
            var actual = await _usersController.Create(new User
            {
                Name = "John",
                Password = "123",
                Email = "john@doe.com"
            }) as CreatedAtActionResult;

            Assert.IsInstanceOfType(actual.Value, typeof(User));
        }

        [TestMethod]
        public async Task CreateUser_GivenUserName_ShouldReturnUE()
        {
            var actual = await _usersController.Create(new User
            {
                Name = "John"
            });

            Assert.IsInstanceOfType(actual, typeof(UnprocessableEntityResult));
        }

        [TestMethod]
        public async Task CreateUser_GivenFullUser_ShouldReturnCreatedAt()
        {
            var actual = await _usersController.Create(new User
            {
                Name = "John",
                Password = "123",
                Email = "john@doe.com"
            });

            Assert.IsInstanceOfType(actual, typeof(CreatedAtActionResult));
        }
    }
}
