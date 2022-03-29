using SOA_Escola_Professores.Entidades;

namespace SOA_Escola_Professores.Fakes
{
    public class EntidadeFake : BaseEntity
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return "Nome: " + Name + "\n    Id: " + Id + "\n";
        }
    }
}
