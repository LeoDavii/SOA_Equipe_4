using SOA_Escola_Professores.Fakes;
using SOA_Escola_Professores.Repositorios;
using System;

namespace SOA_Escola_Professores.Service
{
    public class PresencaService
    {
        private AlunoRepositoryFake _alunoRepositoryFake { get; set; }
        private AulaRepositoryFake _aulaRepositoryFake { get; set; }
        private PresencaRepository _presencaRepository { get; set; }
        private ServiceFake _serviceFake { get; set; }

        public PresencaService()
        {
            _alunoRepositoryFake = new AlunoRepositoryFake();
            _aulaRepositoryFake = new AulaRepositoryFake();
            _presencaRepository = new PresencaRepository();
            _serviceFake = new ServiceFake();
        }

        public void LançarPresença()
        {
            _serviceFake.ExibirAlunos();
            Console.Write("\nInforme o Id do aluno ao qual deseja cadastrar presença: ");
            var aluno = _alunoRepositoryFake.GetAlunoById(int.Parse(Console.ReadLine()));

            _serviceFake.ExibirAulas();
            Console.Write("\nInforme o Id da aula: ");
            var aula = _aulaRepositoryFake.GetAulaById(int.Parse(Console.ReadLine()));

            Console.Write("Informe quantas aulas o aluno obteve presença: ");
            var presencas = int.Parse(Console.ReadLine());

            Console.Write("Informe quantas aulas o aluno NÃO obteve presença: ");
            var ausencias = int.Parse(Console.ReadLine());

            _presencaRepository.CadastrarPresença(aluno, aula, presencas, ausencias);
        }

        public void ExibirPresenca()
        {
            var listaControlePresenca = _presencaRepository.ListarControlePresenca();

            Console.WriteLine("\nControle de presença:\n");

            foreach (var controle in listaControlePresenca)
            {
                Console.WriteLine($"- {controle}\n");
            }
        }
    }
}
