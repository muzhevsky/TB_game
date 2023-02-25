using Internal.Controllers;
using UnityEngine;
using UnityEngine.UI;
using Views.Interfaces;

namespace Views
{
    public class DefaultPlayerUIView : MonoBehaviour, IPlayerUIView
    {
        [SerializeField] private Image _hpBar;
        [SerializeField] private Image _boosterBar;
        public IPlayerUIView InitSuitController(IPlayerUIController controller)
        {
            controller.BindToView(this);
            return this;
        }
        
        public IPlayerUIView InitHPBar(Image bar)
        {
            _hpBar = bar;
            return this;
        }

        public IPlayerUIView InitBoosterBar(Image bar)
        {
            _boosterBar = bar;
            return this;
        }


        public void DrawHP(float value)
        {
            _hpBar.fillAmount = value;
        }

        public void DrawBoosterCap(float value)
        {
            _boosterBar.fillAmount = value;
        }
    }
}