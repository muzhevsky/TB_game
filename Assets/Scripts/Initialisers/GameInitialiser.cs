using MonoBehaviours;
using ScriptableObjects;
using UnityEngine;

namespace Initialisers
{
    public class GameInitialiser : MonoBehaviour
    {
        [SerializeField] private ResearchableConfigList _configList;
        void Start()
        {
            Application.targetFrameRate = 60;
            GlobalEventManager.Init(_configList);
        }
    }
}
