using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StarWarsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Infra.Repositories.Models
{
    public class Search
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string SearchTerm{ get; set; }
        public ESearchType SearchType { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
