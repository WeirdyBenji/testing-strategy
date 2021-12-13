using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.OpenApi.Any;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TwitterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public IEnumerable<AnyType> Get()
        {
            return new AnyType[] {};
        }
    }
}
