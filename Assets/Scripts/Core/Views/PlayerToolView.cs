using Core.Controllers;
using Core.Controllers.Interfaces;
using Core.Models;
using Interfaces;
using MonoBehaviours;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Core.Views
{
    public class PlayerToolView : View
    { 
        [SerializeField] private Image _batteryBar;
        [SerializeField] private Text _warningText;
        [SerializeField] private AlertView _alertView;
        
        private IPlayerToolController _controller;
        public void Init(PlayerToolModel playerModel, PlayerResearchesModel researchesModel, IPlayerToolController controller)
        {
            _controller = controller;
            playerModel.OnBatteryChange += DrawBattery;
            researchesModel.OnResearchNeedEvent += () => DrawError("Ресурс не изучен");
            GlobalEventManager.OnResearchEnd += dto => { _alertView.NewAlert(dto); };
        }

        public PlayerToolView SetBatteryBar(Image bar)
        {
            _batteryBar = bar;
            return this;
        }

        public PlayerToolView SetWarningText(Text text)
        {
            _warningText = text;
            return this;
        }

        public PlayerToolView SetAlertView(AlertView alert)
        {
            _alertView = alert;
            return this;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _controller.PrimaryAction();
            }
            else if (Input.GetMouseButton(1))
            {
                _controller.SecondaryAction();
            }
        }

        private void DrawBattery(float value)
        {
            _batteryBar.fillAmount = value;
            if (value <= 0) DrawError("Батарея разряжена");
        }

        private void DrawError(string text)
        {
            _warningText.text = text;
        }
    }
}