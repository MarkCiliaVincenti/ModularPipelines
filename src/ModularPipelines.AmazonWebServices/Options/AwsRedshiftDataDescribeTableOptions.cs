using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("redshift-data", "describe-table")]
public record AwsRedshiftDataDescribeTableOptions(
[property: CommandSwitch("--database")] string Database
) : AwsOptions
{
    [CommandSwitch("--cluster-identifier")]
    public string? ClusterIdentifier { get; set; }

    [CommandSwitch("--connected-database")]
    public string? ConnectedDatabase { get; set; }

    [CommandSwitch("--db-user")]
    public string? DbUser { get; set; }

    [CommandSwitch("--schema")]
    public string? Schema { get; set; }

    [CommandSwitch("--secret-arn")]
    public string? SecretArn { get; set; }

    [CommandSwitch("--table")]
    public string? Table { get; set; }

    [CommandSwitch("--workgroup-name")]
    public string? WorkgroupName { get; set; }

    [CommandSwitch("--starting-token")]
    public string? StartingToken { get; set; }

    [CommandSwitch("--page-size")]
    public int? PageSize { get; set; }

    [CommandSwitch("--max-items")]
    public int? MaxItems { get; set; }

    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}