using System;
using Core.Controllers.Interfaces;
using Core.Models;
using Core.Views.Interfaces;
using MonoBehaviours;
using UnityEngine;

namespace Core.Controllers.Player
{
    public class DefaultPlayerToolController : IPlayerToolController
    {
        private ObjectComponentsModel _playerComponents;
        private PlayerToolModel _toolModel;
        private PlayerResearchesModel _researchesModel;

        public DefaultPlayerToolController(ObjectComponentsModel playerComponents, PlayerToolModel toolModel, PlayerResearchesModel researchesModel)
        {
            if (playerComponents == null) throw new NullReferenceException("playerComponents is null");
            if (toolModel == null) throw new NullReferenceException("toolModel is null");
            if (researchesModel == null) throw new NullReferenceException("researchesModel is null");
            
            _playerComponents = playerComponents;
            _toolModel = toolModel;
            _researchesModel = researchesModel;

            GlobalEventManager.OnResearchEnd += dto => _researchesModel.AddResearchedResource(dto);
        }

        public void PrimaryAction()
        {
            IResourceView defaultResourceView = GetResourceView();
            if (defaultResourceView == null) return;
            if (!IsBatteryEnough()) return;

            var researchable = GetResearchableView();
            if (researchable != null && !_researchesModel.IsResearched(researchable.GetResearchableType()))
            {
                _researchesModel.OnResearchNeed();
                return;
            }

            _toolModel.BatteryLeft -= _toolModel.BatteryConsumption;
            defaultResourceView.OnHarvest(_toolModel.Efficiency);
        }
        
        
        public void SecondaryAction()
        {
            IResourceView defaultResourceView = GetResourceView();
            if (defaultResourceView == null) return;
            if (!IsBatteryEnough()) return;

            var researchable = GetResearchableView();
            if (researchable == null) return;
            if (_researchesModel.IsResearched(researchable.GetResearchableType())) return;
            
            if (researchable.Research(_toolModel.Efficiency))
                _toolModel.BatteryLeft -= _toolModel.BatteryConsumption;
        }

        private IResourceView GetResourceView()
        {
            RaycastHit hit;
            if (!Physics.Raycast(_playerComponents.Transform.position, 
                    _playerComponents.Transform.forward, out hit, _toolModel.Range /*TODO: добавить маску*/))
                return null;
            
            IResourceView resourceView = null;
            if (!hit.transform.TryGetComponent<IResourceView>(out resourceView))
                return null;

            return resourceView;
        }

        private IResearchableView GetResearchableView()
        {
            RaycastHit hit;
            if (!Physics.Raycast(_playerComponents.Transform.position,
                    _playerComponents.Transform.forward, out hit, _toolModel.Range /*TODO: добавить маску*/))
                return null;
            
            IResearchableView researchableView = null;
            if (!hit.transform.TryGetComponent<IResearchableView>(out researchableView))
                return null;

            return researchableView;
        }

        private bool IsBatteryEnough()
        {
            return _toolModel.BatteryLeft > 0;
        }
    }
}