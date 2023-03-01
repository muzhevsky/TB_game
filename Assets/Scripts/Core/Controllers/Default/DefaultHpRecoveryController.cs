using System;
using Core.Controllers.Interfaces;
using Core.Models;
using Core.Utils;

namespace Core.Controllers.Default
{
    public class DefaultHpRecoveryController : IRecoveryController, IFixedUpdatable
    {
        private readonly CharacterModel _characterModel;

        public DefaultHpRecoveryController(CharacterModel characterModel)
        {
            if (characterModel == null) throw new ArgumentException("characterModel can not be null");

            _characterModel = characterModel;
        }

        public void ActivateFixedUpdate()
        {
            _characterModel.Recoverable = true;
        }

        public void FixedUpdate()
        {
            if (_characterModel.Recoverable)
                _characterModel.Hp += _characterModel.HpRecovery;
        }

        public void StopFixedUpdate()
        {
            _characterModel.Recoverable = false;
        }

        public void Recover(float value)
        {
            _characterModel.Hp += value;
        }
    }
}