namespace Tests.AzureTable4
{
    using Microsoft.Extensions.DependencyInjection;
    using NServiceBus;
    using NServiceBus.AcceptanceTesting.Support;
    using NServiceBus.Configuration.AdvancedExtensibility;

    public static class EndpointConfigurationExtensions
    {
        public static void RegisterComponentsAndInheritanceHierarchy(this EndpointConfiguration builder, RunDescriptor runDescriptor)
        {
            builder.RegisterComponents(r => { RegisterInheritanceHierarchyOfContextOnContainer(runDescriptor, r); });
        }

        static void RegisterInheritanceHierarchyOfContextOnContainer(RunDescriptor runDescriptor, IServiceCollection r)
        {
            var type = runDescriptor.ScenarioContext.GetType();
            while (type != typeof(object))
            {
                r.AddSingleton(type, runDescriptor.ScenarioContext);
                type = type.BaseType;
            }
        }

        public static RoutingSettings ConfigureTransport(this EndpointConfiguration endpointConfiguration)
        {
            return new RoutingSettings(endpointConfiguration.GetSettings());
        }
    }
}
