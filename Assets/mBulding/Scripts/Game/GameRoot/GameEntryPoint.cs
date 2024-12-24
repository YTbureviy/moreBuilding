using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mBuilding.Scripts
{
    public class GameEntryPoint 
    {
        private static GameEntryPoint _instance;
        private Coroutines _coroutines;
        private UIRootView _uiRootView;

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
            _uiRootView = Object.Instantiate(prefabUIRoot);
            Object.DontDestroyOnLoad(_uiRootView.gameObject);
        }

        private void RunGame()
        {
            //
        }
    }
}

