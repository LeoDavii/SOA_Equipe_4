using SOA_Escola_Professores.Entidades;
using SOA_Escola_Professores.Repositorios;
using System;

namespace SOA_Escola_Professores.Service
{
    public class ProfessorService
    {
        private ProfessoresRepository _professoresRepository { get; set; }

        public ProfessorService()
        {
            _professoresRepository = new ProfessoresRepository();
        }

        public void InserirProfessor()
        {
            Console.WriteLine("Cadastro de professor\n");

            Console.Write("Nome do professor: ");
            var name = Console.ReadLine();

            var newProfessor = new Professores(name);

            _professoresRepository.CriarProfessor(newProfessor);
        }

        public void ExibirProfessores()
        {
            var professoresCadastrados = _professoresRepository.ListarProfessores();

            Console.WriteLine("Lista de professores cadastrados:");

            foreach (var professor in professoresCadastrados)
            {
                Console.WriteLine($"- {professor}");
            }
        }

        public void AtualizarProfessor()
        {
            ExibirProfessores();

            Console.Write("\nDigite o nome do professor que deseja editar: ");
            var nome = Console.ReadLine();
            var professorEscolhido = _professoresRepository.GetProfessorByName(nome);

            Console.Write("Digite o novo nome para o professor selecionado: ");
            var novoNome = Console.ReadLine();

            _professoresRepository.EditarProfessor(professorEscolhido, novoNome);
        }

        public void DeletarProfessor()
        {
            Console.Write("\nDigite o nome do professor que deseja remover: ");
            var nome = Console.ReadLine();
            var professorEscolhido = _professoresRepository.GetProfessorByName(nome);
            _professoresRepository.RemoverProfessor(professorEscolhido);
        }
    }
}
