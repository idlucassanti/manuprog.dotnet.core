using MP.Core.Domain.Validations;

namespace MP.Core.Domain.Entities
{
    public sealed class Pessoa
    {
        public Pessoa(string nome, string documento, string telefone)
        {
            Validation(nome, documento, telefone);
        }

        public Pessoa(int id, string nome, string documento, string telefone)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior que zero!");
            Id = id;

            Validation(nome, documento, telefone);
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Documento { get; private set; }

        public string Telefone { get; private set; }

        private void Validation(string nome, string documento, string telefone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(documento), "Documento deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(telefone), "Telefone deve ser informado!");

            Nome = nome;
            Documento = documento;
            Telefone = telefone;
        }
    }
}
