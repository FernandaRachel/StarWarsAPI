using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using StarWarsApi;

namespace StarWarsAPI.Test
{
    public class BaseTest
    {
        public Random rnd = new Random();
        protected TestServer server;
        public static HttpClient TestHttpClient;
        public string dbFile;
        public string enderecoBase;
        public int timeout;
        public IConfiguration configuration;

        [TestInitialize]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            var testServer = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>()
            // this would cause it to use StartupIntegrationTest class
            // or ConfigureServicesIntegrationTest / ConfigureIntegrationTest
            // methods (if existing)
            // rather than Startup, ConfigureServices and Configure
            //.UseEnvironment("Debug")
            .ConfigureAppConfiguration((hostContext, configurationBuilder) =>
            {
                configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
                configurationBuilder.AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appSettings.json", optional: true,
                        reloadOnChange: true);
                configurationBuilder.AddEnvironmentVariables(prefix: "APPSETTING_ASPNETCORE_");
            }));

            TestHttpClient = testServer.CreateClient();
        }


        public async Task<T> GetAsync<T>(string address) where T : class
        {
            var response = await TestHttpClient.GetAsync(address);

            return await CheckResponseAsync<T>(response);
        }

        public async Task<TR> PostAsync<T, TR>(string address, T body) where T : class where TR : class
        {
            var response = await TestHttpClient.PostAsJsonAsync(address, body);

            var result = await CheckResponseAsync<TR>(response);
            return result;
        }

        public async Task<TR> PutAsync<T, TR>(string address, T body) where T : class where TR : class
        {
            var response = await TestHttpClient.PutAsJsonAsync(address, body);

            return await CheckResponseAsync<TR>(response);
        }


        private async Task<T> CheckResponseAsync<T>(HttpResponseMessage response) where T : class
        {
            Assert.IsTrue(response.IsSuccessStatusCode, $"Erro na chamada, código de erro: {response.StatusCode}");

            var result = await response.Content.ReadAsAsync<T>();

            Assert.IsNotNull(result, "O resultado foi nulo");

            return result;
        }

        [TestCleanup]
        public void Teardown()
        {

        }
    }
}