using System;
using System.IO;
using System.Text.RegularExpressions;
using Depra.Logging.IO;
using Xunit;

namespace Depra.Logging.UnitTests
{
	public sealed class FileLogOutputTests : IDisposable
	{
		private readonly string _path = Path.GetTempFileName();

		public void Dispose()
		{
			if (File.Exists(_path))
			{
				File.Delete(_path);
			}
		}

		[Fact]
		public void Write_WritesMessageWithHeader()
		{
			// Arrange:
			// Act:
			using (var output = new FileLogOutput(_path, streaming: true))
			{
				((ILogOutput)output).Write(LogLevel.INFO, "started");
			}

			// Assert:
			var line = File.ReadAllText(_path).TrimEnd();
			Assert.Matches(new Regex(@"^\d{2}:\d{2}:\d{2} INFO started$"), line);
		}

		[Fact]
		public void Write_ExceptionWritesErrorHeader()
		{
			// Arrange:
			var exception = new InvalidOperationException("failed");

			// Act:
			using (var output = new FileLogOutput(_path, streaming: true))
			{
				((ILogOutput)output).Write(exception);
			}

			// Assert:
			var line = File.ReadAllText(_path).TrimEnd();
			Assert.Matches(new Regex(@"^\d{2}:\d{2}:\d{2} ERROR InvalidOperationException: failed$"), line);
		}

		[Fact]
		public void Write_BatchesUntilThreshold()
		{
			// Arrange:
			// Act:
			using (var output = new FileLogOutput(_path, streaming: false, batchSize: 2))
			{
				((ILogOutput)output).Write(LogLevel.DEBUG, "first");
				((ILogOutput)output).Write(LogLevel.DEBUG, "second");
			}

			// Assert:
			Assert.Equal(2, File.ReadAllLines(_path).Length);
		}

		[Fact]
		public void Flush_PersistsPendingLines()
		{
			// Arrange:
			var output = new FileLogOutput(_path, streaming: false, batchSize: 64);

			try
			{
				// Act:
				((ILogOutput)output).Write(LogLevel.WARNING, "pending");
				output.Flush();
			}
			finally
			{
				output.Dispose();
			}

			// Assert:
			Assert.EndsWith("WARNING pending", File.ReadAllText(_path).TrimEnd());
		}

		[Fact]
		public void Dispose_FlushesRemainingLines()
		{
			// Arrange:
			// Act:
			using (var output = new FileLogOutput(_path, streaming: false, batchSize: 64))
			{
				((ILogOutput)output).Write(LogLevel.ERROR, "on dispose");
			}

			// Assert:
			Assert.EndsWith("ERROR on dispose", File.ReadAllText(_path).TrimEnd());
		}
	}
}
