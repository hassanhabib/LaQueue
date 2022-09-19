// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LaQueue.Brokers.Queues;
using Microsoft.Azure.ServiceBus;

namespace LaQueue.Services.Foundations.ExternalEvents
{
    public class ExternalEventService : IExternalEventService
    {
        private readonly IQueueBroker queueBroker;

        public ExternalEventService(IQueueBroker queueBroker) =>
            this.queueBroker = queueBroker;

        public void RegisterEventHandler<T>(Func<T, ValueTask> eventHandler, string eventName)
        {
            this.queueBroker.RegisterEventListener(async (message, token) =>
            {
                T messageObject = MapTo<T>(message);
                await eventHandler.Invoke(messageObject);
            }, eventName);
        }

        public async ValueTask<T> PublishEventAsync<T>(T @event, string eventName)
        {
            Message message = MapToMessage<T>(@event);
            await this.queueBroker.EnqueueMessageAsync(message, eventName);

            return @event;
        }

        private Message MapToMessage<T>(T @event)
        {
            string serializedEvent =
                JsonSerializer.Serialize(@event);

            return new Message
            {
                Body = Encoding.UTF8.GetBytes(serializedEvent)
            };
        }

        private static T MapTo<T>(Message message)
        {
            var stringifiedMessage =
                Encoding.UTF8.GetString(message.Body);

            var deserializedMessage =
                Newtonsoft.Json.JsonConvert.DeserializeObject<T>(
                    stringifiedMessage);

            return deserializedMessage;
        }
    }
}
