
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_Escola_Nota.Entidade
{
    public class Nota 
    {
        public Nota(decimal valor, int idAluno, int idProfessor)
        {
            Valor = valor;
            IdAluno = idAluno;
            IdProfessor = idProfessor;
        }

        public decimal Valor { get; set; }
        public int IdAluno { get; set; }
        public int IdProfessor { get; set; }
    }
}
