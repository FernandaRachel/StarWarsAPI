using StarWarsApi.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Infra.Repositories
{
    public class SearchDatabaseSettings : ISearchDatabaseSettings
    {
        public string SearchCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
