using System;

namespace Core.Models
{
    public class PlayerModel : CharacterModel
    {
        private float _booster;

        private float _boosterConsumption;
        private float _boosterRecovery;
        private float _maxBooster;

        public float MaxBooster
        {
            get => _maxBooster;
            set
            {
                if (value <= 0) throw new ArgumentException("MaxBooster should be greater then 0");
                _maxBooster = value;
                OnBoosterChanged?.Invoke(_booster / _maxBooster);
            }
        }

        public float Booster
        {
            get => _booster;
            set
            {
                _booster = value;
                if (value <= 0) _booster = 0;
                if (_booster > _maxBooster) _booster = _maxBooster;
                OnBoosterChanged?.Invoke(_booster / _maxBooster);
            }
        }

        public float BoosterRecovery
        {
            get => _boosterRecovery;
            set
            {
                if (value <= 0) throw new ArgumentException("BoosterRecovery should be greater then 0");
                _boosterRecovery = value;
            }
        }

        public float BoosterConsumption
        {
            get => _boosterConsumption;
            set
            {
                if (value <= 0) throw new ArgumentException("BoosterConsumption should be greater then 0");
                _boosterConsumption = value;
            }
        }

        public event Action<float> OnBoosterChanged;
    }
}