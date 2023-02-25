using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class WarningText : Text
    {
        public override string text
        {
            get => m_Text;
            set
            {
                StopCoroutine(FadeOut());
                color = new Color(color.r, color.g, color.b, 1f);
                m_Text = value;
                StartCoroutine(FadeOut());
            }
        }

        private IEnumerator FadeOut()
        {
            color = new Color(color.r, color.g, color.b, color.a - 0.01f);
            yield return new WaitForFixedUpdate();
        }
    }
}