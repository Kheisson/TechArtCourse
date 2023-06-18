using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Effects.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ShiningButtonEffect : ButtonHoverEffect
    {
        #region --- Inspector Variables ---

        [SerializeField] private Material buttonMaterial; // assign the custom button material here
        [SerializeField] private float normalSpeed = 0f;
        [SerializeField] private float hoverSpeed = 1.0f;

        #endregion


        #region --- Private Variables ---

        private static readonly int Speed = Shader.PropertyToID("_Speed");

         #endregion


        #region --- Unity Methods ---

        private void Start()
        {
            Button.targetGraphic.material = buttonMaterial;
        }

        #endregion


        #region --- Interface Methods ---

        public override void OnPointerEnter(PointerEventData eventData)
        {
            buttonMaterial.SetFloat(Speed, hoverSpeed);
            base.OnPointerEnter(eventData);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            buttonMaterial.SetFloat(Speed, normalSpeed);
            base.OnPointerExit(eventData);
        }

        #endregion
    }
}