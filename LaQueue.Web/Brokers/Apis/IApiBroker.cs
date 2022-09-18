// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace LaQueue.Web.Brokers.Apis
{
    public interface IApiBroker
    {
        void CreatePublisherEndpoint<T>(Func<T, ValueTask> publisherFunction, string endpoint);
        void RunApi();
    }
}
