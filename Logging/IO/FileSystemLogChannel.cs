// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;

namespace Depra.Logging.IO
{
	public sealed class FileSystemLogChannel : ILogChannel
	{
		private readonly string _filePath;

		public FileSystemLogChannel(string filePath) => _filePath = filePath;

		public void Log(string message, LogLevel level) =>
			System.IO.File.AppendAllText(_filePath, $"{level}: {message}\n");

		void ILogChannel.Log(string message, LogLevel level, params object[] args)
		{
			if (args.Length > 0)
			{
				message = string.Format(message, args);
			}

			Log(message, level);
		}

		void ILogChannel.Log(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception), "Exception cannot be null.");
			}

			var message = $"{exception.GetType().Name}: {exception.Message}\n{exception.StackTrace}";
			System.IO.File.AppendAllText(_filePath, $"Exception: {message}\n");
		}
	}
}