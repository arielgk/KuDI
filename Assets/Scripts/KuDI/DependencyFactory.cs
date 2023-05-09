using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace KuDI {
    public static class DependencyFactory {
        public delegate object DependencyCreationDelegate(DependencyInjector dependencies);

        public static DependencyCreationDelegate CreateFromClass<T>() where T : class, new() {
            return (dependencies) => {
                var type = typeof(T);
                var obj = FormatterServices.GetUninitializedObject(type);
                dependencies.InjectDependencies(obj);
                type.GetConstructor(Type.EmptyTypes).Invoke(obj, null);
                return (T) obj;
            };
        }

        public static DependencyCreationDelegate CreateFromPrefab<T>(T prefab) where T : MonoBehaviour {
            return (dependencies) => {
                bool wasActive = prefab.gameObject.activeSelf;
                prefab.gameObject.SetActive(false);
                var instance = GameObject.Instantiate(prefab);
                prefab.gameObject.SetActive(wasActive);
                var children = instance.GetComponentsInChildren<MonoBehaviour>(true);
                foreach (var child in children) {
                    dependencies.InjectDependencies(child);
                }
                instance.gameObject.SetActive(wasActive);
                return instance.GetComponent<T>();
            };
        }

        public static DependencyCreationDelegate CreateFromGameObject<T>(T instance) where T : MonoBehaviour {
            return (dependencies) => {
                var children = instance.GetComponentsInChildren<MonoBehaviour>(true);
                foreach (var child in children) {
                    dependencies.InjectDependencies(child);
                }
                return instance;
            };
        }
    }
}
