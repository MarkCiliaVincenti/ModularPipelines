using System.Diagnostics.CodeAnalysis;
using ModularPipelines.Attributes;

namespace ModularPipelines.AmazonWebServices.Options;

[ExcludeFromCodeCoverage]
[CommandPrecedingArguments("deploy", "update-deployment-group")]
public record AwsDeployUpdateDeploymentGroupOptions(
[property: CommandSwitch("--application-name")] string ApplicationName,
[property: CommandSwitch("--current-deployment-group-name")] string CurrentDeploymentGroupName
) : AwsOptions
{
    [CommandSwitch("--new-deployment-group-name")]
    public string? NewDeploymentGroupName { get; set; }

    [CommandSwitch("--deployment-config-name")]
    public string? DeploymentConfigName { get; set; }

    [CommandSwitch("--ec2-tag-filters")]
    public string[]? Ec2TagFilters { get; set; }

    [CommandSwitch("--on-premises-instance-tag-filters")]
    public string[]? OnPremisesInstanceTagFilters { get; set; }

    [CommandSwitch("--auto-scaling-groups")]
    public string[]? AutoScalingGroups { get; set; }

    [CommandSwitch("--service-role-arn")]
    public string? ServiceRoleArn { get; set; }

    [CommandSwitch("--trigger-configurations")]
    public string[]? TriggerConfigurations { get; set; }

    [CommandSwitch("--alarm-configuration")]
    public string? AlarmConfiguration { get; set; }

    [CommandSwitch("--auto-rollback-configuration")]
    public string? AutoRollbackConfiguration { get; set; }

    [CommandSwitch("--outdated-instances-strategy")]
    public string? OutdatedInstancesStrategy { get; set; }

    [CommandSwitch("--deployment-style")]
    public string? DeploymentStyle { get; set; }

    [CommandSwitch("--blue-green-deployment-configuration")]
    public string? BlueGreenDeploymentConfiguration { get; set; }

    [CommandSwitch("--load-balancer-info")]
    public string? LoadBalancerInfo { get; set; }

    [CommandSwitch("--ec2-tag-set")]
    public string? Ec2TagSet { get; set; }

    [CommandSwitch("--ecs-services")]
    public string[]? EcsServices { get; set; }

    [CommandSwitch("--on-premises-tag-set")]
    public string? OnPremisesTagSet { get; set; }

    [CommandSwitch("--generate-cli-skeleton")]
    public string? GenerateCliSkeleton { get; set; }
}