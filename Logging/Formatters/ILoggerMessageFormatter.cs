// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Logging.Dto;

namespace Depra.Logging.Formatters
{
    public interface ILoggerMessageFormatter
    {
        string Format(LoggerEntry loggerEntry);
    }
}