// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace LaQueue.Tests.Unit.Services.Orchestrations.Events
{
    public partial class EventOrchestrationServiceTests
    {
        [Fact]
        public async Task ShouldPublishEventAsync()
        {
            // given
            string randomEvent = GetRandomEventName();
            string inputEvent = randomEvent;
            string postedEvent = inputEvent;
            string expectedEvent = postedEvent;
            string randomEventName = GetRandomEventName();
            string inputEventName = randomEventName;

            this.eventPublishServiceMock.Setup(service =>
                service.PublishEventAsync(inputEventName, inputEvent))
                    .ReturnsAsync(postedEvent);

            // when
            string actualEvent =
                await this.eventOrchestrationService.PublishEventAsync(
                    inputEvent,
                    inputEventName);

            // then
            actualEvent.Should().BeEquivalentTo(expectedEvent);

            this.eventPublishServiceMock.Verify(service =>
                service.PublishEventAsync(inputEventName, inputEvent),
                    Times.Once);

            this.eventPublishServiceMock.VerifyNoOtherCalls();
        }
    }
}
