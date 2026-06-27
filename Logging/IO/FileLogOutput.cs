// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using System.IO;

namespace Depra.Logging.IO
{
	public sealed class FileLogOutput : ILogOutput, IDisposable
	{
		private readonly StreamWriter _writer;
		private readonly bool _streaming;
		private readonly int _batchSize;
		private int _pendingCount;

		public FileLogOutput(string path, bool streaming = false, int batchSize = 64)
		{
			_writer = new StreamWriter(path, append: true) { AutoFlush = false };
			_streaming = streaming;
			_batchSize = batchSize;
		}

		void ILogOutput.Write(LogLevel level, string message)
		{
			_writer.WriteLine(message);
			_pendingCount++;

			if (_streaming || _pendingCount >= _batchSize)
			{
				Flush();
			}
		}

		void ILogOutput.Write(Exception exception)
		{
			_writer.WriteLine(exception.Message);
			_pendingCount++;

			if (_streaming || _pendingCount >= _batchSize)
			{
				Flush();
			}
		}

		public void Flush()
		{
			_writer.Flush();
			_pendingCount = 0;
		}

		public void Dispose()
		{
			Flush();
			_writer.Dispose();
		}
	}
}