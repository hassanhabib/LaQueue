// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LaQueue.Brokers.ApiServers;

namespace LaQueue.Services.Foundations.EventSubscriptions
{
    public class EventSubscriptionService : IEventSubscriptionService
    {
        private readonly IApiServerBroker apiServerBroker;

        public EventSubscriptionService(IApiServerBroker apiServerBroker) =>
            this.apiServerBroker = apiServerBroker;

        public void RegisterEventHandler<T>(Func<T, ValueTask> eventHandler, string eventName) =>
            this.apiServerBroker.RegisterEventListener(eventHandler, eventName);

        public void RunSubscriptionServer()
        {
            throw new NotImplementedException();
        }
    }
}