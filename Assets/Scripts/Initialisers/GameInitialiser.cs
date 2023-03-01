using UnityEngine;

namespace Initialisers
{
    public class GameInitialiser : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
            Cursor.visible = false;
        }
    }
}