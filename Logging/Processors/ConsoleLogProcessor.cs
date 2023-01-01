// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Logging.Dto;
using Depra.Logging.Formatters;

namespace Depra.Logging.Processors
{
    public sealed class ConsoleLogProcessor : ILogProcessor
    {
        private readonly ILoggerMessageFormatter _formatter;

        public ConsoleLogProcessor(ILoggerMessageFormatter formatter = null) =>
            _formatter = formatter ?? new StandardLoggerMessageFormatter();

        public void Post(LoggerEntry loggerEntry) => Console.WriteLine(_formatter.Format(loggerEntry));
    }
}