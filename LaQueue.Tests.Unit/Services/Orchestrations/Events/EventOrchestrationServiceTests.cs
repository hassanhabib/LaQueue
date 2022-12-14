// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using LaQueue.Services.Foundations.EventPublishes;
using LaQueue.Services.Foundations.EventSubscriptions;
using LaQueue.Services.Foundations.ExternalEvents;
using LaQueue.Services.Orchestrations.Events;
using Moq;
using Tynamix.ObjectFiller;

namespace LaQueue.Tests.Unit.Services.Orchestrations.Events
{
    public partial class EventOrchestrationServiceTests
    {
        private readonly Mock<IEventPublishService> eventPublishServiceMock;
        private readonly Mock<IEventSubscriptionService> eventSubscriptionServiceMock;
        private readonly Mock<IExternalEventService> externalEventServiceMock;
        private IEventOrchestrationService eventOrchestrationService;

        public EventOrchestrationServiceTests()
        {
            this.eventPublishServiceMock = new Mock<IEventPublishService>();
            this.eventSubscriptionServiceMock = new Mock<IEventSubscriptionService>();
            this.externalEventServiceMock = new Mock<IExternalEventService>();
        }

        private static string GetRandomEventName() =>
            new MnemonicString().GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();
    }
}
