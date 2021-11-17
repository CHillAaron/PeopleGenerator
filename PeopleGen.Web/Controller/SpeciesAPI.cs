using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleGen.Core;
using PeopleGen.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleGen.Web.Controller
{
    [Route("api/species")]
    [ApiController]
    public class SpeciesAPI : ControllerBase
    {
        private readonly ILogger<SpeciesAPI> _logger;
        private readonly SpeciesAPIService _speciesService;

        public SpeciesAPI(ILogger<SpeciesAPI> logger, SpeciesAPIService speciesService)
        {
            _logger = logger;
            _speciesService = speciesService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string race)
        {
            List<APISpecies> creatures = new List<APISpecies>();
            //creatures = await _speciesService.GetApiSpecies(race);
            return Ok("Does this work?");
        }
        //[HttpGet]
        //public async Task<string> GetSpecies(string race)
        //{
        //    List<APISpecies> creatures = new List<APISpecies>();
        //    creatures = await _speciesService.get(race);
        //    return View(creatures);
        //}

    }
}
