// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using System;

namespace Depra.Logging
{
	public interface ILogOutput
	{
		void Write(LogLevel level, string message);
		void Write(Exception exception);

		void Flush();
	}
}