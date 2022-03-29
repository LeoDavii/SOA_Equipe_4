using SOA_Escola_Professores.Repositorios;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SOA_Escola_Professores.Fakes
{
    public class AulaRepositoryFake : BaseRepository<EntidadeFake>
    {
        public AulaRepositoryFake()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Fakes\AulasFake.json";
        }

        public List<EntidadeFake> ListarAulas()
        {
            return GetDatabase().ToList();
        }

        public EntidadeFake GetAulaById(int id)
        {
            var database = GetDatabase();
            var alunoEscolhido = database.Single(x => x.Id == id);
            return alunoEscolhido;
        }
    }
}
