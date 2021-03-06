// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.OpenApiMetadata.Strageties.ResourceStrategies
{
    [TestFixture]
    public class OpenApiMetadataUiDescriptorOnlyStrategyTests
    {
        protected static IResourceModelProvider ResourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        protected static ISchemaNameMapProvider SchemaNameMapProvider = DomainModelDefinitionsProviderHelper.SchemaNameMapProvider;

        public class When_filtering_resources_with_descriptor_only_strategy : TestFixtureBase
        {
            private IEnumerable<Resource> _actualDescriptors;
            private OpenApiMetadataUiDescriptorOnlyStrategy _openApiMetadataUiDescriptorOnlyStrategy;
            private string[] _expectedDescriptors;

            protected override void Arrange()
            {
                _expectedDescriptors = ResourceModelProvider.GetResourceModel()
                    .GetAllResources()
                    .Where(x => x.IsDescriptorEntity())
                    .Select(x => x.Name)
                    .ToArray();

                _openApiMetadataUiDescriptorOnlyStrategy = new OpenApiMetadataUiDescriptorOnlyStrategy();
            }

            protected override void Act()
            {
                _actualDescriptors = _openApiMetadataUiDescriptorOnlyStrategy.GetFilteredResources(
                        DomainModelDefinitionsProviderHelper
                            .DefaultopenApiMetadataDocumentContext)
                    .Select(x => x.Resource);
            }

            [Assert]
            public void Should_contain_only_descriptors()
            {
                Assert.That(
                    _actualDescriptors.Select(x => x.Name)
                        .ToArray(),
                    Is.EquivalentTo(_expectedDescriptors));
            }
        }
    }
}