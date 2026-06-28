using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using Depra.Logging.IO;

namespace Depra.Logging.Benchmarks;

[MemoryDiagnoser]
public class FileLogOutputBenchmarks
{
	private string _path = null!;
	private FileLogOutput _output = null!;

	[Params(false, true)]
	public bool Streaming { get; set; }

	[GlobalSetup]
	public void Setup()
	{
		_path = Path.Combine(Path.GetTempPath(), $"depra-logging-file-{Streaming}.log");
		_output = new FileLogOutput(_path, streaming: Streaming, batchSize: 64);
	}

	[IterationCleanup]
	public void IterationCleanup()
	{
		_output.Flush();
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

	[Benchmark]
	public void WriteMessage()
	{
		((ILogOutput)_output).Write(LogLevel.INFO, "benchmark message");
	}

	[Benchmark]
	public void WriteException()
	{
		((ILogOutput)_output).Write(new InvalidOperationException("benchmark failure"));
	}
}
