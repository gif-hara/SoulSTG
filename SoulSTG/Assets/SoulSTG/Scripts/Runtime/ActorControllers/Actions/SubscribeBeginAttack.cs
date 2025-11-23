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
    public class SubscribeBeginAttack : IAction
    {
#if UNITY_EDITOR
        [ClassesOnly]
#endif
        [SerializeField]
        private List<SerializableInterface<IAction>> actions = new();

        [SerializeField]
        private bool takeUntilAnimatorStateExit;

        public UniTask InvokeAsync(Actor actor, CancellationToken cancellationToken)
        {
            var observable = actor.GetAbility<Abilities.Event>().Broker.Receive<Abilities.Event.BeginAttack>();
            if (takeUntilAnimatorStateExit)
            {
                observable = observable.TakeUntil(actor.GetAbility<SceneViewController>().SceneView.Animator.GetBehaviour<ObservableStateMachineTrigger>().OnStateExitAsObservable());
            }
            var disposable = observable
                .SubscribeAwait((actor, actions), static async (_, t, cts) =>
                {
                    var (actor, actions) = t;
                    foreach (var action in actions)
                    {
                        await action.Value.InvokeAsync(actor, cts);
                    }
                });
            disposable.RegisterTo(cancellationToken);
            return UniTask.CompletedTask;
        }
    }
}
