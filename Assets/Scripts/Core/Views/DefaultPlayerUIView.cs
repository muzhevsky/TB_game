using DefaultNamespace;
using DefaultNamespaceasd;
using Dto;
using Internal.Controllers;
using MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;
using Views.Interfaces;

namespace Views
{
    public class DefaultPlayerUIView : MonoBehaviour, IPlayerUIView
    {
        [SerializeField] private Image _hpBar;
        [SerializeField] private Image _boosterBar;
        [SerializeField] private Image _batteryBar;
        [SerializeField] private Text _warningText;
        [SerializeField] private Tip _tip;

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

        public IPlayerUIView InitBatteryBar(Image bar)
        {
            _batteryBar = bar;
            return this;
        }

        public IPlayerUIView InitWarningText(Text text)
        {
            _warningText = text;
            return this;
        }

        public IPlayerUIView InitTip(Tip tip)
        {
            _tip = tip;
            GlobalEventManager.OnResearchEnd += ShowTip;
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

        public void DrawBattery(float value)
        {
            _batteryBar.fillAmount = value;
        }

        public void DrawError(string text)
        {
            _warningText.text = text;
        }

        public void ShowTip(TipDto tipDto)
        {
            _tip.NewTip(tipDto);
        }
    }
}