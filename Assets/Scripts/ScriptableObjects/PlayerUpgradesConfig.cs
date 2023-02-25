using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerUpgradesConfig")]
    public class PlayerUpgradesConfig : ScriptableObject
    {
        [SerializeField] private float[] _efficiencyValues;
        [SerializeField] private float[] _maxBoosterValues;
        [SerializeField] private float[] _maxBatteryValues;

        public float GetEfficiencyByLevel(int level)
        {
            return _efficiencyValues[level];
        }

        public float GetMaxBoosterByLevel(int level)
        {
            return _maxBoosterValues[level];
        }

        public float GetBatteryCapByLevel(int level)
        {
            return _maxBatteryValues[level];
        }
    }
}