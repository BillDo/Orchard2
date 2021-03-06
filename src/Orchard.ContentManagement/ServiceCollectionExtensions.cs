﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Orchard.ContentManagement.Cache;
using Orchard.ContentManagement.Metadata;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.Records;
using Orchard.Data.Migration;
using Orchard.Environment.Cache.Abstractions;
using YesSql.Core.Indexes;

namespace Orchard.ContentManagement
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddContentManagement(this IServiceCollection services)
        {
            services.TryAddScoped<ICacheContextProvider, ContentDefinitionCacheContextProvider>();
            services.TryAddScoped<IContentDefinitionManager, ContentDefinitionManager>();
            services.TryAddScoped<IContentManager, DefaultContentManager>();
            services.TryAddScoped<IContentManagerSession, DefaultContentManagerSession>();
            services.AddScoped<IIndexProvider, ContentItemIndexProvider>();
            services.AddScoped<IDataMigration, Migrations>();

            return services;
        }
    }
}
