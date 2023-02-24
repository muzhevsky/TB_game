using Internal.Models;
using Views.Interfaces;

namespace Internal.Controllers
{
    public class DefaultUIController : IPlayerUIController
    {
        private IPlayerUIView _view;
        private PlayerSuitModel _playerSuitModel;

        public void Init(IPlayerUIView view)
        {
            _view = view;
            
            _playerSuitModel.OnBoosterChanged += NotifyBoosterChange;
            _playerSuitModel.OnHPChanged += NotifyHpChange;
            _playerSuitModel.OnMaxHpChanged += NotifyMaxHpChange;
            _playerSuitModel.OnMaxBoosterCapChanged += NotifyMaxBoosterChange;
        }
        
        public void NotifyMaxHpChange(float newMaxHp)
        {
            _view.DrawHP(_playerSuitModel.Hp / newMaxHp);
        }

        public void NotifyHpChange(float newHp)
        {
            _view.DrawHP(newHp / _playerSuitModel.MaxHp);
        }

        public void NotifyMaxBoosterChange(float newBoosterCap)
        {
            _view.DrawBoosterCap(_playerSuitModel.Booster / newBoosterCap);
        }

        public void NotifyBoosterChange(float newBooster)
        {
            _view.DrawBoosterCap(newBooster / _playerSuitModel.MaxBooster);
        }
    }
}