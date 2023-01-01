// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics;
using Depra.Logging.Dto;
using Depra.Logging.Enums;
using Depra.Logging.Processors;

namespace Depra.Logging.Services
{
    public sealed class LogService
    {
        private const string DEBUG_MODE_DEFINE = "DEBUG";

        private readonly ILogProcessor _logProcessor;

        public LogService(ILogProcessor logProcessor) => _logProcessor = logProcessor;

        [Conditional(DEBUG_MODE_DEFINE)]
        public void Info(params object[] args)
        {
            var logEntry = new LoggerEntry(LogType.Info, Priority.Info, args);
            _logProcessor.Post(logEntry);
        }

        [Conditional(DEBUG_MODE_DEFINE)]
        public void Warning(params object[] args)
        {
            var logEntry = new LoggerEntry(LogType.Warning, Priority.Warning, args);
            _logProcessor.Post(logEntry);
        }

        [Conditional(DEBUG_MODE_DEFINE)]
        public void Assert(params object[] args)
        {
            var logEntry = new LoggerEntry(LogType.Assert, Priority.Error, args);
            _logProcessor.Post(logEntry);
        }

        [Conditional(DEBUG_MODE_DEFINE)]
        public void Exception(params object[] args)
        {
            var logEntry = new LoggerEntry(LogType.Exception, Priority.FatalError, args);
            _logProcessor.Post(logEntry);
        }

        [Conditional(DEBUG_MODE_DEFINE)]
        public void Custom(LogType type, Priority priority, params object[] args)
        {
            var logEntry = new LoggerEntry(type, priority, args);
            _logProcessor.Post(logEntry);
        }
    }
}