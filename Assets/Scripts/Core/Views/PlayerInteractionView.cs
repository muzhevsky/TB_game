using Core.Controllers;
using Core.Views.Interfaces;
using Interfaces;
using UnityEngine;

namespace Core.Views
{
    public class PlayerInteractionView : View
    {
        [SerializeField] private float _interactionDistance;

        public float InteractionDistance
        {
            get => _interactionDistance;
            set => _interactionDistance = value;
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E) && !GameStateController.UserInputIsLocked)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
                {
                    IInteractableView view = null;
                    if (hit.transform.TryGetComponent(out view)) view.Interact(gameObject);
                }
            }
        }
    }
}