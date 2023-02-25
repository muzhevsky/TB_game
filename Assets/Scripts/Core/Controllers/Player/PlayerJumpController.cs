using System;
using System.Diagnostics.CodeAnalysis;
using Internal.Models;
using Microsoft.Build.Framework;
using UnityEngine;

namespace Internal.Controllers
{
    public class PlayerJumpController : IJumpController
    {
        private IJumpController _wrappedController;
        private PlayerModel _playerModel;

        public PlayerJumpController(IJumpController wrappedController, PlayerModel playerModel)
        {
            if (wrappedController == null) throw new NullReferenceException("wrappedController is null");
            if (playerModel == null) throw new NullReferenceException("playerSuitModel is null");
            
            _wrappedController = wrappedController;
            _playerModel = playerModel;
        }
        public void Jump(Vector3 value)
        {
            if (_playerModel.Booster > 0)
            {
                _playerModel.Booster -= _playerModel.BoosterConsumption;
                _wrappedController.Jump(value * _playerModel.JumpForce);
            }
        }
    }
}