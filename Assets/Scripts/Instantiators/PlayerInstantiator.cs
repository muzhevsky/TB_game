using System;
using DefaultNamespace.Initialisers;
using DefaultNamespaceasd;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Instantiators
{
    public class PlayerInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Image _hpBar;
        [SerializeField] private Image _boosterBar;
        [SerializeField] private Image _batteryBar;
        [SerializeField] private WarningText _warningText;
        private void Start()
        {
            GameObject player = Instantiate(_prefab, Vector3.zero, Quaternion.identity);

            PlayerInitialiser initialiser = null;
            player.TryGetComponent<PlayerInitialiser>(out initialiser);
            if (initialiser != null)
            {
                initialiser.HpBar = _hpBar;
                initialiser.BoosterBar = _boosterBar;
                initialiser.BatteryBar = _batteryBar;
                initialiser.WarningText = _warningText;
                initialiser.Init();
            }
        }
    }
}