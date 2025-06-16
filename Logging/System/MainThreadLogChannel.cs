// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Depra.Logging
{
	public sealed class MainThreadLogChannel : ILogChannel
	{
		private static readonly int MAIN_THREAD_ID;
		private static readonly SynchronizationContext CONTEXT;

		static MainThreadLogChannel()
		{
			CONTEXT = SynchronizationContext.Current;
			MAIN_THREAD_ID = Thread.CurrentThread.ManagedThreadId;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Call(SendOrPostCallback callback)
		{
			if (Thread.CurrentThread.ManagedThreadId != MAIN_THREAD_ID)
			{
				CONTEXT.Post(callback, null);
				return;
			}

			callback(null);
		}

		private readonly ILogChannel _channel;

		public MainThreadLogChannel(ILogChannel channel) => _channel = channel;

		void ILogChannel.Log(Exception exception)
		{
			Call(Handle);

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			void Handle(object state) => _channel.Log(exception);
		}

		void ILogChannel.Log(string message, LogLevel level)
		{
			Call(Handle);

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			void Handle(object state) => _channel.Log(message, level);
		}

		void ILogChannel.Log(string message, LogLevel level, params object[] args)
		{
			Call(Handle);

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			void Handle(object state) => _channel.Log(message, level, args);
		}
	}
}