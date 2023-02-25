﻿using System;
using System.IO;
using Internal.Models;
using UnityEngine;

namespace Internal.Controllers
{
    public class DefaultJumpController : IJumpController
    {
        private ObjectComponentsModel _objectComponentsModel;
        public DefaultJumpController(ObjectComponentsModel objectComponentsModel)
        {
            if (objectComponentsModel == null) throw new InvalidDataException("objectComponentsModel can not be null");
            
            _objectComponentsModel = objectComponentsModel;
        }

        public void Jump(Vector3 value)
        {
            _objectComponentsModel.Rigidbody.AddForce(value);
        }
    }
}