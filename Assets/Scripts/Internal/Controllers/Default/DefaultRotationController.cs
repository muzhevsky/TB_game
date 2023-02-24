using Internal.Models;
using UnityEngine;

namespace Internal.Controllers
{
    public class DefaultRotationController : IRotationController
    {
        private ObjectComponentsModel _objectComponentsModel;
        
        private const int ConstraintValue = 85;
        public DefaultRotationController(ObjectComponentsModel objectComponentsModel)
        {
            _objectComponentsModel = objectComponentsModel;
        }
        
        public void Rotate(Vector3 direction)
        {
            _objectComponentsModel.Transform.Rotate(direction);
            RestrictRotation();
        }

        private void RestrictRotation()
        {
            var rotation = _objectComponentsModel.Transform.rotation.eulerAngles;
            
            if (rotation.x > 180) rotation.x -= 360;
            else if (rotation.x < -180) rotation.x += 360;

            if (rotation.x > ConstraintValue)
            {
                rotation.x = ConstraintValue;
            }
            else if (rotation.x < -ConstraintValue)
            {
                rotation.x = -ConstraintValue;
            }
            
            rotation.z = 0;

            _objectComponentsModel.Transform.rotation = Quaternion.Euler(rotation);
        }
    }
}