using MP.Core.Application.DTOs;

namespace MP.Core.Application.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<ResultService<PessoaDTO>> InserirAsync(PessoaDTO pessoaDTO);
    }
}
