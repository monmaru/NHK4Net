using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace NHK4Net.Internal
{
    internal static class HttpContentExtensions
    {
        internal static async Task<T> DeserializeAsJsonAsync<T>(this HttpContent content)
        {
            var text = await content.ReadAsStringAsync().ContextFree();
            return JsonConvert.DeserializeObject<T>(text);
        }
    }
}
