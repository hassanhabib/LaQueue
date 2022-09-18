// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Moq;
using Xunit;

namespace LaQueue.Tests.Unit.Services.Foundations.EventSubscriptions
{
    public partial class EventSubscriptionServiceTests
    {
        [Fact]
        public void ShouldRunSubscriptionServer()
        {
            // given . when
            this.eventSubscriptionService.RunSubscriptionServer();

            // then
            this.apiServerBrokerMock.Verify(broker =>
                broker.RunServer(),
                    Times.Once);

            this.apiServerBrokerMock.VerifyNoOtherCalls();
        }
    }
}
