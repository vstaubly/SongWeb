using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
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
        OdbcConnection conn = null;
        string connStr = "DSN=SongsDB";

        SongFile[] songs = new SongFile[] { // dummy song list until DB code is done
            new SongFile { ID = 1, Title = "Puff the Magic Dragon", Artist = "Peter, Paul, and Mary", Album = "Ten Years After", Year = "1970", Track = "1" },
            new SongFile { ID = 2, Title = "Black Sabbath", Artist = "Black Sabbath", Album = "Black Sabbath", Year = "1970", Track = "1" }
        };

        public SongsController()
        {
            try {
                conn = new OdbcConnection(connStr);
                conn.Open();
            } catch (Exception e) {
                Console.Error.WriteLine("Error connecting to DB: " + e);
                conn = null;
            }
        }
        private string getDbString(OdbcDataReader reader, int n)
        {
            if (reader.IsDBNull(n))
                return "null";
            else
                return reader.GetString(n);
        }

        // GET: api/<SongsController>
        [HttpGet]
        public IEnumerable<SongFile> Get()
        {
            if (conn != null) {
                try {
                    List<SongFile> list = new List<SongFile>();
                    string queryStr = "SELECT id, title, artist, album, year, track FROM songs ORDER BY id";
                    OdbcCommand cmd = new OdbcCommand(queryStr, conn);
                    OdbcDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            SongFile song = new SongFile();
                            if (reader.IsDBNull(0))
                                song.ID = 0;
                            else
                                song.ID = reader.GetInt32(0);
                            song.Title = getDbString(reader, 1);
                            song.Artist = getDbString(reader, 2);
                            song.Album = getDbString(reader, 3);
                            song.Year = getDbString(reader, 4);
                            song.Track = getDbString(reader, 5);
                            list.Add(song);
                        }
                    }
                    return list;
                } catch (Exception e) {
                    Console.Error.WriteLine("Error reading from DB: " + e);
                    // should throw exception so AJAX knows to execute error handler
                    throw e;
                }
            }
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
