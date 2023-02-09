using MP.Core.Domain.Validations;

namespace MP.Core.Domain.Entities
{
    public class Compra
    {
        public Compra(int pessoaId, int produtoId, DateTime? dataCadastro)
        {
            Validation(pessoaId, produtoId, dataCadastro);
        }

        public Compra(int id, int pessoaId, int produtoId, DateTime? dataCadastro)
        {
            DomainValidationException.When(id <= 0, "Id deve ser mair que zero!");
            Id = id;

            Validation(pessoaId, produtoId, dataCadastro);
        }

        public int Id { get; private set; }

        public int PessoaId { get; private set; }

        public int ProdutoId { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public Pessoa Pessoa { get; set; }

        public Produto Produto { get; set; }

        private void Validation(int pessoaId, int produtoId, DateTime? dataCadastro)
        {
            DomainValidationException.When(pessoaId <= 0, "PessoaId deve ser maior que zero!");
            DomainValidationException.When(produtoId <= 0, "ProdutoId deve ser maior que zero!");
            DomainValidationException.When(!dataCadastro.HasValue, "DataCadastro deve ser informado!");

            PessoaId= pessoaId;
            ProdutoId= produtoId;
            DataCadastro = dataCadastro.Value;
        }
    }
}
