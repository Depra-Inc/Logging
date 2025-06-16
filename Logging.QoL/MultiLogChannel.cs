// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

namespace Depra.Logging
{
	public sealed class MultiLogChannel : ILogChannel
	{
		private readonly ILogChannel[] _channels;

		public MultiLogChannel(params ILogChannel[] channels) => _channels = channels;

		void ILogChannel.Log(string message, LogLevel level)
		{
			foreach (var channel in _channels)
			{
				channel.Log(message, level);
			}
		}

		void ILogChannel.Log(string message, LogLevel level, params object[] args)
		{
			foreach (var channel in _channels)
			{
				channel.Log(message, level, args);
			}
		}
	}
}