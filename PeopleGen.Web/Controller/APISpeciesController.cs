﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleGen.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleGen.Web.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class APISpeciesController : ControllerBase
    {
        private readonly ILogger<APISpeciesController> _logger;
        private readonly SpeciesAPIService _speciesService;

        public APISpeciesController(ILogger<APISpeciesController> logger, SpeciesAPIService speciesService)
        {
            _logger = logger;
            _speciesService = speciesService;
        }
        [HttpGet]
        public async Task<string> Get(string race)
        {

            return await _speciesService.get(race);


        }
    }
}