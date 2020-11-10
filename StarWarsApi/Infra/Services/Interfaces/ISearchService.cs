using MongoDB.Bson;
using StarWarsApi.Infra.Repositories.Models;
using StarWarsApi.Infra.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Infra.Services.Interfaces
{
    public interface ISearchService
    {
        Task<List<SearchTermResult>> Get();

        Task<Search> CreateAsync(Search search);

        void Remove(string id);
    }
}
