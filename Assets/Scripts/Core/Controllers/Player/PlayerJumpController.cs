using System;
using Core.Controllers.Interfaces;
using Core.Models;
using UnityEngine;

namespace Core.Controllers.Player
{
    public class PlayerJumpController : IJumpController
    {
        private IJumpController _wrappedController;
        private PlayerModel _playerModel;

        private PlayerJumpController()
        {
        }
        
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
                if (!GameStateController.UserInputIsLocked) _wrappedController.Jump(value * _playerModel.JumpForce);
            }
        }
    }
}