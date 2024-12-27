using R3;
using System;
using UnityEngine;

public class GameplayEntryPoint : MonoBehaviour
{
    //public event Action GoToMainMenuSceneRequested;

    [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;

    public Observable<GameplayExitParams> Run(UIRootView uiRoot, 
        GameplayEnterParams enterParams)
    {
        var uiScene = Instantiate(_sceneUIRootPrefab);
        uiRoot.AttachSceneUI(uiScene.gameObject);

        var exitSceneSignalSubj = new Subject<Unit>();
        uiScene.Bind(exitSceneSignalSubj);

        Debug.Log($"Gameplay entry poin: save file name: {enterParams.SaveFileName}, leve to load: {enterParams.LevelNumber}");

        var mainMenuEnterParems = new MainMenuEnterParams("Fatality");
        var exitParams = new GameplayExitParams(mainMenuEnterParems);
        var exitToaMainMenuSceneSignal = exitSceneSignalSubj.Select(_ => exitParams);

        return exitToaMainMenuSceneSignal;
    }
}
