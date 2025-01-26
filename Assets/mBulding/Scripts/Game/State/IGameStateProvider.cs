using Assets.mBulding.Scripts.Game.State.Root;
using R3;

namespace Assets.mBulding.Scripts.Game.State
{
    public interface IGameStateProvider
    {
        public GameStateProxy GameState { get; }
        public GameSettingsStateProxy GameSettings { get; }

        public Observable<GameStateProxy> LoadGameState();
        public Observable<GameSettingsStateProxy> LoadSettingsState();

        public Observable<bool> SaveGameState();
        public Observable<bool> SaveSettingsState();

        public Observable<bool> ResetGameState();
        public Observable<bool> ResetSettingsState();
    }

}