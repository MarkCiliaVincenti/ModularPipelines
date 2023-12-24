using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("kinesisvideo", "describe-media-storage-configuration")]
public record AwsKinesisvideoDescribeMediaStorageConfigurationOptions : AwsOptions
{
    [CommandSwitch("--channel-name")]
    public string? ChannelName { get; set; }

    [CommandSwitch("--channel-arn")]
    public string? ChannelArn { get; set; }

    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}