using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Infra.Repositories.Interfaces
{
    public interface ISearchDatabaseSettings
    {
        string SearchCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
