// Copyright (c) Escendit Ltd. All Rights Reserved.
// Licensed under the MIT. See LICENSE.txt file in the solution root for full license information.

namespace Escendit.Orleans.Clients.MongoDb
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// MongoDb Connection Options.
    /// </summary>
    [DynamicallyAccessedMembers(
        DynamicallyAccessedMemberTypes.All)]
    public class MongoDbOptions
    {
        /// <summary>
        /// Default Key for Named Default.
        /// </summary>
        public const string DefaultKey = "Default";

        /// <summary>
        /// Gets or sets the Application Name.
        /// </summary>
        /// <value>The username.</value>
        public string? ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets the Heartbeat Timeout.
        /// </summary>
        /// <value>The username.</value>
        public TimeSpan HearbeatTimeout { get; set; }

        /// <summary>
        /// Gets or sets the Heartbeat Interval.
        /// </summary>
        /// <value>The username.</value>
        public TimeSpan HearbeatInterval { get; set; }

        // Add more options here as neccesary.
    }
}
