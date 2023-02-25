using System;
using System.IO;
using Internal.Models;
using Internal.Utils;
using UnityEngine;

namespace Internal.Controllers
{
    public class DefaultBoosterRecoveryController: IRecoveryController, IFixedUpdatable
    {
        private PlayerModel _playerModel;
        
        private bool _recoverAvailable;

        public DefaultBoosterRecoveryController(PlayerModel playerModel)
        {
            if (playerModel == null) throw new InvalidDataException("playerSuitModel can not be null");
            
            _playerModel = playerModel;
        }

        public void Activate()
        {
            _recoverAvailable = true;
        }

        public void FixedUpdate()
        {
            if(_recoverAvailable)
                _playerModel.Booster += _playerModel.BoosterRecovery;
        }

        public void StopUpdate()
        {
            _recoverAvailable = false;
        }

        public void Recover(float value)
        {
            _playerModel.Booster += value;
            Debug.Log(_playerModel.Booster);
        }
    }
}