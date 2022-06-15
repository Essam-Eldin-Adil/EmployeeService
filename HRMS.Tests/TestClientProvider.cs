using HRMS.EmployeeAPIService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace HRMS.Tests
{
    public class TestClientProvider:IDisposable
    {
        TestServer testServer;
        public HttpClient httpClient { get; set; }
        public TestClientProvider()
        {
            testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            httpClient = testServer.CreateClient();
        }

        public void Dispose()
        {
            testServer?.Dispose();
            httpClient?.Dispose();
        }
    }
}
