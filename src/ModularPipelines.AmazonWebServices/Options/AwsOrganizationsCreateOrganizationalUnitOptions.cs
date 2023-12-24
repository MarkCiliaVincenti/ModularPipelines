using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("organizations", "create-organizational-unit")]
public record AwsOrganizationsCreateOrganizationalUnitOptions(
[property: CommandSwitch("--parent-id")] string ParentId,
[property: CommandSwitch("--name")] string Name
) : AwsOptions
{
    [CommandSwitch("--tags")]
    public string[]? Tags { get; set; }

    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}