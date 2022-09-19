// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using LaQueue.Services.Orchestrations.Events;
using Moq;
using Xunit;

namespace LaQueue.Tests.Unit.Services.Orchestrations.Events
{
    public partial class EventOrchestrationServiceTests
    {
        [Fact]
        public void ShouldSubscribeEventHandlerWithLocalEvent()
        {
            // given
            string localConnectionString = "something.localhost.com";

            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> eventHandler =
                eventHandlerMock.Object;

            string randomEventName = GetRandomEventName();
            string inputEventName = randomEventName;

            this.eventOrchestrationService = new EventOrchestrationService(
                connectionString: localConnectionString,
                eventPublishService: this.eventPublishServiceMock.Object,
                eventSubscriptionService: this.eventSubscriptionServiceMock.Object,
                externalEventService: this.externalEventServiceMock.Object);

            // when
            this.eventOrchestrationService.SubscribeEventHandler(
                eventHandler,
                inputEventName);

            // then
            this.eventSubscriptionServiceMock.Verify(service =>
                service.RegisterEventHandler(
                    eventHandler,
                    inputEventName),
                        Times.Once);

            this.externalEventServiceMock.Verify(service =>
                service.RegisterEventHandler(
                    eventHandler,
                    inputEventName),
                        Times.Never);

            this.eventSubscriptionServiceMock.VerifyNoOtherCalls();
            this.externalEventServiceMock.VerifyNoOtherCalls();
            this.eventPublishServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldSubscribeEventHandlerWithExternalEvent()
        {
            // given
            string localConnectionString = "something.servicebus.com";

            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> eventHandler =
                eventHandlerMock.Object;

            string randomEventName = GetRandomEventName();
            string inputEventName = randomEventName;

            this.eventOrchestrationService = new EventOrchestrationService(
                connectionString: localConnectionString,
                eventPublishService: this.eventPublishServiceMock.Object,
                eventSubscriptionService: this.eventSubscriptionServiceMock.Object,
                externalEventService: this.externalEventServiceMock.Object);

            // when
            this.eventOrchestrationService.SubscribeEventHandler(
                eventHandler,
                inputEventName);

            // then
            this.externalEventServiceMock.Verify(service =>
                service.RegisterEventHandler(
                    eventHandler,
                    inputEventName),
                        Times.Once);

            this.eventSubscriptionServiceMock.Verify(service =>
                service.RegisterEventHandler(
                    eventHandler,
                    inputEventName),
                        Times.Never);

            this.eventSubscriptionServiceMock.VerifyNoOtherCalls();
            this.externalEventServiceMock.VerifyNoOtherCalls();
            this.eventPublishServiceMock.VerifyNoOtherCalls();
        }
    }
}
