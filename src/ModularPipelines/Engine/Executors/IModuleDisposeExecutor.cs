﻿using ModularPipelines.Modules;

namespace ModularPipelines.Engine.Executors;

internal interface IModuleDisposeExecutor
{
    Task ExecuteAndDispose(IEnumerable<ModuleBase> modules, Func<Task> executeDelegate);
}