using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Infra.Repositories.Interfaces
{
    public interface ISearchDatabaseSettings
    {
        string SearchCollectionName { get; set; }
        string ConnectionString { get; }
        string DatabaseName { get; set; }
        string Host { get; set; }
        string Port { get; set; }
        string User { get; set; }
        string Password { get; set; }
    }
}
