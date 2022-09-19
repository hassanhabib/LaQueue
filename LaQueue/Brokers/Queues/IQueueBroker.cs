// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace LaQueue.Brokers.Queues
{
    public interface IQueueBroker
    {
        void RegisterEventListener(Func<Message, CancellationToken, Task> eventHandler, string eventName);
        ValueTask EnqueueMessageAsync(Message message, string eventName);
    }
}
