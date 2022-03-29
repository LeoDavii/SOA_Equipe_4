using SOA_Escola_Aula.Entities;
using System;
using System.IO;
using System.Linq;

namespace SOA_Escola_Aula.Repositories
{
    public class AulaRepository
    {
        private readonly GenericRepository<Aula> _genericRepository;
        public AulaRepository()
        {
            _genericRepository = new(@"..\..\..\..\SOA_Escola_Aula\Database\aula.json"); 
        }
        public void Create(Aula aula)
        {
            _genericRepository.Add(aula);
        }
        public Aula GetAulaById(Guid aulaId)
        {
            return _genericRepository.GetById(aulaId);
        }

        public Aula GetAulaByMateria(string materia)
        {
            var database = _genericRepository.GetAll();
            var aula = database.SingleOrDefault(x => x.Materia.Equals(materia, StringComparison.InvariantCultureIgnoreCase));
            return aula;
        }

        public void Update(Aula aulaDto)
        {
            var database = _genericRepository.GetAll();

            var aula = database.SingleOrDefault(x => x.Id.Equals(aulaDto.Id));

            aula.Materia = aulaDto.Materia;

            _genericRepository.UpdateDatabase(aula);
        }

        public void DeleteByAulaId(Guid aulaId)
        {
            var database = _genericRepository.GetAll();

            var aula = database.SingleOrDefault(x => x.Id.Equals(aulaId));

            _genericRepository.Delete(aula);
        }
    }
}
