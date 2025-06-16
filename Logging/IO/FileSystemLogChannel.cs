// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

namespace Depra.Logging
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

			Log(string.Format(message, args), level);
		}
	}
}