using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("eks", "describe-nodegroup")]
public record AwsEksDescribeNodegroupOptions(
[property: CommandSwitch("--cluster-name")] string ClusterName,
[property: CommandSwitch("--nodegroup-name")] string NodegroupName
) : AwsOptions
{
    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}