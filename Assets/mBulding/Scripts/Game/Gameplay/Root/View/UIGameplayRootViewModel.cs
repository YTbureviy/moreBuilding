using Assets.mBulding.Scripts.Game.Gameplay.Services;
using BaCon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mBulding.Scripts.Game.Gameplay.Root.View
{
    internal class UIGameplayRootViewModel
    {
        private readonly SomeGameplayService _someGameplayService;

        public UIGameplayRootViewModel(SomeGameplayService someGameplayService) 
        {
            _someGameplayService = someGameplayService;
        }

    }
}
