using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC_API.Infrastructure.Enums;

namespace TCC_API.Infrastructure.Repository
{
    public class Usuarios
    {
        public ObjectId? id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public Permissoes permissao { get; set; }
    }
}
