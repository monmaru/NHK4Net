using System.Net.Http;
using System.Threading.Tasks;

namespace NHK4Net.Internal
{
    internal static class HttpClientExtensions
    {
        internal static async Task<T> ReadAsAsync<T>(this HttpClient client, string endpoint)
        {
            Ensure.ArgumentNotNullOrEmptyString(endpoint);
            using (var response = await client.GetAsync(endpoint).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.DeserializeAsString<T>().ConfigureAwait(false);
                }

                var e = await response.Content.DeserializeAsString<NhkError>();
                throw new NhkException(e.Error.Code, e.Error.Message);
            }
        }
    }
}
