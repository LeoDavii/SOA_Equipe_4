using System.Collections.Generic;

namespace SOA_Escola_Turmas.Entidade
{
    public class Turmas
    {
        public int Vagas { get; set; }
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}
