using SOA_Escola_Nota.Service;
using System;

namespace SOA_Escola_Nota
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Qual o Código do Professor:");
            var idProfessor = Convert.ToInt16(Console.ReadLine());
            MenuNotas(idProfessor);
        }

        private static void MenuNotas(int idProfessor)
        {
            Console.WriteLine("************************ Módulo Notas ************************");
            Console.WriteLine("Escolha uma das opções:");
            Console.WriteLine("1 - Cadastrar Nota");
            Console.WriteLine("2 - Listar Notas do Professor Cadastrados");
            Console.WriteLine("3 - Atualizar Cadastro de Notas");
            Console.WriteLine("4 - Deletar Cadastro de Nota");
            Console.WriteLine("5 - Alterar Usuário do Sistema");
            var opcao = Console.ReadLine();
            var idAluno = 0;
            var valor = 0m;
            NotaService service = new NotaService();
            switch (opcao)
            {
                case "1":
                   
                    Console.WriteLine("Qual o Código do Aluno:");
                    idAluno = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Qual é a Nota do Aluno:");
                    valor = Convert.ToDecimal(Console.ReadLine());
                    service.InsertNota(valor, idAluno, idProfessor);
                    break;
                case "2":
                    Console.WriteLine("Qual o Código do Professor:");
                    Console.WriteLine("**** Lista de Notas ****");
                    service.ExibirNotas(idProfessor);
                    break;
                case "3":
                    Console.WriteLine("**** Informe o id do Professor e do Aluno e a Nota ser alterada: ****");
                    Console.WriteLine("Qual o Código do Aluno:");
                    idAluno = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Qual é a Nota do Aluno:");
                    valor = Convert.ToDecimal(Console.ReadLine());
                    service.UpdateNota(valor, idAluno, idProfessor);
                    break;
                case "4":
                    Console.WriteLine("**** Informe o id do Professor e do Aluno da nota a ser deletada: ****");
                    Console.WriteLine("Qual o Código do Aluno:");
                    idAluno = Convert.ToInt16(Console.ReadLine());
                    service.DeleteNota(idAluno, idProfessor);
                    break;
                case "5":
                    Console.WriteLine("**** Informe o id do Professor que vai acessar o sistema: ****");
                    idProfessor = Convert.ToInt16(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Aperte qualquer tecla para voltar ao menu anterior");
                    Console.ReadLine();
                    //  MenuPrincipal();
                    break;
            }
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu anterior");
            Console.ReadLine();
            MenuNotas(idProfessor);
        }
    }
}
