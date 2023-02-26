using System.Collections.Generic;
using System.IO;
using Core.Controllers;
using Dto;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public class AlertView : View
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _closeButton;
        [SerializeField] private CanvasGroup _canvasGroup;
        
        private static Queue<ResearchableDto> _tipQueue = new Queue<ResearchableDto>(4);

        void Start()
        {
            CloseAlert();
        }
        
        public void NewAlert(ResearchableDto dto)
        {
            if (dto.Sprite == null) throw new InvalidDataException("Image can not be null");
            if (dto.Text == null) throw new InvalidDataException("Text can not be null");

            _tipQueue.Enqueue(dto);
            ShowAlert();
        }

        void ShowAlert()
        {
            _canvasGroup.alpha = 1f;
            ResearchableDto dto = _tipQueue.Dequeue();
            
            _text.text = dto.Text;
            _image.sprite = dto.Sprite;
            
            GameStateController.Pause();
        }

        public void CloseAlert()
        {
            _canvasGroup.alpha = 0f;
            
            GameStateController.Unpause();
        }
    }
}