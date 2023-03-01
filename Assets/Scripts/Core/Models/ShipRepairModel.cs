using System;
using System.Collections.Generic;
using Enums;

namespace Core.Models
{
    public class ShipRepairModel
    {
        private IShipRepairState _currentRepairState = ShipRepairState.GetFirstState();

        public bool ReadyToFly { get; private set; }

        public event Action OnReadyToFly;

        public Dictionary<ResourceType, float> TryToRepair(Dictionary<ResourceType, float> resources)
        {
            var next = _currentRepairState.GetNext();

            if (next == null)
            {
                ReadyToFly = true;
                OnReadyToFly?.Invoke();
                return null;
            }

            var resourcesToSpend = _currentRepairState.TryToRepair(resources);

            if (resourcesToSpend != null)
                _currentRepairState = next;

            return resourcesToSpend;
        }

        public Dictionary<ResourceType, float> GetResourceAmount()
        {
            return _currentRepairState.GetResourceAmount();
        }
    }

    public interface IShipRepairState
    {
        IShipRepairState GetNext();
        public Dictionary<ResourceType, float> GetResourceAmount();
        public Dictionary<ResourceType, float> TryToRepair(Dictionary<ResourceType, float> resources);
    }

    public class ShipRepairState : IShipRepairState
    {
        private readonly Dictionary<ResourceType, float> _resourcesNeed;
        private readonly IShipRepairState _next;

        private static List<IShipRepairState> _states = new List<IShipRepairState>();

        static ShipRepairState()
        {
            var values = new Dictionary<ResourceType, float>();
            values.Add(ResourceType.CommonOre, 120);
            values.Add(ResourceType.SpecialOre, 40);
            var thirdState = new ShipRepairState(values, null);

            values[ResourceType.CommonOre] = 80;
            values[ResourceType.SpecialOre] = 20;
            var secondState = new ShipRepairState(values, thirdState);

            values.Remove(ResourceType.SpecialOre);
            values[ResourceType.CommonOre] = 50;
            var firstState = new ShipRepairState(values, secondState);
            
            _states.Add(firstState);
            _states.Add(secondState);
            _states.Add(thirdState);
        }

        public static IShipRepairState GetFirstState()
        {
            return _states[0];
        }
        
        private ShipRepairState(Dictionary<ResourceType, float> values, IShipRepairState next)
        {
            _resourcesNeed = new Dictionary<ResourceType, float>(values);
            _next = next;
        }

        public IShipRepairState GetNext()
        {
            return _next;
        }

        public Dictionary<ResourceType, float> GetResourceAmount()
        {
            return new Dictionary<ResourceType, float>(_resourcesNeed);
        }

        public Dictionary<ResourceType, float> TryToRepair(Dictionary<ResourceType, float> resources)
        {
            foreach (var key in _resourcesNeed.Keys)
            {
                if (!resources.ContainsKey(key)) return null;
                if (_resourcesNeed[key] > resources[key]) return null;
            }

            return GetResourceAmount();
        }
    }
}