using MP.Core.Domain.Validations;

namespace MP.Core.Domain.Entities
{
    public class Produto
    {
        public Produto(string nome, string codigo, decimal preco)
        {
            Validation(nome, codigo, preco);
        }

        public Produto(int id, string nome, string codigo, decimal preco)
        {
            DomainValidationException.When(id <= 0, "Id deve ser maior que zero");
            Validation(nome, codigo, preco);
        }

        public int Id { get; set; }

        public string Nome { get; private set; }

        public string Codigo { get; private set; }

        public decimal Preco { get; private set; }

        public ICollection<Compra> Compras { get; set; }

        private void Validation(string nome, string codigo, decimal preco)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(codigo), "Código deve ser informado!");
            DomainValidationException.When(preco < 0, "Preço deve ser maior que zero!");

            Nome = nome;
            Codigo = codigo;
            Preco = preco;
        }
    }
}
