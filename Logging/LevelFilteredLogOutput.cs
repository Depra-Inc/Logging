// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using System;
using System.Runtime.CompilerServices;

namespace Depra.Logging
{
	public static class LogOutputExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ILogOutput WithMinLevel(this ILogOutput output, LogLevel minLevel) =>
			new LevelFilteredLogOutput(output, minLevel);
	}

	public sealed class LevelFilteredLogOutput : ILogOutput
	{
		private readonly ILogOutput _inner;
		private readonly LogLevel _minLevel;

		public LevelFilteredLogOutput(ILogOutput inner, LogLevel minLevel)
		{
			_inner = inner;
			_minLevel = minLevel;
		}

		void ILogOutput.Write(LogLevel level, string message)
		{
			if (level >= _minLevel)
			{
				_inner.Write(level, message);
			}
		}

		void ILogOutput.Write(Exception exception)
		{
			if (LogLevel.ERROR >= _minLevel)
			{
				_inner.Write(exception);
			}
		}

		void ILogOutput.Flush() => _inner.Flush();
	}
}