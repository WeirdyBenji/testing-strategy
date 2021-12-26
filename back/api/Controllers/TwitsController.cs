using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Collections;
using System.Collections.Generic;
using TwitterApi.Models;

namespace TwitterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitsController : ControllerBase
    {
        IEnumerable<Twit> twits = new Twit[] { };

        [HttpGet]
        public IEnumerable<Twit> Get()
        {
            return new Twit[] { };
        }

        [HttpGet("id:int")]
        public Twit Get(int id)
        {
            return new Twit { };
        }

        [HttpPost("{body}")]
        public Twit Post(string body)
        {
            return new Twit {};
        }

        [HttpPut]
        public StatusCodeResult Put(int id)
        {
            if (id >= 0)
            {
            // Add the id of the user to the like array
                return Ok();
            }

            return NotFound();

        }
    }
}
