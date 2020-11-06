using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StarWarsApi.Models;
using StarWarsApi.Services;

namespace StarWarsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly ICharacterService _characterService;

        public CharacterController(ILogger<CharacterController> logger, ICharacterService characterService)
        {
            _logger = logger;
            _characterService = characterService;
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
            var response = await _characterService.GetCharacterByNameAsync(name);
            if (response is null)
                return Ok("Não encontrado");
            return Ok(response);
        }
    }
}
