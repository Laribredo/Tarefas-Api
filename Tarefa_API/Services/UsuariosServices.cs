using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarefa_Api.Infrastructure;
using TCC_API.DTO;
using TCC_API.Infrastructure.Context;
using TCC_API.Infrastructure.Repository;

namespace Tarefa_Api.Services
{
    public class UsuariosServices
    {
        private MongoDbContext context;

        public List<string> ValidaCadastro(Usuarios user)
        {
            List<string> erros = new List<string>();

            context = new MongoDbContext();
            Usuarios us = context.Usuarios.Find(s => s.email == user.email).FirstOrDefault();

            if (us != null)
            {
                erros.Add("Já existe um usuário com esse email.");
            }

            if (String.IsNullOrEmpty(user.nome))
            {
                erros.Add("É necessário ter um nome para o usuário");
            }

            if (String.IsNullOrEmpty(user.email))
            {
                erros.Add("É necessário ter um email para o usuário");

            }
            else
            if (!Util.IsValidEmail(user.email))
            {
                erros.Add("O endereço de email digitado não é válido");
            }


            if (String.IsNullOrEmpty(user.senha))
            {
                erros.Add("É necessário ter uma senha para o usuário");

            }

            return erros;

        }

        public ResponseCadastroDTO AddUsuario(Usuarios user)
        {
            ResponseCadastroDTO rs = new ResponseCadastroDTO();
            List<string> erros = ValidaCadastro(user);
            if (erros.Count == 0)
            {
                context = new MongoDbContext();

                user.id = ObjectId.GenerateNewId();
                context.Usuarios.InsertOne(user);

                rs.cadastrado = true;
            }
            else
            {
                rs.cadastrado = false;
                rs.erros = erros;
            }


            return rs;

        }

        public Usuarios Login(RequestLoginDTO request)
        {
            context = new MongoDbContext();
            Usuarios us = context.Usuarios.Find(s => s.email == request.login && s.senha == request.senha).FirstOrDefault();
            return us;
        }
    }
}
