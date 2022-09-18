// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace LaQueue.Web.Tests.Unit.Services.Apis
{
    public partial class ApiServiceTests
    {
        [Fact]
        public void ShouldCreatePublisherEndpoint()
        {
            // given
            var publisherFunctionMock = new Mock<Func<object, ValueTask>>();
            Func<object, ValueTask> publisherFunction = publisherFunctionMock.Object;
            string randomEndpoint = GetRandomEndpoint();
            string inputEndpoint = randomEndpoint;

            // when
            this.apiService.CreatePublisherEndpoint(publisherFunction, inputEndpoint);

            // then

        }
    }
}
