using System;
using UI.Effects;
using UnityEngine;
namespace UI.Core
{
    public class UIEffectManager : MonoBehaviour
    {
        #region --- Inspector Data ---
        
        [Header("UI Effect Manager Settings")]
        [SerializeField] private bool destroyOnLoad = true;
        [Space(10)]
        [Header("Effect Settings Files")]
        [SerializeField] private EffectSettings buttonEffectSettings;

        #endregion


        #region --- Constants ---

        private const float DESTROY_DELAY = 1f;

        #endregion
        
        
        #region --- Unity Methods ---

        private void Awake ()
        {
            ApplySettings();
        }
        private void OnValidate ()
        {
            if (buttonEffectSettings == null)
            {
                throw new ArgumentNullException(nameof(buttonEffectSettings));
            }
        }

        #endregion

        
        #region --- Private Methods ---

        private void ApplySettings ()
        {
            //All Settings that need to be applied on Awake
            SetButtonEffectSettings();
            
            //Object will remove itself from scene when done if destroyOnLoad is true
            if (destroyOnLoad) Destroy(this, DESTROY_DELAY);
        }

        #endregion

        
        #region --- Public Methods ---

        [ContextMenu("Set Button Effect Settings")]
        public void SetButtonEffectSettings ()
        {
            var buttons = FindObjectsOfType<ButtonHoverEffect>();

            foreach (var button in buttons)
            {
                button.SetSettings(buttonEffectSettings.GetEffectSettings());
            }
            
        }

        #endregion
    }
}
