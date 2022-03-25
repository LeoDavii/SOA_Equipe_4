﻿using SOA_Escola_Aula.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SOA_Escola_Aula.Repositories
{
    public class GenericRepository<T> where T : EntidadeBase
    {
        protected string Host { get; set; }

        protected List<T> GetDatabase()
        {
            var registros = File.ReadAllText(Host);
            if (registros == "")
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(registros);
        }

        protected void UpdateDatabase(List<T> database)
        {
            File.WriteAllTextAsync(Host, JsonSerializer.Serialize(database));
        }

        public List<T> GetAll()
        {
            return GetDatabase().ToList();
        }
    }
}
