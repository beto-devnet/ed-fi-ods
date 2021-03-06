// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using EdFi.Common;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Common;
using log4net;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class AssemblyDataProvider : IAssemblyDataProvider
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AssembliesProvider));

        private readonly AssemblyDataHelper _assemblyDataHelper;
        private readonly ICodeRepositoryProvider _codeRepositoryProvider;
        private readonly IExtensionPluginsProvider _extensionPluginsProviderProvider;

        public const string AssemblyMetadataSearchString = "assemblyMetadata.json";

        public AssemblyDataProvider(
            AssemblyDataHelper assemblyDataHelper,
            ICodeRepositoryProvider codeRepositoryProvider,
            IExtensionPluginsProvider extensionPluginsProvider)
        {
            _assemblyDataHelper = Preconditions.ThrowIfNull(assemblyDataHelper, nameof(assemblyDataHelper));
            _codeRepositoryProvider = Preconditions.ThrowIfNull(codeRepositoryProvider, nameof(codeRepositoryProvider));
            _extensionPluginsProviderProvider = Preconditions.ThrowIfNull(extensionPluginsProvider, nameof(extensionPluginsProvider));
        }

        public IEnumerable<AssemblyData> Get()
        {
            var paths = new List<string>
            {
                _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                    CodeRepositoryConventions.Ods,
                    CodeRepositoryConventions.Application),
                _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                    CodeRepositoryConventions.Implementation,
                    CodeRepositoryConventions.Application)
            };

            paths.AddRange(_extensionPluginsProviderProvider.GetExtensionLocationPlugins());

            var assemblyData = paths.Where(Directory.Exists)
                .SelectMany(
                    x =>
                        Directory.GetFiles(
                            x,
                            AssemblyMetadataSearchString,
                            SearchOption.AllDirectories))
                .Select(_assemblyDataHelper.CreateAssemblyData)
                .ToList();

            assemblyData.ForEach(x => _logger.Debug($"Found file matching '{AssemblyMetadataSearchString}' at '{x.Path}'"));

            return assemblyData;
        }
    }
}
