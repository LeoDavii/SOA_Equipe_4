using System;

namespace SOA_Escola_Turmas.Entidade
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Professor() { }

        public Professor(string name)
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
