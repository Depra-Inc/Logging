using System;
using Depra.Logging.UnitTests.Helpers;
using Xunit;

namespace Depra.Logging.UnitTests
{
	public sealed class LoggerTests
	{
		[Fact]
		public void Write_WithNoOutputs_DoesNothing()
		{
			// Arrange:
			var logger = new Logger();

			// Act:
			var exception = Record.Exception(() => logger.Write(LogLevel.INFO, "message"));

			// Assert:
			Assert.Null(exception);
		}

		[Fact]
		public void Write_WritesMessageToAllOutputs()
		{
			// Arrange:
			var first = new TestLogOutput();
			var second = new TestLogOutput();
			var logger = new LoggerBuilder()
				.AddOutput(first)
				.AddOutput(second)
				.Build();

			// Act:
			logger.Write(LogLevel.INFO, "hello");

			// Assert:
			Assert.Single(first.Messages);
			Assert.Equal((LogLevel.INFO, "hello"), first.Messages[0]);
			Assert.Single(second.Messages);
			Assert.Equal((LogLevel.INFO, "hello"), second.Messages[0]);
		}

		[Fact]
		public void Write_WithFormatArgs_FormatsMessage()
		{
			// Arrange:
			var output = new TestLogOutput();
			var logger = new LoggerBuilder().AddOutput(output).Build();

			// Act:
			logger.Write(LogLevel.WARNING, "value={0}", 42);

			// Assert:
			Assert.Single(output.Messages);
			Assert.Equal((LogLevel.WARNING, "value=42"), output.Messages[0]);
		}

		[Fact]
		public void Channel_PrependsTagsToMessage()
		{
			// Arrange:
			var output = new TestLogOutput();
			var logger = new LoggerBuilder()
				.AddOutput(output)
				.Build()
				.Channel("Network")
				.Channel("Auth");

			// Act:
			logger.Write(LogLevel.ERROR, "failed");

			// Assert:
			Assert.Single(output.Messages);
			Assert.Equal((LogLevel.ERROR, "[Network][Auth] failed"), output.Messages[0]);
		}

		[Fact]
		public void Channel_MinLevelIsSharedWithRoot()
		{
			// Arrange:
			var root = new LoggerBuilder().Build();
			var channel = root.Channel("Child");

			// Act:
			root.MinLevel = LogLevel.DEBUG;

			// Assert:
			Assert.Equal(LogLevel.DEBUG, root.MinLevel);
			Assert.Equal(LogLevel.DEBUG, channel.MinLevel);

			// Act:
			channel.MinLevel = LogLevel.WARNING;

			// Assert:
			Assert.Equal(LogLevel.WARNING, root.MinLevel);
			Assert.Equal(LogLevel.WARNING, channel.MinLevel);
		}

		[Fact]
		public void Exception_WritesToAllOutputs()
		{
			// Arrange:
			var output = new TestLogOutput();
			var logger = new LoggerBuilder().AddOutput(output).Build();
			var exception = new InvalidOperationException("boom");

			// Act:
			logger.Exception(exception);

			// Assert:
			Assert.Single(output.Exceptions);
			Assert.Same(exception, output.Exceptions[0]);
		}

		[Fact]
		public void FlushAll_FlushesEveryOutput()
		{
			// Arrange:
			var first = new TestLogOutput();
			var second = new TestLogOutput();
			var logger = new LoggerBuilder()
				.AddOutput(first)
				.AddOutput(second)
				.Build();

			// Act:
			logger.FlushAll();

			// Assert:
			Assert.Equal(1, first.FlushCount);
			Assert.Equal(1, second.FlushCount);
		}
	}
}
