﻿using System;
using Deskly.DNT.Configuration;
using Deskly.DNT.EFCore.Configuration;
using Deskly.DNT.EFCore.Context;
using Deskly.DNT.EFCore.Context.Hooks;
using Deskly.DNT.EFCore.Transaction;
using Deskly.DNT.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Deskly.DNT.EFCore
{
    /// <summary>
    ///     Nice method to create the EFCore builder
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Add the services (application specific tenant class)
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static EFCoreBuilder AddEFCore<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext, IUnitOfWork
        {
            services.AddScoped(provider => (IUnitOfWork)provider.GetRequiredService(typeof(TDbContext)));
            services.AddTransient<TransactionInterceptor>();
            services.AddScoped<IKeyValueService, KeyValueService>();
            services.AddTransient<IHook, PreUpdateRowVersionHook>();

            return new EFCoreBuilder(services, typeof(TDbContext));
        }
    }

    public class EFCoreBuilder
    {
        public EFCoreBuilder(IServiceCollection services, Type contextType)
        {
            Services = services;
            ContextType = contextType;
        }

        public IServiceCollection Services { get; }
        public Type ContextType { get; }

        public EFCoreBuilder WithTransactionOptions(Action<TransactionOptions> options)
        {
            Services.Configure(options);
            return this;
        }

        public EFCoreBuilder WithRowLevelSecurityHook<TUserId>() where TUserId : IEquatable<TUserId>
        {
            Services.AddTransient<IHook, PreInsertRowLevelSecurityHook<TUserId>>();
            return this;
        }

        public EFCoreBuilder WithTrackingHook<TUserId>() where TUserId : IEquatable<TUserId>
        {
            Services.AddTransient<IHook, PreInsertCreationTrackingHook<TUserId>>();
            Services.AddTransient<IHook, PreUpdateModificationTrackingHook<TUserId>>();
            return this;
        }

        public EFCoreBuilder WithRowIntegrityHook()
        {
            Services.AddTransient<IHook, RowIntegrityHook>();
            return this;
        }

        public EFCoreBuilder WithDeletedEntityHook()
        {
            Services.AddTransient<IHook, PreDeleteDeletedEntityHook>();
            return this;
        }

    }
}
