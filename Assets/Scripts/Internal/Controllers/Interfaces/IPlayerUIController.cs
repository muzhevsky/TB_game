using Views.Interfaces;

namespace Internal.Controllers
{
    public interface IPlayerUIController : Controller
    {
        void Init(IPlayerUIView view);
    }
}