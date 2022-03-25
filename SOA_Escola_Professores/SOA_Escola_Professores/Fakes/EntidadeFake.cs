namespace SOA_Escola_Professores.Fakes
{
    public class EntidadeFake
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return "Nome: " + Name + "\n    Id: " + Id + "\n";
        }
    }
}
