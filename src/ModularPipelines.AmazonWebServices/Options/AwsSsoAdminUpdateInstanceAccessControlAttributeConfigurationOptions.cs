using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("sso-admin", "update-instance-access-control-attribute-configuration")]
public record AwsSsoAdminUpdateInstanceAccessControlAttributeConfigurationOptions(
[property: CommandSwitch("--instance-access-control-attribute-configuration")] string InstanceAccessControlAttributeConfiguration,
[property: CommandSwitch("--instance-arn")] string InstanceArn
) : AwsOptions
{
    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}