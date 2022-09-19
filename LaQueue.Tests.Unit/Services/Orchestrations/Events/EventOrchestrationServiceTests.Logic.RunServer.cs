// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using LaQueue.Services.Orchestrations.Events;
using Moq;
using Xunit;

namespace LaQueue.Tests.Unit.Services.Orchestrations.Events
{
    public partial class EventOrchestrationServiceTests
    {
        [Fact]
        public void ShouldRunSubscriptionServer()
        {
            // given
            string someConnectionString = GetRandomString();

            this.eventOrchestrationService = new EventOrchestrationService(
                connectionString: someConnectionString,
                eventPublishService: this.eventPublishServiceMock.Object,
                eventSubscriptionService: this.eventSubscriptionServiceMock.Object,
                externalEventService: this.externalEventServiceMock.Object);

            // when
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
