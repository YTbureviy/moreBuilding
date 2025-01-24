
using UnityEngine;
using R3;
using BaCon;
using Assets.mBulding.Scripts.Game.MainMenu.Root;
using Assets.mBulding.Scripts.Game.MainMenu.Root.View;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;

    public Observable<MainMenuExitParams> Run(DIContainer container, MainMenuEnterParams enterParams)
    {
        MainMenuRagistrations.Registre(container, enterParams);
        var mainMenuViewModelsContainer = new DIContainer(container);
        MainMenuViewModelsRegistrations.Registre(mainMenuViewModelsContainer);

        var uiRoot = container.Resolve<UIRootView>();
        var uiScene = Instantiate(_sceneUIRootPrefab);
        uiRoot.AttachSceneUI(uiScene.gameObject);

        var exitSignalSubj = new Subject<Unit>();
        uiScene.Bind(exitSignalSubj);

        Debug.Log($"Main Menu Entry Point: Results {enterParams?.Result}");

        var saveFileName = "ololo save";
        var levelNumber = UnityEngine.Random.Range(0, 300);
        var gameplayEnterParams = new GameplayEnterParams(saveFileName, levelNumber);
        var mainMenuExitParams = new MainMenuExitParams(gameplayEnterParams);
        var exitToGameplaySceneSignal = exitSignalSubj.Select(_ => mainMenuExitParams);

        return exitToGameplaySceneSignal;
    }
}
