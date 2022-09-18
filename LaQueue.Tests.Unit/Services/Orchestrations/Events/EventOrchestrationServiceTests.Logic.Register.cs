// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace LaQueue.Tests.Unit.Services.Orchestrations.Events
{
    public partial class EventOrchestrationServiceTests
    {
        [Fact]
        public void ShouldSubscribeEventHandler()
        {
            // given
            var eventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> eventHandler =
                eventHandlerMock.Object;

            string randomEventName = GetRandomEventName();
            string inputEventName = randomEventName;

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

            this.eventSubscriptionServiceMock.VerifyNoOtherCalls();
            this.eventPublishServiceMock.VerifyNoOtherCalls();
        }
    }
}
