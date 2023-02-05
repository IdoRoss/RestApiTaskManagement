using Microsoft.AspNetCore.Mvc.Testing;

namespace Api.Test
{
    [TestClass]
    public class UnitTest1
    {
        private HttpClient _httpClient;

        public UnitTest1()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }
        [TestMethod]
        public async Task GetUser1_ReturnsUser1()

        {
            var response = await _httpClient.GetAsync("api/Users/GetUser/1");
            var stringResult = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(1, 1);
        }
    }
}