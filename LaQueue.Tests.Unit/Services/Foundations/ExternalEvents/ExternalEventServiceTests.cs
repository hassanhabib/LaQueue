// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Linq.Expressions;
using System;
using System.Text;
using KellermanSoftware.CompareNetObjects;
using LaQueue.Brokers.Queues;
using LaQueue.Services.Foundations.ExternalEvents;
using Microsoft.Azure.ServiceBus;
using Moq;
using Newtonsoft.Json;
using Tynamix.ObjectFiller;

namespace LaQueue.Tests.Unit.Services.Foundations.ExternalEvents
{
    public partial class ExternalEventServiceTests
    {
        private readonly Mock<IQueueBroker> queueBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IExternalEventService externalEventService;

        public ExternalEventServiceTests()
        {
            this.queueBrokerMock = new Mock<IQueueBroker>();
            this.compareLogic = new CompareLogic();

            this.externalEventService = new ExternalEventService(
                queueBroker: this.queueBrokerMock.Object);
        }

        private static string GetRandomEventName() =>
            new MnemonicString().GetValue();        
        
        private static string GetRandomObject() =>
            new MnemonicString().GetValue();

        private Expression<Func<object, bool>> SameObjectEventAs(
            object expectedObject)
        {
            return actualContributionEvent =>
                this.compareLogic.Compare(
                    expectedObject,
                    actualContributionEvent)
                        .AreEqual;
        }

        private static Message CreateObjectMessage(object @object)
        {
            string serializedStudent = JsonConvert.SerializeObject(@object);
            byte[] contributionBody = Encoding.UTF8.GetBytes(serializedStudent);

            return new Message
            {
                Body = contributionBody
            };
        }
    }
}
