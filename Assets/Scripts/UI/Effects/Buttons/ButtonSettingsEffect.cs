using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Effects.Buttons
{
    [CreateAssetMenu(fileName = "ButtonEffectSettings", menuName = "_Custom Items/Effects/Button Effect Settings")]
    public class ButtonSettingsEffect : EffectSettings
    {
        #region --- Inspector Variables ---

        [SerializeField] private float hoverScale = 1.2f;
        [SerializeField] private float hoverDuration = 0.1f;

        #endregion

        
        #region --- Properties ---

        public float HoverScale => hoverScale;
        public float HoverDuration => hoverDuration;

        #endregion

        
        #region --- Public Methods ---

        public override EffectSettings GetEffectSettings ()
        {
            return this;
        }

        #endregion
    }
}