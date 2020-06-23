using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Corporate.Back.Copa.API;
using System.Threading.Tasks;
using System.Net;
using Corporate.Back.Copa.Api.Client.TO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Corporate.Back.Copa.Tests
{
    public class TeamCupAPITest
    {
        private readonly HttpClient _client;

        public TeamCupAPITest ()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        #region Team (GET) all test

        [Theory]
        [InlineData("POST")]
        public async Task TeamGetAllTestAsync(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/teamscup/allteams");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        #endregion Team (GET) all test

        #region Team (POST) do gamming test

        public static IEnumerable<object[]> TestSendTeamsData =>
            new List<object[]>
            {
                new object[] { new TeamsTO() },
                new object[] { new TeamsTO() }
            };

        [Theory]
        [MemberData(nameof(TestSendTeamsData))]
        public async Task TeamPostDoGammingTestAsync(TeamsTO teams)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("POST"), "/teamscup/dogaming");
            request.Content = new StringContent(JsonConvert.SerializeObject(teams));

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        #endregion Team (POST) do gamming test
    }
}
