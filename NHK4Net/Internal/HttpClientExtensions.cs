using System.Net.Http;
using System.Threading.Tasks;

namespace NHK4Net.Internal
{
    internal static class HttpClientExtensions
    {
        internal static async Task<T> ReadAsAsync<T>(this HttpClient client, string endpoint)
        {
            Ensure.ArgumentNotNullOrEmptyString(endpoint);
            using (var response = await client.GetAsync(endpoint).ContextFree())
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.DeserializeAsString<T>().ContextFree();

                var nhkError = await response.Content.DeserializeAsString<NHKError>().ContextFree();
                throw new NHKException(nhkError.Error.Code, nhkError.Error.Message);
            }
        }
    }
}
