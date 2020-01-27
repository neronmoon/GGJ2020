using UnityEngine;

namespace Source.Unity.Common
{
    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool _isShuttingDown;
        private static object _lock = new object();
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_isShuttingDown) {
                    Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed. Returning null.");
                    return null;
                }

                lock (_lock) {
                    if (_instance == null) {
                        _instance = (T) FindObjectOfType(typeof(T));

                        if (_instance == null) {
                            Debug.LogWarning(
                                $"[Singleton] Instance '{typeof(T)}' was never created in scene. Creating!");
                            var singletonObject = new GameObject();
                            _instance = singletonObject.AddComponent<T>();
                            singletonObject.name = $"[{typeof(T)}]";

                            DontDestroyOnLoad(singletonObject);
                        } else {
                            DontDestroyOnLoad(_instance.gameObject);
                        }
                    }

                    return _instance;
                }
            }
        }

        private void OnApplicationQuit()
        {
            _isShuttingDown = true;
        }

        private void OnDestroy()
        {
            _isShuttingDown = true;
        }
    }
}