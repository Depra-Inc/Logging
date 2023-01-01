// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading.Tasks;
using Depra.Logging.Dto;

namespace Depra.Logging.Processors
{
    public interface IAsyncLogProcessor : IAsyncDisposable
    {
        Task PostAsync(LoggerEntry loggerEntry);
    }
}