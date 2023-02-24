using Internal.Models;
using UnityEngine;

namespace Internal.Controllers
{
    public class DefaultJumpController : IJumpController
    {
        private ObjectComponentsModel _objectComponentsModel;
        public DefaultJumpController(ObjectComponentsModel objectComponentsModel)
        {
            _objectComponentsModel = objectComponentsModel;
        }

        public void Jump(Vector3 value)
        {
            _objectComponentsModel.Rigidbody.AddForce(value);
        }
    }
}