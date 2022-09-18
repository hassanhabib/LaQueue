// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using LaQueue.Brokers.Apis;
using LaQueue.Services.Foundations.EventPublishes;
using Moq;
using Tynamix.ObjectFiller;

namespace LaQueue.Tests.Unit.Services.Foundations.EventPublishes
{
    public partial class EventPublishServiceTests
    {
        private readonly Mock<IApiBroker> apiBrokerMock;
        private readonly IEventPublishService eventPublishService;

        public EventPublishServiceTests()
        {
            this.apiBrokerMock = new Mock<IApiBroker>();

            this.eventPublishService = new EventPublishService(
                apiBroker: this.apiBrokerMock.Object);
        }

        private static string GetRandomEventName() =>
           new MnemonicString().GetValue();
    }
}
