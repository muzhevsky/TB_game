using Internal.Models;
using UnityEngine;

namespace Internal.Controllers
{
    public class DefaultJumpController : IJumpController
    {
        private PlayerSuitModel _playerSuitModel;
        private ObjectComponentsModel _objectComponentsModel;
        public DefaultJumpController(ObjectComponentsModel objectComponentsModel, PlayerSuitModel playerSuitModel)
        {
            _playerSuitModel = playerSuitModel;
            _objectComponentsModel = objectComponentsModel;
        }

        public void Jump()
        {
            _objectComponentsModel.Rigidbody.AddForce(Vector3.up * _playerSuitModel.JumpForce);
        }
    }
}