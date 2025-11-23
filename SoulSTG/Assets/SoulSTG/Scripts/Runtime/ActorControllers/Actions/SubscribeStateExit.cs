using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using R3.Triggers;
using SoulSTG.ActorControllers.Abilities;
using TNRD;
using UnityEngine;

namespace SoulSTG.ActorControllers.Actions
{
    public class SubscribeStateExit : IAction
    {
#if UNITY_EDITOR
        [ClassesOnly]
#endif
        [SerializeField]
        private List<SerializableInterface<IAction>> actions = new();

        public UniTask InvokeAsync(Actor actor, CancellationToken cancellationToken)
        {
            var observable = actor.GetAbility<SceneViewController>().SceneView.Animator.GetBehaviour<ObservableStateMachineTrigger>().OnStateExitAsObservable();
            observable
                .Take(1)
                .SubscribeAwait((actor, actions), static async (_, t, cts) =>
                {
                    var (actor, actions) = t;
                    foreach (var action in actions)
                    {
                        await action.Value.InvokeAsync(actor, cts);
                    }
                })
                .RegisterTo(cancellationToken);
            return UniTask.CompletedTask;
        }
    }
}
