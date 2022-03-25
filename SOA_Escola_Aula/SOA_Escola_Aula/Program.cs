using SOA_Escola_Aula.Services;
using System;
using System.Threading;

namespace SOA_Escola_Aula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Iniciar();
        }

        static void Iniciar()
        {
            var aulaService = new AulaService();

            Console.Title = "Lets Code Escola";
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao cadastro de Aulas\n");

            Console.WriteLine("Digite a opção que você deseja\n");
            Console.WriteLine("1 - Cadastrar Aula");
            Console.WriteLine("2 - Editar Aula");
            Console.WriteLine("3 - Buscar Aula por matéria");
            Console.WriteLine("4 - Buscar Aula por id");
            Console.WriteLine("5 - Remover Aula por id");
            Console.WriteLine("0 - Sair\n");
            Console.Write("Opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    aulaService.CreateAula();
                    break;

                case "2":
                    aulaService.UpdateAula();
                    break;

                case "3":
                    aulaService.GetAulaByMateria();
                    break;

                case "4":
                    aulaService.GetAulaById();
                    break;

                case "5":
                    aulaService.DeleteAula();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\nOpção invalida, tente novamente...\n");
                    Thread.Sleep(2000);
                    Iniciar();
                    break;
            }
            Iniciar();
        }
    }
}
