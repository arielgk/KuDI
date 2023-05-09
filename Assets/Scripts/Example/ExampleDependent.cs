using System.Collections;
using System.Collections.Generic;
using KuDI;
using UnityEngine;

namespace Example
{
    public class ExampleDependent : MonoBehaviour
    {
        [InjectField]
        private ExampleDependencyMonoBehaviour dependency = null;
        [InjectField]
        private ExampleDependencyPlainClass dependency2 = null;

        void Awake()
        {
            dependency.DoSomethingComplex();

            dependency2.DoSomethingAlsoComplex();
        }
    }
}