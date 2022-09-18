// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

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

        public ValueTask<T> PublishEventAsync<T>(T @event, string eventName)
        {
            throw new System.NotImplementedException();
        }
    }
}
