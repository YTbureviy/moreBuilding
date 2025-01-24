using System;
using UnityEngine;

namespace Assets.mBulding.Scripts.Game.Gameplay.Services
{
    internal class SomeGameplayService : IDisposable
    {
        private readonly SomeCommonService _someCommonService;

        public SomeGameplayService(SomeCommonService someCommonService)
        {
            _someCommonService = someCommonService;

            Debug.Log(GetType().Name + " has been created.");
        }

        public void Dispose()
        {
            Debug.Log("dispose all subscribe");
        }
    }
}
