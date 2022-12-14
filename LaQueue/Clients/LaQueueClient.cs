// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LaQueue.Brokers.Apis;
using LaQueue.Brokers.ApiServers;
using LaQueue.Brokers.Queues;
using LaQueue.Services.Foundations.EventPublishes;
using LaQueue.Services.Foundations.EventSubscriptions;
using LaQueue.Services.Foundations.ExternalEvents;
using LaQueue.Services.Orchestrations.Events;

namespace LaQueue.Clients
{
    public class LaQueueClient : ILaQueueClient
    {
        private readonly IEventOrchestrationService eventOrchestrationService;

        public LaQueueClient(string connectionString)
        {
            IQueueBroker queueBroker = new QueueBroker(connectionString);
            IEventPublishService eventPublishService = null;
            IEventSubscriptionService eventSubscriptionService = null;

            if (connectionString.Contains("localhost") is true)
            {
                IApiBroker apiBroker = new ApiBroker(connectionString);
                IApiServerBroker apiServerBroker = new ApiServerBroker(connectionString);
                eventPublishService = new EventPublishService(apiBroker);
                eventSubscriptionService = new EventSubscriptionService(apiServerBroker);
            }
            
           
            IExternalEventService externalEventService = new ExternalEventService(queueBroker);

            this.eventOrchestrationService = new EventOrchestrationService(
                connectionString,
                eventPublishService,
                eventSubscriptionService,
                externalEventService);
        }

        public ValueTask<T> PublishEventAsync<T>(T @event, string eventName) =>
            this.eventOrchestrationService.PublishEventAsync(@event, eventName);

        public void SubscribeEventHandler<T>(Func<T, ValueTask> eventHandler, string eventName)
        {
            this.eventOrchestrationService.SubscribeEventHandler(eventHandler, eventName);
        }
    }
}
