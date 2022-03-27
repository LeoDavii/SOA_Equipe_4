using SOA_Escola_Aula.Database;
using SOA_Escola_Aula.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOA_Escola_Aula.Repositories
{
    public class GenericRepository<T> where T : EntidadeBase
    {
        private readonly Database<T> _database;

        public GenericRepository(string jsonPath)
        {
            _database = Database<T>.GetInstance(jsonPath);
        }

        public List<T> GetAll() => _database.GetDatabase();

        public T GetById(Guid id)
        {
            var database = GetAll();
            return database.FirstOrDefault(x => x.Id == id);
        }
        public void UpdateDatabase(T entity)
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

        public Guid Add(T entity)
        {
            var database = GetAll();
            database.Add(entity);
            _database.UpdateDatabase(database);
            return entity.Id;
        }
    }
}
