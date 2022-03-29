using SOA_Escola_Professores.Repositorios;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SOA_Escola_Professores.Fakes
{
    public class AlunoRepositoryFake : BaseRepository<EntidadeFake>
    {
        public AlunoRepositoryFake()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Fakes\AlunosFake.json";
        }

        public List<EntidadeFake> ListarAlunos()
        {
            return GetDatabase().ToList();
        }

        public EntidadeFake GetAlunoById(int id)
        {
            var database = GetDatabase();
            var alunoEscolhido = database.Single(x => x.Id == id);
            return alunoEscolhido;
        }
    }
}
