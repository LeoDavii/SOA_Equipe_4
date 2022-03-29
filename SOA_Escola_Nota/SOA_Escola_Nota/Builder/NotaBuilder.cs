using SOA_Escola_Nota.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_Escola_Nota.Builder
{
    public class NotaBuilder
    {
        private decimal _valor;
        private int _idAluno;
        private int _idProfessor;

        public NotaBuilder Valor(decimal valor) { _valor = valor; return this; }
        public NotaBuilder IdAluno(int valor) { _idAluno = valor; return this; }
        public NotaBuilder IdProfessor(int valor) { _idProfessor = valor; return this; }

        public bool Valido()
        {
            return (_valor >= 0) && (_valor <= 10) && _idAluno > 0 && _idProfessor > 0;
        }

        public Nota Build()
            => Valido() ? new Nota(_valor, _idAluno, _idProfessor) : null;

        public void Clear()
        {
            _valor = 0m;
            _idAluno = 0;
            _idProfessor = 0;
        }
    }
}
