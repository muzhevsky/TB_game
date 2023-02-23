using Internal.Models;
using UnityEngine;

namespace Internal.Controllers
{
    public class DefaultPlayerRotationController : IRotationController
    {
        private DefaultRotationController _rotationController;

        public DefaultPlayerRotationController(ObjectComponentsModel objectComponentsModel, PlayerSettingsModel playerSettings)
        {
            _rotationController = new DefaultRotationController(objectComponentsModel, playerSettings);
        }
        
        public void Rotate(Vector3 mouseDiff)
        {
            Vector3 direction = new Vector3(-mouseDiff.y, mouseDiff.x, 0);
            _rotationController.Rotate(direction);
        }
    }
}