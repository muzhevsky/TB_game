using Core.Controllers.Interfaces;
using Core.Models;
using UnityEngine;

namespace Core.Controllers.Player
{
    public class PlayerMoveController : IMoveController
    {
        private readonly Transform _playerTransform;
        private readonly IMoveController _wrappedController;


        private PlayerMoveController()
        {
        }

        public PlayerMoveController(IMoveController wrappedController, ObjectComponentsModel objectComponentsModel)
        {
            _wrappedController = wrappedController;
            _playerTransform = objectComponentsModel.Transform;
        }

        public void Move(Vector3 axisValue)
        {
            var direction = _playerTransform.forward * axisValue.y + _playerTransform.right * axisValue.x;
            direction.Set(direction.x, 0, direction.z);
            if (!GameStateController.UserInputIsLocked) _wrappedController.Move(direction);
        }
    }
}