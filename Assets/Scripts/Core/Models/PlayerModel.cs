using System;
using System.IO;

namespace Core.Models
{
    public class PlayerModel : CharacterModel
    {
        private float _booster;
        private float _maxBooster;
        private float _boosterRecovery;

        private float _boosterConsumption;
        public event Action<float> OnBoosterChanged;
        
        public float MaxBooster
        {
            get => _maxBooster;
            set
            {
                if (value <= 0) throw new ArgumentException ("MaxBooster should be greater then 0");
                _maxBooster = value;
                OnBoosterChanged?.Invoke(_booster / _maxBooster);
            }
        }

        public float Booster
        {
            get => _booster;
            set
            {
                if (value <= 0) throw new ArgumentException ("Booster should be greater then 0");
                _booster = value;
                if (_booster > _maxBooster) _booster = _maxBooster;
                OnBoosterChanged?.Invoke(_booster / _maxBooster);
            }
        }

        public float BoosterRecovery
        {
            get => _boosterRecovery;
            set
            {
                if (value <= 0) throw new ArgumentException ("BoosterRecovery should be greater then 0");
                _boosterRecovery = value;
            }
        }

        public float BoosterConsumption
        {
            get => _boosterConsumption;
            set
            {
                if (value <= 0) throw new ArgumentException ("BoosterConsumption should be greater then 0");
                _boosterConsumption = value;
            }
        }
    }
}
