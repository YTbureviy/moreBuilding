using Assets.mBulding.Scripts.Game.State.Buidings;
using ObservableCollections;
using System.Linq;
using R3;

namespace Assets.mBulding.Scripts.Game.State.Root
{
    public class GameStateProxy
    {
        public ObservableList<BuildingEntityProxy> Buildings { get; } = new();

        public GameStateProxy(GameState gameState)
        {
            gameState.Buildings.ForEach(buidingEntity =>
            {
                Buildings.Add(new BuildingEntityProxy(buidingEntity));
            });

            Buildings.ObserveAdd<BuildingEntityProxy>().Subscribe(e =>
            {
                BuildingEntityProxy addedBuildingEntityProxy = e.Value;
                gameState.Buildings.Add(new BuildingEntity()
                {
                    Id = addedBuildingEntityProxy.Id,
                    TypeId = addedBuildingEntityProxy.TypeId,
                    Position = addedBuildingEntityProxy.Position.Value,
                    Level = addedBuildingEntityProxy.Level.Value,
                });
            });

            Buildings.ObserveRemove<BuildingEntityProxy>().Subscribe(removeData => 
            {
                BuildingEntityProxy removeBuildingEntityProxy = removeData.Value;
                BuildingEntity removeBuildingEntity = gameState.Buildings.FirstOrDefault(b => b.Id == removeBuildingEntityProxy.Id);
                gameState.Buildings.Remove(removeBuildingEntity);
            });
        }
    }
}
