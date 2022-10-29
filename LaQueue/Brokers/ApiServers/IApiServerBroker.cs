// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace LaQueue.Brokers.ApiServers
{
    public interface IApiServerBroker
    {
        void RegisterEventListener<T>(Func<T, ValueTask> eventHandler, string eventName);
    }
}
