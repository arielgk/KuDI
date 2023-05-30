using KuDI;
using Game.State;
using UnityEngine;

namespace Game.Installers
{
    public class GameDIContext : DependencyInjectionContext
    {
        [SerializeField]
        private AppState appState;


        protected override void Setup()
        {
          
            
            dependencyRegistrations.Add(new Dependency { Type = typeof(IAppState), Factory = DependencyFactory.CreateFromClass<AppState>(), ResolutionStrategy = Dependency.DependencyResolutionStrategy.Singleton});
        }

        protected override void Configure()
        {
            
            
        }
    }
}