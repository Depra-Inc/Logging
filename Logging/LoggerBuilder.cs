// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using System;
using System.Collections.Generic;

namespace Depra.Logging
{
	public sealed class LoggerBuilder
	{
		private LogLevel _minLevel = LogLevel.DEBUG;
		private readonly List<ILogOutput> _outputs = new();

		public LoggerBuilder WithMinLevel(LogLevel minLevel)
		{
			_minLevel = minLevel;
			return this;
		}

		public LoggerBuilder AddOutput(ILogOutput output)
		{
			_outputs.Add(output);
			return this;
		}

		public Logger Build()
		{
			var logger = new Logger(Array.Empty<string>(), _outputs)
			{
				MinLevel = _minLevel
			};

			return logger;
		}
	}
}