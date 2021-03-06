// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.CodeGen.Providers
{
    public interface IDomainModelDefinitionsProviderProvider
    {
        IEnumerable<IDomainModelDefinitionsProvider> DomainModelDefinitionProviders();

        IDictionary<string, IDomainModelDefinitionsProvider> DomainModelDefinitionsProvidersByProjectName();
    }
}
