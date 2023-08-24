// Copyright (c) Escendit Ltd. All Rights Reserved.
// Licensed under the MIT. See LICENSE.txt file in the solution root for full license information.

namespace Escendit.Orleans.Clients.MongoDb
{
    using MongoDB.Driver;
    using Orleans;

    /// <summary>
    /// MongoDb Factory.
    /// </summary>
    public static class MongoDbFactory
    {
        /// <summary>
        /// Create a MongoDb Client.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="name">The name.</param>
        /// <returns>A MongoDb Client.</returns>
        public static MongoClient CreateMongoDb(IServiceProvider serviceProvider, string name)
        {
            var options = serviceProvider.GetOptionsByName<MongoDbOptions>(name);
            var config = CreateMongoDbSetting(options);
            return new MongoClient(config);
        }

        private static MongoClientSettings CreateMongoDbSetting(MongoDbOptions options)
        {
            return new MongoClientSettings
            {
                ApplicationName = options.ApplicationName,
                HeartbeatInterval = options.HearbeatInterval,
                HeartbeatTimeout = options.HearbeatTimeout,

                // Add more options here as neccesary.
            };
        }
    }
}
