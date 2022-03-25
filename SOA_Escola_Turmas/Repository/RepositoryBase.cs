using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SOA_Escola_Turmas.Comum
{
    public class RepositoryBase
    {
        private string pathFile { get; set; }

        public RepositoryBase(string path)
        {
            pathFile = Directory.GetCurrentDirectory() + path;
        }

        public bool Create<T>(T objetos)
        {
            FileStream stream = File.OpenRead(pathFile);
            var database = JsonSerializer.DeserializeAsync<List<T>>(stream).Result;

            stream.Close();

            database.Add(objetos);
            File.WriteAllText(pathFile, JsonSerializer.Serialize(database));
            return true;
        }

        public List<T> ReadAll<T>()
        {
            FileStream stream = File.OpenRead(pathFile);
            return JsonSerializer.DeserializeAsync<List<T>>(stream).Result;
        }

        public bool Delete<T>(T objeto)
        {
            FileStream stream = File.OpenRead(pathFile);
            var database = JsonSerializer.DeserializeAsync<List<T>>(stream).Result;
            stream.Close();

            database.Remove(objeto);
            File.WriteAllText(pathFile, JsonSerializer.Serialize(database));
            return true;
        }
    }
}
