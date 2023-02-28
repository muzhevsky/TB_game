using System.Collections.Generic;
using Enums;

namespace Core.Models
{
    public class ShipRepairModel
    {
        private IShipRepairState _currentRepairState = new FirstShipRepairState();
        private bool _readyToFly = false;
        
        public Dictionary<ResourceType, float> TryToRepair(Dictionary<ResourceType, float> resources)
        {
            IShipRepairState next = _currentRepairState.GetNext();

            if (next == null) return null;

            var resourcesToSpend = _currentRepairState.TryToRepair(resources);

            if (resourcesToSpend != null)
                _currentRepairState = next;

            return resourcesToSpend;
        }

        public bool ReadyToFly
        {
            get => _readyToFly;
            private set => _readyToFly = value;
        }
    }

    public interface IShipRepairState
    {
        IShipRepairState GetNext();
        public Dictionary<ResourceType, float> TryToRepair(Dictionary<ResourceType, float> resources);
    }

    public class FirstShipRepairState : IShipRepairState
    {
        private Dictionary<ResourceType, float> _resourcesNeed = new Dictionary<ResourceType, float>();

        public FirstShipRepairState()
        {
            _resourcesNeed.Add(ResourceType.CommonOre, 50);
        }

        public IShipRepairState GetNext()
        {
            return new SecondShipRepairState();
        }

        public Dictionary<ResourceType, float> TryToRepair(Dictionary<ResourceType, float> resources)
        {
            foreach (var key in _resourcesNeed.Keys)
            {
                if (!resources.ContainsKey(key)) return null;
                if (_resourcesNeed[key] > resources[key]) return null;
            }

            return new Dictionary<ResourceType, float>(_resourcesNeed);
        }
    }

    public class SecondShipRepairState : IShipRepairState
    {
        private Dictionary<ResourceType, float> _resourcesNeed = new Dictionary<ResourceType, float>();

        public SecondShipRepairState()
        {
            _resourcesNeed.Add(ResourceType.CommonOre, 70);
            _resourcesNeed.Add(ResourceType.SpecialOre, 40);
        }

        public IShipRepairState GetNext()
        {
            return null;
        }

        public Dictionary<ResourceType, float> TryToRepair(Dictionary<ResourceType, float> resources)
        {
            foreach (var key in _resourcesNeed.Keys)
            {
                if (!resources.ContainsKey(key)) return null;
                if (_resourcesNeed[key] > resources[key]) return null;
            }

            return new Dictionary<ResourceType, float>(_resourcesNeed);
        }
    }
}