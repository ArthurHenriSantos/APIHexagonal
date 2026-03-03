using APIHexagonal.Domain.Entities;
namespace APIHexagonal.Domain.Ports

{
    public interface IAlunoRepository
    {
        public void Create(Aluno aluno);
        public Aluno GetByFirstName (string firstName);
        public Aluno GetAlunoById(Guid id);
        public List<Aluno> GetList();
        public void Update(Aluno aluno);
        public void Delete(Guid id);

    }
}
