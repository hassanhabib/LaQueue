// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace LaQueue.Brokers.ApiServers
{
    public class ApiServerBroker : IApiServerBroker
    {
        private readonly WireMockServer wireMockServer;

        public ApiServerBroker(string connectionString) =>
            this.wireMockServer = WireMockServer.Start(connectionString);

        public void RegisterEventListener<T>(Func<T, ValueTask> eventHandler, string eventName)
        {
            this.wireMockServer
                .Given(Request.Create()
                    .WithPath(eventName)
                    .UsingPost())
                .RespondWith(Response.Create()
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithBody(async (requestMessage) =>
                    {
                        T request = JsonConvert
                            .DeserializeObject<T>(requestMessage.Body);
                        
                        await eventHandler(request);

                        return requestMessage.Body;
                    }));
        }
    }
}
