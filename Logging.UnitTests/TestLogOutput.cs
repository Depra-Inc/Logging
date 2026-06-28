using System;
using System.Collections.Generic;

namespace Depra.Logging.UnitTests.Helpers
{
	internal sealed class TestLogOutput : ILogOutput
	{
		public List<(LogLevel Level, string Message)> Messages { get; } = [];
		public List<Exception> Exceptions { get; } = [];
		public int FlushCount { get; private set; }

		public void Write(LogLevel level, string message) => Messages.Add((level, message));

		public void Write(Exception exception) => Exceptions.Add(exception);

		public void Flush() => FlushCount++;
	}
}
