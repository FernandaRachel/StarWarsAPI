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
    public class StarshipController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly IStarshipService _starshipService;

        public StarshipController(ILogger<CharacterController> logger, IStarshipService starshipService)
        {
            _logger = logger;
            _starshipService = starshipService;
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
            var response = await _starshipService.GetStarshipByNameAsync(name);
            if (response is null)
                return Ok("Não encontrado");
            return Ok(response);
        }
    }
}
