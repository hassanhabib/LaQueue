// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Net.Http;
using System.Threading.Tasks;
using RESTFulSense.Clients;

namespace LaQueue.Brokers.Apis
{
    public class ApiBroker : IApiBroker
    {
        private readonly string serverUrl;
        private IRESTFulApiFactoryClient restfulApiClient;

        public ApiBroker(string serverUrl)
        {
            this.serverUrl = serverUrl;
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(serverUrl);

            this.restfulApiClient =
                new RESTFulApiFactoryClient(httpClient);
        }

        public ValueTask<T> PostAsync<T>(string url, T request) =>
            this.restfulApiClient.PostContentAsync(url, request);
    }
}
