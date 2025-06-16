using Depra.Logging.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Logging.UnitTests;

internal sealed class FileSystemLogChannelTests
{
	private const string FILE_PATH = "test_log.txt";
	private FileSystemLogChannel _logChannel;

	[SetUp]
	public void Setup()
	{
		_logChannel = new FileSystemLogChannel(FILE_PATH);
	}

	[TearDown]
	public void TearDown()
	{
		if (System.IO.File.Exists(FILE_PATH))
		{
			System.IO.File.Delete(FILE_PATH);
		}
	}

	[Test]
	public void Log_ShouldWriteMessageToFile()
	{
		// Arrange:
		const string MESSAGE = "Test log message";
		const LogLevel LOG_LEVEL = LogLevel.INFO;

		// Act:
		_logChannel.As<ILogChannel>().Log("4324{0}", LOG_LEVEL, "message");
		_logChannel.Log(MESSAGE, LOG_LEVEL);

		// Assert:
		var logContent = System.IO.File.ReadAllText(FILE_PATH);
		Assert.IsTrue(logContent.Contains($"{LOG_LEVEL}: {MESSAGE}"));
	}
}