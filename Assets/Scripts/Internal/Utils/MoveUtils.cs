using UnityEngine;

namespace Internal.Utils
{
    public static class MoveUtils
    {
        public static Vector3 GetDirection(Transform transform, float horizontalAxis, float verticalAxis)
        {
            return transform.forward * verticalAxis + transform.right * horizontalAxis;
        }
    }
}