using Assets.mBulding.Scripts.Game.Gameplay.Root;
using Assets.mBulding.Scripts.Game.Gameplay.Root.View;
using BaCon;
using R3;
using UnityEngine;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;

    public Observable<GameplayExitParams> Run(DIContainer container, GameplayEnterParams enterParams)
    {
        GameplayRegistrations.Registre(container, enterParams);
        var gameplayViewModelsContainer = new DIContainer(container);
        GameplayViewModelsRegistrations.Registre(gameplayViewModelsContainer);

        var uiRoot = container.Resolve<UIRootView>();
        var uiScene = Instantiate(_sceneUIRootPrefab);
        uiRoot.AttachSceneUI(uiScene.gameObject);

        var exitSceneSignalSubj = new Subject<Unit>();
        uiScene.Bind(exitSceneSignalSubj);

        Debug.Log($"Gameplay entry poin: save file name: {enterParams.SaveFileName}, leve to load: {enterParams.LevelNumber}");

        var mainMenuEnterParems = new MainMenuEnterParams("Fatality");
        var exitParams = new GameplayExitParams(mainMenuEnterParems);
        var exitToMainMenuSceneSignal = exitSceneSignalSubj.Select(_ => exitParams);

        return exitToMainMenuSceneSignal;
    }
}
