using Initialisers;
using MonoBehaviours;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Instantiators
{
    public class PlayerInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Image _hpBar;
        [SerializeField] private Image _boosterBar;
        [SerializeField] private Image _batteryBar;
        [SerializeField] private AlertView alertView;
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
                initialiser.AlertView = alertView;
                initialiser.Init();
            }
        }
    }
}