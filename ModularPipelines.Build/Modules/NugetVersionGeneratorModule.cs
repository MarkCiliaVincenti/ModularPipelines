﻿using ModularPipelines.Context;
using ModularPipelines.Models;
using ModularPipelines.Modules;
// ReSharper disable HeuristicUnreachableCode
#pragma warning disable CS0162

namespace ModularPipelines.Build.Modules;

public class NugetVersionGeneratorModule : Module<string>
{
    protected override async Task<ModuleResult<string>?> ExecuteAsync(IModuleContext context, CancellationToken cancellationToken)
    {
        await Task.Yield();

        if (GitVersionInformation.BranchName == "main")
        {
            return $"{GitVersionInformation.Major}.{GitVersionInformation.Minor}.{GitVersionInformation.Patch}";
        }
        
        return $"{GitVersionInformation.Major}.{GitVersionInformation.Minor}.{GitVersionInformation.Patch}-{GitVersionInformation.PreReleaseLabel}-{GitVersionInformation.CommitsSinceVersionSource}";
    }
}