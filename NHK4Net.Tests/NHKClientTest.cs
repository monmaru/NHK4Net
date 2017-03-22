using System;
using System.Net.Http;
using NHK4Net.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace NHK4Net.Tests
{
    public class NHKClientTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly FakeResponseHandler _fakeHandler;
        private readonly NHKClient _client;
        private const string DummyApiKey = "DummyAPIKey";

        public NHKClientTest(ITestOutputHelper output)
        {
            _output = output;
            _fakeHandler = new FakeResponseHandler();
            _client = new NHKClient(DummyApiKey, new HttpClient(_fakeHandler));
        }

        public void Dispose()
        {
            _fakeHandler?.Dispose();
            _client?.Dispose();
        }

        [Fact]
        public void ProgramListUrlTest()
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
        public void ProgramInfoUrlTest()
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
        public void NowOnAirUrlTest()
        {
            // Arrange
            var expected = $"http://api.nhk.or.jp/v2/pg/now/{NHKArea.東京}/{NHKService.総合1}.json?key={DummyApiKey}";
            // Act
            var url = _client.NowOnAirUrl(NHKArea.東京, NHKService.総合1);
            _output.WriteLine($"URL = {url}");
            // Assert
            Assert.Equal(expected, url);
        }
    }
}
