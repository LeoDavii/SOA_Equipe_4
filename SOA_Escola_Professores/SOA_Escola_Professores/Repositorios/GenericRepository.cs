using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SOA_Escola_Professores.Repositorios
{
    public class GenericRepository<T>
    {
        protected string Host { get; set; }

        protected List<T> GetDatabase()
        {
            var dados = File.ReadAllText(Host);
            if (dados == "")
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(dados);
        }

        protected void UpdateDatabase(List<T> database)
        {
            File.WriteAllTextAsync(Host, JsonSerializer.Serialize(database));
        }
    }
}
