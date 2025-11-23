using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers.Abilities;
using UnityEngine;

namespace SoulSTG.ActorControllers.Actions
{
    [Serializable]
    public sealed class AnimatorSetTrigger : IAction
    {
        [SerializeField]
        private string triggerName;

        public UniTask InvokeAsync(Actor actor, CancellationToken cancellationToken)
        {
            actor.GetAbility<SceneViewController>().SceneView.Animator.SetTrigger(triggerName);
            return UniTask.CompletedTask;
        }
    }
}
