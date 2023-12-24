using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("ec2", "create-coip-cidr")]
public record AwsEc2CreateCoipCidrOptions(
[property: CommandSwitch("--cidr")] string Cidr,
[property: CommandSwitch("--coip-pool-id")] string CoipPoolId
) : AwsOptions
{
    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}