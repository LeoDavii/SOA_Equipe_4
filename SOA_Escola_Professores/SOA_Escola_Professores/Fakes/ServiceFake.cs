using System;

namespace SOA_Escola_Professores.Fakes
{
    public class ServiceFake
    {
        private AlunoRepositoryFake _alunosRepository { get; set; }
        private AulaRepositoryFake _aulasRepository { get; set; }

        public ServiceFake()
        {
            _alunosRepository = new AlunoRepositoryFake();
            _aulasRepository = new AulaRepositoryFake();
        }

        public void ExibirAlunos()
        {
            var alunosCadastrados = _alunosRepository.ListarAlunos();

            Console.WriteLine("Lista de alunos cadastrados:");

            foreach (var aluno in alunosCadastrados)
            {
                Console.WriteLine($"- {aluno}");
            }
        }

        public void ExibirAulas()
        {
            var aulasCadastradas = _aulasRepository.ListarAulas();

            Console.WriteLine("Lista de aulas cadastradas:");

            foreach (var aula in aulasCadastradas)
            {
                Console.WriteLine($"- {aula}");
            }
        }
    }
}
