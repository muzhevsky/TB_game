using System;
using Core.Controllers.Interfaces;
using Core.Models;
using UnityEngine;

namespace Core.Controllers.Default
{
    public class DefaultJumpController : IJumpController
    {
        private readonly ObjectComponentsModel _objectComponentsModel;

        private DefaultJumpController()
        {
        }

        public DefaultJumpController(ObjectComponentsModel objectComponentsModel)
        {
            if (objectComponentsModel == null) throw new ArgumentException("objectComponentsModel can not be null");

            _objectComponentsModel = objectComponentsModel;
        }

        public void Jump(Vector3 value)
        {
            _objectComponentsModel.Rigidbody.AddForce(value);
        }
    }
}