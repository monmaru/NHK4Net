using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NHK4Net.Internal;

namespace NHK4Net
{
    public class NHKRestClient : NHKClient
    {
        private const string BaseUrl = @"http://api.nhk.or.jp/v2/pg";
        private const string JsonAndKey = ".json?key=";
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public NHKRestClient(string apiKey)
            : this(apiKey, new HttpClient())
        {
        }

        internal NHKRestClient(string apiKey, HttpClient httpClient)
        {
            Ensure.ArgumentNotNullOrEmptyString(apiKey, nameof(apiKey));
            Ensure.ArgumentNotNull(httpClient, nameof(httpClient));
            _apiKey = apiKey;
            _httpClient = httpClient;
        }

        public override async Task<IEnumerable<Program>> GetProgramListAsync(string area, string service, DateTime date)
        {
            var obj = await ReadAsAsync<CommonRootObject>(ProgramListUrl(area, service, date)).ContextFree();
            return obj.List.Programs;
        }
            
        internal string ProgramListUrl(string area, string service, DateTime date)
            => $"{BaseUrl}/list/{area}/{service}/{date:yyyy-MM-dd}{JsonAndKey}{_apiKey}";

        public override async Task<Program> GetProgramInfoAsync(string area, string service, string id)
        {
            var obj = await ReadAsAsync<CommonRootObject>(ProgramInfoUrl(area, service, id)).ContextFree();
            return obj.List.Programs.First();
        }

        internal string ProgramInfoUrl(string area, string service, string id)
            => $"{BaseUrl}/info/{area}/{service}/{id}{JsonAndKey}{_apiKey}";

        public override async Task<IEnumerable<Program>> GetProgramGenreAsync(string area, string service, string genre, DateTime date)
        {
            var obj = await ReadAsAsync<CommonRootObject>(ProgramGenreUrl(area, service, genre, date)).ContextFree();
            return obj.List.Programs;
        }

        internal string ProgramGenreUrl(string area, string service, string genre, DateTime date)
            => $"{BaseUrl}/genre/{area}/{service}/{genre}/{date:yyyy-MM-dd}{JsonAndKey}{_apiKey}";

        public override async Task<NowOnAir> GetNowOnAirAsync(string area, string service)
        {
            var obj = await ReadAsAsync<NowOnAirRootObject>(NowOnAirUrl(area, service)).ContextFree();
            return obj.NowOnAirList.NowOnAir;
        }

        internal string NowOnAirUrl(string area, string service)
            => $"{BaseUrl}/now/{area}/{service}{JsonAndKey}{_apiKey}";

        internal async Task<T> ReadAsAsync<T>(string url)
        {
            try
            {
                Ensure.ArgumentNotNullOrEmptyString(url, nameof(url));
                using (var response = await _httpClient.GetAsync(url).ContextFree())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.DeserializeAsString<T>().ContextFree();
                    }

                    var nhkError = (await response.Content.DeserializeAsString<RootErrorObject>().ContextFree())?.Error;
                    if (nhkError == null)
                    {
                        throw new NHKException(ErrorCode.Other, "Unexpected error occurred.");
                    }

                    throw new NHKException(nhkError.Code, nhkError.Message);
                }
            }
            catch (Exception ex) when(!(ex is NHKException))
            {
                throw new NHKException(ErrorCode.Other, "Unexpected error occurred.", ex);
            }
        }

        public override void Dispose() => _httpClient?.Dispose();
    }
}
