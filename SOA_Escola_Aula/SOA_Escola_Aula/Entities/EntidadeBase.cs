using System;

namespace SOA_Escola_Aula.Entities
{
    public class EntidadeBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
