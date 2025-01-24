using Assets.mBulding.Scripts.Game.MainMenu.Services;
using BaCon;

namespace Assets.mBulding.Scripts.Game.MainMenu.Root
{
    public static class MainMenuRagistrations
    {
        public static void Registre(DIContainer container, MainMenuEnterParams mainMenuEnterParams)
        {
            container.RegisterFactory(c => new SomeMainMenuService(c.Resolve<SomeCommonService>())).AsSingle();
        }
    }
}
