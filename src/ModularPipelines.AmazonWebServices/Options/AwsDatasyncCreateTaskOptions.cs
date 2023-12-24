using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("datasync", "create-task")]
public record AwsDatasyncCreateTaskOptions(
[property: CommandSwitch("--source-location-arn")] string SourceLocationArn,
[property: CommandSwitch("--destination-location-arn")] string DestinationLocationArn
) : AwsOptions
{
    [CommandSwitch("--cloud-watch-log-group-arn")]
    public string? CloudWatchLogGroupArn { get; set; }

    [CommandSwitch("--name")]
    public string? Name { get; set; }

    [CommandSwitch("--options")]
    public string? Options { get; set; }

    [CommandSwitch("--excludes")]
    public string[]? Excludes { get; set; }

    [CommandSwitch("--schedule")]
    public string? Schedule { get; set; }

    [CommandSwitch("--tags")]
    public string[]? Tags { get; set; }

    [CommandSwitch("--includes")]
    public string[]? Includes { get; set; }

    [CommandSwitch("--task-report-config")]
    public string? TaskReportConfig { get; set; }

    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}