using Depra.Logging.UnitTests.Helpers;
using Xunit;

namespace Depra.Logging.UnitTests
{
	public sealed class LoggerBuilderTests
	{
		[Fact]
		public void Build_SetsMinLevel()
		{
			// Arrange:
			var builder = new LoggerBuilder().WithMinLevel(LogLevel.WARNING);

			// Act:
			var logger = builder.Build();

			// Assert:
			Assert.Equal(LogLevel.WARNING, logger.MinLevel);
		}

		[Fact]
		public void Build_RegistersOutputs()
		{
			// Arrange:
			var output = new TestLogOutput();
			var logger = new LoggerBuilder()
				.AddOutput(output)
				.Build();

			// Act:
			logger.Write(LogLevel.INFO, "ready");

			// Assert:
			Assert.Single(output.Messages);
			Assert.Equal((LogLevel.INFO, "ready"), output.Messages[0]);
		}

		[Fact]
		public void Build_DefaultMinLevelIsDebug()
		{
			// Arrange:
			var builder = new LoggerBuilder();

			// Act:
			var logger = builder.Build();

			// Assert:
			Assert.Equal(LogLevel.DEBUG, logger.MinLevel);
		}
	}
}
