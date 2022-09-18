// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;

namespace LaQueue.Services.Foundations.EventPublishes
{
    public interface IEventPublishService
    {
        ValueTask<T> PublishEventAsync<T>(T request, string eventName);
    }
}
