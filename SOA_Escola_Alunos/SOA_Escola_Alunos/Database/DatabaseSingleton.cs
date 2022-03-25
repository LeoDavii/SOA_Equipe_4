using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SOA_Escola_Alunos.Database
{
    public sealed class DatabaseSingleton<T>
    {
        private static DatabaseSingleton<T> _instance;
        private string _filePath { get; set; }

        private DatabaseSingleton()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();
            var relativeFilePath = config["DatabaseFilePath"];

            _filePath = Directory.GetCurrentDirectory() + relativeFilePath;
        }

        public static DatabaseSingleton<T> GetInstance()
        {
            if (_instance == null)
                _instance = new DatabaseSingleton<T>();

            return _instance;
        }


        public List<T> GetDatabase()
        {
            var registros = File.ReadAllText(_filePath);
            if (registros == "")
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(registros);
        }

        public void UpdateDatabase(List<T> database)
        {
            File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(database));
        }
    }
}
