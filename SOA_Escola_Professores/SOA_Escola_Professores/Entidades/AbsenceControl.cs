namespace SOA_Escola_Professores.Entidades
{
    public class AbsenceControl : BaseEntity
    {
        public int Presence { get; set; }
        public int Absence { get; set; }
        public int IdAluno { get; set; }
        public int IdAula { get; set; }
        public string NomeAluno { get; set; }
        public string NomeAula { get; set; }

        public override string ToString()
        {
            return "Nome do Aluno: " + NomeAluno +
                "\n    Aula: " + NomeAula +
                "\n  Quantidade de presenças: " + Presence +
                "\n  Quantidade de ausencias: " + Absence;
        }
    }
}
