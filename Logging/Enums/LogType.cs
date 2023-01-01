// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Logging.Enums
{
    /// <summary>
    ///   <para>The type of the log message in Debug.unityLogger.Log or delegate registered with Application.RegisterLogCallback.</para>
    /// </summary>
    public enum LogType
    {
        /// <summary>
        ///   <para><see cref="LogType"/> used for Errors.</para>
        /// </summary>
        Error,

        /// <summary>
        ///   <para><see cref="LogType"/> used for Asserts. (These could also indicate an error inside Unity itself.)</para>
        /// </summary>
        Assert,

        /// <summary>
        ///   <para><see cref="LogType"/> used for Warnings.</para>
        /// </summary>
        Warning,

        /// <summary>
        ///   <para><see cref="LogType"/> used for regular log messages.</para>
        /// </summary>
        Info,

        /// <summary>
        ///   <para><see cref="LogType"/> used for Exceptions.</para>
        /// </summary>
        Exception,
    }
}