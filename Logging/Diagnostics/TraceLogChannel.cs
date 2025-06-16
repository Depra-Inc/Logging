// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using System.Diagnostics;

namespace Depra.Logging
{
	public sealed class TraceLogChannel : ILogChannel
	{
		public void Log(string message, LogLevel level) => Trace.WriteLine(message, category: level.ToString());

		void ILogChannel.Log(string message, LogLevel level, params object[] args)
		{
			if (args.Length > 0)
			{
				message = string.Format(message, args);
			}

			Log(string.Format(message, args), level);
		}

		void ILogChannel.Log(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception), "Exception cannot be null.");
			}

			var message = $"{exception.GetType().Name}: {exception.Message}\n{exception.StackTrace}";
			Trace.WriteLine(message, category: "Exception");
		}
	}
}