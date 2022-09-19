// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Moq;
using Xunit;

namespace LaQueue.Tests.Unit.Services.Foundations.ExternalEvents
{
    public partial class ExternalEventServiceTests
    {
        [Fact]
        public void ShouldRegisterEventHandler()
        {
            // given
            string randomEventName = GetRandomEventName();
            string inputEventName = randomEventName;

            var inputEventHandlerMock =
                new Mock<Func<object, ValueTask>>();

            Func<object, ValueTask> inputEventHandler =
                inputEventHandlerMock.Object;

            object randomObject = GetRandomObject();
            object incomingObject = randomObject;
            Message objectMessage = CreateObjectMessage(incomingObject);

            this.queueBrokerMock.Setup(broker =>
                broker.RegisterEventListener(
                    It.IsAny<Func<Message, CancellationToken, Task>>(), inputEventName))
                        .Callback<Func<Message, CancellationToken, Task>, string>((eventFunction, eventName) =>
                            eventFunction.Invoke(objectMessage, It.IsAny<CancellationToken>()));

            // when
            this.externalEventService.RegisterEventHandler(
                eventHandler: inputEventHandlerMock.Object,
                eventName: inputEventName);

            // then
            inputEventHandlerMock.Verify(handler =>
                handler.Invoke(It.Is(
                    SameObjectEventAs(incomingObject))),
                        Times.Once);

            this.queueBrokerMock.Verify(broker =>
                broker.RegisterEventListener(
                    It.IsAny<Func<Message, CancellationToken, Task>>(), inputEventName),
                        Times.Once);

            this.queueBrokerMock.VerifyNoOtherCalls();
        }
    }
}
