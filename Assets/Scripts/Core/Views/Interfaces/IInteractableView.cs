using UnityEngine;

namespace Core.Views.Interfaces
{
    public interface IInteractableView
    {
        void Interact(GameObject interactCaller);
    }
}