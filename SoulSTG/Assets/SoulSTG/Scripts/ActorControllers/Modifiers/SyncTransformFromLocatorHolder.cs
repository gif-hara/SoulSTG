using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

namespace SoulSTG.ActorControllers.Modifiers
{
    [Serializable]
    public sealed class SyncTransformFromLocatorHolder : IActorModifier
    {
        [field: SerializeField]
        private string sceneViewName = "SceneView";

        [field: SerializeField]
        private string locatorName;

        [field: SerializeField]
        private bool syncPosition;

        [field: SerializeField]
        private bool syncRotation;

        public UniTask InvokeAsync(Actor owner, Actor spawnedActor, Container container, CancellationToken cancellationToken)
        {
            var locator = owner.Document.Q<SceneView>(sceneViewName).LocatorHolder.Get(locatorName);
            Assert.IsNotNull(locator, $"Locator '{locatorName}' not found in SceneView '{sceneViewName}'.");
            if (syncPosition)
            {
                spawnedActor.transform.position = locator.position;
            }
            if (syncRotation)
            {
                spawnedActor.transform.rotation = locator.rotation;
            }
            return UniTask.CompletedTask;
        }
    }
}
