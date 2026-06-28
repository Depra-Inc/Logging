// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Depra.Logging.IO
{
	public sealed class FileLogOutput : ILogOutput, IDisposable
	{
		private static readonly string[] LEVEL_NAMES = { "DEBUG", "INFO", "WARNING", "ERROR" };

		private readonly StreamWriter _writer;
		private readonly StringBuilder _sb = new();
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
			_sb.Clear();
			AppendHeader(level);
			_sb.Append(message);
			_writer.WriteLine(_sb.ToString());

			_pendingCount++;
			if (_streaming || _pendingCount >= _batchSize)
			{
				Flush();
			}
		}

		void ILogOutput.Write(Exception exception)
		{
			_sb.Clear();
			AppendHeader(LogLevel.ERROR);
			_sb.Append(exception.GetType().Name);
			_sb.Append(": ");
			_sb.Append(exception.Message);
			_writer.WriteLine(_sb.ToString());

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

		private void AppendHeader(LogLevel level)
		{
			var now = DateTime.Now;
			AppendTwoDigits(now.Hour);
			_sb.Append(':');
			AppendTwoDigits(now.Minute);
			_sb.Append(':');
			AppendTwoDigits(now.Second);
			_sb.Append(' ');
			_sb.Append(LEVEL_NAMES[(int)level]);
			_sb.Append(' ');
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AppendTwoDigits(int value)
		{
			_sb.Append((char)('0' + value / 10));
			_sb.Append((char)('0' + value % 10));
		}
	}
}