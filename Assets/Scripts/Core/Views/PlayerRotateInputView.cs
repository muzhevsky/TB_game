using Core.Controllers.Interfaces;
using Interfaces;
using UnityEngine;

namespace Core.Views
{
    public class PlayerRotateInputView : View
    {
        private IRotationController _controller;
        
        public void InitRotateInputView(IRotationController controller)
        {
            _controller = controller;
        }

        void Update()
        {
            Rotate();
        }

        void Rotate()
        {
            Vector2 mousePosition = Input.mousePosition;
            _controller.Rotate(new Vector3 (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
        }
    }
}