using System;
using UnityEngine;

namespace Source.Unity
{
    public class UnityGameWorld : MonoBehaviour
    {
        public event Action OnStart;
        public event Action<float> OnTick;
        public event Action OnQuit;

        private void Start()
        {
            OnStart.Invoke();
        }

        private void FixedUpdate()
        {
            OnTick.Invoke(Time.deltaTime);
        }

        private void OnApplicationQuit()
        {
            OnQuit.Invoke();
        }
    }
}