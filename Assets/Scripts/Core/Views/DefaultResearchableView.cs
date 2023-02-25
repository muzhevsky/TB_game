using DefaultNamespace;
using Internal.Controllers;
using UnityEngine;

namespace Internal.Views.Interfaces
{
    public class DefaultResearchableView : MonoBehaviour, IResearchableView
    {
        private IResearchableController _controller;


        public void InitResearchableController(IResearchableController controller)
        {
            _controller = controller;
            _controller.InitReserchableView(this);
        }

        public void Research(float value)
        {
            _controller.Research(value);
        }

        public void Visualize(float value)
        {
            // TODO: визуальный эффект изучения ресурса 
        }
    }
}