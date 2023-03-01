using System;
using UnityEngine;

namespace Core.Utils
{
    [Serializable]
    public abstract class PausableBehaviour : MonoBehaviour
    {
        public event Action OnPause;
        public event Action OnUnpause;

        protected void OnPauseInvoke()
        {
            OnPause?.Invoke();
        }

        protected void OnUnpauseInvoke()
        {
            OnUnpause?.Invoke();
        }
    }
}