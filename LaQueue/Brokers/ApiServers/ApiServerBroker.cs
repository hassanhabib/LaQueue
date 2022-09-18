// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LaQueue.Web.Clients;

namespace LaQueue.Brokers.ApiServers
{
    public class ApiServerBroker : IApiServerBroker
    {
        private readonly ApiClient apiClient;
        private readonly string connectionString;

        public ApiServerBroker(string connectionString)
        {
            this.apiClient = new ApiClient();
            this.connectionString = connectionString;
        }

        public void RegisterEventListener<T>(Func<T, ValueTask> eventHandler, string eventName) =>
            this.apiClient.CreatePublisherEndpoint(eventHandler, eventName);

        public void RunServer() =>
            this.apiClient.RunApiServer(url: connectionString);
    }
}
