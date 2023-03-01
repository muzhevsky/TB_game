using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public class WarningText : Text
    {
        private Coroutine _fadeOut;

        public override string text
        {
            get => m_Text;
            set
            {
                if (_fadeOut != null) StopCoroutine(_fadeOut);
                color = new Color(color.r, color.g, color.b, 1f);
                m_Text = value;
                _fadeOut = StartCoroutine(FadeOut());
            }
        }

        private IEnumerator FadeOut()
        {
            color = new Color(color.r, color.g, color.b, color.a - 0.01f);
            yield return new WaitForFixedUpdate();
            if (color.a <= 0)
            {
                _fadeOut = null;
                yield break;
            }

            _fadeOut = StartCoroutine(FadeOut());
        }
    }
}