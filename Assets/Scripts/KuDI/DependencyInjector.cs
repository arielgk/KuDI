using System;
using System.Collections.Generic;
using System.Reflection;

namespace KuDI {
    public class DependencyInjector : IServiceProvider {
        private readonly Dictionary<Type, Dependency> dependencies = new Dictionary<Type, Dependency>();
        private readonly Dictionary<Type, object> singletons = new Dictionary<Type, object>();

        public DependencyInjector(DependencyRegistrationCollection dependencyRegistrations) {
            foreach (var dependencyRegistration in dependencyRegistrations) {
                dependencies.Add(dependencyRegistration.Type, dependencyRegistration);
            }
        }

        public object GetService(Type type) {
            if (!dependencies.ContainsKey(type)) {
                throw new ArgumentException($" dependency not registered: {type.FullName}");
            }

            var dependency = dependencies[type];

            switch (dependency.ResolutionStrategy)
            {
                case Dependency.DependencyResolutionStrategy.Singleton:
                    if (!singletons.ContainsKey(type))
                    {
                        singletons.Add(type, dependency.Factory(this));
                    }
                    return singletons[type];

                case Dependency.DependencyResolutionStrategy.Transient:
                    return dependency.Factory(this);

                default:
                    throw new ArgumentException($"Invalid dependency resolution strategy: {dependency.ResolutionStrategy}");
            }
        }

        public T GetService<T>() {
            return (T) GetService(typeof(T));
        }

        public object InjectDependencies(object dependent) {
            Type type = dependent.GetType();

            while (type != null) {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance);

                foreach (var field in fields) {
                    if (field.GetCustomAttribute<InjectFieldAttribute>(false) == null) {
                        continue;
                    }

                    field.SetValue(dependent, GetService(field.FieldType));
                }

                type = type.BaseType;
            }

            return dependent;
        }
    }
}