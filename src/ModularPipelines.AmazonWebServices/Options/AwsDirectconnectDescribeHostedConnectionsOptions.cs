using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("directconnect", "describe-hosted-connections")]
public record AwsDirectconnectDescribeHostedConnectionsOptions(
[property: CommandSwitch("--connection-id")] string ConnectionId
) : AwsOptions
{
    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}