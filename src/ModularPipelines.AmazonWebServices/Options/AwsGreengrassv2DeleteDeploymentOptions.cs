using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("greengrassv2", "delete-deployment")]
public record AwsGreengrassv2DeleteDeploymentOptions(
[property: CommandSwitch("--deployment-id")] string DeploymentId
) : AwsOptions
{
    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}