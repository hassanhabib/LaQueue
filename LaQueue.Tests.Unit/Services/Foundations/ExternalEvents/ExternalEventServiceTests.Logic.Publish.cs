// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Azure.ServiceBus;
using Moq;
using Xunit;

namespace LaQueue.Tests.Unit.Services.Foundations.ExternalEvents
{
    public partial class ExternalEventServiceTests
    {
        [Fact]
        public async Task ShouldPublishEventAsync()
        {
            // given
            string randomEventName = GetRandomEventName();
            string inputEventName = randomEventName;
            object randomObjectEvent = GetRandomObject();
            object inputObjectEvent = randomObjectEvent;
            object expectedObjectEvent = inputObjectEvent;

            string serializedObjectEvent =
                JsonSerializer.Serialize(expectedObjectEvent);

            var expectedObjectEventMessage = new Message
            {
                Body = Encoding.UTF8.GetBytes(serializedObjectEvent)
            };

            // when
            object actualObjectEvent =
                await this.externalEventService.PublishEventAsync<object>(
                    inputObjectEvent,
                    inputEventName);

            // then
            actualObjectEvent.Should().BeEquivalentTo(expectedObjectEvent);

            this.queueBrokerMock.Verify(broker =>
                broker.EnqueueMessageAsync(It.Is(
                    SameMessageAs(expectedObjectEventMessage)), inputEventName),
                        Times.Once);

            this.queueBrokerMock.VerifyNoOtherCalls();
        }
    }
}
