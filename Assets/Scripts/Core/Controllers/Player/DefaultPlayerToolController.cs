using System;
using DefaultNamespace;
using Internal.Models;
using Internal.Views.Interfaces;
using UnityEngine;
using Views;
using Views.Interfaces;

namespace Internal.Controllers
{
    public class DefaultPlayerToolController : IPlayerToolController
    {
        private IPlayerToolView _playerToolView;
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
        }
        
        public void InitPlayerToolView(IPlayerToolView view)
        {
            if (view == null) throw new NullReferenceException("PlayerToolView can not be null");
            _playerToolView = view;
        }

        public void PrimaryAction()
        {
            IResourceView defaultResourceView = GetResourceView();
            if (defaultResourceView == null) return;
            if (!IsBatteryEnough()) return;

            var researchable = GetResearchableView();
            if (researchable != null && !_researchesModel.IsResearched(researchable))
            {
                _playerToolView.OnActionError("Неизвестный ресурс \n Проведите исследование");
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
            if (researchable == null || _researchesModel.IsResearched(researchable)) return;
            
            _toolModel.BatteryLeft -= _toolModel.BatteryConsumption;
            researchable.Research(_toolModel.Efficiency);
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
            if (_toolModel.BatteryLeft <= 0)
            {
                _playerToolView.OnActionError("Недостаточно заряда батареи \n Зарядите инструмент у ракеты");
                return false;
            }
            return true;
        }
    }
}