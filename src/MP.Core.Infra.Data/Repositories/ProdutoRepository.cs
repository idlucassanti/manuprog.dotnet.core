using Microsoft.EntityFrameworkCore;
using MP.Core.Domain.Entities;
using MP.Core.Domain.Repositories;
using MP.Core.Infra.Data.Context;

namespace MP.Core.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MpDbContext _connection;

        public ProdutoRepository(MpDbContext context)
        {
            _connection = context;
        }

        public async Task<ICollection<Produto>> ObterListaProdutosAsync()
        {
            return await _connection.Produtos.ToListAsync();
        }

        public async Task<Produto> ObterProdutoPorIdAsync(int produtoId)
        {
            return await _connection.Produtos.FirstOrDefaultAsync(p => p.Id.Equals(produtoId));
        }

        public async Task<Produto> InserirProduto(Produto produto)
        {
            _connection.Produtos.Add(produto);
            await _connection.SaveChangesAsync();

            return produto;
        }

        public async Task AtualizarProduto(Produto produto)
        {
            _connection.Produtos.Update(produto);
            await _connection.SaveChangesAsync();
        }

        public async Task DeletarProduto(Produto produto)
        {
            _connection.Produtos.Remove(produto);
            await _connection.SaveChangesAsync();
        }
    }
}
