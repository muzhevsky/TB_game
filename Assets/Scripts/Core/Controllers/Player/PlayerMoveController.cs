using Internal.Models;
using UnityEngine;

namespace Internal.Controllers
{
    public class PlayerMoveController : IMoveController
    {
        private IMoveController _wrappedController;
        private Transform _playerTransform;

        public PlayerMoveController(IMoveController wrappedController, ObjectComponentsModel objectComponentsModel)
        {
            _wrappedController = wrappedController;
            _playerTransform = objectComponentsModel.Transform;
        }

        public void Move(Vector3 axisValue)
        {
            Vector3 direction = _playerTransform.forward * axisValue.y + _playerTransform.right * axisValue.x;
            direction.Set(direction.x, 0, direction.z);
            _wrappedController.Move(direction);
        }
    }
}