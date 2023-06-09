using UnityEngine;

namespace UI.Camera
{
    [RequireComponent(typeof(Canvas))]
    public class SafeAreaHandler : MonoBehaviour
    {
#region --- Private Variables ---

        private RectTransform _safeAreaRect;

#endregion

        
#region --- Unity Methods ---

        private void Awake ()
        {
            _safeAreaRect = GetComponent<RectTransform>();
            ApplySafeArea();
        }

#endregion


#region --- Private Methods ---

        private void ApplySafeArea ()
        {
            Rect safeArea = Screen.safeArea;

            // Convert safe area rectangle from absolute pixels to normalized values
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            // Apply safe area insets to the UI element
            _safeAreaRect.anchorMin = anchorMin;
            _safeAreaRect.anchorMax = anchorMax;
        }

#endregion
    }
}