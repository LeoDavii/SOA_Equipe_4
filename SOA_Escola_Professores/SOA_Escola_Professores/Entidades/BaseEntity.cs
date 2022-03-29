using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_Escola_Professores.Entidades
{
    public class BaseEntity
    {
        public int Id { get; set; }
        protected int GerarId()
        {
            var randNum = new Random();
            Id = randNum.Next(1000);
            return Id;
        }
    }
}
