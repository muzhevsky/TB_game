using System;
using MonoBehaviours;

namespace Core.Utils
{
    public class WarningTextManager
    {
        private static WarningText _text;

        public static void Init(WarningText text)
        {
            if (text == null) throw new ArgumentException("text is null");

            _text = text;
        }

        public static void SetText(string message)
        {
            _text.text = message;
        }
    }
}