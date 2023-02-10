using AutoMapper;
using MP.Core.Application.DTOs;
using MP.Core.Domain.Entities;

namespace MP.Core.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping() 
        {
            CreateMap<PessoaDTO, Pessoa>();
        }
    }
}
