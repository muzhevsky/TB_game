using System.IO;
using Core.Controllers.Interfaces;
using Core.Models;
using UnityEngine;

namespace Core.Controllers.Default
{
    public class DefaultMoveController : IMoveController
    {
        private PlayerModel _playerModel;
        private ObjectComponentsModel _objectComponentsModel;

        public DefaultMoveController(ObjectComponentsModel objectComponentsModel, PlayerModel playerModel)
        {
            if (objectComponentsModel == null) throw new InvalidDataException("objectComponentsModel can not be null");
            if (playerModel == null) throw new InvalidDataException("playerSuitModel can not be null");
            
            _objectComponentsModel = objectComponentsModel;
            _playerModel = playerModel;
        }

        public void Move(Vector3 value)
        {
            _objectComponentsModel.Rigidbody.AddForce(value.normalized * _playerModel.Acceleration);
            if (_objectComponentsModel.Rigidbody.velocity.magnitude > _playerModel.MaxSpeed)
            {
                _objectComponentsModel.Rigidbody.velocity = _objectComponentsModel.Rigidbody.velocity.normalized;
                _objectComponentsModel.Rigidbody.velocity *= _playerModel.MaxSpeed;
            }
        }
    }
}