using System;
using System.IO;
using Depra.Logging.System;
using Xunit;

namespace Depra.Logging.UnitTests
{
	public sealed class ConsoleLogOutputTests
	{
		[Fact]
		public void Write_WritesMessageToConsole()
		{
			// Arrange:
			var output = new ConsoleLogOutput();
			using var writer = new StringWriter();
			var previous = Console.Out;
			Console.SetOut(writer);

			try
			{
				// Act:
				((ILogOutput)output).Write(LogLevel.INFO, "console message");
			}
			finally
			{
				Console.SetOut(previous);
			}

			// Assert:
			Assert.Equal("console message", writer.ToString().TrimEnd());
		}

		[Fact]
		public void Write_NullException_Throws()
		{
			// Arrange:
			var output = new ConsoleLogOutput();

			// Act:
			var exception = Assert.Throws<ArgumentNullException>(() =>
				((ILogOutput)output).Write((Exception)null));

			// Assert:
			Assert.Equal("exception", exception.ParamName);
		}

		[Fact]
		public void Write_ExceptionIncludesStackTrace()
		{
			// Arrange:
			var output = new ConsoleLogOutput();
			using var writer = new StringWriter();
			var previous = Console.Out;
			Console.SetOut(writer);

			try
			{
				// Act:
				((ILogOutput)output).Write(CreateExceptionWithStackTrace());
			}
			finally
			{
				Console.SetOut(previous);
			}

			// Assert:
			var text = writer.ToString();
			Assert.Contains("Exception: traced", text);
			Assert.Contains("at Depra.Logging.UnitTests.ConsoleLogOutputTests.CreateExceptionWithStackTrace", text);
		}

		private static Exception CreateExceptionWithStackTrace()
		{
			try
			{
				throw new InvalidOperationException("traced");
			}
			catch (Exception exception)
			{
				return exception;
			}
		}
	}
}
