namespace SOA_Escola_Professores.Entidades
{
    public class ControleDePresenca
    {
        public int Presencas { get; set; }
        public int Ausencias { get; set; }
        public int IdAluno { get; set; }
        public int IdAula { get; set; }
        public string NomeAluno { get; set; }
        public string NomeAula { get; set; }

        public override string ToString()
        {
            return "Nome do Aluno: " + NomeAluno +
                "\n    Aula: " + NomeAula +
                "\n  Quantidade de presenças: " + Presencas +
                "\n  Quantidade de ausencias: " + Ausencias;
        }
    }
}
