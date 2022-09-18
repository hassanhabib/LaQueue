// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LaQueue.Services.Foundations.EventPublishes;
using LaQueue.Services.Foundations.EventSubscriptions;

namespace LaQueue.Services.Orchestrations.Events
{
    public class EventOrchestrationsService : IEventOrchestrationService
    {
        private readonly IEventPublishService eventPublishService;
        private readonly IEventSubscriptionService eventSubscriptionService;

        public EventOrchestrationsService(
            IEventPublishService eventPublishService,
            IEventSubscriptionService eventSubscriptionService)
        {
            this.eventPublishService = eventPublishService;
            this.eventSubscriptionService = eventSubscriptionService;
        }

        public async ValueTask<T> PublishEventAsync<T>(T @event, string eventName) =>
            await this.eventPublishService.PublishEventAsync(@event, eventName);

        public void SubscribeEventHandler<T>(Func<T, ValueTask> eventHandler, string eventName) =>
            this.eventSubscriptionService.RegisterEventHandler(eventHandler, eventName);

        public void RunSubscriptionServer() =>
            this.eventSubscriptionService.RunSubscriptionServer();
    }
}
