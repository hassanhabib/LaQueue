// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LaQueue.Web.Brokers.Apis;

namespace LaQueue.Web.Services.Apis
{
    public class ApiService : IApiService
    {
        private readonly IApiBroker apiBroker;

        public ApiService(IApiBroker apiBroker) =>
            this.apiBroker = apiBroker;

        public void CreatePublisherEndpoint<T>(Func<T, ValueTask> publisherFunction, string endpoint) =>
            this.apiBroker.CreatePublisherEndpoint(publisherFunction, endpoint);

        public void RunApiServer(string url)
        {
            throw new NotImplementedException();
        }
    }
}
