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

        /// <summary>
        /// Add MongoDb Client As Default.
        /// </summary>
        /// <param name="hostBuilder">The initial host builder.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClientAsDefault(
            this IHostBuilder hostBuilder,
            Action<MongoDbOptions> configureOptions)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(MongoDbOptions.DefaultKey);
            ArgumentNullException.ThrowIfNull(configureOptions);
            return hostBuilder
                .AddMongoDbClientOptions(MongoDbOptions.DefaultKey, configureOptions)
                .ConfigureServices(services =>
                    services
                        .AddSingletonNamedService(MongoDbOptions.DefaultKey, MongoDbFactory.CreateMongoDb));
        }

        /// <summary>
        /// Add MongoDb Client As Default.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClientAsDefault(
            this IHostBuilder hostBuilder,
            Action<OptionsBuilder<MongoDbOptions>> configureOptions)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(MongoDbOptions.DefaultKey);
            ArgumentNullException.ThrowIfNull(configureOptions);
            return hostBuilder
                .AddMongoDbClientOptions(MongoDbOptions.DefaultKey, configureOptions)
                .ConfigureServices(services => services
                    .AddSingletonNamedService(MongoDbOptions.DefaultKey, MongoDbFactory.CreateMongoDb));
        }

        /// <summary>
        /// Add MongoDb Client As Default.
        /// </summary>
        /// <param name="hostBuilder">The initial host builder.</param>
        /// <param name="configSectionPath">The config section path.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClientAsDefault(
            this IHostBuilder hostBuilder,
            string configSectionPath)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(configSectionPath);
            return hostBuilder
                .AddMongoDbClientOptions(MongoDbOptions.DefaultKey, configSectionPath)
                .ConfigureServices(services => services
                    .AddSingletonNamedService(MongoDbOptions.DefaultKey, MongoDbFactory.CreateMongoDb));
        }

        /// <summary>
        /// Add MongoDb Client From Options As Default.
        /// </summary>
        /// <remarks>
        /// It needs provided connection options.
        /// </remarks>
        /// <param name="hostBuilder">The initial host builder.</param>
        /// <param name="optionName">The named option.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClientFromOptionAsDefault(
            this IHostBuilder hostBuilder,
            string optionName)
        {
            return hostBuilder
                .ConfigureServices(services => services
                    .AddSingletonNamedService(MongoDbOptions.DefaultKey, (serviceProvider, _) =>
                        MongoDbFactory.CreateMongoDb(serviceProvider, optionName)));
        }

        /// <summary>
        /// Add MongoDb Client.
        /// </summary>
        /// <param name="hostBuilder">The initial host builder.</param>
        /// <param name="name">The name.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClient(
            this IHostBuilder hostBuilder,
            string name,
            Action<MongoDbOptions> configureOptions)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(configureOptions);
            return hostBuilder
                .AddMongoDbClientOptions(name, configureOptions)
                .ConfigureServices(services =>
                    services
                        .AddSingletonNamedService(name, MongoDbFactory.CreateMongoDb));
        }

        /// <summary>
        /// Add MongoDb Client.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <param name="name">The name.</param>
        /// <param name="configureOptions">The configure options.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClient(
            this IHostBuilder hostBuilder,
            string name,
            Action<OptionsBuilder<MongoDbOptions>> configureOptions)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(configureOptions);
            return hostBuilder
                .AddMongoDbClientOptions(name, configureOptions)
                .ConfigureServices(services => services
                    .AddSingletonNamedService(name, MongoDbFactory.CreateMongoDb));
        }

        /// <summary>
        /// Add MongoDb Client.
        /// </summary>
        /// <param name="hostBuilder">The initial host builder.</param>
        /// <param name="name">The name.</param>
        /// <param name="configSectionPath">The config section path.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClient(
            this IHostBuilder hostBuilder,
            string name,
            string configSectionPath)
        {
            ArgumentNullException.ThrowIfNull(hostBuilder);
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(configSectionPath);
            return hostBuilder
                .AddMongoDbClientOptions(name, configSectionPath)
                .ConfigureServices(services => services
                    .AddSingletonNamedService(name, MongoDbFactory.CreateMongoDb));
        }

        /// <summary>
        /// Add MongoDb Client From Option.
        /// </summary>
        /// <remarks>
        /// It needs provided connection options.
        /// </remarks>
        /// <param name="hostBuilder">The initial host builder.</param>
        /// <param name="name">The name.</param>
        /// <param name="optionName">The named option.</param>
        /// <returns>The updated host builder.</returns>
        public static IHostBuilder AddMongoDbClientFromOption(
            this IHostBuilder hostBuilder,
            string name,
            string optionName)
        {
            return hostBuilder
                .ConfigureServices(services => services
                    .AddSingletonNamedService(name, (serviceProvider, _) =>
                        MongoDbFactory.CreateMongoDb(serviceProvider, optionName)));
        }
    }
}
