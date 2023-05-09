using System;

namespace KuDI
{
    public struct Dependency
    {
        public Type Type { get; set; }
        public DependencyFactory.DependencyCreationDelegate Factory { get; set; }
        public DependencyResolutionStrategy ResolutionStrategy { get; set; }

        public enum DependencyResolutionStrategy
        {
            Singleton,
            Transient
        }
    }
}