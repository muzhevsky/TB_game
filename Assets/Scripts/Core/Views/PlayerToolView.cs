using DefaultNamespace;
using DefaultNamespaceasd;
using Internal.Controllers;
using UnityEngine;
using Views.Interfaces;

namespace Views
{
    public class PlayerToolView : View, IPlayerToolView
    { 
        private IPlayerToolController _controller;
        private IPlayerUIView _uiView;

        public void InitPlayerToolController(IPlayerToolController controller)
        {
            _controller = controller;
            _controller.InitPlayerToolView(this);
        }

        public void InitPlayerUiView(IPlayerUIView view)
        {
            _uiView = view;
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _controller.PrimaryAction();
            }
            else if (Input.GetMouseButton(1))
            {
                _controller.SecondaryAction();
            }
        }

        public void OnActionError(string message)
        {
            _uiView.DrawError(message);
        }
    }
}