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
    public class QueueBroker : IQueueBroker
    {
        private readonly string connectionString;
        private IQueueClient queueClient;

        public QueueBroker(string connectionString) =>
            this.connectionString = connectionString;

        public void RegisterEventListener(Func<Message, CancellationToken, Task> eventHandler, string eventName)
        {
            this.queueClient = new QueueClient(this.connectionString, eventName);
            MessageHandlerOptions messageHandlerOptions = GetMessageHandlerOptions();

            Func<Message, CancellationToken, Task> listenerFunction =
                CompleteQueueMessageAsync(eventHandler);

            this.queueClient.RegisterMessageHandler(listenerFunction, messageHandlerOptions);
        }

        private Func<Message, CancellationToken, Task> CompleteQueueMessageAsync(
               Func<Message, CancellationToken, Task> eventHandler)
        {
            return async (message, token) =>
            {
                await eventHandler(message, token);
                await this.queueClient.CompleteAsync(message.SystemProperties.LockToken);
            };
        }

        private MessageHandlerOptions GetMessageHandlerOptions()
        {
            return new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                AutoComplete = false,
                MaxConcurrentCalls = 1
            };
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            ExceptionReceivedContext context = exceptionReceivedEventArgs.ExceptionReceivedContext;

            return Task.CompletedTask;
        }
    }
}
