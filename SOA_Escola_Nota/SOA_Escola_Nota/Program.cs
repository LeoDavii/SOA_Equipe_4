using SOA_Escola_Nota.Builder;
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
            var opcao = Console.ReadLine();
            var idAluno = 0;
            NotaService service = new NotaService();
            NotaBuilder notaBuilder = new NotaBuilder();
            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Qual o Código do Professor:");
                    idProfessor = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Qual o Código do Aluno:");
                    idAluno = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Qual é a Nota do Aluno:");
                    var valor = Convert.ToDecimal(Console.ReadLine());
                    notaBuilder = new NotaBuilder();
                    notaBuilder.Valor(valor).IdAluno(idAluno).IdProfessor(idProfessor);
                    service.InsertNota(notaBuilder);
                    break;
                case "2":
                    Console.WriteLine("Qual o Código do Professor:");
                    idProfessor = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("**** Lista de Notas ****");
                    notaBuilder.IdProfessor(idProfessor);
                    service.ExibirNotas(notaBuilder);
                    break;
                case "3":
                    Console.WriteLine("**** Informe o id do Professor e do Aluno e a Nota ser alterada: ****");
                    Console.WriteLine("Qual o Código do Aluno:");
                    idAluno = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Qual é a Nota do Aluno:");
                    valor = Convert.ToDecimal(Console.ReadLine());
                    notaBuilder.Valor(valor).IdAluno(idAluno).IdProfessor(idProfessor);
                    service.UpdateNota(notaBuilder);
                    break;
                case "4":
                    Console.WriteLine("**** Informe o id do Professor e do Aluno da nota a ser deletada: ****");
                    Console.WriteLine("Qual o Código do Aluno:");
                    idAluno = Convert.ToInt16(Console.ReadLine());
                    notaBuilder.IdAluno(idAluno).IdProfessor(idProfessor);
                    service.DeleteNota(notaBuilder);
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
