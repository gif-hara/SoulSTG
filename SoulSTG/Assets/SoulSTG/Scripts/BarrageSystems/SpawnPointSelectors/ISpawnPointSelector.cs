using SoulSTG.ActorControllers;
using UnityEngine;

namespace SoulSTG.BarrageSystems.SpawnPointSelectors
{
    public interface ISpawnPointSelector
    {
        Transform GetSpawnPoint(Actor owner);
    }
}
