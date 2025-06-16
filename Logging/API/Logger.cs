// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System.Runtime.CompilerServices;

namespace Depra.Logging
{
	public sealed class Logger : ILogChannel
	{
		private readonly ILogChannel _master;

		public Logger(ILogChannel master) => _master = master;

		public Logger Channel(string channelName) => new(_master);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Log(string message, LogLevel level) => _master.Log(message, level);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Log(string message, LogLevel level, params object[] args) => _master.Log(message, level, args);
	}
}