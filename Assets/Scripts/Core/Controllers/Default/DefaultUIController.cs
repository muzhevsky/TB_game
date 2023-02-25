using System;
using System.IO;
using Internal.Models;
using Views.Interfaces;

namespace Internal.Controllers
{
    public class DefaultUIController : IPlayerUIController
    {
        private IPlayerUIView _view;
        private PlayerModel _playerModel;
        private PlayerToolModel _playerToolModel;

        public DefaultUIController(PlayerModel playerModel, PlayerToolModel playerToolModel)
        {
            if (playerModel == null) throw new InvalidDataException("playerModel can not be null");
            if (playerToolModel == null) throw new InvalidDataException("playerToolModel can not be null");

            _playerToolModel = playerToolModel;
            _playerModel = playerModel;
        }
        
        public void BindToView(IPlayerUIView view)
        {
            if (view == null) throw new InvalidDataException("view can not be null");
            
            _view = view;
            
            _playerModel.OnBoosterChanged += NotifyBoosterChange;
            _playerModel.OnHPChanged += NotifyHpChange;
            _playerModel.OnMaxHpChanged += NotifyMaxHpChange;
            _playerModel.OnMaxBoosterCapChanged += NotifyMaxBoosterChange;
            _playerToolModel.OnBatteryChange += NotifyBatteryChange;
        }
        
        public void NotifyMaxHpChange(float newMaxHp)
        {
            _view.DrawHP(_playerModel.Hp / newMaxHp);
        }

        public void NotifyHpChange(float newHp)
        {
            _view.DrawHP(newHp / _playerModel.MaxHp);
        }

        public void NotifyMaxBoosterChange(float newBoosterCap)
        {
            _view.DrawBoosterCap(_playerModel.Booster / newBoosterCap);
        }

        public void NotifyBoosterChange(float newBooster)
        {
            _view.DrawBoosterCap(newBooster / _playerModel.MaxBooster);
        }

        public void NotifyBatteryChange(float newBattery)
        {
            _view.DrawBattery(_playerToolModel.BatteryLeft / _playerToolModel.BatteryCap);
        }
    }
}