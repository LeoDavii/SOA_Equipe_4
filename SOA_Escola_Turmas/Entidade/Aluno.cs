namespace SOA_Escola_Turmas.Entidade
{
    public class Aluno : EntidadeBase
    {
        public string Nome { get; set; }

        public Aluno(string name)
        {
            Nome = name;
        }
    }
}
