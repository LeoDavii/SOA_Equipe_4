using SOA_Escola_Nota.Entidade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOA_Escola_Nota.Comum
{
    public class RepositoryBase<T> where T : Nota
    {
        private string pathFile { get; set; }

        public RepositoryBase(string path)
        {
            pathFile =  path;
        }

        private List<T> Database()
        {
            var registros = File.ReadAllText(pathFile);
            if (registros == "")
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(registros);
        }

        private void UpdateDatabase(List<T> database)
          =>  File.WriteAllTextAsync(pathFile, JsonSerializer.Serialize(database));

        public bool Insert(T objetos)
        {
            var dataBase = Database();
            dataBase.Add(objetos);
            UpdateDatabase(dataBase);
            return true;
        }

        public List<T> GetAll(int idProfessor)
        {
            var database = Database();
            return database.FindAll(x => x.IdProfessor == idProfessor); 
        }

        public void Delete(int idAlunno,int idProfessor)
        {
            var database = Database();
            database.RemoveAll(p => p.IdProfessor == idProfessor && p.IdAluno == idAlunno);
            UpdateDatabase(database);
        }

        public void Update(T entity)
        {
            Delete(entity.IdAluno, entity.IdProfessor);
            Insert(entity);
        }
    }
}
