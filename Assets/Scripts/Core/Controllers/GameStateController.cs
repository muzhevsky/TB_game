using System;
using System.Collections.Generic;
using Core.Utils;
using Dto;
using UnityEngine;

namespace Core.Controllers
{
    public class GameStateController : MonoBehaviour
    {
        public static Canvas _mainCanvas;
        private static AlertDto _winAlert;
        private static List<AlertDto> _startAlerts;
        private static GameObject _winWindow;

        [SerializeField] private List<PausableBehaviour> _pausables;

        public static event Action OnPause;
        public static event Action OnUnpause;

        public static bool UserInputIsLocked { get; private set; }

        private void Start()
        {
            foreach (var pausable in _pausables)
            {
                pausable.OnPause += Pause;
                pausable.OnUnpause += Unpause;
            }

            foreach (var alert in _startAlerts) AlertManager.NewAlert(alert);

            AlertManager.ShowAlerts();
        }

        public static void Init(AlertDto winAlert, List<AlertDto> startAlerts, Canvas canvas, GameObject winWindow)
        {
            if (startAlerts == null) throw new ArgumentException("startAlerts is null");
            if (canvas == null) throw new ArgumentException("canvas is null");
            if (winWindow == null) throw new ArgumentException("winWindow is null");

            _mainCanvas = canvas;
            _winAlert = winAlert;
            _startAlerts = startAlerts;
            _winWindow = winWindow;
        }

        public static void Pause()
        {
            UserInputIsLocked = true;
            Time.timeScale = 0f;
            OnPause?.Invoke();
        }

        public static void Unpause()
        {
            UserInputIsLocked = false;
            Time.timeScale = 1f;
            OnUnpause?.Invoke();
        }

        public static void PlayerWins()
        {
            var canvasTr = _mainCanvas.transform;
            for (var i = 0; i < canvasTr.childCount; i++)
                canvasTr.GetChild(i).gameObject.SetActive(false);

            AlertManager.NewAlert(_winAlert);
            AlertManager.ShowAlerts();
            
            
            OnUnpause += () =>
            {
                _winWindow.SetActive(true);
                Pause();
            };
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}