using APIHexagonal.Application.DTOs;
using APIHexagonal.Domain.Entities;

namespace APIHexagonal.Application.Interfaces
{
    public interface IAlunoService
    {
        public void Matricular(CreateAlunoDTO Aluno);
        public Aluno GetAlunoById(Guid Id);

        public Aluno GetAlunoByFirstName (string FirstName);
        public List<Aluno> GetList();

    }
}
