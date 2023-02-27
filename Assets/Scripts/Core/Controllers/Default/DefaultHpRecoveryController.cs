using System;
using System.IO;
using Core.Controllers.Interfaces;
using Core.Models;
using Core.Utils;

namespace Core.Controllers.Default
{
    public class DefaultHpRecoveryController: IRecoveryController, IFixedUpdatable
    {
        private CharacterModel _characterModel;
        
        private bool _recoverAvailable;

        public DefaultHpRecoveryController(CharacterModel characterModel)
        {
            if (characterModel == null) throw new ArgumentException ("characterModel can not be null");
            
            _characterModel = characterModel;
        }

        public void Recover(float value)
        {
            _characterModel.Hp += value;
        }

        public void ActivateFixedUpdate()
        {
            _recoverAvailable = true;
        }

        public void FixedUpdate()
        {
            if (_recoverAvailable)
                _characterModel.Hp += _characterModel.HpRecovery;
        }

        public void StopFixedUpdate()
        {
            _recoverAvailable = false;
        }
    }
}