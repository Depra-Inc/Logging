using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using Depra.Logging.IO;

namespace Depra.Logging.Benchmarks;

[MemoryDiagnoser]
public class LoggerBenchmarks
{
	private string _path = null!;
	private FileLogOutput _output = null!;
	private Logger _logger = null!;
	private Logger _channelLogger = null!;

	[GlobalSetup]
	public void Setup()
	{
		_path = Path.Combine(Path.GetTempPath(), $"depra-logging-{GetType().Name}.log");
		_output = new FileLogOutput(_path, streaming: true);
		_logger = new LoggerBuilder()
			.AddOutput(new FakeOutput())
			.AddOutput(_output)
			.Build();
		_channelLogger = _logger
			.Channel("Network")
			.Channel("Session");
	}

	[GlobalCleanup]
	public void Cleanup()
	{
		_output.Dispose();
		if (File.Exists(_path))
		{
			File.Delete(_path);
		}
	}

	[Benchmark(Baseline = true)]
	public void WritePlain()
	{
		_logger.Info("request completed");
	}

	[Benchmark]
	public void WriteFormatted()
	{
		_logger.Info("user={0} elapsed={1}ms", 42, 13);
	}

	[Benchmark]
	public void WriteWithChannel()
	{
		_channelLogger.Info("connected");
	}

	private sealed class FakeOutput : ILogOutput
	{
		void ILogOutput.Write(LogLevel level, string message) { }
		void ILogOutput.Write(Exception exception) { }
		void ILogOutput.Flush() { }
	}
}