﻿using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using ModularPipelines.Attributes;
using ModularPipelines.Helpers;
using ModularPipelines.Modules;

namespace ModularPipelines.Logging;

internal class ModuleLoggerProvider : IModuleLoggerProvider, IDisposable
{
    private readonly IServiceProvider _serviceProvider;

    private IModuleLogger? _logger;

    public ModuleLoggerProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IModuleLogger GetLogger(Type type) => MakeLogger(type);

    public IModuleLogger GetLogger()
    {
        if (_logger != null)
        {
            return _logger;
        }

        var stackFrames = new StackTrace().GetFrames().ToList();

        var module = GetModuleFromMarkerAttributes(stackFrames)
                     ?? stackFrames.Select(GetNonCompilerGeneratedType).FirstOrDefault(IsModule);

        if (module == null)
        {
            var getLoggerFrame = stackFrames.FirstOrDefault(sf => sf.GetMethod()?.Name == "get_Logger");

            if (getLoggerFrame == null)
            {
                return MakeLogger(GetCallingClassType(stackFrames));
            }

            var getLoggerFrameIndex = stackFrames.IndexOf(getLoggerFrame);
            var nextFrame = stackFrames[getLoggerFrameIndex + 1];
            var type = nextFrame.GetMethod()?.ReflectedType;

            if (type != null)
            {
                return MakeLogger(type);
            }

            return MakeLogger(GetCallingClassType(stackFrames));
        }

        return MakeLogger(module);
    }

    public void Dispose()
    {
        Disposer.DisposeObject(_logger);
    }

    private Type? GetModuleFromMarkerAttributes(List<StackFrame> stackFrames)
    {
        return stackFrames
            .Select(x => x.GetMethod())
            .FirstOrDefault(x => x?.GetCustomAttribute<ModuleMethodMarkerAttribute>() != null)
            ?.DeclaringType;
    }

    private IModuleLogger MakeLogger(Type module)
    {
        var loggerType = typeof(ModuleLogger<>).MakeGenericType(module);

        var logger = (IModuleLogger)_serviceProvider.GetRequiredService(loggerType);

        _logger = logger;

        return logger;
    }

    private bool IsModule(Type? type)
    {
        if (type is null)
        {
            return false;
        }

        return !type.IsAbstract && type.IsAssignableTo(typeof(ModuleBase));
    }

    private static Type GetCallingClassType(List<StackFrame> stackFrames)
    {
        var entryAssemblyFirstCallingClass = stackFrames
            .Select(GetNonCompilerGeneratedType)
            .OfType<Type>()
            .Where(t => t != typeof(ModuleLoggerProvider))
            .Where(x => x.Assembly == Assembly.GetEntryAssembly())
            .FirstOrDefault(x => x is { IsAbstract: false, IsGenericTypeDefinition: false });

        if (entryAssemblyFirstCallingClass != null)
        {
            return entryAssemblyFirstCallingClass;
        }

        return stackFrames
            .Select(GetNonCompilerGeneratedType)
            .OfType<Type>()
            .Where(t => t != typeof(ModuleLoggerProvider))
            .First(x => x is { IsAbstract: false, IsGenericTypeDefinition: false });
    }

    private static Type? GetNonCompilerGeneratedType(StackFrame stackFrame)
    {
        var type = stackFrame.GetMethod()?.ReflectedType;

        while (type?.GetCustomAttribute<CompilerGeneratedAttribute>() != null)
        {
            type = type.DeclaringType;
        }

        return type;
    }
}
