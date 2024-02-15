﻿using ModularPipelines.Context;
using ModularPipelines.DotNet;
using ModularPipelines.DotNet.Enums;
using ModularPipelines.DotNet.Extensions;
using ModularPipelines.DotNet.Options;
using ModularPipelines.DotNet.Parsers.NUnitTrx;
using ModularPipelines.Enums;
using ModularPipelines.Git.Extensions;
using ModularPipelines.Modules;
using ModularPipelines.TestHelpers;
using File = ModularPipelines.FileSystem.File;

namespace ModularPipelines.UnitTests;

public class TrxParsingTests : TestBase
{
    public class NUnitModule : Module<DotNetTestResult>
    {
        protected override async Task<DotNetTestResult?> ExecuteAsync(IPipelineContext context, CancellationToken cancellationToken)
        {
            var testProject = context.Git().RootDirectory
                .FindFile(x => x.Name == "ModularPipelines.TestsForTests.csproj")!;

            var trxFile = File.GetNewTemporaryFilePath();
            
            await context.DotNet().Test(new DotNetTestOptions
            {
                ProjectSolutionDirectoryDllExe = testProject,
                Framework = "net7.0",
                CommandLogging = CommandLogging.Error,
                Logger = [$"trx;logfilename={trxFile}"],
                ThrowOnNonZeroExitCode = false
            }, token: cancellationToken);

            var trxContents = await trxFile.ReadAsync(cancellationToken);

            return new TrxParser().ParseTrxContents(trxContents);
        }
    }

    [Test]
    public async Task NUnit()
    {
        var result = await RunModule<NUnitModule>();

        await Assert.That(result.Result.Value!.Successful).Is.False();
        
        await Assert.That(result.Result.Value!.UnitTestResults.Where(x => x.Outcome == TestOutcome.Failed))
            .Has.Count().EqualTo(1);
        
        await Assert.That(result.Result.Value!.UnitTestResults.Where(x => x.Outcome == TestOutcome.NotExecuted))
            .Has.Count().EqualTo(1);
        
        await Assert.That(result.Result.Value!.UnitTestResults.Where(x => x.Outcome == TestOutcome.Passed))
            .Has.Count().EqualTo(2);
    }
}