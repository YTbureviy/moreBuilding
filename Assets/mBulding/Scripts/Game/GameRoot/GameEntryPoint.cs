using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace mBuilding.Scripts
{
    public class GameEntryPoint 
    {
        private static GameEntryPoint _instance;
        private Coroutines _coroutines;
        private UIRootView _uiRoot;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutostartGame()
        {
            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint()
        {
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);

            var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
            _uiRoot = Object.Instantiate(prefabUIRoot);
            Object.DontDestroyOnLoad(_uiRoot.gameObject);
        }

        private void RunGame()
        {
#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "Gameplay")
            {
                _coroutines.StartCoroutine(LoadAndStartGameplay());
                return;
            }

            if (sceneName == Scenes.MAIN_MENU)
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu());
            }

            if (sceneName != "Boot")
            {
                return;
            }
#endif
            _coroutines.StartCoroutine(LoadAndStartGameplay());
        }

        private IEnumerator LoadAndStartGameplay()
        {
            _uiRoot.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.GAMEPLAY);
            yield return new WaitForSeconds(3.0f); // show loading screen

            var sceneEntryPoint = Object.FindObjectOfType<GameplayEntryPoint>();
            sceneEntryPoint.Run(_uiRoot);

            sceneEntryPoint.GoToMainMenuSceneRequested += () =>
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu());
            };

            _uiRoot.HideLoadingScreen();
        }

        private IEnumerator LoadAndStartMainMenu()
        {
            _uiRoot.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.MAIN_MENU);
            yield return new WaitForSeconds(3.0f); // show loading screen

            var sceneEntryPoint = Object.FindObjectOfType<MainMenuEntryPoint>();
            sceneEntryPoint.Run(_uiRoot);

            sceneEntryPoint.GoToGameplaySceneRequested += () =>
            {
                _coroutines.StartCoroutine(LoadAndStartGameplay());
            };

            _uiRoot.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}

