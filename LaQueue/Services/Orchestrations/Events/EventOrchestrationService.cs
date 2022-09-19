// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LaQueue.Services.Foundations.EventPublishes;
using LaQueue.Services.Foundations.EventSubscriptions;
using LaQueue.Services.Foundations.ExternalEvents;

namespace LaQueue.Services.Orchestrations.Events
{
    public class EventOrchestrationService : IEventOrchestrationService
    {
        private readonly IEventPublishService eventPublishService;
        private readonly IEventSubscriptionService eventSubscriptionService;
        private readonly IExternalEventService externalEventService;
        private readonly string connectionString;

        public EventOrchestrationService(
            string connectionString,
            IEventPublishService eventPublishService,
            IEventSubscriptionService eventSubscriptionService,
            IExternalEventService externalEventService)
        {
            this.eventPublishService = eventPublishService;
            this.eventSubscriptionService = eventSubscriptionService;
            this.externalEventService = externalEventService;
            this.connectionString = connectionString;
        }

        public async ValueTask<T> PublishEventAsync<T>(T @event, string eventName) =>
            await this.eventPublishService.PublishEventAsync(@event, eventName);

        public void SubscribeEventHandler<T>(Func<T, ValueTask> eventHandler, string eventName) =>
            this.eventSubscriptionService.RegisterEventHandler(eventHandler, eventName);

        public void RunSubscriptionServer() =>
            this.eventSubscriptionService.RunSubscriptionServer();
    }
}
