using System;
using System.IO;
using Interfaces;

namespace Core.Models
{
    public class PlayerToolModel : Model
    {
        private float _range;
        private float _efficiency;
        
        private float _batteryLeft;
        private float _batteryCap;
        private float _batteryConsumption;

        public event Action<float> OnBatteryChange;
        
        public float BatteryCap
        {
            get => _batteryCap;
            set
            {
                if (value <= 0) throw new InvalidDataException("BatteryCap should be greater then zero");
                _batteryCap = value;
            }
        }

        public float BatteryConsumption
        {
            get => _batteryConsumption;
            set
            {
                if (value <= 0) throw new InvalidDataException("BatteryConsumption should be greater then zero");
                _batteryConsumption = value;
            }
        }

        public float BatteryLeft
        {
            get => _batteryLeft;
            set
            {
                _batteryLeft = value;
                OnBatteryChange?.Invoke(_batteryLeft / _batteryCap);
            }
        }

        public float Range
        {
            get => _range;
            set
            {
                if (value <= 0) throw new InvalidDataException("Range should be greater then 0");
                _range = value;
            }
        }

        public float Efficiency
        {
            get => _efficiency;
            set
            {
                if (value <= 0) throw new InvalidDataException("Efficiency should be greater then 0");
                _efficiency = value;
            }
        }
    }
}