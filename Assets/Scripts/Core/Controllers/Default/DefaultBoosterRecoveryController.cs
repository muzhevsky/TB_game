using System;
using System.IO;
using Core.Controllers.Interfaces;
using Core.Models;
using Core.Utils;
using UnityEngine;

namespace Core.Controllers.Default
{
    public class DefaultBoosterRecoveryController: IRecoveryController, IFixedUpdatable
    {
        private PlayerModel _playerModel;
        
        private bool _recoverAvailable;

        public DefaultBoosterRecoveryController(PlayerModel playerModel)
        {
            if (playerModel == null) throw new ArgumentException ("playerSuitModel can not be null");
            
            _playerModel = playerModel;
        }

        public void ActivateFixedUpdate()
        {
            _recoverAvailable = true;
        }

        public void FixedUpdate()
        {
            if(_recoverAvailable)
                _playerModel.Booster += _playerModel.BoosterRecovery;
        }

        public void StopFixedUpdate()
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