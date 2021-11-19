
namespace Cotacoes.Domain.Entities
{
    public class CotacaoItem
    {
        public long NumeroCotacao { get; set; }
        public string Descricao { get; set; }
        public long NumeroItem { get; set; }
        public decimal? Preco { get; set; }
        public decimal Quantidade { get; set; } // pode ser pesável
        public string Marca { get; set; }
        public string Unidade { get; set; }
        public Cotacao Cotacao { get; set; }
    }
}
