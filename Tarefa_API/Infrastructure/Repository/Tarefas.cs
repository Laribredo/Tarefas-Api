using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarefa_Api.Infrastructure.Repository
{
    public class Tarefas
    {
        public Guid? Id { get; set; }        
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DtCriacao { get; set; }
        public bool? Fixado { get; set; }
        public DateTime? DtFixado  { get; set; }
        public bool? Feito{ get; set; }
    }
}
