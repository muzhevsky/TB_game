using System;
using Interfaces;

namespace Core.Models
{
    public class CharacterModel : Model
    {
        public bool IsGrounded;
        
        private float _hp = 100;
        private float _maxHp = 100;
        private float _hpRecovery = 0.5f;
        
        private float _acceleration = 35;
        private float _jumpForce = 10;
        private float _maxSpeed = 100;

        public event Action<float> OnHPChanged;
        public float MaxHp
        {
            get => _maxHp;
            set
            {
                if (value <= 0) throw new NullReferenceException("Max hp should be greater then 0");
                _maxHp = value;
                OnHPChanged?.Invoke(_hp / _maxHp);
            }
        }
        public float Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                if (_hp > _maxHp) _hp = _maxHp;
                OnHPChanged?.Invoke(_hp / _maxHp);
            }
        }
        
        public float Acceleration
        {
            get => _acceleration;
            set
            {
                if (value <= 0) throw new NullReferenceException("Acceleration should be greater then 0");
                _acceleration = value;
            }
        }

        public float MaxSpeed
        {
            get => _maxSpeed;
            set
            {
                if (value <= 0) throw new NullReferenceException("MaxSpeed should be greater then 0");
                _maxSpeed = value;
            }
        }

        public float JumpForce
        {
            get => _jumpForce;
            set
            {
                if (value <= 0) throw new NullReferenceException("JumpForce should be greater then 0");
                _jumpForce = value;
            }
        }

        public float HpRecovery
        {
            get => _hpRecovery;
            set
            {
                if (value <= 0) throw new NullReferenceException("HpRecovery should be greater then 0");
                _hpRecovery = value;
            }
        }
    }
}
