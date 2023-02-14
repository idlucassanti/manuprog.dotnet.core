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

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPessoaPorId(int pessoaId)
        {
            var result = await _pessoaService.ObterPessoaPorIdAsync(pessoaId);

            if (!result.IsSuccess) return BadRequest(result);

            if (result == null) return NoContent();

            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> ObterListaPessoasAsync()
        {
            var result = await _pessoaService.ObterListaPessoasAsync();

            if (!result.IsSuccess) return BadRequest();

            if (result == null) return NoContent();

            return Ok(result);
        }
    }
}
