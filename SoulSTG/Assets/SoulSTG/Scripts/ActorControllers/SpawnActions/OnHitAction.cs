using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using R3.Triggers;
using SoulSTG.ActorControllers.OnHitActions;
using TNRD;
using UnityEngine;

namespace SoulSTG.ActorControllers.SpawnActions
{
    [Serializable]
    public sealed class OnHitAction : ISpawnAction
    {
        [field: SerializeField, ClassesOnly]
        private List<SerializableInterface<IOnHitAction>> actions = new();

        public UniTask InvokeAsync(Actor owner, Actor spawnedActor, FloatContainer floatContainer, CancellationToken cancellationToken)
        {
            spawnedActor.OnTriggerEnter2DAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.attachedRigidbody.TryGetComponent<Actor>(out var hitActor))
                    {
                        foreach (var action in actions)
                        {
                            action.Value.Invoke(owner, spawnedActor, hitActor);
                        }
                    }
                })
                .RegisterTo(cancellationToken);
            return UniTask.CompletedTask;
        }
    }
}
