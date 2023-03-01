using Core.Models;
using UnityEngine;

namespace ScriptableObjects.Player
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerDefaultSettings")]
    public class PlayerDefaultStateConfig : ScriptableObject
    {
        [Header("Upgrades")] [SerializeField] private PlayerUpgradesConfig _upgradesConfig;

        [Header("Hp")] [SerializeField] private float _hp;

        [SerializeField] private float _maxHp;
        [SerializeField] private float _hpRecovery;

        [Header("Movement")] [SerializeField] private float _acceleration;

        [SerializeField] private float _jumpForce;
        [SerializeField] private float _maxSpeed;

        [Header("Booster")] [SerializeField] private float _boosterRecovery;

        [SerializeField] private float _boosterConsumption;

        [Header("Tool")] [SerializeField] private float _range;

        [SerializeField] private float _batteryConsumption;

        public PlayerModel GetPlayerStatsModel()
        {
            var result = new PlayerModel();
            result.Hp = _hp;
            result.MaxHp = _maxHp;
            result.HpRecovery = _hpRecovery;
            result.Acceleration = _acceleration;
            result.JumpForce = _jumpForce;
            result.MaxSpeed = _maxSpeed;
            result.MaxBooster = _upgradesConfig.GetMaxBoosterByLevel(0);
            result.Booster = result.MaxBooster;
            result.BoosterRecovery = _boosterRecovery;
            result.BoosterConsumption = _boosterConsumption;
            return result;
        }

        public PlayerToolModel GetPlayerToolModel()
        {
            var result = new PlayerToolModel();
            result.Efficiency = _upgradesConfig.GetEfficiencyByLevel(0);
            result.Range = _range;
            result.BatteryConsumption = _batteryConsumption;
            result.BatteryCap = _upgradesConfig.GetBatteryCapByLevel(0);
            result.BatteryLeft = 0f;
            return result;
        }
    }
}