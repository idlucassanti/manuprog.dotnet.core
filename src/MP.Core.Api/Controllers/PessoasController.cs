using Microsoft.AspNetCore.Mvc;
using MP.Core.Application.DTOs;
using MP.Core.Application.Services.Interfaces;

namespace MP.Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        public async Task<IActionResult> InserirAsync([FromBody] PessoaDTO pessoaDTO)
        {
            var result = await _pessoaService.InserirAsync(pessoaDTO);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }
    }
}
