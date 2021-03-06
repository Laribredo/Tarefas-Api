using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Tarefa_Api.Infrastructure.Repository;
using TCC_API.Infrastructure.Repository;

namespace Tarefa_Api.Infrastructure.Context
{
    public class MongoDbContext {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        private IMongoDatabase _database { get; }

        public MongoDbContext()
        {
            try
            {
                //URL PARA CONEXÃO COM O MONGO.
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false"));
                if (true)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.None };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase("Tarefas");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<Usuarios> Usuarios
        {
            get
            {
                return _database.GetCollection<Usuarios>("Usuarios");
            }
        }

        public IMongoCollection<Tarefas> Tarefas
        {
            get
            {
                return _database.GetCollection<Tarefas>("Tarefas");
            }
        }

    }
}
