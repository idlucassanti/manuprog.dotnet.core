using AutoMapper;
using MP.Core.Application.DTOs;
using MP.Core.Application.Mappings;
using MP.Core.Application.Services.Interfaces;
using MP.Core.Application.Validators;
using MP.Core.Domain.Entities;
using MP.Core.Domain.Repositories;

namespace MP.Core.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IMapper _mapper;

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IMapper mapper, IPessoaRepository pessoaRepository)
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<ResultService<PessoaDTO>> ObterPessoaPorIdAsync(int pessoaId)
        {
            var pessoa = await _pessoaRepository.ObterPessoaPorIdAsync(pessoaId);

            if (pessoa == null) return ResultService.Fail<PessoaDTO>("Objeto não encontrado");

            return ResultService.Ok<PessoaDTO>(_mapper.Map<PessoaDTO>(pessoa));
        }

        public async Task<ResultService<ICollection<PessoaDTO>>> ObterListaPessoasAsync()
        {
            var pessoas = await _pessoaRepository.ObterListaPessoasAsync();

            return ResultService.Ok<ICollection<PessoaDTO>>(_mapper.Map<ICollection<PessoaDTO>>(pessoas));
        }

        public async Task<ResultService<PessoaDTO>> InserirAsync(PessoaDTO pessoaDTO)
        {
            //validou se é null
            if (pessoaDTO == null) return ResultService.Fail<PessoaDTO>("Objeto deve ser informado!");

            //validou se as informações estão válidas
            var result = new PessoaValidator().Validate(pessoaDTO);

            if (!result.IsValid) return ResultService.RequestError<PessoaDTO>("Erro na validação dos dados", result);

            //transforma na entidade que será persistida no banco de dados
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);

            //inserir no banco de dados após validações
            var data = await _pessoaRepository.InserirPessoaAsync(pessoa);

            return ResultService.Ok<PessoaDTO>(_mapper.Map<PessoaDTO>(data));
        }
    }
}
