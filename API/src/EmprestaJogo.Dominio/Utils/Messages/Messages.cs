
namespace Cotacoes.Domain.Utils.Messages
{
    public static class Messages
    {
        #region Geral
        public static string Mandatory(string field) { return $"O Campo {field} é obrigatório(a)."; }
        public static string MaximumCharacters(string nomeCampo, int qtdCaracteres) { return $"O Campo {nomeCampo} deve ter no máximo {qtdCaracteres}."; }
        #endregion

        #region CotacaoItem
        public static string BiggerThanZero(string nomeCampo) { return $"O Campo {nomeCampo} deve ser maior que zero."; }
        #endregion

    }
}
