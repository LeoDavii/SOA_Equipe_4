using SOA_Escola_Professores.Entidades;
using SOA_Escola_Professores.Repositorios;
using System;

namespace SOA_Escola_Professores.Service
{
    public class TeacherService
    {
        private TeachersRepository _professoresRepository { get; set; }

        public TeacherService()
        {
            _professoresRepository = new TeachersRepository();
        }

        public void InserirProfessor()
        {
            Console.WriteLine("Cadastro de professor(a)\n");

            Console.Write("Nome do(a) professor(a): ");
            var name = Console.ReadLine();

            var newProfessor = new Teachers(name);

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

            Console.Write("\nDigite o Id do professor que deseja editar: ");
            var id = int.Parse(Console.ReadLine());
            var professorEscolhido = _professoresRepository.EscolherProfessor(id);

            Console.Write("Digite o novo nome para o professor selecionado: ");
            var novoNome = Console.ReadLine();

            _professoresRepository.EditarProfessor(professorEscolhido, novoNome);
        }

        public void DeletarProfessor()
        {
            Console.Write("\nDigite o Id do professor que deseja remover: ");
            var id = int.Parse(Console.ReadLine());
            var professorEscolhido = _professoresRepository.EscolherProfessor(id);
            _professoresRepository.RemoverProfessor(professorEscolhido);
        }
    }
}
