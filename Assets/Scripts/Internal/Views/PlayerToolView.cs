using DefaultNamespace;
using Internal.Controllers;
using UnityEngine;
using Views.Interfaces;

namespace Views
{
    public class PlayerToolView : View, IPlayerToolView
    { 
        private IPlayerToolController _controller;
        private WarningText _errorText;

        public PlayerToolView(WarningText errorText)
        {
            _errorText = errorText;
        }

        public void InitPlayerToolView(IPlayerToolController controller)
        {
            _controller = controller;
            _controller.InitPlayerToolView(this);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _controller.PrimaryAction();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _controller.SecondaryAction();
            }
        }

        public void OnActionError(string message)
        {
            _errorText.text = message;
        }
    }
}