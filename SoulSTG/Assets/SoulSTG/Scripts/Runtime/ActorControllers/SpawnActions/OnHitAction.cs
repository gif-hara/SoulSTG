using System;
using System.Collections.Generic;
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
#if UNITY_EDITOR
        [ClassesOnly]
#endif
        [field: SerializeField]
        private List<SerializableInterface<IOnHitAction>> actions = new();

        public UniTask InvokeAsync(ISpawnAction.Data data)
        {
            data.SpawnedActor.OnTriggerEnter2DAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.attachedRigidbody.TryGetComponent<Actor>(out var hitActor))
                    {
                        foreach (var action in actions)
                        {
                            action.Value.Invoke(data.Owner, data.SpawnedActor, hitActor);
                        }
                    }
                })
                .RegisterTo(data.CancellationToken);
            return UniTask.CompletedTask;
        }
    }
}
