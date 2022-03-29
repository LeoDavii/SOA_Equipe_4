using SOA_Escola_Professores.Entidades;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SOA_Escola_Professores.Repositorios
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected string Host { get; set; }

        protected List<T> GetDatabase()
        {
            var database = File.ReadAllText(Host);
            if (database == "")
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(database);
        }

        protected void UpdateDatabase(List<T> database)
        {
            File.WriteAllTextAsync(Host, JsonSerializer.Serialize(database));
        }

        protected T GetById(int id)
        {
            var database = GetDatabase();
            return database.FirstOrDefault(x => x.Id == id);
        }

        protected void Save(T entity)
        {
            var database = GetDatabase();
            database.Add(entity);
            UpdateDatabase(database);
        }

        protected void Delete(T entity)
        {
            var database = GetDatabase();
            database.RemoveAll(x => x.Id == entity.Id);
            UpdateDatabase(database);
        }
        
    }
}
