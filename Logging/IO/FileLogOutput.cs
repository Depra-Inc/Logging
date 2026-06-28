// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Depra.Logging.IO
{
	public sealed class FileLogOutput : ILogOutput, IDisposable
	{
		private static readonly string[] LEVEL_NAMES = { "DEBUG", "INFO", "WARNING", "ERROR" };

		private readonly StreamWriter _writer;
		private readonly bool _streaming;
		private readonly int _batchSize;
		private int _pendingCount;

		public FileLogOutput(string path, bool streaming = false, int batchSize = 64)
		{
			_writer = new StreamWriter(path, append: false) { AutoFlush = false };
			_streaming = streaming;
			_batchSize = batchSize;
		}

		void ILogOutput.Write(LogLevel level, string message)
		{
			WriteHeader(level);
			_writer.WriteLine(message);
			OnWritten();
		}

		void ILogOutput.Write(Exception exception)
		{
			WriteHeader(LogLevel.ERROR);
			_writer.Write(exception.GetType().Name);
			_writer.Write(": ");
			_writer.WriteLine(exception.Message);
			OnWritten();
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

		private void WriteHeader(LogLevel level)
		{
			Span<char> buffer = stackalloc char[20];
			var position = 0;
			var now = DateTime.Now;

			buffer[position++] = (char)('0' + now.Hour / 10);
			buffer[position++] = (char)('0' + now.Hour % 10);
			buffer[position++] = ':';
			buffer[position++] = (char)('0' + now.Minute / 10);
			buffer[position++] = (char)('0' + now.Minute % 10);
			buffer[position++] = ':';
			buffer[position++] = (char)('0' + now.Second / 10);
			buffer[position++] = (char)('0' + now.Second % 10);
			buffer[position++] = ' ';

			var levelName = LEVEL_NAMES[(int)level].AsSpan();
			levelName.CopyTo(buffer[position..]);
			position += levelName.Length;
			buffer[position++] = ' ';

			_writer.Write(buffer[..position]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OnWritten()
		{
			if (++_pendingCount >= _batchSize || _streaming)
			{
				Flush();
			}
		}
	}
}