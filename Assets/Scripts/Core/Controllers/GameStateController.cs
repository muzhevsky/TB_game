using UnityEngine;

namespace Core.Controllers
{
    public static class GameStateController
    {
        public static bool UserInputIsLocked { get; private set; }

        public static void Pause()
        {
            UserInputIsLocked = true;
            Time.timeScale = 0f;
        }

        public static void Unpause()
        {
            UserInputIsLocked = false;
            Time.timeScale = 1f;
        }
    }
}