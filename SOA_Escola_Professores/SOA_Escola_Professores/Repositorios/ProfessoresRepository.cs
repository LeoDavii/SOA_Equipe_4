using SOA_Escola_Professores.Entidades;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SOA_Escola_Professores.Repositorios
{
    public class ProfessoresRepository : GenericRepository<Professores>
    {
        public ProfessoresRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Database\Professores.json";
        }

        public void EditarProfessor(Professores professorEscolhido, string novoNome)
        {
            var professorEditado = new Professores()
            {
                Id = professorEscolhido.Id,
                Name = novoNome
            };

            var database = GetDatabase();
            database.RemoveAll(x => x.Name == professorEscolhido.Name);
            database.Add(professorEditado);
            UpdateDatabase(database);
        }

        public List<Professores> ListarProfessores()
        {
            return GetDatabase().ToList();
        }

        public void CriarProfessor(Professores newProfessor)
        {
            var database = GetDatabase();
            database.Add(newProfessor);
            UpdateDatabase(database);
        }

        public Professores GetProfessorByName(string name)
        {
            var database = GetDatabase();
            var professorEscolhido = database.Single(x => x.Name == name);
            return professorEscolhido;
        }

        public void RemoverProfessor(Professores professorEscolhido)
        {
            var database = GetDatabase();
            database.RemoveAll(x => x.Name == professorEscolhido.Name);
            UpdateDatabase(database);
        }

    }
}
