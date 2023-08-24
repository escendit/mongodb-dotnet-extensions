// Copyright (c) Escendit Ltd. All Rights Reserved.
// Licensed under the MIT. See LICENSE.txt file in the solution root for full license information.

namespace Escendit.Orleans.Clients.MongoDb
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Host Builder Extensions.
    /// </summary>
    [DynamicallyAccessedMembers(
        DynamicallyAccessedMemberTypes.All)]
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// Add MongoDb Client Options As Default.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClientOptionsAsDefault(
            this IHostBuilder hostBuilder,
            Action<MongoDbOptions> configureOptions)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(configureOptions);
            return hostBuilder
                .ConfigureServices(services => services
                    .AddOptions<MongoDbOptions>(MongoDbOptions.DefaultKey)
                    .Configure(configureOptions));
        }

        /// <summary>
        /// Add MongoDb Client Options As Default.
        /// </summary>
        /// <param name="hostBuilder">The initial host builder.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClientOptionsAsDefault(
            this IHostBuilder hostBuilder,
            Action<OptionsBuilder<MongoDbOptions>> configureOptions)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(configureOptions);
            return hostBuilder
                .ConfigureServices(services =>
                {
                    configureOptions.Invoke(services
                        .AddOptions<MongoDbOptions>(MongoDbOptions.DefaultKey));
                });
        }

        /// <summary>
        /// Add MongoDb Client Options As Default.
        /// </summary>
        /// <param name="hostBuilder">The initial host builder.</param>
        /// <param name="configSectionPath">The config section path.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClientOptionsAsDefault(
            this IHostBuilder hostBuilder,
            string configSectionPath)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(configSectionPath);
            return hostBuilder
                .ConfigureServices(services => services
                    .AddOptions<MongoDbOptions>(MongoDbOptions.DefaultKey)
                    .BindConfiguration(configSectionPath));
        }

        /// <summary>
        /// Add MongoDb Client Options.
        /// </summary>
        /// <param name="hostBuilder">The initial host builder.</param>
        /// <param name="name">The name.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClientOptions(
            this IHostBuilder hostBuilder,
            string name,
            Action<MongoDbOptions> configureOptions)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(configureOptions);
            return hostBuilder
                .ConfigureServices(services => services
                    .AddOptions<MongoDbOptions>(name)
                    .Configure(configureOptions));
        }

        /// <summary>
        /// Add MongoDb Client Options.
        /// </summary>
        /// <param name="hostBuilder">The initial host builder.</param>
        /// <param name="name">The name.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClientOptions(
            this IHostBuilder hostBuilder,
            string name,
            Action<OptionsBuilder<MongoDbOptions>> configureOptions)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(configureOptions);
            return hostBuilder
                .ConfigureServices(services =>
                {
                    configureOptions.Invoke(services
                        .AddOptions<MongoDbOptions>(name));
                });
        }

        /// <summary>
        /// Add MongoDb Client Options.
        /// </summary>
        /// <param name="hostBuilder">The initial host builder.</param>
        /// <param name="name">The name.</param>
        /// <param name="configSectionPath">The config section path.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClientOptions(
            this IHostBuilder hostBuilder,
            string name,
            string configSectionPath)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(configSectionPath);
            return hostBuilder
                .ConfigureServices(services => services
                    .AddOptions<MongoDbOptions>(name)
                    .BindConfiguration(configSectionPath));
        }
    }
}
