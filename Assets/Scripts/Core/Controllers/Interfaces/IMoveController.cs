using Interfaces;
using UnityEngine;

namespace Core.Controllers.Interfaces
{
    public interface IMoveController : Controller
    {
        void Move(Vector3 value);
    }
}