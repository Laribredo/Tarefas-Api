using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarefa_Api.DTO
{
    public class ResponseCadastroDTO
    {
        public bool cadastrado { get; set; }
        public List<string> erros;
    }
}
