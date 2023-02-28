using System;
using System.Collections.Generic;
using Core.Views.Interfaces;
using Interfaces;

namespace Core.Models
{
    public class BatteryChargerModel : Model
    {
        public bool ChargeAvailable;
        
        private float _efficiency;
        private LinkedList<IChargableToolView> _toolsNearby = new LinkedList<IChargableToolView>();
        
        public LinkedList<IChargableToolView> ToolsNearby
        {
            get => _toolsNearby;
            private set => _toolsNearby = value;
        }

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