// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using LaQueue.Brokers.ApiServers;
using LaQueue.Services.Foundations.EventSubscriptions;
using Moq;
using Tynamix.ObjectFiller;

namespace LaQueue.Tests.Unit.Services.Foundations.EventSubscriptions
{
    public partial class EventSubscriptionServiceTests
    {
        private readonly Mock<IApiServerBroker> apiServerBrokerMock;
        private readonly IEventSubscriptionService eventSubscriptionService;

        public EventSubscriptionServiceTests()
        {
            this.apiServerBrokerMock = new Mock<IApiServerBroker>();

            this.eventSubscriptionService = new EventSubscriptionService(
                apiServerBroker: this.apiServerBrokerMock.Object);
        }

        private static string GetRandomEventName() =>
            new MnemonicString().GetValue();
    }
}
