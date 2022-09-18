// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LaQueue.Web.Brokers.Apis;
using LaQueue.Web.Services.Apis;

namespace LaQueue.Web.Clients
{
    public class ApiClient
    {
        private readonly IApiService apiService;

        public ApiClient()
        {
            var apiBroker = new ApiBroker();
            this.apiService = new ApiService(apiBroker);
        }

        public void CreatePublisherEndpoint<T>(Func<T, ValueTask> publisherFunction, string endpoint) =>
            this.apiService.CreatePublisherEndpoint(publisherFunction, endpoint);

        public void RunApiServer(string url) =>
            this.apiService.RunApiServer(url);
    }
}
