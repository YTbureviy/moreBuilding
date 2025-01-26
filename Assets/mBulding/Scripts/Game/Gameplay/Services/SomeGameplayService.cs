using System;
using UnityEngine;
using Assets.mBulding.Scripts.Game.State.Root;

namespace Assets.mBulding.Scripts.Game.Gameplay.Services
{
    internal class SomeGameplayService : IDisposable
    {
        private readonly GameStateProxy _gameStateProxy;
        private readonly SomeCommonService _someCommonService;

        public SomeGameplayService(GameStateProxy gameStateProxy, SomeCommonService someCommonService)
        {
            _gameStateProxy = gameStateProxy;
            _someCommonService = someCommonService;

            Debug.Log(GetType().Name + " has been created.");
            // _gameStateProxy.Buildings.ObserveAdd().Subscribe() ...
            // _gameStateProxy.Buildings.ObserveRemove().Subscribe() ...
        }

        public void Dispose()
        {
            Debug.Log("dispose all subscribe");
        }
    }
}
