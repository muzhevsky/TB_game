using System;
using System.IO;
using UnityEngine;

namespace Internal.Models
{
    public class PlayerModel : CharacterModel
    {
        private float _booster;
        private float _maxBooster;
        private float _boosterRecovery;
        private float _boosterConsumption;

        public event Action<float> OnMaxBoosterCapChanged;
        public event Action<float> OnBoosterChanged;
        
        public float MaxBooster
        {
            get => _maxBooster;
            set
            {
                if (value <= 0) throw new InvalidDataException("MaxBooster should be greater then 0");
                _maxBooster = value;
                OnMaxBoosterCapChanged?.Invoke(_maxBooster);
            }
        }

        public float Booster
        {
            get => _booster;
            set
            {
                if (value <= 0) throw new InvalidDataException("Booster should be greater then 0");
                _booster = value;
                if (_booster > _maxBooster) _booster = _maxBooster;
                OnBoosterChanged?.Invoke(_booster);
            }
        }

        public float BoosterRecovery
        {
            get => _boosterRecovery;
            set
            {
                if (value <= 0) throw new InvalidDataException("BoosterRecovery should be greater then 0");
                _boosterRecovery = value;
            }
        }

        public float BoosterConsumption
        {
            get => _boosterConsumption;
            set
            {
                if (value <= 0) throw new InvalidDataException("BoosterConsumption should be greater then 0");
                _boosterConsumption = value;
            }
        }
    }
}
