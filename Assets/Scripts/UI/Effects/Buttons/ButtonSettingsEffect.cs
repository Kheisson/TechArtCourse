using UnityEngine;

namespace UI.Effects
{
    [CreateAssetMenu(fileName = "ButtonEffectSettings", menuName = "_Custom Items/Effects/Button Effect Settings")]
    public class ButtonSettingsEffect : EffectSettings
    {
        #region --- Inspector Variables ---

        [SerializeField] private float _hoverScale = 1.2f;
        [SerializeField] private float _hoverDuration = 0.1f;

        #endregion

        
        #region --- Properties ---

        public float HoverScale => _hoverScale;
        public float HoverDuration => _hoverDuration;

        #endregion

        
        #region --- Public Methods ---

        public override EffectSettings GetEffectSettings ()
        {
            return this;
        }

        #endregion
    }
}