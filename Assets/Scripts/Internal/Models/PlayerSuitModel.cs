using System;

namespace Internal.Models
{
    public class PlayerSuitModel : Model
    {
        private float _acceleration = 35;
        private float _jumpForce = 10;
        private float _maxSpeed = 100;
        
        private float _hp = 100;
        private float _maxHP = 100;

        private float _booster = 100;
        private float _maxBooster = 100;

        public const float BoosterConsumption = 1f;
        
        public event Action<float> OnMaxBoosterCapChanged;
        public event Action<float> OnMaxHpChanged;
        public event Action<float> OnHPChanged;
        public event Action<float> OnBoosterChanged;
        
        public float MaxHp
        {
            get => _maxHP;
            set
            {
                _maxHP = value;
                OnMaxHpChanged?.Invoke(_maxHP);
            }
        }

        public float MaxBooster
        {
            get => _maxBooster;
            set
            {
                _maxBooster = value;
                OnMaxBoosterCapChanged?.Invoke(_maxBooster);
            }
        }
        
        public float Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                OnHPChanged?.Invoke(_hp);
            }
        }

        public float Booster
        {
            get => _booster;
            set
            {
                _booster = value;
                OnBoosterChanged?.Invoke(_booster);
            }
        }

        public float Acceleration
        {
            get => _acceleration;
            set => _acceleration = value;
        }

        public float MaxSpeed
        {
            get => _maxSpeed;
            set => _maxSpeed = value;
        }

        public float JumpForce
        {
            get => _jumpForce;
            set => _jumpForce = value;
        }
    }
}
