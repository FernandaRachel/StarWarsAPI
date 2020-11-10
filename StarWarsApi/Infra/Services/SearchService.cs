using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using StarWarsApi.Infra.Repositories;
using StarWarsApi.Infra.Repositories.Interfaces;
using StarWarsApi.Infra.Repositories.Models;
using StarWarsApi.Infra.Result;
using StarWarsApi.Infra.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StarWarsApi.Infra.Services
{
    public class SearchService : ISearchService
    {
        private readonly IMongoCollection<Search> _search;

        public SearchService(IOptions<SearchDatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _search = database.GetCollection<Search>(settings.Value.SearchCollectionName);
        }


        public async Task<List<SearchTermResult>> Get()
        {
            List<SearchTermResult> searchTermResult = new List<SearchTermResult>();
          
            var r = await _search.Aggregate().Group(s => s.SearchTerm,
                g => new { Result = g.Select(s => s.SearchTerm) }).ToListAsync();

            r.ForEach(doc => searchTermResult.Add( new SearchTermResult() { SeachTerm = doc.Result.FirstOrDefault(), QtdSearch = doc.Result.Count() }));

            searchTermResult = searchTermResult.OrderBy(s => s.SeachTerm).ToList();
            
            return searchTermResult;
        }

        public async Task<Search> CreateAsync(Search search)
        {
            search.SearchTerm = search.SearchTerm.ToUpper();
            await _search.InsertOneAsync(search);
            return search;
        }


        public void Remove(string id) =>
            _search.DeleteOne(search => search.Id == id);
    }
}
