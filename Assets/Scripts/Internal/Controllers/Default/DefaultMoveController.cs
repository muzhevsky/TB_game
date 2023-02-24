using Internal.Models;
using UnityEngine;

namespace Internal.Controllers
{
    public class DefaultMoveController : IMoveController
    {
        private PlayerSuitModel _playerSuitModel;
        private ObjectComponentsModel _objectComponentsModel;

        public DefaultMoveController(ObjectComponentsModel objectComponentsModel, PlayerSuitModel playerSuitModel)
        {
            _objectComponentsModel = objectComponentsModel;
            _playerSuitModel = playerSuitModel;
        }

        public void Move(Vector3 value)
        {
            _objectComponentsModel.Rigidbody.AddForce(value.normalized * _playerSuitModel.Acceleration);
            if (_objectComponentsModel.Rigidbody.velocity.magnitude > _playerSuitModel.MaxSpeed)
            {
                _objectComponentsModel.Rigidbody.velocity = _objectComponentsModel.Rigidbody.velocity.normalized;
                _objectComponentsModel.Rigidbody.velocity *= _playerSuitModel.MaxSpeed;
            }
        }
    }
}