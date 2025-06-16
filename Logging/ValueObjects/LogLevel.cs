// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

namespace Depra.Logging
{
    /// <summary>
    /// The priority of the log messages.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// <para><see cref="LogLevel"/> used for regular log messages.</para>
        /// </summary>
        INFO,
        
        /// <summary>
        /// <para><see cref="LogLevel"/> used for Warnings.</para>
        /// </summary>
        WARNING,
        
        /// <summary>
        /// <see cref="LogLevel"/> used for Asserts.
        /// <remarks>These could also indicate an error inside Unity itself.</remarks>
        /// </summary>
        ASSERT,
        
        /// <summary>
        /// <see cref="LogLevel"/> used for Errors.
        /// </summary>
        ERROR
    }
}