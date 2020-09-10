﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Admin.DataAccess.Utils
{
    public class DefaultApplicationCreator : IDefaultApplicationCreator
    {
        private readonly IConfigValueProvider _configValueProvider;
        private readonly IUsersContextFactory _usersContextFactory;

        public DefaultApplicationCreator(
            IUsersContextFactory usersContextFactory,
            IConfigValueProvider configValueProvider)
        {
            _usersContextFactory = Preconditions.ThrowIfNull(usersContextFactory, nameof(usersContextFactory));
            _configValueProvider = Preconditions.ThrowIfNull(configValueProvider, nameof(configValueProvider));
        }

        /// <summary>
        /// Look for an existing default application for this particular sandbox type.  Also, make sure that all
        /// Local Education Agency associations are updated.
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="sandboxType"></param>
        /// <returns></returns>
        public Application FindOrCreateUpdatedDefaultSandboxApplication(int vendorId, SandboxType sandboxType)
        {
            using (var context = _usersContextFactory.CreateContext())
            {
                var vendor = context.Vendors
                                    .Where(x => x.VendorId == vendorId)
                                    .Include(x => x.Applications.Select<Application, ICollection<ApplicationEducationOrganization>>(a => a.ApplicationEducationOrganizations))
                                    .Single();

                var defaultAppName = _configValueProvider.GetValue("DefaultClaimSetName");
                var applicationName = defaultAppName + " " + sandboxType;
                var application = GetApplication(context, vendor, applicationName);

                context.SaveChanges();
                return application;
            }
        }

        public void AddLeaIdsToApplication(IList<int> localEducationAgencyIds, int applicationId)
        {
            using (var context = _usersContextFactory.CreateContext())
            {
                var application = context.Applications.SingleOrDefault(a => a.ApplicationId == applicationId);

                if (application != null)
                {
                    foreach (var leaId in localEducationAgencyIds)
                    {
                        if (application.ApplicationEducationOrganizations.All(x => x.EducationOrganizationId != leaId))
                        {
                            var applicationEducationOrganization = application.CreateApplicationEducationOrganization(leaId);
                            application.ApplicationEducationOrganizations.Add(applicationEducationOrganization);
                            context.ApplicationEducationOrganizations.AddOrUpdate(applicationEducationOrganization);
                        }
                    }

                    context.SaveChanges();
                }
            }
        }

        private Application GetApplication(IUsersContext context, Vendor vendor, string applicationName)
        {
            if (vendor.Applications.Any(x => x.ApplicationName == applicationName))
            {
                return vendor.Applications.Single(x => x.ApplicationName == applicationName);
            }

            var defaultClaimSetName = _configValueProvider.GetValue("DefaultClaimSetName");
            var newApplication = vendor.CreateApplication(applicationName, defaultClaimSetName);

            newApplication.OperationalContextUri = _configValueProvider.GetValue("DefaultOperationalContextUri");
            context.Applications.Add(newApplication);
            return newApplication;
        }
    }
}
#endif