// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using System.Collections.Generic;
using System.Text;

namespace Depra.Logging.QoL
{
	public sealed class LogStorage : ILogStorage
	{
		private readonly List<LogEntry> _entries = new List<LogEntry>(10);
		private readonly StringBuilder _logTraceBuilder = new StringBuilder(2048);

		public LogStorage(int maxStoredLogs = -1) => MaxStoredLogs = maxStoredLogs;

		public int MaxStoredLogs { get; set; }
		public IReadOnlyList<LogEntry> Entries => _entries;

		public void Add(LogEntry entry)
		{
			_entries.Add(entry);

			var logLength = _logTraceBuilder.Length + entry.Text.Length;
			if (entry.NewLine && _logTraceBuilder.Length > 0)
			{
				logLength += Environment.NewLine.Length;
			}

			if (MaxStoredLogs > 0)
			{
				while (_entries.Count > MaxStoredLogs)
				{
					var junkLength = _entries[0].Text.Length;
					if (_entries.Count > 1 && _entries[1].NewLine)
					{
						junkLength += Environment.NewLine.Length;
					}

					junkLength = Math.Min(junkLength, _logTraceBuilder.Length);
					logLength -= junkLength;

					_logTraceBuilder.Remove(0, junkLength);
					_entries.RemoveAt(0);
				}
			}

			var capacity = _logTraceBuilder.Capacity;
			while (capacity < logLength)
			{
				capacity *= 2;
			}

			_logTraceBuilder.EnsureCapacity(capacity);
			if (entry.NewLine && _logTraceBuilder.Length > 0)
			{
				_logTraceBuilder.Append(Environment.NewLine);
			}

			_logTraceBuilder.Append(entry.Text);
		}

		public void Remove()
		{
			if (_entries.Count <= 0)
			{
				return;
			}

			var entry = _entries[^1];
			_entries.RemoveAt(_entries.Count - 1);

			var removeLength = entry.Text.Length;
			if (entry.NewLine && _entries.Count > 0)
			{
				removeLength += Environment.NewLine.Length;
			}

			_logTraceBuilder.Remove(_logTraceBuilder.Length - removeLength, removeLength);
		}

		public void Clear()
		{
			_entries.Clear();
			_logTraceBuilder.Length = 0;
		}

		public override string ToString() => _logTraceBuilder.ToString();
	}
}