using SOA_Escola_Professores.Entidades;
using SOA_Escola_Professores.Fakes;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SOA_Escola_Professores.Repositorios
{
    public class PresencaRepository : GenericRepository<ControleDePresenca>
    {
        public PresencaRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Database\ControleDePresenca.json";
        }

        public void CadastrarPresença(EntidadeFake aluno, EntidadeFake aula, int presencas, int ausencias)
        {
            var database = GetDatabase();

            var ausencia = new ControleDePresenca()
            {
                Presencas = presencas,
                Ausencias = ausencias,
                IdAluno = aluno.Id,
                IdAula = aula.Id,
                NomeAluno = aluno.Name,
                NomeAula = aula.Name
            };

            database.Add(ausencia);
            UpdateDatabase(database);
        }
        public List<ControleDePresenca> ListarControlePresenca()
        {
            return GetDatabase().ToList();
        }
    }
}
