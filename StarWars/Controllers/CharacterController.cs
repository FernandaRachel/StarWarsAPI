using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StarWars.Models;
using StarWars.Services;

namespace StarWars.Controllers
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
            var response = await _characterService.GetAllCharacterAsync();
            if (response is null)
                return Ok("Não encontrado");
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _characterService.GetCharacterAsync(id);
            if (response is null)
                return Ok("Não encontrado");
            return Ok(response);
        }
    }
}
