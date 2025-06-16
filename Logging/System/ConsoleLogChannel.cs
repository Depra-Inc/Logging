// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;

namespace Depra.Logging
{
	public sealed class ConsoleLogChannel : ILogChannel
	{
		private readonly string _tag;

		public ConsoleLogChannel(string tag) => _tag = tag;

		public void Log(LogEntry entry)
		{
			var prefix = entry.Level.ToString().ToUpperInvariant() + ": ";
			var message = prefix + entry.Text;
			if (entry.NewLine)
			{
				Console.WriteLine(message);
			}
			else
			{
				Console.Write(message);
			}
		}

		void ILogChannel.Log(string message, LogLevel level) => Console.WriteLine(message);

		void ILogChannel.Log(string message, LogLevel level, params object[] args) => Console.WriteLine(message, args);
	}
}