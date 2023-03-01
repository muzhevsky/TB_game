using System.Collections.Generic;
using Core.Controllers;
using Dto;
using UnityEngine;

namespace Initialisers
{
    public class GameStateControllerInitialiser : MonoBehaviour
    {
        [SerializeField] private AlertDto _winAlert;
        [SerializeField] private List<AlertDto> _startAlerts;
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private GameObject _winWindow;

        private void Awake()
        {
            GameStateController.Init(_winAlert, _startAlerts, _mainCanvas, _winWindow);
        }
    }
}