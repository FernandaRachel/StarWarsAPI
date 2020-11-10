using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWarsApi.Infra.Services.Interfaces;

namespace StarWarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchTermController : ControllerBase
    {
        private readonly ISearchService _searchTerm;

        public SearchTermController(ISearchService searchTerm)
        {
            _searchTerm = searchTerm;
        }

        [HttpGet]
        public async Task<IActionResult> Get ()
        {
            var searchTerms = await _searchTerm.Get();

            return Ok(searchTerms);
        }
    }
}
