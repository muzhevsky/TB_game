using System;
using System.Collections.Generic;
using Core.Controllers;
using Dto;
using MonoBehaviours;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Utils
{
    public class AlertManager : MonoBehaviour
    {
        private static Queue<AlertDto> _alertQueue = new Queue<AlertDto>(4);
        private static Image _image;
        private static TMP_Text _text;
        private static CanvasGroup _canvasGroup;

        public static void Init(Image image, TMP_Text text, CanvasGroup canvasGroup)
        {
            _image = image;
            _text = text;
            _canvasGroup = canvasGroup;
        }
        
        public static void NewAlert(Sprite sprite, string text)
        {
            if (sprite == null) throw new ArgumentException ("Image can not be null");
            if (text == null) throw new ArgumentException ("Text can not be null");

            AlertDto dto = new AlertDto()
            {
                Text = text,
                Sprite = sprite
            };
            
            _alertQueue.Enqueue(dto);
        }

        public static void ShowAlerts()
        {
            AlertDto dto = _alertQueue.Dequeue();

            _text.text = dto.Text;
            _image.sprite = dto.Sprite;
            
            _canvasGroup.alpha = 1f;
            GameStateController.Pause();
        }

        public void CloseAlert()
        {
            _canvasGroup.alpha = 0f;
            GameStateController.Unpause();
            
            if (_alertQueue.Count > 0)
                ShowAlerts();
        }
    }
}