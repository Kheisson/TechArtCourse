using UnityEngine;

namespace UI.Effects
{
    public class SeeThroughMenuEffect : MonoBehaviour
    {
        #region --- Inspector Variables ---

        [SerializeField] private Material xRayMaterial;
        [SerializeField] private float radius = 0.05f;

        #endregion


        #region --- Private Variables ---

        private static readonly int MousePos = Shader.PropertyToID("_MousePos");
        private static readonly int Radius = Shader.PropertyToID("_Radius");

        #endregion


        #region --- Unity Methods ---   

        private void Update()
        {
            Vector2 mousePos = Input.mousePosition;

            // Convert mouse position to [0, 1] range
            mousePos.x /= Screen.width;
            mousePos.y /= Screen.height;

            // Convert to clip space [-1, 1] range
            mousePos *= 2;
            mousePos -= Vector2.one;

            xRayMaterial.SetVector(MousePos, mousePos);
            xRayMaterial.SetFloat(Radius, radius);
        }

        #endregion
    }
}