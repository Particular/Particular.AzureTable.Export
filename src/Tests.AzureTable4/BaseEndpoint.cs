namespace Tests.AzureTable4
{
    using System;
    using System.Threading.Tasks;
    using NServiceBus;
    using NServiceBus.AcceptanceTesting.Support;

    public class BaseEndpoint : IEndpointSetupTemplate
    {
        public virtual async Task<EndpointConfiguration> GetConfiguration(
            RunDescriptor runDescriptor,
            EndpointCustomizationConfiguration endpointCustomizationConfiguration,
#pragma warning disable PS0013 // Add a CancellationToken parameter type argument
            Func<EndpointConfiguration, Task> configurationBuilderCustomization)
#pragma warning restore PS0013
        {
            var endpointConfiguration = new EndpointConfiguration(endpointCustomizationConfiguration.EndpointName);

            endpointConfiguration.Recoverability()
                .Delayed(delayed => delayed.NumberOfRetries(0))
                .Immediate(immediate => immediate.NumberOfRetries(0));

            endpointConfiguration.UseTransport(new AcceptanceTestingTransport());

            endpointConfiguration.RegisterComponentsAndInheritanceHierarchy(runDescriptor);

            await configurationBuilderCustomization(endpointConfiguration);

            return endpointConfiguration;
        }
    }
}
