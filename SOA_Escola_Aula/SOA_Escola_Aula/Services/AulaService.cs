using SOA_Escola_Aula.Entities;
using SOA_Escola_Aula.Repositories;
using System;
using System.Threading;

namespace SOA_Escola_Aula.Services
{
    internal class AulaService
    {
        private AulaRepository _aulaRepository { get; set; }

        public AulaService()
        {
            _aulaRepository = new AulaRepository();
        }

        public void CreateAula()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Aula\n");

            Console.Write("Matéria da Aula: ");
            var materia = Console.ReadLine();

            var aula = new Aula();
            aula.Materia = materia;
            _aulaRepository.Create(aula);

            Console.Clear();
            Console.WriteLine($"Aula criada com sucesso!");
        }

        public void GetAulaById()
        {
            Console.Clear();
            Console.WriteLine("Busca de Aula\n");

            Console.Write("Id da Aula: ");
            var aulaId = Console.ReadLine();

            var aula = _aulaRepository.GetAulaById(Guid.Parse(aulaId));

            Console.Clear();
            Console.WriteLine($"Matéria da aula: {aula.Materia}");
            Thread.Sleep(2000);
        }

        public void GetAulaByMateria()
        {
            Console.Clear();
            Console.WriteLine("Busca de Aula\n");

            Console.Write("Matéria da Aula: ");
            var materia = Console.ReadLine();

            var aula = _aulaRepository.GetAulaByMateria(materia);

            Console.Clear();
            Console.WriteLine($"Matéria da aula: {aula.Materia}");
            Thread.Sleep(2000);
        }

        public void UpdateAula()
        {
            Console.Clear();
            Console.WriteLine("Atualização de Aula\n");

            var aula = new Aula();

            Console.Write("Id da Aula: ");
            var aulaId = Console.ReadLine();

            aula.Id = Guid.Parse(aulaId);

            Console.Write("Nova matéria da aula: ");
            var aulaMateria = Console.ReadLine();

            aula.Materia = aulaMateria;

            _aulaRepository.Update(aula);

            Console.Clear();
            Console.WriteLine($"Aula alterada com sucesso!");
        }

        public void DeleteAula()
        {
            Console.Clear();
            Console.WriteLine("Remoção de Aula\n");

            Console.Write("Id da Aula: ");
            var aulaId = Console.ReadLine();

            _aulaRepository.DeleteByAulaId(Guid.Parse(aulaId));

            Console.Clear();
            Console.WriteLine($"Aula removida com sucesso!");
        }
    }
}
