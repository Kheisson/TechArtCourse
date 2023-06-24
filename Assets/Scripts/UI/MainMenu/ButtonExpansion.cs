#if UNITY_EDITOR
using TMPro;
using UnityEngine;

namespace UI.MainMenu
{
    [ExecuteInEditMode]
    public class ButtonExpansion : MonoBehaviour
    {
        #region --- Unity Methods ---

        private void OnEnable ()
        {
            SetNameAndTextBasedOnPosition();
        }
        
        #endregion


        #region --- Private Methods ---

        private void SetNameAndTextBasedOnPosition ()
        {
            int position = transform.GetSiblingIndex();
            transform.GetComponentInChildren<TextMeshProUGUI>().text = $"{position + 1}";
        }

        #endregion
    }
}
#endif