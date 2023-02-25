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

        public DefaultUIController(PlayerModel playerModel)
        {
            if (playerModel == null) throw new InvalidDataException("playerSuitModel can not be null");
            
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
    }
}