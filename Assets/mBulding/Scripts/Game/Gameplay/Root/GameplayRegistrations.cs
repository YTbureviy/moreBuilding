using Assets.mBulding.Scripts.Game.Gameplay.Services;
using BaCon;



namespace Assets.mBulding.Scripts.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Registre(DIContainer container, GameplayEnterParams gameplayEnterParams) 
        {
            container.RegisterFactory(c => new SomeGameplayService(c.Resolve<SomeCommonService>())).AsSingle();
        }
    }
}
