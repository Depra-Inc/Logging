// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;

namespace Depra.Logging
{
	public sealed class ConsoleLogChannel : ILogChannel
	{
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

		void ILogChannel.Log(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception), "Exception cannot be null.");
			}

			var message = $"Exception: {exception.Message}";
			if (exception.StackTrace != null)
			{
				message += Environment.NewLine + exception.StackTrace;
			}

			Console.WriteLine(message);
		}
	}
}