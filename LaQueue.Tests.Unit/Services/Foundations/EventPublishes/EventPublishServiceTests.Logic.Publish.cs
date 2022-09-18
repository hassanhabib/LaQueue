// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace LaQueue.Tests.Unit.Services.Foundations.EventPublishes
{
    public partial class EventPublishServiceTests
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

            this.apiBrokerMock.Setup(broker =>
                broker.PostAsync(inputEventName, inputEvent))
                    .ReturnsAsync(postedEvent);

            // when
            string actualEvent =
                await this.eventPublishService.PublishEventAsync(
                    inputEvent,
                    inputEventName);

            // then
            actualEvent.Should().BeEquivalentTo(expectedEvent);

            this.apiBrokerMock.Verify(broker =>
                broker.PostAsync(inputEventName, inputEvent),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
