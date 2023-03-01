using System;
using Core.Controllers.Interfaces;
using Core.Views.Interfaces;
using Interfaces;
using MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Views
{
    public class PlayerToolView : View, IChargableToolView
    {
        [SerializeField] private Image _batteryBar;
        [SerializeField] private WarningText _warningText;
        private IChargableToolController _chargableController;

        private IPlayerToolController _controller;

        private void Update()
        {
            if (Input.GetMouseButton(0))
                _controller.PrimaryAction();
            else if (Input.GetMouseButton(1)) _controller.SecondaryAction();
        }

        public void Charge(float value)
        {
            _chargableController.ChargeBattery(value);
        }

        public void Init(IPlayerToolController controller, IChargableToolController chargableToolController)
        {
            if (controller == null) throw new ArgumentException("controller is null");
            if (chargableToolController == null) throw new ArgumentException("chargable Tool Controller is null");

            _chargableController = chargableToolController;
            _controller = controller;

            var chargable = _controller as IChargableToolController;
            if (chargable != null) chargable.OnBatteryChange += DrawBattery;
        }

        public PlayerToolView SetBatteryBar(Image bar)
        {
            _batteryBar = bar;
            return this;
        }

        public PlayerToolView SetWarningText(WarningText text)
        {
            _warningText = text;
            return this;
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