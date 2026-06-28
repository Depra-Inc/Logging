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
		private static readonly StringBuilder BUILDER = new();

		private readonly Logger _root;
		private readonly string[] _tags;
		private readonly List<ILogOutput> _outputs;
		private LogLevel _minLevel = LogLevel.ERROR;

		public Logger() : this(Array.Empty<string>(), new List<ILogOutput>()) { }

		internal Logger(string[] tags, List<ILogOutput> outputs, Logger root = null)
		{
			_root = root;
			_tags = tags;
			_outputs = outputs;
		}

		public LogLevel MinLevel
		{
			get => _root?._minLevel ?? _minLevel;
			set
			{
				if (_root != null)
				{
					_root._minLevel = value;
				}
				else
				{
					_minLevel = value;
				}
			}
		}

		public Logger Channel(string tag)
		{
			var next = new string[_tags.Length + 1];
			Array.Copy(_tags, next, _tags.Length);
			next[_tags.Length] = tag;

			return new Logger(next, _outputs, _root ?? this);
		}

		[StringFormatMethod(nameof(format))]
		public void Write(LogLevel level, string format, params object[] args)
		{
			if (_outputs.Count == 0)
			{
				return;
			}

			BUILDER.Clear();
			AppendTags();
			if (args != null)
			{
				BUILDER.AppendFormat(format, args);
			}

			var message = BUILDER.ToString();
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
				BUILDER.Append('[').Append(tag).Append(']');
			}

			if (_tags.Length > 0)
			{
				BUILDER.Append(' ');
			}
		}
	}
}