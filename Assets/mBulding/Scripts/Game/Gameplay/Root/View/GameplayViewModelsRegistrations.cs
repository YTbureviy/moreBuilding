using Assets.mBulding.Scripts.Game.Gameplay.Services;
using BaCon;

namespace Assets.mBulding.Scripts.Game.Gameplay.Root.View
{
    public static class GameplayViewModelsRegistrations
    {
        public static void Registre(DIContainer container)
        {
            container.RegisterFactory(c => new UIGameplayRootViewModel(c.Resolve<SomeGameplayService>())).AsSingle();
            container.RegisterFactory(c => new WorldGameplayRootViewModel()).AsSingle();
        }
    }
}
