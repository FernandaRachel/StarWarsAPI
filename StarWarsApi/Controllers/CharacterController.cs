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
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly ICharacterService _characterService;
        private readonly ISearchService _searchService;

        public CharacterController(ILogger<CharacterController> logger, ICharacterService characterService, ISearchService searchService)
        {
            _logger = logger;
            _characterService = characterService;
            _searchService = searchService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _characterService.GetAllCharacterAsync<Character>();
            if (response is null)
                return Ok("Não encontrado");
            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            Search search = new Search() { CreateDate = DateTime.Now, SearchTerm = name, SearchType = ESearchType.Character };
            await _searchService.CreateAsync(search);

            var response = await _characterService.GetCharacterByNameAsync(name);
            if (response is null)
                return Ok("Não encontrado");
            return Ok(response);
        }
    }
}
