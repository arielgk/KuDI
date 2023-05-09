using KuDI;
using UnityEngine;

namespace Example
{
    public class ExampleDependenciesContext : DependencyInjectionContext
    {
        [SerializeField] private ExampleDependencyMonoBehaviour exampleDependency;
        [SerializeField] private ExampleDependencyNested exampleDependencyNested;

        protected override void Setup()
        {
            dependencyRegistrations.Add(new Dependency
            {
                Type = typeof(ExampleDependencyMonoBehaviour),
                Factory = DependencyFactory.CreateFromGameObject(exampleDependency),
                ResolutionStrategy = Dependency.DependencyResolutionStrategy.Singleton
            });

            dependencyRegistrations.Add(new Dependency
            {
                Type = typeof(ExampleDependencyPlainClass),
                Factory = DependencyFactory.CreateFromClass<ExampleDependencyPlainClass>(), ResolutionStrategy =Dependency.DependencyResolutionStrategy.Transient 
            });

            dependencyRegistrations.Add(new Dependency
            {
                Type = typeof(ExampleDependencyNested),
                Factory = DependencyFactory.CreateFromPrefab(exampleDependencyNested), ResolutionStrategy = Dependency.DependencyResolutionStrategy.Singleton
            });
        }

        protected override void Configure()
        {
        }
    }
}