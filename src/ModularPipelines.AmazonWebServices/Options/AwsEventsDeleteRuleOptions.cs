using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("events", "delete-rule")]
public record AwsEventsDeleteRuleOptions(
[property: CommandSwitch("--name")] string Name
) : AwsOptions
{
    [CommandSwitch("--event-bus-name")]
    public string? EventBusName { get; set; }

    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}