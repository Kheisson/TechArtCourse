using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Effects
{
    public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        #region --- Private Variables ---

        private Button _button;
        private Vector3 _defaultScale;

        #endregion

        
        #region --- Inspector Variables ---

        [SerializeField] private float hoverScale = 1.2f;
        [SerializeField] private float hoverDuration = 0.1f;

        #endregion

        
        #region --- Unity Methods ---

        private void Awake()
        {
            _button = GetComponent<Button>();
            _defaultScale = transform.localScale;
        }

        #endregion

        
        #region --- Interface Methods ---

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_button.interactable)
            {
                LeanTween.scale(gameObject, _defaultScale * hoverScale, hoverDuration);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_button.interactable)
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





