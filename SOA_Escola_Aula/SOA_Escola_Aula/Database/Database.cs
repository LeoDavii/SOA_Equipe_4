using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SOA_Escola_Aula.Database
{
    public sealed class Database<T>
    {
        private static Database<T> _instance;
        private string _jsonPath { get; set; }
        private Database(string jsonPath)
        {
            _jsonPath = jsonPath;
        }
        public static Database<T> GetInstance(string jsonPath)
        {
            if (_instance == null)
                _instance = new Database<T>(jsonPath);

            return _instance;
        }
        public List<T> GetDatabase()
        {
            var registros = File.ReadAllText(_jsonPath);
            if (registros == "")
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(registros);
        }

        public void UpdateDatabase(List<T> database)
        {
            File.WriteAllTextAsync(_jsonPath, JsonSerializer.Serialize(database));
        }
    }
}
