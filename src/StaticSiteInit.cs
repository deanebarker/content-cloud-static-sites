﻿using EPiServer.Core.Routing;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DeaneBarker.Optimizely.StaticSites;
using DeaneBarker.Optimizely.StaticSites.Services;

namespace opti.deanebarker.net.PathServicing
{
    [InitializableModule]
    public class StaticSiteInit : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<IPartialRouter, StaticSitePartialRouter>();
            context.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            context.Services.AddSingleton<IStaticSourceLocator, StaticSourceLocator>();
            context.Services.AddSingleton<IStaticSitePathManager, StaticSitePathManager>();
            context.Services.AddSingleton<IStaticResourceRetriever, StaticResourceRetriever>();
            context.Services.AddSingleton<IStaticSiteCommandManager, StaticSiteCommandManager>();
            context.Services.AddSingleton<IStaticSiteCommandManager, StaticSiteCommandManager>();
            context.Services.AddSingleton<IMimeTypeMap, MimeTypeMap>();
            context.Services.AddSingleton<IStaticSiteLog, StaticSiteLog>();

        }

        public void Initialize(InitializationEngine context)
        {
            
        }

        public void Uninitialize(InitializationEngine context)
        {
            
        }
    }
}
