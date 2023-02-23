using Internal.Controllers;
using UnityEngine;
using UnityEngine.UIElements;

namespace Views
{
    public class PlayerRotateInputView : View
    {
        private IRotationController _controller;
        private Vector2 _prevMousePosition;

        void Start()
        {
            _prevMousePosition = Input.mousePosition;
        }
        
        public void InitRotateInputView(IRotationController controller)
        {
            _controller = controller;
        }

        void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            Vector2 mousePosition = Input.mousePosition;
            _controller.Rotate(mousePosition - _prevMousePosition);
            _prevMousePosition = mousePosition;
        }
    }
}