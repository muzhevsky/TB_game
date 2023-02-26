using Core.Controllers.Interfaces;
using Core.Models;
using UnityEngine;

namespace Core.Controllers.Player
{
    public class PlayerRotationController : IRotationController
    {
        private Transform _objectTransform;
        private float _sensitivity;
        private IRotationController _wrappedController;
        public PlayerRotationController(IRotationController wrappedController, ObjectComponentsModel objectComponentsModel, PlayerSettingsModel playerSettings)
        {
            _sensitivity = playerSettings.MouseSensitivity;
            _objectTransform = objectComponentsModel.Transform;
            _wrappedController = wrappedController;
        }
        
        
        public void Rotate(Vector3 mouseDiff)
        {
            var x = Quaternion.AngleAxis(-mouseDiff.y * _sensitivity, Vector3.right).eulerAngles;
            var y = Quaternion.AngleAxis(mouseDiff.x * _sensitivity, Vector3.up).eulerAngles;
            if (!GameStateController.UserInputIsLocked) _wrappedController.Rotate(x + y);
        }
    }
}