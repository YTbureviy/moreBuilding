using BaCon;

namespace Assets.mBulding.Scripts.Game.MainMenu.Root.View
{
    internal class MainMenuViewModelsRegistrations
    {
        public static void Registre(DIContainer container)
        {
            container.RegisterFactory(c => new UIMainMenuRootViewModel()).AsSingle();
        }
    }
}
