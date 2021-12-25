using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Collections;
using System.Collections.Generic;

namespace TwitterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<AnyType> Get()
        {
            return new AnyType[] {};
        }
    }
}
