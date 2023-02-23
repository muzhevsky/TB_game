using System.Diagnostics;
using Internal.Models;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Internal.Controllers
{
    public class DefaultRotationController : IRotationController
    {
        private PlayerSettingsModel _playerSettings;
        private ObjectComponentsModel _objectComponentsModel;
        public DefaultRotationController(ObjectComponentsModel objectComponentsModel, PlayerSettingsModel playerSettings)
        {
            _playerSettings = playerSettings;
            _objectComponentsModel = objectComponentsModel;
        }

        public void Rotate(Vector3 direction)
        {
            _objectComponentsModel.Transform.Rotate(direction * _playerSettings.MouseSensitivity);
            Vector3 rotation = _objectComponentsModel.Transform.rotation.eulerAngles;
            
            _objectComponentsModel.Transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
        }
    }
}