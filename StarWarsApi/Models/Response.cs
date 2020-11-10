using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApi.Models
{
    public class Response<T>
    {

        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<T> results { get; set; }
    }
}
