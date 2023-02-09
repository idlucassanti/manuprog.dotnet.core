using MP.Core.Domain.Entities;

namespace MP.Core.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> ObterProdutoPorIdAsync(int produtoId);

        Task<ICollection<Produto>> ObterListaProdutosAsync();

        Task<Produto> InserirProduto(Produto produto);

        Task AtualizarProduto(Produto produto);

        Task DeletarProduto(Produto produto);
    }
}
