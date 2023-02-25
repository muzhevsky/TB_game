using System.Collections.Generic;
using System.IO;
using Dto;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public class Tip
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _text;
        private static Queue<TipDto> _tipQueue;

        public void NewTip(TipDto dto) // TODO: подумать над подсказками
        {
            if (dto.Sprite == null) throw new InvalidDataException("Image can not be null");
            if (dto.Text == null) throw new InvalidDataException("Text can not be null");

            _text.text = dto.Text;
            _image.sprite = dto.Sprite;
            _tipQueue.Enqueue(dto);
        }
    }
}