using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NHK4Net.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace NHK4Net.Tests
{
    public class NHKRestClientTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly FakeResponseHandler _fakeHandler;
        private readonly NHKRestClient _client;
        private const string DummyApiKey = "DummyAPIKey";

        public NHKRestClientTest(ITestOutputHelper output)
        {
            _output = output;
            _fakeHandler = new FakeResponseHandler();
            _client = new NHKRestClient(DummyApiKey, new HttpClient(_fakeHandler));
        }

        public void Dispose()
        {
            _fakeHandler?.Dispose();
            _client?.Dispose();
        }

        private void SetupFakeResponse(string url, HttpStatusCode statusCode, string json)
        {
            var fakeResponse = new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(json)
            };
            _fakeHandler.AddFakeResponse(new Uri(url), fakeResponse);
        }

        [Fact]
        public void ProgramListUrl()
        {
            // Arrange
            var today = DateTime.Today;
            var expected =
                $"http://api.nhk.or.jp/v2/pg/list/{NHKArea.東京}/{NHKService.総合1}/{today:yyyy-MM-dd}.json?key={DummyApiKey}";
            // Act
            var url = _client.ProgramListUrl(NHKArea.東京, NHKService.総合1, today);
            _output.WriteLine($"URL = {url}");
            // Assert
            Assert.Equal(expected, url);
        }

        [Fact]
        public void ProgramInfoUrl()
        {
            // Arrange
            const string dummyId = "dummyID";
            var expected = 
                $"http://api.nhk.or.jp/v2/pg/info/{NHKArea.東京}/{NHKService.総合1}/{dummyId}.json?key={DummyApiKey}";
            // Act
            var url = _client.ProgramInfoUrl(NHKArea.東京, NHKService.総合1, dummyId);
            _output.WriteLine($"URL = {url}");
            // Assert
            Assert.Equal(expected, url);
        }

        [Fact]
        public void NowOnAirUrl()
        {
            // Arrange
            var expected = $"http://api.nhk.or.jp/v2/pg/now/{NHKArea.東京}/{NHKService.総合1}.json?key={DummyApiKey}";
            // Act
            var url = _client.NowOnAirUrl(NHKArea.東京, NHKService.総合1);
            _output.WriteLine($"URL = {url}");
            // Assert
            Assert.Equal(expected, url);
        }

        [Fact]
        public async Task GetProgramListAsync()
        {
            // Arrange
            var area = NHKArea.東京;
            var service = NHKService.総合1;
            var today = DateTime.Today;
            var url = _client.ProgramListUrl(area, service, today);
            SetupFakeResponse(url, HttpStatusCode.OK, TestData.ProgramInfoJson);
            // Act
            var programs = await _client.GetProgramListAsync(area, service, today);
            var program = programs.FirstOrDefault();
            // Assert
            Assert.NotNull(program);
            _output.WriteLine(program.Title);
        }

        [Fact]
        public async Task GetProgramInfoAsync()
        {
            // Arrange
            var area = NHKArea.東京;
            var service = NHKService.総合1;
            const string id = "dummyID";
            var url = _client.ProgramInfoUrl(area, service, id);
            SetupFakeResponse(url, HttpStatusCode.OK, TestData.ProgramInfoJson);
            // Act
            var program = await _client.GetProgramInfoAsync(area, service, id);
            // Assert
            Assert.NotNull(program);
            _output.WriteLine(program.Title);
        }

        [Fact]
        public async Task GetProgramGenreAsync()
        {
            // Arrange
            var area = NHKArea.東京;
            var service = NHKService.総合1;
            var genre = NHKGenre.スポーツ;
            var today = DateTime.Today;
            var url = _client.ProgramGenreUrl(area, service, genre, today);
            SetupFakeResponse(url, HttpStatusCode.OK, TestData.ProgramGenreJson);
            // Act
            var programs = await _client.GetProgramGenreAsync(area, service, genre, today);
            var program = programs.FirstOrDefault();
            // Assert
            Assert.NotNull(program);
            _output.WriteLine(program.Title);
        }

        [Fact]
        public async Task GetNowOnAirAsync()
        {
            // Arrange
            var area = NHKArea.東京;
            var service = NHKService.総合1;
            var url = _client.NowOnAirUrl(area, service);
            SetupFakeResponse(url, HttpStatusCode.OK, TestData.NowOnAirJson);
            // Act
            var nowOnAirSet = await _client.GetNowOnAirAsync(area, service);
            // Assert
            Assert.NotNull(nowOnAirSet.Present);
            _output.WriteLine(nowOnAirSet.Present.Title);
        }

        [Fact]
        public async Task ReadAsAsyncWithCustomError()
        {
            // Arrange
            const string url = @"http://api.nhk.or.jp/v2/pg/dummy";
            SetupFakeResponse(url, HttpStatusCode.InternalServerError, string.Empty/* Invalid Json format */);
            // Act
            var ex = await Assert.ThrowsAsync<NHKException>(() => _client.ReadAsAsync<NowOnAir>(url));
            // Assert
            Assert.Equal(ErrorCode.Other, ex.ErrorCode);
            Assert.Equal("Unexpected error occurred.", ex.Message);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotModified)]
        [InlineData(HttpStatusCode.BadRequest)]
        [InlineData(HttpStatusCode.Unauthorized)]
        [InlineData(HttpStatusCode.Forbidden)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.InternalServerError)]
        [InlineData(HttpStatusCode.ServiceUnavailable)]
        public async Task ReadAsAsyncWithApiError(HttpStatusCode statusCode)
        {
            // Arrange
            const string url = @"http://api.nhk.or.jp/v2/pg/dummy";
            SetupFakeResponse(url, statusCode, TestData.ErrorJson);
            // Act
            var ex = await Assert.ThrowsAsync<NHKException>(() => _client.ReadAsAsync<NowOnAir>(url));
            // Assert
            Assert.Equal(ErrorCode.InvalidParameters, ex.ErrorCode);
        }
    }
}
