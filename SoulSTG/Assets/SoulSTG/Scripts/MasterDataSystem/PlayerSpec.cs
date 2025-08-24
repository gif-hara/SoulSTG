using SoulSTG.ActorControllers;
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
        public Actor bulletPrefab { get; private set; }
    }
}
