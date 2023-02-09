using Microsoft.EntityFrameworkCore;
using MP.Core.Domain.Entities;
using MP.Core.Domain.Repositories;
using MP.Core.Infra.Data.Context;

namespace MP.Core.Infra.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly MpDbContext _connection;

        public PessoaRepository(MpDbContext context)
        {
            _connection = context;
        }

        public async Task<ICollection<Pessoa>> ObterListaPessoasAsync()
        {
            return await _connection.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> ObterPessoaPorIdAsync(int pessoaId)
        {
            return await _connection.Pessoas.FirstOrDefaultAsync(p => p.Id.Equals(pessoaId));
        }

        public async Task<Pessoa> InserirPessoaAsync(Pessoa pessoa)
        {
            _connection.Pessoas.Add(pessoa);
            await _connection.SaveChangesAsync();
            return pessoa;
        }

        public async Task AtualizarPessoaAsync(Pessoa pessoa)
        {
            _connection.Pessoas.Update(pessoa);
            await _connection.SaveChangesAsync();
        }

        public async Task DeletarPessoaAsync(Pessoa pessoa)
        {
            _connection.Pessoas.Remove(pessoa);
            await _connection.SaveChangesAsync();
        }
    }
}
