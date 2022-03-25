using System;

namespace SOA_Escola_Professores.Entidades
{
    public class Professores
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Professores() { }

        public Professores(string name)
        {
            Id = GerarId();
            Name = name;
        }

        public int GerarId()
        {
            var randNum = new Random();
            Id = randNum.Next(1000);
            return Id;
        }

        public override string ToString()
        {
            return "Nome: " + Name + "\n    Id: " + Id + "\n";
        }
    }
}
