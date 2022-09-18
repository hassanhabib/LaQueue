// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using LaQueue.Services.Foundations.EventPublishes;
using LaQueue.Services.Foundations.EventSubscriptions;
using LaQueue.Services.Orchestrations.Events;
using Moq;
using Tynamix.ObjectFiller;

namespace LaQueue.Tests.Unit.Services.Orchestrations.Events
{
    public partial class EventOrchestrationServiceTests
    {
        private readonly Mock<IEventPublishService> eventPublishServiceMock;
        private readonly Mock<IEventSubscriptionService> eventSubscriptionServiceMock;
        private readonly IEventOrchestrationService eventOrchestrationService;

        public EventOrchestrationServiceTests()
        {
            this.eventPublishServiceMock = new Mock<IEventPublishService>();
            this.eventSubscriptionServiceMock = new Mock<IEventSubscriptionService>();

            this.eventOrchestrationService = new EventOrchestrationService(
                eventPublishService: this.eventPublishServiceMock.Object,
                eventSubscriptionService: this.eventSubscriptionServiceMock.Object);
        }

        private static string GetRandomEventName() =>
            new MnemonicString().GetValue();
    }
}
