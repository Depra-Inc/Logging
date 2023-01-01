// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using Depra.Logging.Dto;

namespace Depra.Logging.Formatters
{
    public sealed class StandardLoggerMessageFormatter : ILoggerMessageFormatter
    {
        private const string MESSAGE_FORMAT_WITHOUT_ARGS = "[{0}] | Priority: {2}";
        private const string MESSAGE_FORMAT_WITH_ARGS = "[{0}] | Args: {1} | Priority: {2}";

        public string Format(LoggerEntry loggerEntry)
        {
            var format = loggerEntry.Args.Length > 0 ? MESSAGE_FORMAT_WITH_ARGS : MESSAGE_FORMAT_WITHOUT_ARGS;
            var formattedMessage = string.Format(format, loggerEntry.Type, FormatArgsArrayToString(loggerEntry.Args),
                loggerEntry.Priority);

            return formattedMessage;
        }

        private static string FormatArgsArrayToString(IReadOnlyList<object> args)
        {
            var result = string.Empty;
            for (var i = 0; i < args.Count; i++)
            {
                var arg = args[i];
                result += arg;

                if (i < args.Count - 1)
                {
                    result += "; ";
                }
            }

            return result;
        }
    }
}