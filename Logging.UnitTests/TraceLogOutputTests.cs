using System;
using System.Collections.Generic;
using System.Diagnostics;
using Depra.Logging.System;
using Xunit;

namespace Depra.Logging.UnitTests
{
	public sealed class TraceLogOutputTests : IDisposable
	{
		private readonly TestTraceListener _listener;

		public TraceLogOutputTests()
		{
			_listener = new TestTraceListener();
			Trace.Listeners.Add(_listener);
		}

		public void Dispose()
		{
			Trace.Listeners.Remove(_listener);
			_listener.Dispose();
		}

		[Fact]
		public void Write_WritesMessageWithCategory()
		{
			// Arrange:
			var output = new TraceLogOutput();

			// Act:
			((ILogOutput)output).Write(LogLevel.WARNING, "trace message");

			// Assert:
			Assert.Single(_listener.Entries);
			Assert.Equal(("WARNING", "trace message"), _listener.Entries[0]);
		}

		[Fact]
		public void Write_ExceptionIsTraced()
		{
			// Arrange:
			var output = new TraceLogOutput();
			var exception = new InvalidOperationException("trace error");

			// Act:
			((ILogOutput)output).Write(exception);

			// Assert:
			Assert.Single(_listener.Exceptions);
			Assert.Same(exception, _listener.Exceptions[0]);
		}

		private sealed class TestTraceListener : TraceListener
		{
			public List<(string Category, string Message)> Entries { get; } = [];
			public List<Exception> Exceptions { get; } = [];

			public override void Write(string message) { }

			public override void WriteLine(string message) { }

			public override void WriteLine(string message, string category) =>
				Entries.Add((category, message));

			public override void WriteLine(object o) =>
				Exceptions.Add((Exception)o);
		}
	}
}
