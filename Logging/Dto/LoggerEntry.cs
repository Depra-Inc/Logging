// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Logging.Enums;

namespace Depra.Logging.Dto
{
    [Serializable]
    public readonly struct LoggerEntry
    {
        public readonly LogType Type;
        public readonly object[] Args;
        public readonly Priority Priority;

        public LoggerEntry(LogType type, Priority priority, object[] args)
        {
            Type = type;
            Priority = priority;
            Args = args;
        }
    }
}