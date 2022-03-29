using System;

namespace SOA_Escola_Professores.Entidades
{
    public class Teachers : BaseEntity
    {        
        public string Name { get; set; }

        public Teachers() { }

        public Teachers(string name)
        {
            Id = GerarId();
            Name = name;
        }

        public override string ToString()
        {
            return "Nome: " + Name + "\n    Id: " + Id + "\n";
        }
    }
}
