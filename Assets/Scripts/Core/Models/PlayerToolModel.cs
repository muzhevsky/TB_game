using System;
using Interfaces;

namespace Core.Models
{
    public class PlayerToolModel : Model
    {
        private float _batteryCap;
        private float _batteryConsumption;

        private float _batteryLeft;
        private float _efficiency;
        private float _range;

        public float BatteryCap
        {
            get => _batteryCap;
            set
            {
                if (value <= 0) throw new ArgumentException("BatteryCap should be greater then zero");
                _batteryCap = value;
            }
        }

        public float BatteryConsumption
        {
            get => _batteryConsumption;
            set
            {
                if (value <= 0) throw new ArgumentException("BatteryConsumption should be greater then zero");
                _batteryConsumption = value;
            }
        }

        public float BatteryLeft
        {
            get => _batteryLeft;
            set
            {
                _batteryLeft = value;
                if (_batteryLeft >= _batteryCap) _batteryLeft = _batteryCap;
            }
        }

        public float Range
        {
            get => _range;
            set
            {
                if (value <= 0) throw new ArgumentException("Range should be greater then 0");
                _range = value;
            }
        }

        public float Efficiency
        {
            get => _efficiency;
            set
            {
                if (value <= 0) throw new ArgumentException("Efficiency should be greater then 0");
                _efficiency = value;
            }
        }
    }
}