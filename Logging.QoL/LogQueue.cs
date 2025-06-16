// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System.Collections.Concurrent;

namespace Depra.Logging.QoL
{
	public sealed class LogQueue : ILogQueue
	{
		private readonly ConcurrentQueue<LogEntry> _queuedLogs = new ConcurrentQueue<LogEntry>();

		public int MaxStoredEntries { get; set; }

		public bool IsEmpty => _queuedLogs.IsEmpty;

		public void Enqueue(LogEntry entry)
		{
			_queuedLogs.Enqueue(entry);
			if (MaxStoredEntries > 0 && _queuedLogs.Count > MaxStoredEntries)
			{
				_queuedLogs.TryDequeue(out _);
			}
		}

		public bool TryDequeue(out LogEntry entry) => _queuedLogs.TryDequeue(out entry);

		public void Clear()
		{
			while (TryDequeue(out _)) { }
		}
	}
}