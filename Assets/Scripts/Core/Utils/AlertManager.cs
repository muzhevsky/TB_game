using System;
using System.Collections.Generic;
using Core.Controllers;
using Dto;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Utils
{
    public class AlertManager : MonoBehaviour
    {
        private static readonly Queue<AlertDto> _alertQueue = new(4);
        private static Image _image;
        private static TMP_Text _text;
        private static GameObject _window;

        private static GameObject _winWindow;

        public static void Init(Image image, TMP_Text text, GameObject window)
        {
            if (image == null) throw new ArgumentException("image is null");
            if (text == null) throw new ArgumentException("text is null");

            _image = image;
            _text = text;
            _window = window;
        }

        public static void NewAlert(Sprite sprite, string text)
        {
            if (sprite == null) throw new ArgumentException("Image can not be null");
            if (text == null) throw new ArgumentException("Text can not be null");

            var dto = new AlertDto
            {
                Text = text,
                Sprite = sprite
            };

            _alertQueue.Enqueue(dto);
        }

        public static void NewAlert(AlertDto dto)
        {
            NewAlert(dto.Sprite, dto.Text);
        }

        public static void ShowAlerts()
        {
            _window.SetActive(true);
            var dto = _alertQueue.Dequeue();

            _text.text = dto.Text;
            _image.sprite = dto.Sprite;

            GameStateController.Pause();
        }

        public void CloseAlert()
        {
            _window.SetActive(false);
            GameStateController.Unpause();

            if (_alertQueue.Count > 0)
                ShowAlerts();
        }
    }
}