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
        [FormerlySerializedAs("_alertView")] [SerializeField] private Alert alert;
        
        private IPlayerToolController _controller;
        public void Init(PlayerToolModel playerModel, PlayerResearchesModel researchesModel, IPlayerToolController controller)
        {
            _controller = controller;
            playerModel.OnBatteryChange += DrawBattery;
            researchesModel.OnResearchNeedEvent += () => DrawError("Ресурс не изучен");
            GlobalEventManager.OnResearchEnd += dto => { alert.NewAlert(dto); };
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

        public PlayerToolView SetAlertView(Alert alert)
        {
            this.alert = alert;
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