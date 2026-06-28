// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Depra.Logging
{
	public static class LoggerExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Debug(this Logger self, string message) =>
			self.Write(LogLevel.DEBUG, message);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Debug(this Logger self, string format, params object[] args) =>
			self.Write(LogLevel.DEBUG, format, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Info(this Logger self, string message) =>
			self.Write(LogLevel.INFO, message);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Info(this Logger self, string format, params object[] args) =>
			self.Write(LogLevel.INFO, format, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Warn(this Logger self, string message) =>
			self.Write(LogLevel.WARNING, message);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Warn(this Logger self, string format, params object[] args) =>
			self.Write(LogLevel.WARNING, format, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Error(this Logger self, string message) =>
			self.Write(LogLevel.ERROR, message);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Error(this Logger self, string format, params object[] args) =>
			self.Write(LogLevel.ERROR, format, args);
	}
}