using SOA_Escola_Nota.Builder;
using SOA_Escola_Nota.Comum;
using SOA_Escola_Nota.Entidade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_Escola_Nota.Service
{
    public class NotaService
    {
        public RepositoryBase<Nota> _repositoryBase { get; set; }

        public NotaService()
        {
            var teste = Directory.GetCurrentDirectory() + @"..\..\..\..\Repository\NotasRepository.txt";
            _repositoryBase = new RepositoryBase<Nota>(teste);
        }

        public bool InsertNota(decimal valor, int idAluno, int idProfessor)
        {
            NotaBuilder nota = new NotaBuilder();
            nota.Valor(valor).IdAluno(idAluno).IdProfessor(idProfessor);
            if (nota.Valido())
                _repositoryBase.Insert(nota.Build());

            return nota.Valido();
        }

        public List<Nota> GetAllNota(int idProfessor)
            => _repositoryBase.GetAll(idProfessor);

        public void DeleteNota(int idAluno, int idProfessor)
          =>  _repositoryBase.Delete(idAluno, idProfessor);

        public void UpdateNota(decimal valor, int idAluno, int idProfessor)
        {
            NotaBuilder notaBuilder = new NotaBuilder();
            notaBuilder.Valor(valor).IdAluno(idAluno).IdProfessor(idProfessor);
            if (notaBuilder.Valido())
            {
                var nota = notaBuilder.Build();
                var notaRepository = _repositoryBase.GetAll(idProfessor).Find(n => n.IdAluno == nota.IdAluno);

                if (notaRepository != null)
                {
                    _repositoryBase.Delete(nota.IdAluno, nota.IdProfessor);
                    _repositoryBase.Insert(nota);
                }
            }

        }

        public void ExibirNotas(int idProfessor)
        {
          var notas =  GetAllNota(idProfessor);
            foreach (var item in notas)
                Console.WriteLine($"Nota {item.Valor} do Aluno {item.IdAluno}");
        }
    }
}
