// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace LaQueue.Tests.Unit.Services.Foundations.EventSubscriptions
{
    public partial class EventSubscriptionServiceTests
    {
        [Fact]
        public void ShouldRegisterEventWithEventName()
        {
            // given
            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> eventHandler =
                eventHandlerMock.Object;

            string randomEventName = GetRandomEventName();
            string inputEventName = randomEventName;

            // when
            this.eventSubscriptionService.RegisterEventHandler(
                eventHandler,
                inputEventName);

            // then
            this.apiServerBrokerMock.Verify(broker =>
                broker.RegisterEventListener(
                    eventHandler,
                    inputEventName),
                        Times.Once);

            this.apiServerBrokerMock.VerifyNoOtherCalls();
        }
    }
}
