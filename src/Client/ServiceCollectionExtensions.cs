// Copyright (c) Escendit Ltd. All Rights Reserved.
// Licensed under the MIT. See LICENSE.txt file in the solution root for full license information.

namespace Escendit.Orleans.Clients.MongoDb;

using System.Diagnostics.CodeAnalysis;
using global::Orleans.Runtime;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

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
        services
            .AddOptions<MongoDbOptions>(MongoDbOptions.DefaultKey)
            .Configure(configureOptions);
        return services;
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
        services
            .AddOptions<MongoDbOptions>(name)
            .Configure(configureOptions);
        return services;
    }

    /// <summary>
    /// Add MongoDb Client as Default.
    /// </summary>
    /// <param name="services">The initial service collection.</param>
    /// <param name="configureOptions">The configure options.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddMongoDbClientAsDefault(
        this IServiceCollection services,
        Action<MongoDbOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);
        return services
            .AddMongoDbClientOptions(MongoDbOptions.DefaultKey, configureOptions)
            .AddSingletonNamedService<IMongoClient>(MongoDbOptions.DefaultKey, MongoDbFactory.CreateMongoDb);
    }

    /// <summary>
    /// Add MongoDb Client As Default from Options.
    /// </summary>
    /// <param name="services">The initial service collection.</param>
    /// <param name="name">The name.</param>
    /// <param name="configureOptions">The configure options.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddMongoDbClient(
        this IServiceCollection services,
        string name,
        Action<MongoDbOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(configureOptions);
        return services
            .AddMongoDbClientOptions(name, configureOptions)
            .AddSingletonNamedService<IMongoClient>(name, MongoDbFactory.CreateMongoDb);
    }
}
