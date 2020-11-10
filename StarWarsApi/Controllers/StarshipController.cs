using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StarWarsApi.Infra.Repositories.Models;
using StarWarsApi.Infra.Services.Interfaces;
using StarWarsApi.Models;
using StarWarsApi.Services;

namespace StarWarsApi.Controllers
{
    [Route("api/[controller]")]
    public class StarshipController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly IStarshipService _starshipService;
        private readonly ISearchService _searchService;

        public StarshipController(ILogger<CharacterController> logger, IStarshipService starshipService, ISearchService searchService)
        {
            _logger = logger;
            _starshipService = starshipService;
            _searchService = searchService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _starshipService.GetAllStarshipAsync<Starship>();
            if (response is null)
                return Ok("Não encontrado");
            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            Search search = new Search() { CreateDate = DateTime.Now, SearchTerm = name, SearchType = ESearchType.Character };
            await _searchService.CreateAsync(search);

            var response = await _starshipService.GetStarshipByNameAsync(name);
            if (response is null)
                return Ok("Não encontrado");
            return Ok(response);
        }
    }
}
