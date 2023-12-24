using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;
using ModularPipelines.Models;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("entityresolution", "create-matching-workflow")]
public record AwsEntityresolutionCreateMatchingWorkflowOptions(
[property: CommandSwitch("--input-source-config")] string[] InputSourceConfig,
[property: CommandSwitch("--output-source-config")] string[] OutputSourceConfig,
[property: CommandSwitch("--resolution-techniques")] string ResolutionTechniques,
[property: CommandSwitch("--role-arn")] string RoleArn,
[property: CommandSwitch("--workflow-name")] string WorkflowName
) : AwsOptions
{
    [CommandSwitch("--description")]
    public string? Description { get; set; }

    [CommandSwitch("--incremental-run-config")]
    public string? IncrementalRunConfig { get; set; }

    [CommandSwitch("--tags")]
    public IEnumerable<KeyValue>? Tags { get; set; }

    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}