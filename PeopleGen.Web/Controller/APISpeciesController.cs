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
    [Route("api/[controller]")]
    [ApiController]
    public class APISpeciesController : ControllerBase
    {
        private readonly ILogger<APISpeciesController> _logger;
        private readonly APIService _apiService;

        public APISpeciesController(ILogger<APISpeciesController> logger, APIService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
        //Pulls just one species
        //[HttpGet]
        //public async Task<APISpecies> Get()
        //{
        //    return await _speciesService.GetALLSpecies();
        //}

        //pulls multiple species
        [HttpGet]
        public List<SpecificSpecies> Get()
        {
            return _apiService.GetALLSpecies();
        }
    }
}
