using SOA_Escola_Nota.Builder;
using SOA_Escola_Nota.Comum;
using SOA_Escola_Nota.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_Escola_Nota.Service
{
    public class NotaService
    {
        public RepositoryBase _repositoryBase { get; set; }

        public NotaService()
        {
            _repositoryBase = new RepositoryBase(@"\NotasRepository.txt");
        }

        public bool InsertNota(NotaBuilder nota)
        {
            if (nota.Valido())
                _repositoryBase.Insert<Nota>(nota.Build());

            return nota.Valido();
        }

        public List<Nota> GetAllNota(NotaBuilder nota)
            => _repositoryBase.GetAll<Nota>().FindAll(n => n.IdProfessor == nota.Build().IdProfessor);

        public void DeleteNota(NotaBuilder nota)
          => _repositoryBase.Delete<Nota>(nota.Build());

        public void UpdateNota(NotaBuilder notaBuilder)
        {
            if (notaBuilder.Valido())
            {
                var nota = notaBuilder.Build();
                var notaRepository = _repositoryBase.GetAll<Nota>().Find(n => n.IdProfessor == nota.IdProfessor && n.IdAluno == nota.IdAluno);

                if (notaRepository != null)
                {
                    _repositoryBase.Delete<Nota>(notaRepository);
                    _repositoryBase.Insert(nota);
                }
            }

        }

        public void ExibirNotas(NotaBuilder nota)
        {
          var notas =  GetAllNota(nota);
            foreach (var item in notas)
                Console.WriteLine($"Nota {item.Valor} do Aluno {item.IdAluno}");
        }
    }
}
