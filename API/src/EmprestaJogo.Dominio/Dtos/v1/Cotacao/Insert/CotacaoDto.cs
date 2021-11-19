using System;
using System.Collections.Generic;

namespace Cotacoes.Domain.Dtos.v1
{
    public class CotacaoDto
    {
        public string CNPJComprador { get; set; }
        public string CNPJFornecedor { get; set; }
        public long NumeroCotacao { get; set; }
        public DateTime DataCotacao { get; set; }
        public DateTime DataEntregaCotacao { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Observacao { get; set; }
        public IEnumerable<CotacaoItemDto> CotacaoItens { get; set; }
    }
}
