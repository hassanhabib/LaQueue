// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace LaQueue.Web.Services.Apis
{
    public interface IApiService
    {
        void CreatePublisherEndpoint<T>(Func<T, ValueTask> publisherFunction, string endpoint);
        void RunApiServer(string url);
    }
}
