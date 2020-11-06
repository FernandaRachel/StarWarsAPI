using MongoDB.Driver;
using StarWarsApi.Infra.Repositories.Interfaces;
using StarWarsApi.Infra.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Infra.Services
{
    public class SearchService
    {
        private readonly IMongoCollection<Search> _search;

        public SearchService(ISearchDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _search = database.GetCollection<Search>(settings.SearchCollectionName);
        }

        public List<Search> Get() =>
            _search.Find(book => true).ToList();

        public Search Get(string id) =>
            _search.Find<Search>(book => book.Id == id).FirstOrDefault();

        public Search Create(Search book)
        {
            _search.InsertOne(book);
            return book;
        }

        public void Update(string id, Search bookIn) =>
            _search.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Search bookIn) =>
            _search.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _search.DeleteOne(book => book.Id == id);
    }
}
