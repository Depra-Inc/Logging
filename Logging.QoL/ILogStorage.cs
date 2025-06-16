// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System.Collections.Generic;

namespace Depra.Logging.QoL
{
	public interface ILogStorage
	{
		int MaxStoredLogs { get; set; }

		IReadOnlyList<LogEntry> Entries { get; }

		void Add(LogEntry entry);

		void Remove();

		void Clear();

		string ToString();
	}
}