using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnagramService.Controllers
{
    /// <summary>
    /// The controller to serve up anagrams
    /// </summary>
    [Route("api/[controller]")]
    public class AnagramsController : Controller
    {
        /// <summary>
        /// Handles HttpGet requests in format "api/anagrams/act"
        /// </summary>
        /// <param name="id">The word to search</param>
        /// <returns>A list of anagrams for the given id</returns>
        [HttpGet("{id}")]
        public IEnumerable<string> Get(string id) => id.GetAnagrams();
    }
}
