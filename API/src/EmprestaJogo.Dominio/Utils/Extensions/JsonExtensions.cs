using System.Text.Json;

namespace Cotacoes.Domain.Utils.Extensions
{
    public static class JsonExtensions
    {
        public static T ToObject<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
