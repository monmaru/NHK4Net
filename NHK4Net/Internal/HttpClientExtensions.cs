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
                    return await response.Content.DeserializeAsString<T>().ConfigureAwait(false);

                var nhkError = await response.Content.DeserializeAsString<NHKError>().ConfigureAwait(false);
                throw new NHKException(nhkError.Error.Code, nhkError.Error.Message);
            }
        }
    }
}
