// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Moq;
using Xunit;

namespace LaQueue.Web.Tests.Unit.Services.Apis
{
    public partial class ApiServiceTests
    {
        [Fact]
        public void ShouldRunApiServer()
        {
            // given
            string randomServerUrl = GetRandomEndpoint();
            string serverUrl = randomServerUrl;

            // when
            this.apiService.RunApiServer(serverUrl);

            // then
            this.apiBrokerMock.Verify(broker =>
                broker.RunApi(serverUrl),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
