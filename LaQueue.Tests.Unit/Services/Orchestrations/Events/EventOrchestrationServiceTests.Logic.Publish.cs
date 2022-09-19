// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using LaQueue.Services.Orchestrations.Events;
using Moq;
using Xunit;

namespace LaQueue.Tests.Unit.Services.Orchestrations.Events
{
    public partial class EventOrchestrationServiceTests
    {
        [Fact]
        public async Task ShouldPublishLocalEventAsync()
        {
            // given
            string randomEvent = GetRandomEventName();
            string inputEvent = randomEvent;
            string postedEvent = inputEvent;
            string expectedEvent = postedEvent;
            string randomEventName = GetRandomEventName();
            string inputEventName = randomEventName;
            string localConnectionString = "something.localhost.something";

            this.eventPublishServiceMock.Setup(service =>
                service.PublishEventAsync(inputEvent, inputEventName))
                    .ReturnsAsync(postedEvent);

            this.eventOrchestrationService = new EventOrchestrationService(
                connectionString: localConnectionString,
                eventPublishService: this.eventPublishServiceMock.Object,
                eventSubscriptionService: this.eventSubscriptionServiceMock.Object,
                externalEventService: this.externalEventServiceMock.Object);

            // when
            string actualEvent =
                await this.eventOrchestrationService.PublishEventAsync(
                    inputEvent,
                    inputEventName);

            // then
            actualEvent.Should().BeEquivalentTo(expectedEvent);

            this.eventPublishServiceMock.Verify(service =>
                service.PublishEventAsync(inputEvent, inputEventName),
                    Times.Once);

            this.externalEventServiceMock.Verify(service =>
                service.PublishEventAsync(inputEvent, inputEventName),
                    Times.Never);

            this.eventPublishServiceMock.VerifyNoOtherCalls();
            this.externalEventServiceMock.VerifyNoOtherCalls();
            this.eventSubscriptionServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldPublishExternalEventAsync()
        {
            // given
            string randomEvent = GetRandomEventName();
            string inputEvent = randomEvent;
            string postedEvent = inputEvent;
            string expectedEvent = postedEvent;
            string randomEventName = GetRandomEventName();
            string inputEventName = randomEventName;
            string localConnectionString = "something.servicebus.something";

            this.externalEventServiceMock.Setup(service =>
                service.PublishEventAsync(inputEvent, inputEventName))
                    .ReturnsAsync(postedEvent);

            this.eventOrchestrationService = new EventOrchestrationService(
                connectionString: localConnectionString,
                eventPublishService: this.eventPublishServiceMock.Object,
                eventSubscriptionService: this.eventSubscriptionServiceMock.Object,
                externalEventService: this.externalEventServiceMock.Object);

            // when
            string actualEvent =
                await this.eventOrchestrationService.PublishEventAsync(
                    inputEvent,
                    inputEventName);

            // then
            actualEvent.Should().BeEquivalentTo(expectedEvent);

            this.externalEventServiceMock.Verify(service =>
                service.PublishEventAsync(inputEvent, inputEventName),
                    Times.Once);

            this.eventPublishServiceMock.Verify(service =>
                service.PublishEventAsync(inputEvent, inputEventName),
                    Times.Never);

            this.externalEventServiceMock.VerifyNoOtherCalls();
            this.eventPublishServiceMock.VerifyNoOtherCalls();
            this.eventSubscriptionServiceMock.VerifyNoOtherCalls();
        }
    }
}
