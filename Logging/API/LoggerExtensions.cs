// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System.Runtime.CompilerServices;

namespace Depra.Logging
{
    public static class LoggerExtensions
    {
	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Info(this ILogChannel self, string message, params object[] args) =>
            self.Log(message, LogLevel.INFO, args);

	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Warning(this ILogChannel self, string message, params object[] args) =>
            self.Log(message, LogLevel.WARNING, args);

	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Assert(this ILogChannel self, string message, params object[] args) =>
            self.Log(message, LogLevel.ASSERT, args);

	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Error(this ILogChannel self, string message, params object[] args) =>
            self.Log(message, LogLevel.ERROR, args);

	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FatalError(this ILogChannel self, string message, params object[] args) =>
            self.Log(message, LogLevel.FATAL_ERROR, args);
    }
}