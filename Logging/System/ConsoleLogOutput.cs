// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using System;

namespace Depra.Logging.System
{
	public sealed class ConsoleLogOutput : ILogOutput
	{
		void ILogOutput.Write(LogLevel level, string message) => Console.WriteLine(message);

		void ILogOutput.Write(Exception exception)
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

		void ILogOutput.Flush() { }
	}
}