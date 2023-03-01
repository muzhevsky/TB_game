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
        [SerializeField] private GameObject _window;

        private void Awake()
        {
            AlertManager.Init(_image, _text, _window);
        }
    }
}