using System;

namespace SOA_Escola_Professores.Service
{
    public class MenuService
    {
        public static void MenuProfessores()
        {
            Console.WriteLine("\r\n************************ Módulo Professor ************************\n");
            Console.WriteLine("1 - Cadastrar Novo Professor");
            Console.WriteLine("2 - Listar Teachers Cadastrados");
            Console.WriteLine("3 - Atualizar Cadastro de Professor");
            Console.WriteLine("4 - Deletar Cadastro de Professor");
            Console.WriteLine("5 - Cadastrar presenças");
            Console.WriteLine("6 - Listar controle de presenças");
            Console.WriteLine("7 - Retornar ao menu anterior\n");
            Console.Write("Escolha uma das opções:");
            var opcao = Console.ReadLine();
            var professorService = new TeacherService();
            var presencaService = new PresencaService();
            switch (opcao)
            {
                case "1":
                    professorService.InserirProfessor();
                    Console.Clear();
                    MenuService.MenuProfessores();
                    break;
                case "2":
                    professorService.ExibirProfessores();
                    MenuService.MenuProfessores();
                    break;
                case "3":
                    professorService.AtualizarProfessor();
                    Console.Clear();
                    MenuService.MenuProfessores();
                    break;
                case "4":
                    professorService.DeletarProfessor();
                    Console.Clear();
                    MenuService.MenuProfessores();
                    break;
                case "5":
                    presencaService.LançarPresença();
                    Console.Clear();
                    MenuService.MenuProfessores();
                    break;
                case "6":
                    presencaService.ExibirPresenca();
                    break;
                case "7":
                    //MenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção não encontrada. Tente novamente.");
                    MenuProfessores();
                    break;
            }
        }
    }
}
