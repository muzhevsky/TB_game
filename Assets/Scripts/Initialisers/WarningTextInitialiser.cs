using Core.Utils;
using MonoBehaviours;
using UnityEngine;

namespace Initialisers
{
    public class WarningTextInitialiser : MonoBehaviour
    {
        [SerializeField] private WarningText _text;

        private void Awake()
        {
            WarningTextManager.Init(_text);
        }
    }
}