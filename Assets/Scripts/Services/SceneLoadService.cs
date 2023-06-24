using System;
using UnityEngine.SceneManagement;

namespace Services
{
    public static class SceneLoadService
    {
        #region --- Public Methods ---

        public static void LoadSceneAsync(string sceneName, Action onSceneLoaded = null)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single).completed += operation =>
            {
                operation.allowSceneActivation = true;
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
                onSceneLoaded?.Invoke();
            };
        }

        #endregion
    }
}