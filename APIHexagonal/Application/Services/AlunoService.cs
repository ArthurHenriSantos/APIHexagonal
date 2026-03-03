using APIHexagonal.Application.Interfaces;
using APIHexagonal.Application.DTOs;
using APIHexagonal.Domain.Entities;
using APIHexagonal.Domain.Ports;

namespace APIHexagonal.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public void Matricular(CreateAlunoDTO alunoDTO)
        {
            if (alunoDTO == null)
                throw new Exception("Informação inválida");

            if (string.IsNullOrWhiteSpace(alunoDTO.FirstName))
                throw new Exception("Nome é obrigatório");

            if (alunoDTO.FirstName.Length > 50)
                throw new Exception("Nome deve ter no máximo 50 caracteres");

            var email = alunoDTO.Email?.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(email) ||
                !email.EndsWith("@faculdade.edu"))
            {
                throw new Exception("Email deve terminar em @faculdade.edu");
            }

            var aluno = new Aluno
            {
                FirstName = alunoDTO.FirstName,
                Email = alunoDTO.Email,
                LastName = alunoDTO.LastName
            };

            _repository.Create(aluno);
        }

        public Aluno GetAlunoByFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new Exception("Nome inválido");

            return _repository.GetByFirstName(firstName);
        }

        public Aluno GetAlunoById(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Id inválido");

            var aluno = _repository.GetAlunoById(id);

            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            return aluno;
        }

        public List<Aluno> GetList()
        {
            return _repository.GetList();
        }
    }
}