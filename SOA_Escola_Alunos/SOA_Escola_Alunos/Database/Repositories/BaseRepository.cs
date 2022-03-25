using SOA_Escola_Alunos.Models;
using System.Collections.Generic;
using System.Linq;

namespace SOA_Escola_Alunos.Database.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        private readonly DatabaseSingleton<T> _database;

        public BaseRepository()
        {
            _database = DatabaseSingleton<T>.GetInstance();
        }

        public List<T> GetAll() => _database.GetDatabase();

        public T GetById(int id)
        {
            var database = GetAll();
            return database.FirstOrDefault(x => x.Id == id);
        }
        public void Update(T entity)
        {
            Delete(entity);
            Add(entity);
        }

        public void Delete(T entity)
        {
            var database = GetAll();
            database.RemoveAll(p => p.Id == entity.Id);
            _database.UpdateDatabase(database);
        }

        public int Add(T entity)
        {
            var database = GetAll();
            database.Add(entity);
            _database.UpdateDatabase(database);
            return entity.Id;
        }
    }
}
