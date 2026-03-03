using APIHexagonal.Domain.Entities;
using APIHexagonal.Domain.Ports;
using APIHexagonal.Infrastructure.Data;
using System;

namespace APIHexagonal.Infraestructure.Repositories
{

    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _database;

        public AlunoRepository(AppDbContext db)
        {
            this._database = db;
        }
        public void Create(Aluno aluno)
        {
            try
            {
                this._database.Alunos.Add(aluno);
                this._database.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Guid id)
        {
            var aluno = _database.Alunos.Find(id);

            if (aluno != null)
            {
                _database.Alunos.Remove(aluno);
                _database.SaveChanges();
            }
        }

        public Aluno GetAlunoById(Guid id)
        {
            return _database.Alunos
                .FirstOrDefault(a => a.Id == id);
        }

        public Aluno GetByFirstName(string firstName)
        {
            return _database.Alunos
                .FirstOrDefault(a => a.FirstName == firstName);
        }

        public List<Aluno> GetList()
        {
            return _database.Alunos.ToList();
        }

        public void Update(Aluno aluno)
        {
            var existente = _database.Alunos.Find(aluno.Id);

            if (existente != null)
            {
                existente.FirstName = aluno.FirstName;
                existente.Email = aluno.Email;

                _database.Alunos.Update(existente);
                _database.SaveChanges();
            }
        }
    }
}
