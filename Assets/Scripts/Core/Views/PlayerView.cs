using Core.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Views
{
    public class DefaultPlayerView : MonoBehaviour
    {
        [SerializeField] private Image _hpBar;
        [SerializeField] private Image _boosterBar;

        public void Init(PlayerModel model)
        {
            model.OnBoosterChanged += DrawBooster;
            model.OnHPChanged += DrawHP;
        }

        public DefaultPlayerView SetHPBar(Image bar)
        {
            _hpBar = bar;
            return this;
        }

        public DefaultPlayerView SetBoosterBar(Image bar)
        {
            _boosterBar = bar;
            return this;
        }

        public void DrawHP(float value)
        {
            _hpBar.fillAmount = value;
        }

        public void DrawBooster(float value)
        {
            _boosterBar.fillAmount = value;
        }
    }
}