using System;
using Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Initialisers
{
    public class AlertInitialiser : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Start()
        {
            AlertManager.Init(_image, _text, _canvasGroup);
        }
    }
}