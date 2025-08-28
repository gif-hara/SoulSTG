using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using R3.Triggers;
using UnityEngine;

namespace SoulSTG.ActorControllers.Modifiers
{
    [Serializable]
    public sealed class OnHitAction : IActorModifier
    {
        public UniTask InvokeAsync(Actor owner, Actor spawnedActor, CancellationToken cancellationToken)
        {
            spawnedActor.OnTriggerEnter2DAsObservable()
                .Subscribe(collision =>
                {
                    Debug.Log("OnHitAction Triggered");
                })
                .RegisterTo(cancellationToken);
            return UniTask.CompletedTask;
        }
    }
}
