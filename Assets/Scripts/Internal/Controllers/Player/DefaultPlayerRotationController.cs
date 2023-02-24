using Internal.Models;
using UnityEngine;

namespace Internal.Controllers
{
    public class DefaultPlayerRotationController : IRotationController
    {
        private Transform _objectTransform;
        private float _sensitivity;
        private IRotationController _wrappedController;
        public DefaultPlayerRotationController(IRotationController wrappedController, ObjectComponentsModel objectComponentsModel, PlayerSettingsModel playerSettings)
        {
            _sensitivity = playerSettings.MouseSensitivity;
            _objectTransform = objectComponentsModel.Transform;
            _wrappedController = wrappedController;
        }
        
        
        public void Rotate(Vector3 mouseDiff)
        {
            var x = Quaternion.AngleAxis(-mouseDiff.y * _sensitivity, Vector3.right).eulerAngles;
            var y = Quaternion.AngleAxis(mouseDiff.x * _sensitivity, Vector3.up).eulerAngles;
            _wrappedController.Rotate(x + y);
        }
    }
}