// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System.Runtime.CompilerServices;
using System.Text;

namespace Depra.Logging
{
	public sealed class Logger : ILogChannel
	{
		private static readonly string[] LOG_LEVEL_NAMES = { "info:", "warn:", "assert:", "error:", "fatal:" };
		private static StringBuilder _stringBuilder;

		private readonly string _channelId;
		private readonly ILogChannel _master;

		public Logger(ILogChannel master, string channelId)
		{
			_master = master;
			_channelId = channelId;
		}

		public Logger Channel(string channelId) => new(_master,
			string.IsNullOrEmpty(_channelId) ? channelId : $"{_channelId}:{channelId}");

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Log(string message, LogLevel level) => _master.Log(
			CreateStringBuilder(_channelId, LOG_LEVEL_NAMES[(int)level]).Append(message).ToString(), level);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Log(string message, LogLevel level, params object[] args) => _master.Log(
			CreateStringBuilder(_channelId, LOG_LEVEL_NAMES[(int)level]).Append(message).ToString(), level, args);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static StringBuilder CreateStringBuilder(string channel, string type)
		{
			_stringBuilder ??= new StringBuilder(byte.MaxValue);
			_stringBuilder.Clear();
			if (!string.IsNullOrEmpty(channel))
			{
				_stringBuilder.Append('[')
					.Append(channel)
					.Append(']')
					.Append(' ');
			}

			return _stringBuilder.Append(type).Append(' ');
		}
	}
}