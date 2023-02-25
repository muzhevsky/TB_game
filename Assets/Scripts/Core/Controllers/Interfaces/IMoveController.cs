using UnityEngine;

namespace Internal.Controllers
{
    public interface IMoveController : Controller
    {
        void Move(Vector3 value);
    }
}
