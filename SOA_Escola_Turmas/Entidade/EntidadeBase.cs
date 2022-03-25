using System;

namespace SOA_Escola_Turmas.Entidade
{
    public class EntidadeBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
