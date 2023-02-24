using System;
using System.Diagnostics.CodeAnalysis;
using Internal.Models;
using Microsoft.Build.Framework;
using UnityEngine;

namespace Internal.Controllers
{
    public class DefaultPlayerJumpController : IJumpController
    {
        private IJumpController _wrappedController;
        private PlayerSuitModel _playerSuitModel;

        public DefaultPlayerJumpController(IJumpController wrappedController, PlayerSuitModel playerSuitModel)
        {
            if (wrappedController == null) throw new NullReferenceException("wrappedController is null");
            if (playerSuitModel == null) throw new NullReferenceException("playerSuitModel is null");
            
            _wrappedController = wrappedController;
            _playerSuitModel = playerSuitModel;
        }
        public void Jump(Vector3 value)
        {
            if (_playerSuitModel.Booster > 0)
            {
                _playerSuitModel.Booster -= PlayerSuitModel.BoosterConsumption;
                _wrappedController.Jump(value * _playerSuitModel.JumpForce);
            }
        }
    }
}