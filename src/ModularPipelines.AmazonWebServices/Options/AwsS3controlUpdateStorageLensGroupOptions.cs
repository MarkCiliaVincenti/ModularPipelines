using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("s3control", "update-storage-lens-group")]
public record AwsS3controlUpdateStorageLensGroupOptions(
[property: CommandSwitch("--name")] string Name,
[property: CommandSwitch("--account-id")] string AccountId,
[property: CommandSwitch("--storage-lens-group")] string StorageLensGroup
) : AwsOptions
{
    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}