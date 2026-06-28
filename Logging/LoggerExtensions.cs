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
		public static void Debug<T>(this Logger self, string format, T arg) =>
			self.Write(LogLevel.DEBUG, format, arg);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Debug<T1, T2>(this Logger self, string format, T1 arg1, T2 arg2) =>
			self.Write(LogLevel.DEBUG, format, arg1, arg2);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Debug(this Logger self, string format, params object[] args) =>
			self.Write(LogLevel.DEBUG, format, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Info(this Logger self, string message) =>
			self.Write(LogLevel.INFO, message);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Info<T>(this Logger self, string format, T arg) =>
			self.Write(LogLevel.INFO, format, arg);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Info<T1, T2>(this Logger self, string format, T1 arg1, T2 arg2) =>
			self.Write(LogLevel.INFO, format, arg1, arg2);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Info(this Logger self, string format, params object[] args) =>
			self.Write(LogLevel.INFO, format, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Warn(this Logger self, string message) =>
			self.Write(LogLevel.WARNING, message);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Warn<T>(this Logger self, string format, T arg) =>
			self.Write(LogLevel.WARNING, format, arg);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Warn<T1, T2>(this Logger self, string format, T1 arg1, T2 arg2) =>
			self.Write(LogLevel.WARNING, format, arg1, arg2);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Warn(this Logger self, string format, params object[] args) =>
			self.Write(LogLevel.WARNING, format, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Error(this Logger self, string message) =>
			self.Write(LogLevel.ERROR, message);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Error<T>(this Logger self, string format, T arg) =>
			self.Write(LogLevel.ERROR, format, arg);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Error<T1, T2>(this Logger self, string format, T1 arg1, T2 arg2) =>
			self.Write(LogLevel.ERROR, format, arg1, arg2);

		[StringFormatMethod(nameof(format))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Error(this Logger self, string format, params object[] args) =>
			self.Write(LogLevel.ERROR, format, args);
	}
}