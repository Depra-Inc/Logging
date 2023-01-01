// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Logging.Enums
{
    /// <summary>
    /// The priority of the log messages.
    /// </summary>
    public enum Priority
    {
        // Default, simple output about game.
        Info,
        // Warnings that things might not be as expected.
        Warning,
        // Things have already failed, alert the dev.
        Error,
        // Things will not recover, bring up pop up dialog.
        FatalError,
    }
}