using Internal.Models;
using Views.Interfaces;

namespace Internal.Controllers
{
    public interface IPlayerUIController : Controller
    {
        void BindToView(IPlayerUIView view);
    }
}