using System;
using System.IO;
using Core.Controllers.Interfaces;
using Core.Models;
using UnityEngine;

namespace Core.Controllers.Default
{
    public class DefaultRotationController : IRotationController
    {
        private ObjectComponentsModel _objectComponentsModel;
        
        private const int ConstraintValue = 85;
        public DefaultRotationController(ObjectComponentsModel objectComponentsModel)
        {
            if (objectComponentsModel == null) throw new ArgumentException ("objectComponentsModel can not be null");
            
            _objectComponentsModel = objectComponentsModel;
        }

        private DefaultRotationController()
        {
            
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