using UnityEngine;

namespace Assets.mBulding.Scripts.Game.MainMenu.Services
{
    internal class SomeMainMenuService
    {
        private readonly SomeCommonService _someCommonService;

        public SomeMainMenuService(SomeCommonService someCommonService)
        {
            _someCommonService = someCommonService;

            Debug.Log(GetType().Name + " has been created.");
        }
    }
}
