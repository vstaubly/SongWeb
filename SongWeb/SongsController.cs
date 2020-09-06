using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongIndexer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SongWeb
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        //OdbcConnection conn = null;
        SongFile[] songs = new SongFile[] { // dummy song list until DB code is done
            new SongFile { ID = 1, Title = "Puff the Magic Dragon", Artist = "Peter, Paul, and Mary", Album = "Ten Years After", Year = "1970", Track = "1" },
            new SongFile { ID = 2, Title = "Black Sabbath", Artist = "Black Sabbath", Album = "Black Sabbath", Year = "1970", Track = "1" }
        };

        // GET: api/<SongsController>
        [HttpGet]
        public IEnumerable<SongFile> Get()
        {
            return songs;
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SongsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
