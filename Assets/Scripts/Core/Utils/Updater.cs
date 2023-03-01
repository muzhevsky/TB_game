using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Utils
{
    public class Updater : MonoBehaviour
    {
        private static readonly List<IUpdatable> s_updates = new();
        private static readonly List<IFixedUpdatable> s_fixedUpdates = new();

        private void Update()
        {
            foreach (var item in s_updates)
                item.Update();
        }

        private void FixedUpdate()
        {
            foreach (var item in s_fixedUpdates)
                item.FixedUpdate();
        }

        public static void AddUpdatable(IUpdatable update)
        {
            if (update == null) throw new NullReferenceException("update can not be null");
            s_updates.Add(update);
        }

        public static void AddFixedUpdatable(IFixedUpdatable update)
        {
            if (update == null) throw new NullReferenceException("update can not be null");
            s_fixedUpdates.Add(update);
        }

        public static void StartUpdateAll()
        {
            foreach (var item in s_updates)
                item.ActivateUpdate();
        }

        public static void StartFixedUpdateAll()
        {
            foreach (var item in s_fixedUpdates)
                item.ActivateFixedUpdate();
        }
    }
}