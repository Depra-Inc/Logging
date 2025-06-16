// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;

namespace Depra.Logging
{
	public sealed class NullLogChannel : ILogChannel
	{
		void ILogChannel.Log(string message, LogLevel level) =>
			throw new NullLogChannelException();

		void ILogChannel.Log(string message, LogLevel level, params object[] args) =>
			throw new NullLogChannelException();

		private sealed class NullLogChannelException : Exception
		{
			public NullLogChannelException() : base($"{nameof(NullLogChannel)} does not support this operation.") { }
		}
	}
}