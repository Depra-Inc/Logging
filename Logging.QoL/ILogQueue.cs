// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

namespace Depra.Logging.QoL
{
	public interface ILogQueue
	{
		bool IsEmpty { get; }

		int MaxStoredEntries { get; set; }

		void Enqueue(LogEntry entry);

		bool TryDequeue(out LogEntry entry);

		void Clear();
	}
}