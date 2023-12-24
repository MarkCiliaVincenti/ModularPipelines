using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("iot", "list-domain-configurations")]
public record AwsIotListDomainConfigurationsOptions : AwsOptions
{
    [CommandSwitch("--page-size")]
    public int? PageSize { get; set; }

    [CommandSwitch("--service-type")]
    public string? ServiceType { get; set; }

    [CommandSwitch("--starting-token")]
    public string? StartingToken { get; set; }

    [CommandSwitch("--max-items")]
    public int? MaxItems { get; set; }

    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}