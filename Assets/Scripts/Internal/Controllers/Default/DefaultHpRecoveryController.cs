using System;
using System.IO;
using Internal.Models;
using Internal.Utils;

namespace Internal.Controllers
{
    public class DefaultHpRecoveryController: IRecoveryController, IFixedUpdatable
    {
        private CharacterModel _characterModel;
        
        private bool _recoverAvailable;

        public DefaultHpRecoveryController(CharacterModel characterModel)
        {
            if (characterModel == null) throw new InvalidDataException("characterModel can not be null");
            
            _characterModel = characterModel;
        }

        public void Recover(float value)
        {
            _characterModel.Hp += value;
        }

        public void Activate()
        {
            _recoverAvailable = true;
        }

        public void FixedUpdate()
        {
            if (_recoverAvailable)
                _characterModel.Hp += _characterModel.HpRecovery;
        }

        public void StopUpdate()
        {
            _recoverAvailable = false;
        }
    }
}