﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using NHK4Net.Internal;

namespace NHK4Net
{
    public abstract class NHKClientBase : IDisposable
    {
        public abstract Task<ProgramList> GetProgramList(string area, string service, DateTime date);
        public abstract Task<ProgramInfo> GetProgramInfo(string area, string service, string id);
        public abstract Task<ProgramGenre> GetProgramGenre(string area, string service, string genre, DateTime date);
        public abstract Task<NowOnAir> GetNowOnAir(string area, string service);
        public abstract void Dispose();
    }

    public class NHKClient : NHKClientBase
    {
        private const string BaseUrl = @"http://api.nhk.or.jp/v2/pg";
        private const string JsonAndKey = ".json?key=";
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public NHKClient(string apiKey)
            : this(apiKey, new HttpClient())
        {
        }

        internal NHKClient(string apiKey, HttpClient httpClient)
        {
            Ensure.ArgumentNotNullOrEmptyString(apiKey);
            Ensure.ArgumentNotNull(httpClient);
            _apiKey = apiKey;
            _httpClient = httpClient;
        }

        public override async Task<ProgramList> GetProgramList(string area, string service, DateTime date)
            => await ReadAsAsync<ProgramList>(ProgramListUrl(area, service, date)).ConfigureAwait(false);

        private string ProgramListUrl(string area, string service, DateTime date)
            => $"{BaseUrl}/list/{area}/{service}/{date:yyyy-MM-dd}{JsonAndKey}{_apiKey}";

        public override async Task<ProgramInfo> GetProgramInfo(string area, string service, string id)
            => await ReadAsAsync<ProgramInfo>(ProgramInfoUrl(area, service, id)).ConfigureAwait(false);

        private string ProgramInfoUrl(string area, string service, string id)
            => $"{BaseUrl}/info/{area}/{service}/{id}{JsonAndKey}{_apiKey}";

        public override async Task<ProgramGenre> GetProgramGenre(string area, string service, string genre, DateTime date)
            => await ReadAsAsync<ProgramGenre>(ProgramGenreUrl(area, service, genre, date)).ConfigureAwait(false);

        private string ProgramGenreUrl(string area, string service, string genre, DateTime date)
            => $"{BaseUrl}/genre/{area}/{service}/{genre}/{date:yyyy-MM-dd}{JsonAndKey}{_apiKey}";

        public override async Task<NowOnAir> GetNowOnAir(string area, string service)
            => await ReadAsAsync<NowOnAir>(NowOnAirUrl(area, service)).ConfigureAwait(false);

        private string NowOnAirUrl(string area, string service)
            => $"{BaseUrl}/now/{area}/{service}{JsonAndKey}{_apiKey}";

        private async Task<T> ReadAsAsync<T>(string url)
            => await _httpClient.ReadAsAsync<T>(url).ConfigureAwait(false);

        public override void Dispose() => _httpClient?.Dispose();
    }
}