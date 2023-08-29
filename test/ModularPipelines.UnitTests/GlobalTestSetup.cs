﻿namespace ModularPipelines.UnitTests;

[SetUpFixture]
public static class GlobalTestSetup
{
    [OneTimeSetUp]
    public static void Setup()
    {
        GlobalConfig.LogCommandInput = false;
        GlobalConfig.LogCommandOutput = false;
    }
}