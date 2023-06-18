using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Effects.Buttons
{
    public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        #region --- Private Variables ---

        protected Button Button;
        private Vector3 _defaultScale;

        #endregion

        
        #region --- Inspector Variables ---

        [SerializeField] private float hoverScale = 1.2f;
        [SerializeField] private float hoverDuration = 0.1f;

        #endregion

        
        #region --- Unity Methods ---

        private void Awake()
        {
            Button = GetComponent<Button>();
            _defaultScale = transform.localScale;
        }

        #endregion

        
        #region --- Interface Methods ---

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (Button.interactable)
            {
                LeanTween.scale(gameObject, _defaultScale * hoverScale, hoverDuration);
            }
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            if (Button.interactable)
            {
                LeanTween.scale(gameObject, _defaultScale, hoverDuration);
            }
        }

        #endregion
        

        #region --- Public Methods ---

        public void SetSettings(EffectSettings getEffectSettings)
        {
            var buttonSettingsEffect = (ButtonSettingsEffect) getEffectSettings;
            hoverScale = buttonSettingsEffect.HoverScale;
            hoverDuration = buttonSettingsEffect.HoverDuration;
        }

        #endregion
    }
}





