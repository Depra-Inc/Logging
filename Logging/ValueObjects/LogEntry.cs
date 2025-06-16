// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

namespace Depra.Logging
{
	[System.Serializable]
	public readonly struct LogEntry
	{
		public readonly string Text;
		public readonly bool NewLine;
		public readonly LogLevel Level;

		public LogEntry(string text, LogLevel level = LogLevel.INFO, bool newLine = true)
		{
			Text = text;
			Level = level;
			NewLine = newLine;
		}
	}
}