// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LaQueue.Brokers.Apis;

namespace LaQueue.Services.Foundations.EventPublishes
{
    public class EventPublishService : IEventPublishService
    {
        private readonly IApiBroker apiBroker;

        public EventPublishService(IApiBroker apiBroker) =>
            this.apiBroker = apiBroker;

        public ValueTask<T> PublishEventAsync<T>(T request, string eventName)
        {
            throw new NotImplementedException();
        }
    }
}
