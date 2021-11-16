using Microsoft.AspNetCore.Mvc;
using PeopleGen.Core;
using PeopleGen.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeopleGen.Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesAPIController : ControllerBase
    {
        private readonly SpeciesAPIService _speciesService;
        public SpeciesAPIController(SpeciesAPIService speciesService)
        {
            _speciesService = speciesService;
        }

        //public async Task<IActionResult> Index(string race,)
        //{
        //    List<APISpecies> listOfApiSpecies = new List<APISpecies>();
        //    listOfApiSpecies = await _speciesService.GetApiSpecies(race);
        //    return View(listOfApiSpecies);
        //}



        // GET: api/<SpeciesAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET api/<SpeciesAPIController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<SpeciesAPIController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SpeciesAPIController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SpeciesAPIController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
