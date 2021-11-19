namespace Cotacoes.Domain.Dtos.v1
{
    public class CotacaoItemDto
    {
        public string Descricao { get; set; }
        public long NumeroItem { get; set; }
        public decimal? Preco { get; set; }
        public decimal Quantidade { get; set; }
        public string Marca { get; set; }
        public string Unidade { get; set; }
    }
}
