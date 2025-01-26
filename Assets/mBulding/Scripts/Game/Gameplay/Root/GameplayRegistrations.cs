using Assets.mBulding.Scripts.Game.Gameplay.Services;
using BaCon;
using Assets.mBulding.Scripts.Game.State;



namespace Assets.mBulding.Scripts.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Registre(DIContainer container, GameplayEnterParams gameplayEnterParams) 
        {
            container.RegisterFactory(c => new SomeGameplayService(
                c.Resolve<IGameStateProvider>().GameState, 
                c.Resolve<SomeCommonService>())
            ).AsSingle();
        }
    }
}
