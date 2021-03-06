// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Tests.TestExtension;
using EdFi.Ods.Tests._Extensions;
using NUnit.Framework;
using Test.Common;
using EdFi.TestFixture;
using System.Reflection;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models
{
    public class DomainModelDefinitionsJsonEmbeddedResourceProviderTests
    {
        public class When_getting_domain_model_definitions_from_valid_extension_assembly
            : ScenarioFor<DomainModelDefinitionsJsonEmbeddedResourceProvider>
        {
            private DomainModelDefinitions _domainModelDefinitions;

            private DomainModelDefinitionsJsonEmbeddedResourceProvider domainmodelprovider;

            protected override void Arrange()
            {
                domainmodelprovider = new DomainModelDefinitionsJsonEmbeddedResourceProvider(Given(typeof(Marker_EdFi_Ods_Test_TestExtension).Assembly));
            }

            protected override void Act()
            {
                _domainModelDefinitions = domainmodelprovider.GetDomainModelDefinitions();
            }

            [Assert]
            public void Should_return_domain_model_definitions()
            {
                Assert.That(_domainModelDefinitions, Is.Not.Null);
                Assert.That(_domainModelDefinitions.SchemaDefinition.LogicalName, Is.EqualTo("Sample"));
            }
        }

        public class When_getting_domain_model_definitions_from_non_extension_assembly
            : ScenarioFor<
                DomainModelDefinitionsJsonEmbeddedResourceProvider>
        {
            private DomainModelDefinitions _domainModelDefinitions;
            private DomainModelDefinitionsJsonEmbeddedResourceProvider domainmodelprovider;
            protected override void Arrange()
            {
                domainmodelprovider = new DomainModelDefinitionsJsonEmbeddedResourceProvider(Given(typeof(When_getting_domain_model_definitions_from_non_extension_assembly).Assembly));
            }

            protected override void Act()
            {
                _domainModelDefinitions = domainmodelprovider.GetDomainModelDefinitions();
            }

            [Assert]
            public void Should_throw_exception()
            {
                Assert.That(ActualException, Is.Not.Null);

                ActualException.MessageShouldContain(
                    The<Assembly>()
                        .FullName);

                ActualException.MessageShouldContain("did not contain the expected embedded resource");
            }
        }
    }
}