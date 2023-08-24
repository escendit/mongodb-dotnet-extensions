// Copyright (c) Escendit Ltd. All Rights Reserved.
// Licensed under the MIT. See LICENSE.txt file in the solution root for full license information.

namespace Microsoft.Extensions.DependencyInjection;

using Escendit.Orleans.Clients.MongoDb;

/// <summary>
/// Service Collection Extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add MongoDb Client Options As Default.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configureOptions">The configure options.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddMongoDbClientOptionsAsDefault(
        this IServiceCollection services,
        Action<MongoDbOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);
        return (IServiceCollection)services
            .AddOptions<MongoDbOptions>(MongoDbOptions.DefaultKey)
            .Configure(configureOptions);
    }

    /// <summary>
    /// Add MongoDb Client Options.
    /// </summary>
    /// <param name="services">The initial service collection.</param>
    /// <param name="name">The name.</param>
    /// <param name="configureOptions">The configure options.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddMongoDbClientOptions(
        this IServiceCollection services,
        string name,
        Action<MongoDbOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configureOptions);
        return (IServiceCollection)services
            .AddOptions<MongoDbOptions>(name)
            .Configure(configureOptions);
    }
}
