using AutoMapper;
using Cotacoes.Domain.Dtos.v1;
using Cotacoes.Domain.Entities;
using Cotacoes.Domain.Interfaces.Repositories;
using Cotacoes.Domain.Interfaces.Services.v1;
using Cotacoes.Domain.Utils.Extensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cotacoes.Servico.Servicos.v1
{
    public class CotacaoService : ICotacaoService
    {
        private readonly ICotacaoRepository _cotacaoRepository;
        private readonly ICotacaoItemRepository _cotacaoItemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CotacaoService> _logger;
        private static HttpClient _httpClient;
        private readonly IValidator<Cotacao> _cotacaoValidator;

        public CotacaoService(ICotacaoRepository cotacaoRepository,
                              ICotacaoItemRepository cotacaoItemRepository,
                                 IMapper mapper,
                                 ILogger<CotacaoService> logger,
                                 IValidator<Cotacao> cotacaoValidator,
                                 HttpClient httpClient)
        {
            _cotacaoRepository = cotacaoRepository;
            _cotacaoItemRepository = cotacaoItemRepository;
            _cotacaoValidator = cotacaoValidator;
            _mapper = mapper;
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CotacaoDto>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<IEnumerable<CotacaoDto>>(await _cotacaoRepository.GetAll().ToListAsync(cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: GetAll");
                throw;
            }
        }

        public async Task<CotacaoDto> GetById(long numeroCotacao, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<CotacaoDto>(await _cotacaoRepository.GetAll().FirstOrDefaultAsync(s => s.NumeroCotacao == numeroCotacao, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: GetAll");
                throw;
            }
        }

        public async Task<CotacaoDto> Post(CotacaoDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var cotacao = _mapper.Map<Cotacao>(dto);
                await _cotacaoValidator.ValidateAndThrowAsync(cotacao);

                cotacao = await ValidateAddress(cotacao);
                return _mapper.Map<CotacaoDto>(await _cotacaoRepository.Add(cotacao, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: Post");
                throw;
            }
        }

        public async Task<CotacaoDto> Put(CotacaoDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var cotacao = _mapper.Map<Cotacao>(await GetById(dto.NumeroCotacao, cancellationToken));
                cotacao = _mapper.Map<Cotacao>(dto);
                await _cotacaoValidator.ValidateAndThrowAsync(cotacao);
                cotacao = await ValidateAddress(cotacao);
                await _cotacaoRepository.Update(cotacao, cancellationToken);
                return _mapper.Map<CotacaoDto>(await GetById(cotacao.NumeroCotacao, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: Put");
                throw;
            }
        }

        public async Task Delete(long numeroCotacao, CancellationToken cancellationToken)
        {
            try
            {
                await _cotacaoRepository.Delete(numeroCotacao, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: Delete");
            }
        }


        #region Private 
        private Cotacao OverwriteAddressData(Cotacao cotacao, Endereco endereco)
        {
            cotacao.Bairro = endereco.Bairro;
            cotacao.Logradouro = endereco.Logradouro;
            cotacao.UF = endereco.UF;
            return cotacao;
        }

        private async Task<Cotacao> ValidateAddress(Cotacao cotacao)
        {
            try
            {
                if (cotacao.Logradouro == null || cotacao.Bairro == null || cotacao.UF == null)
                {
                    var urlViaCep = $"https://viacep.com.br/ws/{cotacao.CEP.Replace("-", "")}/json/";
                    var address = (await (await _httpClient.GetAsync(urlViaCep)).Content.ReadAsStringAsync()).ToObject<Endereco>();
                    cotacao = OverwriteAddressData(cotacao, address);
                }
                return cotacao;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: ValidateAddress");
                throw;
            }
        }
        #endregion
    }
}
