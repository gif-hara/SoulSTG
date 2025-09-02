using System;
using SoulSTG.ActorControllers;
using UnityEngine;

namespace SoulSTG.BarrageSystems.SpawnPointSelectors
{
    [Serializable]
    public sealed class FromActorDocument : ISpawnPointSelector
    {
        [field: SerializeField]
        private string transformName;

        public Transform GetSpawnPoint(Actor owner)
        {
            return owner.Document.Q<Transform>(transformName);
        }
    }
}
