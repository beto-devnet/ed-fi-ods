// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Infrastructure.Pipelines;

namespace EdFi.Ods.Common.Infrastructure.Pipelines.Delete
{
    public class DeletePipeline : PipelineBase<DeleteContext, DeleteResult>
    {
        public DeletePipeline(IStep<DeleteContext, DeleteResult>[] steps)
            : base(steps) { }
    }
}
