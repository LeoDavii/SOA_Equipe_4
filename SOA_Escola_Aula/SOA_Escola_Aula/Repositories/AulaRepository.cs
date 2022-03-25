using SOA_Escola_Aula.Entities;
using System;
using System.IO;
using System.Linq;

namespace SOA_Escola_Aula.Repositories
{
    internal class AulaRepository : GenericRepository<Aula>
    {
        public AulaRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Database\aula.json";
        }

        public void Create(Aula aula)
        {
            var database = GetDatabase();
            database.Add(aula);
            UpdateDatabase(database);
        }

        public Aula GetAulaById(Guid aulaId)
        {
            var database = GetDatabase();
            var aula = database.SingleOrDefault(x => x.Id.Equals(aulaId));
            return aula;
        }

        public Aula GetAulaByMateria(string materia)
        {
            var database = GetDatabase();
            var aula = database.SingleOrDefault(x => x.Materia.Equals(materia, StringComparison.InvariantCultureIgnoreCase));
            return aula;
        }

        public void Update(Aula aulaDto)
        {
            var database = GetDatabase();
            var aulas = GetAll();

            var aula = database.SingleOrDefault(x => x.Id.Equals(aulaDto.Id));

            aula.Materia = aulaDto.Materia;

            UpdateDatabase(database);
        }

        public void DeleteByAulaId(Guid aulaId)
        {
            var database = GetDatabase();
            var aulas = GetAll();

            var index = database.FindIndex(x => x.Id.Equals(aulaId));

            aulas.RemoveAt(index);

            UpdateDatabase(database);
        }
    }
}
