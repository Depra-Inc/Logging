// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using FluentAssertions;
using NUnit.Framework;

namespace Depra.Logging.UnitTests
{
	[TestFixture(TestOf = typeof(ILogChannel))]
	internal sealed class ConsoleLogChannelTests
	{
		private ILogChannel _logChannel;

		[SetUp]
		public void Setup()
		{
			_logChannel = new ConsoleLogChannel("test");
		}

		[Test]
		public void WhenLoggingInfo_AndWithoutArgs_ThenNoExceptionIsThrown()
		{
			// Arrange.
			const string MESSAGE = "123";

			// Act.
			var act = () => _logChannel.Info(MESSAGE);

			// Assert.
			act.Should().NotThrow();
		}

		[Test]
		public void WhenLoggingInfo_AndWithArgs_ThenNoExceptionIsThrown()
		{
			// Arrange.
			const string MESSAGE = "{0} {1}";
			var args = new object[] { 1, nameof(WhenLoggingInfo_AndWithArgs_ThenNoExceptionIsThrown) };

			// Act.
			var act = () => _logChannel.Info(MESSAGE, args);

			act.Should().NotThrow();
		}

		[Test]
		public void WhenLoggingWarning_AndWithoutArgs_ThenNoExceptionIsThrown()
		{
			// Arrange.
			const string MESSAGE = "123";

			// Act.
			var act = () => _logChannel.Warning(MESSAGE);

			// Assert.
			act.Should().NotThrow();
		}

		[Test]
		public void WhenLoggingWarning_AndWithArgs_ThenNoExceptionIsThrown()
		{
			// Arrange.
			const string MESSAGE = "{0} {1}";
			var args = new object[] { 1, nameof(WhenLoggingWarning_AndWithArgs_ThenNoExceptionIsThrown) };

			// Act.
			var act = () => _logChannel.Warning(MESSAGE, args);

			act.Should().NotThrow();
		}

		[Test]
		public void WhenLoggingAssert_AndWithoutArgs_ThenNoExceptionIsThrown()
		{
			// Arrange.
			const string MESSAGE = "123";

			// Act.
			var act = () => _logChannel.Assert(MESSAGE);

			// Assert.
			act.Should().NotThrow();
		}

		[Test]
		public void WhenLoggingAssert_AndWithArgs_ThenNoExceptionIsThrown()
		{
			// Arrange.
			const string MESSAGE = "{0} {1}";
			var args = new object[] { 1, nameof(WhenLoggingAssert_AndWithArgs_ThenNoExceptionIsThrown) };

			// Act.
			var act = () => _logChannel.Assert(MESSAGE, args);

			act.Should().NotThrow();
		}

		[Test]
		public void WhenLoggingException_AndWithoutArgs_ThenNoExceptionIsThrown()
		{
			// Arrange.
			const string MESSAGE = "123";

			// Act.
			var act = () => _logChannel.Error(MESSAGE);

			// Assert.
			act.Should().NotThrow();
		}

		[Test]
		public void WhenLoggingException_AndWithArgs_ThenNoExceptionIsThrown()
		{
			// Arrange.
			const string MESSAGE = "{0} {1}";
			var args = new object[] { 1, nameof(WhenLoggingException_AndWithArgs_ThenNoExceptionIsThrown) };

			// Act.
			var act = () => _logChannel.Error(MESSAGE, args);

			// Assert.
			act.Should().NotThrow();
		}
	}
}