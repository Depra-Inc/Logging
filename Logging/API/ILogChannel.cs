﻿// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;

namespace Depra.Logging
{
	public interface ILogChannel
	{
		void Log(Exception exception);
		void Log(string message, LogLevel level);
		void Log(string message, LogLevel level, params object[] args);
	}
}