// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using JetBrains.Annotations;

namespace Depra.Logging
{
	public class Logger
	{
		private readonly string[] _tags;
		private readonly LogLevel _minLevel;
		private readonly StringBuilder _sb = new();
		private readonly List<ILogOutput> _outputs;

		public Logger(LogLevel minLevel) : this(minLevel, Array.Empty<string>(), new List<ILogOutput>()) { }

		internal Logger(LogLevel level, string[] tags, List<ILogOutput> outputs)
		{
			_tags = tags;
			_minLevel = level;
			_outputs = outputs;
		}

		public Logger Channel(string tag)
		{
			var next = new string[_tags.Length + 1];
			Array.Copy(_tags, next, _tags.Length);
			next[_tags.Length] = tag;

			return new Logger(_minLevel, next, _outputs);
		}

		[StringFormatMethod(nameof(format))]
		public void Write(LogLevel level, string format, params object[] args)
		{
			if (_outputs.Count == 0)
			{
				return;
			}

			_sb.Clear();
			AppendTags();
			if (args != null)
			{
				_sb.AppendFormat(format, args);
			}

			var message = _sb.ToString();
			foreach (var output in _outputs)
			{
				output.Write(level, message);
			}
		}

		public void Exception(Exception exception)
		{
			if (_outputs.Count == 0)
			{
				return;
			}

			foreach (var output in _outputs)
			{
				output.Write(exception);
			}
		}

		public void FlushAll()
		{
			foreach (var output in _outputs)
			{
				output.Flush();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AppendTags()
		{
			foreach (var tag in _tags)
			{
				_sb.Append('[').Append(tag).Append(']');
			}

			if (_tags.Length > 0)
			{
				_sb.Append(' ');
			}
		}
	}
}