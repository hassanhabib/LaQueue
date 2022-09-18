// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using LaQueue.Web.Brokers.Apis;
using LaQueue.Web.Services.Apis;
using Moq;
using Tynamix.ObjectFiller;

namespace LaQueue.Web.Tests.Unit.Services.Apis
{
    public partial class ApiServiceTests
    {
        private readonly Mock<IApiBroker> apiBrokerMock;
        private readonly IApiService apiService;

        public ApiServiceTests()
        {
            this.apiBrokerMock = new Mock<IApiBroker>();

            this.apiService = new ApiService(
                apiBroker: this.apiBrokerMock.Object);
        }

        private static string GetRandomEndpoint() =>
            new MnemonicString().GetValue();
    }
}
