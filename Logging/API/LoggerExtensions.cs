// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using System.Runtime.CompilerServices;

namespace Depra.Logging
{
	public static class LoggerExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Info(this ILogChannel self, string message) => self.Log(message, LogLevel.INFO);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Info(this ILogChannel self, string message, params object[] args) =>
			self.Log(message, LogLevel.INFO, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Warn(this ILogChannel self, string message) => self.Log(message, LogLevel.WARNING);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Warn(this ILogChannel self, string message, params object[] args) =>
			self.Log(message, LogLevel.WARNING, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Assert(this ILogChannel self, string message) => self.Log(message, LogLevel.ASSERT);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Assert(this ILogChannel self, string message, params object[] args) =>
			self.Log(message, LogLevel.ASSERT, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Error(this ILogChannel self, string message) => self.Log(message, LogLevel.ERROR);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Error(this ILogChannel self, string message, params object[] args) =>
			self.Log(message, LogLevel.ERROR, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Exception(this ILogChannel self, Exception exception) =>
			self.Log(exception.Message, LogLevel.ERROR);
	}
}