using System;
using Core.Controllers.Interfaces;
using Core.Views.Interfaces;
using Enums;
using UnityEngine;

namespace Core.Views
{
    public class DefaultResearchableView : MonoBehaviour, IResearchableView, IEquatable<IResearchableView>
    {
        private IResearchableController _controller;

        public void Init(IResearchableController controller)
        {
            _controller = controller;
        }

        public bool Research(float value)
        {
            return _controller.Research(value);
        }

        public void Visualize(float value)
        {
            // TODO: визуальный эффект изучения ресурса 
        }

        ResearchableType IResearchableView.GetResearchableType()
        {
            return _controller.GetResearchableType();
        }

        public bool Equals(IResearchableView other)
        {
            if (other == null) return false;
            if (other == this) return true;
            return other.GetResearchableType() == _controller.GetResearchableType();
        }
    }
}