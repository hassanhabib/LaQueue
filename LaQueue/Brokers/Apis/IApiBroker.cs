// ---------------------------------------------------------------
// Copyright (c) Hassan Habib All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;

namespace LaQueue.Brokers.Apis
{
    public interface IApiBroker
    {
        ValueTask<T> PostAsync<T>(string url, T request);
    }
}
