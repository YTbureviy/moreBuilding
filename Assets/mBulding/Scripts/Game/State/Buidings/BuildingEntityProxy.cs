using R3;
using UnityEngine;
using Assets.mBulding.Scripts.Game.State.Root;

namespace Assets.mBulding.Scripts.Game.State.Buidings
{
    public class BuildingEntityProxy
    {
        public int Id { get; }

        public string TypeId { get; }

        public ReactiveProperty<Vector3Int> Position { get; }

        public ReactiveProperty<int> Level { get; }

        public BuildingEntityProxy(BuildingEntity entity)
        {
            Id = entity.Id;
            TypeId = entity.TypeId;
            Position = new ReactiveProperty<Vector3Int>(entity.Position);
            Level = new ReactiveProperty<int>(entity.Level);

            Position.Skip(1).Subscribe(value => entity.Position = value);
            Level.Skip(1).Subscribe(value => entity.Level = value);
        }
    }
}
