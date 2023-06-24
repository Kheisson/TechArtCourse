using Global;
using Services;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        #region --- Inspector Variables ---

        [Header("Buttons")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button levelSelectButton;
        [SerializeField] private Button exitButton;
        [Header("GameObjects")]
        [SerializeField] private GameObject levelSelectPanel;

        #endregion


        #region --- Unity Methods ---

        private void Awake ()
        {
            RegisterButtons();
        }

        #endregion
        
        
        #region --- Private Methods ---
        
        private void RegisterButtons ()
        {
            startButton.onClick.AddListener(StartGame);
            levelSelectButton.onClick.AddListener(OpenLevelSelect);
            exitButton.onClick.AddListener(ExitGame);
        }
        
        private void StartGame ()
        {
            Debug.Log($"{nameof(MainMenuController)}: Start game button pressed.)");
            SceneLoadService.LoadSceneAsync(ProjectConstants.GAMEPLAY_SCENE);
        }
        
        private void OpenLevelSelect ()
        {
            Debug.Log($"{nameof(MainMenuController)}: Level select button pressed.)");
            levelSelectPanel.SetActive(true);
        }
        
        private void ExitGame ()
        {
            Debug.Log($"{nameof(MainMenuController)}: Exit game button pressed.)");
            #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
            #else
            Application.Quit();
            #endif
        }
        
        #endregion
    }
}
