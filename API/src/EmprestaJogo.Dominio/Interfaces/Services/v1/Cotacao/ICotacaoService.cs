using Cotacoes.Domain.Dtos.v1;
using Cotacoes.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cotacoes.Domain.Interfaces.Services.v1
{
    public interface ICotacaoService
    {
        Task<IEnumerable<CotacaoDto>> GetAll(CancellationToken cancellationToken);
        Task<CotacaoDto> GetById(long numeroCotacao, CancellationToken cancellationToken);
        Task<CotacaoDto> Post(CotacaoDto dto, CancellationToken cancellationToken);
        Task<CotacaoDto> Put(CotacaoDto dto, CancellationToken cancellationToken);
        Task Delete(long numeroCotacao, CancellationToken cancellationToken);
    }
}
