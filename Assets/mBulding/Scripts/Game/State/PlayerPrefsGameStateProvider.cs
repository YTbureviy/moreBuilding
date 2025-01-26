using Assets.mBulding.Scripts.Game.State.Root;
using R3;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.mBulding.Scripts.Game.State
{
    internal class PlayerPrefsGameStateProvider : IGameStateProvider
    {
        private const string GAME_STATE_KEY = nameof(GAME_STATE_KEY); // "GAME_STATE_KEY"
        private const string GAME_SETTINGS_STATE_KEY = nameof(GAME_SETTINGS_STATE_KEY); // GAME_SETTINGS_STATE_KEY

        public GameStateProxy GameState { get; private set; }

        public GameSettingsStateProxy GameSettings { get; private set; }

        private GameState _gameStateOrign;
        private GameSettingsState _gameSettingsStateOrign;

        public Observable<GameStateProxy> LoadGameState()
        {
            if (PlayerPrefs.HasKey(GAME_STATE_KEY) == false)
            {
                GameState = CreateGameStateFromSetting();

                SaveGameState();
            } else
            {
                string json = PlayerPrefs.GetString(GAME_STATE_KEY);
                _gameStateOrign = JsonUtility.FromJson<GameState>(json);
                GameState = new GameStateProxy(_gameStateOrign);
            }

            return Observable.Return(GameState);
        } 

        public Observable<bool> SaveGameState() 
        {
            string json = JsonUtility.ToJson(_gameStateOrign, true);
            PlayerPrefs.SetString(GAME_STATE_KEY, json);

            return Observable.Return(true);
        }

        public Observable<bool> ResetGameState()
        {
            GameState = CreateGameStateFromSetting();
            SaveGameState();

            return Observable.Return(true);
        }

        private GameStateProxy CreateGameStateFromSetting()
        {
            _gameStateOrign = new GameState()
            {
                Buildings = new List<BuildingEntity>()
                {
                    new BuildingEntity()
                    {
                        TypeId = "Lol1"
                    },
                    new BuildingEntity()
                    {
                        TypeId = "Lol2"
                    }
                }
            };

            return new GameStateProxy(_gameStateOrign);
        }

        public Observable<GameSettingsStateProxy> LoadSettingsState()
        {
            if (PlayerPrefs.HasKey(GAME_SETTINGS_STATE_KEY) == false)
            {
                GameSettings = CreateGameSettingsStateFromSetting();

                SaveSettingsState();
            }
            else
            {
                string json = PlayerPrefs.GetString(GAME_SETTINGS_STATE_KEY);
                _gameSettingsStateOrign = JsonUtility.FromJson<GameSettingsState>(json);
                GameSettings = new GameSettingsStateProxy(_gameSettingsStateOrign);
            }

            return Observable.Return(GameSettings);
        }

        public Observable<bool> SaveSettingsState()
        {
            string json = JsonUtility.ToJson(_gameSettingsStateOrign, true);
            PlayerPrefs.SetString(GAME_SETTINGS_STATE_KEY, json);

            return Observable.Return(true);
        }

        public Observable<bool> ResetSettingsState()
        {
            GameSettings = CreateGameSettingsStateFromSetting();
            SaveSettingsState();

            return Observable.Return(true);
        }

        private GameSettingsStateProxy CreateGameSettingsStateFromSetting()
        {
            _gameSettingsStateOrign = new GameSettingsState()
            {
                MusicVolume = 0,
                SFXVolume = 0,
            };

            return new GameSettingsStateProxy(_gameSettingsStateOrign);
        }
    }
}
