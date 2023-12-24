using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("apigatewayv2", "reimport-api")]
public record AwsApigatewayv2ReimportApiOptions(
[property: CommandSwitch("--api-id")] string ApiId,
[property: CommandSwitch("--body")] string Body
) : AwsOptions
{
    [CommandSwitch("--basepath")]
    public string? Basepath { get; set; }

    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}