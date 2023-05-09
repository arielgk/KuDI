using KuDI;
using UnityEngine;

namespace Example
{
    public class ExampleDependencyPlainClass
    {
        [InjectField] private ExampleDependencyNested dependencyNested;

        public void DoSomethingAlsoComplex()
        {
            dependencyNested.DoSomethingSimple();

            Debug.Log("Something complex can happen in plain classes too");
        }
    }
}