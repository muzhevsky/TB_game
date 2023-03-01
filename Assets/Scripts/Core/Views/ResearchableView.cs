using Core.Controllers.Interfaces;
using Core.Views.Interfaces;
using Dto;
using UnityEngine;

namespace Core.Views
{
    public class DefaultResearchableView : MonoBehaviour, IResearchableView
    {
        private IResearchableController _controller;

        public void Init(IResearchableController controller)
        {
            _controller = controller;
        }

        public ResearchActionDto Research(float value)
        {
            return _controller.Research(value);
        }

        public void Visualize(float value)
        {
            // TODO: визуальный эффект изучения ресурса 
        }
    }
}