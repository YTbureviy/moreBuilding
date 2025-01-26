using UnityEngine;

namespace Assets.mBulding.Scripts.Game.State.Root
{
    [System.Serializable]
    public class BuildingEntity
    {
        public int Id;
        public string TypeId;
        public Vector3Int Position;
        public int Level;
    }
}
