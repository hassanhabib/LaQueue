// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Moq;
using Xunit;

namespace LaQueue.Tests.Unit.Services.Orchestrations.Events
{
    public partial class EventOrchestrationServiceTests
    {
        [Fact]
        public void ShouldRunSubscriptionServer()
        {
            // given . when
            this.eventOrchestrationService.RunSubscriptionServer();

            // then
            this.eventSubscriptionServiceMock.Verify(service =>
                service.RunSubscriptionServer(),
                    Times.Once);

            this.eventSubscriptionServiceMock.VerifyNoOtherCalls();
            this.eventPublishServiceMock.VerifyNoOtherCalls();
        }
    }
}
