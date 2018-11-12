using EMDI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EDMI.API.Tests
{
    /// <summary>
    /// Class that simulates the start of the application for unit tests
    /// </summary>
    public class CompositionRootFixture
    {
        private readonly TestServer server;

        /// <summary>
        /// HTTP client to simulate calls to the API
        /// </summary>
        public HttpClient Client { get; }

        public CompositionRootFixture()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}


