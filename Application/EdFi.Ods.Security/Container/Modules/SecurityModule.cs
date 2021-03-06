// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using Autofac;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Authorization.Filtering;
using EdFi.Ods.Security.Authorization.Pipeline;
using EdFi.Ods.Security.AuthorizationStrategies;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Security.Claims;
using EdFi.Ods.Security.Utilities;

namespace EdFi.Ods.Security.Container.Modules
{
    public class SecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorizationContextProvider>()
                .As<IAuthorizationContextProvider>()
                .SingleInstance();

            builder.RegisterType<AuthorizationFilterContextProvider>()
                .As<IAuthorizationFilterContextProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EdFiAuthorizationProvider>()
                .As<IEdFiAuthorizationProvider>()
                .SingleInstance();

            builder.RegisterType<AuthorizationSegmentsVerifier>()
                .As<IAuthorizationSegmentsVerifier>()
                .SingleInstance();

            builder.RegisterType<ResourceAuthorizationMetadataProvider>()
                .As<IResourceAuthorizationMetadataProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthorizationSegmentsToFiltersConverter>()
                .As<IAuthorizationSegmentsToFiltersConverter>()
                .SingleInstance();

            var assembly = typeof(Marker_EdFi_Ods_Security).Assembly;

            var strategyTypes = assembly.GetTypes()
                .Where(t => typeof(IEdFiAuthorizationStrategy).IsAssignableFrom(t) && !t.IsAbstract).ToList();

            foreach (Type strategyType in strategyTypes)
            {
                // Handle relationship based authorization strategies explicitly
                if (strategyType.IsGenericType)
                {
                    // Property injection is used for RelationshipsAuthorizationStrategyBase<>
                    builder.RegisterType(strategyType.MakeGenericType(typeof(RelationshipsAuthorizationContextData)))
                        .PropertiesAutowired()
                        .As<IEdFiAuthorizationStrategy>()
                        .SingleInstance();
                }
                else
                {
                    builder.RegisterType(strategyType)
                        .As<IEdFiAuthorizationStrategy>()
                        .SingleInstance();
                }
            }

            builder.RegisterAssemblyTypes(typeof(Marker_EdFi_Ods_Security).Assembly)
                .Where(t => typeof(INHibernateFilterConfigurator).IsAssignableFrom(t))
                .As<INHibernateFilterConfigurator>()
                .SingleInstance();

            builder.RegisterType<AuthorizationViewsProvider>()
                .As<IAuthorizationViewsProvider>()
                .SingleInstance();

            builder.RegisterType<ClaimsIdentityProvider>()
                .As<IClaimsIdentityProvider>()
                .SingleInstance();

            builder.RegisterType<ResourceClaimUriProvider>()
                .As<IResourceClaimUriProvider>()
                .SingleInstance();

            builder.RegisterType<EducationOrganizationHierarchyProvider>()
                .As<IEducationOrganizationHierarchyProvider>()
                .SingleInstance();

            // RelationshipsAuthorizationContextDataProviderFactory
            builder.RegisterType(
                    typeof(RelationshipsAuthorizationContextDataProviderFactory<>).MakeGenericType(
                        GetRelationshipBasedAuthorizationStrategyContextDataType())).As(
                    typeof(IRelationshipsAuthorizationContextDataProviderFactory<>).MakeGenericType(
                        GetRelationshipBasedAuthorizationStrategyContextDataType()))
                .SingleInstance();

            // ConcreteEducationOrganizationIdAuthorizationContextDataTransformer
            builder.RegisterType(
                    typeof(ConcreteEducationOrganizationIdAuthorizationContextDataTransformer<>).MakeGenericType(
                        GetRelationshipBasedAuthorizationStrategyContextDataType())).As(
                    typeof(IConcreteEducationOrganizationIdAuthorizationContextDataTransformer<>).MakeGenericType(
                        GetRelationshipBasedAuthorizationStrategyContextDataType()))
                .SingleInstance();

            Type GetRelationshipBasedAuthorizationStrategyContextDataType() => typeof(RelationshipsAuthorizationContextData);

            builder.RegisterGeneric(typeof(SetAuthorizationContextForGet<,,,>))
                .AsSelf()
                .SingleInstance();

            builder.RegisterGeneric(typeof(SetAuthorizationContextForPut<,,,>))
                .AsSelf()
                .SingleInstance();

            builder.RegisterGeneric(typeof(SetAuthorizationContextForDelete<,,,>))
                .AsSelf()
                .SingleInstance();

            builder.RegisterGeneric(typeof(SetAuthorizationContextForPost<,,,>))
                .AsSelf()
                .SingleInstance();
        }
    }
}
