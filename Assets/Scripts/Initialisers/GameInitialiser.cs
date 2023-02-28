using MonoBehaviours;
using ScriptableObjects;
using UnityEngine;

namespace Initialisers
{
    public class GameInitialiser : MonoBehaviour
    {
        void Start()
        {
            Application.targetFrameRate = 60;
        }
    }
}
