using MP.Core.Domain.Entities;

namespace MP.Core.Domain.Repositories
{
    public interface IPessoaRepository
    {
        Task<Pessoa> ObterPessoaPorIdAsync(int pessoaId);

        Task<ICollection<Pessoa>> ObterListaPessoasAsync();

        Task<Pessoa> InserirPessoaAsync(Pessoa pessoa);

        Task AtualizarPessoaAsync(Pessoa pessoa);

        Task DeletarPessoaAsync(Pessoa pessoa);
    }
}
