using Core.Views.Interfaces;
using Interfaces;
using UnityEngine;

namespace Core.Views
{
    public class PlayerInteractionView : View
    {
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
                {
                    IInteractableView view = null;
                    if (hit.transform.TryGetComponent<IInteractableView>(out view))
                    {
                        view.Interact(this.gameObject);
                    }
                }
            }
        }
    }
}