using System;
using System.Collections.Generic;
using Core.Views.Interfaces;
using Interfaces;

namespace Core.Models
{
    public class BatteryChargerModel : Model
    {
        private float _efficiency;
        public bool ChargeAvailable;

        public LinkedList<IChargableToolView> ToolsNearby { get; private set; } = new();

        public float Efficiency
        {
            get => _efficiency;
            set
            {
                if (_efficiency < 0) throw new ArgumentException("efficiency should be greater or equal to 0");
                _efficiency = value;
            }
        }
    }
}