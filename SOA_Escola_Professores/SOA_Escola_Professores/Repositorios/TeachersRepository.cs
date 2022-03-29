using SOA_Escola_Professores.Entidades;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SOA_Escola_Professores.Repositorios
{
    public class TeachersRepository : BaseRepository<Teachers>
    {        
        public TeachersRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Database\Teachers.json";
        }

        public void EditarProfessor(Teachers professorEscolhido, string novoNome)
        {
            var professorEditado = new Teachers()
            {
                Id = professorEscolhido.Id,
                Name = novoNome
            };

            var database = GetDatabase();
            database.RemoveAll(x => x.Name == professorEscolhido.Name);
            database.Add(professorEditado);
            UpdateDatabase(database);
        }

        public List<Teachers> ListarProfessores()
        {
            return GetDatabase().ToList();
        }

        public void CriarProfessor(Teachers newProfessor)
        {
            Save(newProfessor);
        }

        public Teachers EscolherProfessor(int id)
        {
            var professorEscolhido = GetById(id);
            return professorEscolhido;
        }

        public void RemoverProfessor(Teachers professorEscolhido)
        {
            Delete(professorEscolhido);
        }

    }
}
