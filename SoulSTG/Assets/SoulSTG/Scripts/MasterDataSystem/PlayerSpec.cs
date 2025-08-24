using SoulSTG.ActorControllers;
using SoulSTG.BarrageSystems;
using UnityEngine;

namespace SoulSTG.MasterDataSystem
{
    [System.Serializable]
    public sealed class PlayerSpec
    {
        [field: SerializeField]
        public float MoveSpeed { get; private set; }

        [field: SerializeField]
        public float RotateSpeed { get; private set; }

        [field: SerializeField]
        public BarrageSpawnData BarrageSpawnData { get; private set; }
    }
}
