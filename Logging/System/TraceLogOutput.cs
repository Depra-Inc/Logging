// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using System;
using System.Diagnostics;

namespace Depra.Logging.System
{
	public sealed class TraceLogOutput : ILogOutput
	{
		void ILogOutput.Write(LogLevel level, string message) =>
			Trace.WriteLine(message, category: level.ToString());

		void ILogOutput.Write(Exception exception) => Trace.WriteLine(exception);

		void ILogOutput.Flush() { }
	}
}