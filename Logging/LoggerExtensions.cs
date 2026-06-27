// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using System.Runtime.CompilerServices;

namespace Depra.Logging
{
	public static class LoggerExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Debug(this Logger self, string message) =>
			self.Write(LogLevel.DEBUG, message);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Debug(this Logger self, string message, params object[] args) =>
			self.Write(LogLevel.DEBUG, message, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Info(this Logger self, string message) =>
			self.Write(LogLevel.INFO, message);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Info(this Logger self, string message, params object[] args) =>
			self.Write(LogLevel.INFO, message, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Warn(this Logger self, string message) =>
			self.Write(LogLevel.WARNING, message);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Warn(this Logger self, string message, params object[] args) =>
			self.Write(LogLevel.WARNING, message, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Error(this Logger self, string message) =>
			self.Write(LogLevel.ERROR, message);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Error(this Logger self, string message, params object[] args) =>
			self.Write(LogLevel.ERROR, message, args);
	}
}