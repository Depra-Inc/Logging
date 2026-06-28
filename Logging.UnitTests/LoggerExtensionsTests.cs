using Depra.Logging.UnitTests.Helpers;
using Xunit;

namespace Depra.Logging.UnitTests
{
	public sealed class LoggerExtensionsTests
	{
		private readonly Logger _logger;
		private readonly TestLogOutput _output;

		public LoggerExtensionsTests()
		{
			_output = new TestLogOutput();
			_logger = new LoggerBuilder().AddOutput(_output).Build();
		}

		[Theory]
		[InlineData(nameof(LoggerExtensions.Debug), LogLevel.DEBUG)]
		[InlineData(nameof(LoggerExtensions.Info), LogLevel.INFO)]
		[InlineData(nameof(LoggerExtensions.Warn), LogLevel.WARNING)]
		[InlineData(nameof(LoggerExtensions.Error), LogLevel.ERROR)]
		public void Extension_WritesPlainMessage(string methodName, LogLevel expectedLevel)
		{
			// Arrange: (see constructor)

			// Act:
			InvokePlain(_logger, methodName, "plain message");

			// Assert:
			Assert.Single(_output.Messages);
			Assert.Equal((expectedLevel, "plain message"), _output.Messages[0]);
		}

		[Theory]
		[InlineData(nameof(LoggerExtensions.Debug), LogLevel.DEBUG)]
		[InlineData(nameof(LoggerExtensions.Info), LogLevel.INFO)]
		[InlineData(nameof(LoggerExtensions.Warn), LogLevel.WARNING)]
		[InlineData(nameof(LoggerExtensions.Error), LogLevel.ERROR)]
		public void Extension_WritesFormattedMessage(string methodName, LogLevel expectedLevel)
		{
			// Arrange: (see constructor)

			// Act:
			InvokeFormatted(_logger, methodName, "value={0}", 7);

			// Assert:
			Assert.Single(_output.Messages);
			Assert.Equal((expectedLevel, "value=7"), _output.Messages[0]);
		}

		private static void InvokePlain(Logger logger, string methodName, string message)
		{
			switch (methodName)
			{
				case nameof(LoggerExtensions.Debug):
					logger.Debug(message);
					break;
				case nameof(LoggerExtensions.Info):
					logger.Info(message);
					break;
				case nameof(LoggerExtensions.Warn):
					logger.Warn(message);
					break;
				case nameof(LoggerExtensions.Error):
					logger.Error(message);
					break;
			}
		}

		private static void InvokeFormatted(Logger logger, string methodName, string format, params object[] args)
		{
			switch (methodName)
			{
				case nameof(LoggerExtensions.Debug):
					logger.Debug(format, args);
					break;
				case nameof(LoggerExtensions.Info):
					logger.Info(format, args);
					break;
				case nameof(LoggerExtensions.Warn):
					logger.Warn(format, args);
					break;
				case nameof(LoggerExtensions.Error):
					logger.Error(format, args);
					break;
			}
		}
	}
}
