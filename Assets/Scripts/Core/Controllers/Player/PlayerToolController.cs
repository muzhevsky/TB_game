using System;
using Core.Controllers.Interfaces;
using Core.Models;
using Core.Utils;
using Core.Views.Interfaces;
using UnityEngine;

namespace Core.Controllers.Player
{
    public class PlayerToolController : IPlayerToolController, IChargableToolController
    {
        private readonly InventoryModel _inventoryModel;
        private readonly ObjectComponentsModel _playerComponents;
        private readonly PlayerResearchesModel _researchesModel;
        private readonly PlayerToolModel _toolModel;

        private PlayerToolController()
        {
        }

        public PlayerToolController(ObjectComponentsModel playerComponents, PlayerToolModel toolModel,
            PlayerResearchesModel researchesModel, InventoryModel inventoryModel)
        {
            if (playerComponents == null) throw new NullReferenceException("playerComponents is null");
            if (toolModel == null) throw new NullReferenceException("toolModel is null");
            if (researchesModel == null) throw new NullReferenceException("researchesModel is null");
            if (inventoryModel == null) throw new NullReferenceException("inventoryModel is null");

            _playerComponents = playerComponents;
            _toolModel = toolModel;
            _researchesModel = researchesModel;
            _inventoryModel = inventoryModel;
        }

        public event Action<float> OnBatteryChange;

        public void ChargeBattery(float value)
        {
            _toolModel.BatteryLeft += value;
            OnBatteryChange?.Invoke(_toolModel.BatteryLeft / _toolModel.BatteryCap);
        }


        public void PrimaryAction()
        {
            var resourceView = GetResourceView();
            if (resourceView == null) return;
            if (!IsBatteryEnough())
            {
                WarningTextManager.SetText("Не хватает заряда батареи\n Зарядите у корабля");
                return;
            }

            var researchable = GetResearchableView();

            if (researchable != null)
            {
                var researchData = researchable.Research(_toolModel.Efficiency);

                if (!_researchesModel.IsResearched(researchData.ResearchableData.Type))
                {
                    WarningTextManager.SetText("Неизвестный ресурс.\nНеобходимо исследование");
                    return;
                }
            }

            var harvestData = resourceView.OnHarvest(_toolModel.Efficiency);

            if (harvestData.IsSucceed)
            {
                _toolModel.BatteryLeft -= _toolModel.BatteryConsumption;
                _inventoryModel.AddResource(harvestData.ResourceDto.Type, _toolModel.Efficiency);

                OnBatteryChange?.Invoke(_toolModel.BatteryLeft / _toolModel.BatteryCap);
            }

            else
            {
                WarningTextManager.SetText("Залежа истощена.\n");
            }
        }


        public void SecondaryAction()
        {
            var defaultResourceView = GetResourceView();
            if (defaultResourceView == null) return;
            if (!IsBatteryEnough())
            {
                WarningTextManager.SetText("Не хватает заряда батареи\n Зарядите у корабля");
                return;
            }

            var researchable = GetResearchableView();
            if (researchable == null) return;

            var researchData = researchable.Research(_toolModel.Efficiency);
            var researchableData = researchData.ResearchableData;

            if (_researchesModel.IsResearched(researchableData.Type)) return;

            if (researchData.IsSucceed)
            {
                _toolModel.BatteryLeft -= _toolModel.BatteryConsumption;
                OnBatteryChange?.Invoke(_toolModel.BatteryLeft / _toolModel.BatteryCap);
            }

            if (researchData.IsFinished)
            {
                AlertManager.NewAlert(researchableData.Config.DescriptionSprite,
                    researchableData.Config.Description);
                AlertManager.ShowAlerts();
                _researchesModel.AddResearchedResource(researchableData);
            }
        }

        private IResourceView GetResourceView()
        {
            RaycastHit hit;
            if (!Physics.Raycast(_playerComponents.Transform.position,
                    _playerComponents.Transform.forward, out hit, _toolModel.Range /*TODO: добавить маску*/))
                return null;

            IResourceView resourceView = null;
            if (!hit.transform.TryGetComponent(out resourceView))
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
            if (!hit.transform.TryGetComponent(out researchableView))
                return null;

            return researchableView;
        }

        private bool IsBatteryEnough()
        {
            return _toolModel.BatteryLeft > 0;
        }
    }
}