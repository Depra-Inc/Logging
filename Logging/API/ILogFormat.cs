// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

namespace Depra.Logging
{
	public interface ILogFormat
	{
		LogEntry Format(string message, LogLevel level, object[] args);
	}
}