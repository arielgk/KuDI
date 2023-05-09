using UnityEngine;

namespace KuDI {
    [DefaultExecutionOrder(-1)]
    public abstract class DependencyInjectionContext : MonoBehaviour {
        private DependencyInjector dependencyInjector;
        protected DependencyRegistrationCollection dependencyRegistrations = new DependencyRegistrationCollection();

        private void Awake() {
            DontDestroyOnLoad(gameObject);
            Setup();
            dependencyInjector = new DependencyInjector(dependencyRegistrations);

            foreach (var child in GetComponentsInChildren<MonoBehaviour>(true)) {
                dependencyInjector.InjectDependencies(child);
            }

            Configure();
        }

        protected abstract void Setup();
        protected abstract void Configure();
    }
}