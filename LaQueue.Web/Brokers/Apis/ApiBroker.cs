// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace LaQueue.Web.Brokers.Apis
{
    public class ApiBroker : IApiBroker
    {
        private readonly WebApplication webApplication;

        public ApiBroker()
        {
            var builder = WebApplication.CreateBuilder();
            this.webApplication = builder.Build();
        }

        public void CreatePublisherEndpoint<T>(Func<T, ValueTask> publisherFunction, string endpoint)
        {
            this.webApplication.MapPost(
                pattern: $"/{endpoint}",
                handler: async ([FromBody] T requestBody) => await publisherFunction(requestBody));
        }

        public void RunApi() => this.webApplication.Run();
    }
}
