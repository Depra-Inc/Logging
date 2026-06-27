// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

namespace Depra.Logging
{
	/// <summary>
	/// Severity level of a log message.
	/// Controls both the visual representation and output filtering.
	/// </summary>
	public enum LogLevel
	{
		/// <summary>
		/// Verbose diagnostic information.
		/// Useful during active development; typically disabled in release builds.
		/// </summary>
		DEBUG,

		/// <summary>
		/// General informational messages about application flow.
		/// Safe to leave enabled in release builds.
		/// </summary>
		INFO,

		/// <summary>
		/// Unexpected but recoverable situations.
		/// The application continues to function, but something may behave incorrectly.
		/// </summary>
		WARNING,

		/// <summary>
		/// Failures that affect functionality and require attention.
		/// Corresponds to <see cref="UnityEngine.Debug.LogError"/> in Unity context.
		/// </summary>
		ERROR
	}
}