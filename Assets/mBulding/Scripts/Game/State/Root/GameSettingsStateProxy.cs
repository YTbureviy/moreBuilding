using System.Linq;
using R3;

namespace Assets.mBulding.Scripts.Game.State.Root
{
    public class GameSettingsStateProxy
    {
        public ReactiveProperty<int> MusicVolume { get; }

        public ReactiveProperty<int> SFXVolume { get; }

        public GameSettingsStateProxy(GameSettingsState gameSettingsState)
        {
            MusicVolume = new ReactiveProperty<int>(gameSettingsState.MusicVolume);
            SFXVolume = new ReactiveProperty<int>(gameSettingsState.SFXVolume);

            MusicVolume.Skip(1).Subscribe<int>(value => gameSettingsState.MusicVolume = value);
            SFXVolume.Skip(1).Subscribe<int>(value => gameSettingsState.SFXVolume = value);
        }
    }
}
