// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace LaQueue.Services.Foundations.ExternalEvents
{
    public interface IExternalEventService
    {
        ValueTask<T> PublishEventAsync<T>(T @event, string eventName);
        void RegisterEventHandler<T>(Func<T, ValueTask> eventHandler, string eventName);
    }
}
