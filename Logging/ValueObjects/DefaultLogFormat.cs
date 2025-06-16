// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;

namespace Depra.Logging
{
	public sealed class DefaultLogFormat
	{
		private static string FormatPrefix(LogEntry entry) => entry.Level.ToString().ToUpperInvariant() + ": ";

		private Func<LogEntry, string> _prefixSource = FormatPrefix;

		public ILogFormat Build() => new Instance();

		public DefaultLogFormat WithPrefix(Func<LogEntry, string> formatFunc)
		{
			_prefixSource = formatFunc;
			return this;
		}

		private sealed class Instance : ILogFormat
		{
			public LogEntry Format(string message, LogLevel level, object[] args) => throw new NotImplementedException();
		}
	}
}