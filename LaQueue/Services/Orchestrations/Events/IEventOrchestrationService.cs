// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace LaQueue.Services.Orchestrations.Events
{
    public interface IEventOrchestrationService
    {
        ValueTask<T> PublishEventAsync<T>(T @event, string eventName);
        void SubscribeEventHandler<T>(Func<T, ValueTask> eventHandler, string eventName);
    }
}
