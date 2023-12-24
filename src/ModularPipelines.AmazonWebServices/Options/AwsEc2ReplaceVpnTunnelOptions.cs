using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("ec2", "replace-vpn-tunnel")]
public record AwsEc2ReplaceVpnTunnelOptions(
[property: CommandSwitch("--vpn-connection-id")] string VpnConnectionId,
[property: CommandSwitch("--vpn-tunnel-outside-ip-address")] string VpnTunnelOutsideIpAddress
) : AwsOptions
{
    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}