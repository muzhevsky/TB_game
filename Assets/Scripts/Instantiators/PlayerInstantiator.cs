using System;
using DefaultNamespace.Initialisers;
using UnityEngine;

namespace DefaultNamespace.Instantiators
{
    public class PlayerInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        private void Start()
        {
            GameObject player = Instantiate(_prefab, Vector3.zero, Quaternion.identity);

            IInitialiser initialiser = null;
            
            if (player.TryGetComponent<IInitialiser>(out initialiser))
                initialiser.Init();
        }
    }
}