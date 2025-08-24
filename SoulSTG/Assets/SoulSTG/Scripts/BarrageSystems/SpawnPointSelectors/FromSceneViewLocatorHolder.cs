using System;
using SoulSTG.ActorControllers;
using UnityEngine;

namespace SoulSTG.BarrageSystems.SpawnPointSelectors
{
    [Serializable]
    public sealed class FromSceneViewLocatorHolder : ISpawnPointSelector
    {
        [field: SerializeField]
        private string sceneViewName = "SceneView";

        [field: SerializeField]
        private string locatorName;

        public Transform GetSpawnPoint(Actor owner)
        {
            return owner.Document.Q<SceneView>(sceneViewName).LocatorHolder.Get(locatorName);
        }
    }
}
