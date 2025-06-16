// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using FluentAssertions;
using NUnit.Framework;

namespace Depra.Logging.UnitTests
{
	[TestFixture(TestOf = typeof(ILogChannel))]
	internal sealed class ConsoleLogChannelTests
	{
		private ILogChannel _logChannel;

		[SetUp]
		public void Setup() => _logChannel = new ConsoleLogChannel();

		[Test]
		[TestCase("info message", LogLevel.INFO)]
		[TestCase("error message", LogLevel.ERROR)]
		[TestCase("assert message", LogLevel.ASSERT)]
		[TestCase("warning message", LogLevel.WARNING)]
		public void Log_WithoutArgs_ThenNoExceptionIsThrown(string message, LogLevel level)
		{
			// Act:
			var act = () => _logChannel.Log(message, level);

			// Assert:
			act.Should().NotThrow();
		}

		[Test]
		[TestCase("{0} {1}", LogLevel.INFO, new object[] { 1, nameof(Log_WithArgs_ThenNoExceptionIsThrown) })]
		[TestCase("{0} {1}", LogLevel.ERROR, new object[] { 1, nameof(Log_WithArgs_ThenNoExceptionIsThrown) })]
		[TestCase("{0} {1}", LogLevel.ASSERT, new object[] { 1, nameof(Log_WithArgs_ThenNoExceptionIsThrown) })]
		[TestCase("{0} {1}", LogLevel.WARNING, new object[] { 1, nameof(Log_WithArgs_ThenNoExceptionIsThrown) })]
		public void Log_WithArgs_ThenNoExceptionIsThrown(string message, LogLevel level, object[] args)
		{
			// Act:
			var act = () => _logChannel.Log(message, level, args);

			// Assert:
			act.Should().NotThrow();
		}
	}
}