using Cotacoes.Domain.Dtos.v1;
using Cotacoes.Domain.Interfaces.Services.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cotacoes.Api.Application.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class CotacaoController : ControllerBase
    {
        private readonly ICotacaoService _cotacaoServico;
        public CotacaoController(ICotacaoService cotacaoServico)
        {
            _cotacaoServico = cotacaoServico;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CotacaoDto>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _cotacaoServico.GetAll(cancellationToken));
        }

        [HttpGet("{numeroCotacao}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CotacaoDto>))]
        public async Task<IActionResult> GetById([FromRoute]long numeroCotacao, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _cotacaoServico.GetById(numeroCotacao, cancellationToken));
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CotacaoDto>))]
        public async Task<IActionResult> Post(CotacaoDto dto, CancellationToken cancellationToken)
        {
            return Ok(await _cotacaoServico.Post(dto, cancellationToken));
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CotacaoDto>))]
        public async Task<IActionResult> Put(CotacaoDto dto, CancellationToken cancellationToken)
        {
            return Ok(await _cotacaoServico.Put(dto, cancellationToken));
        }

        [HttpDelete("{numeroCotacao}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(long numeroCotacao, CancellationToken cancellationToken)
        {
            await _cotacaoServico.Delete(numeroCotacao, cancellationToken);
            return NoContent();
        }
    }
}
