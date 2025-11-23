using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using R3.Triggers;
using SoulSTG.ActorControllers.Abilities;
using UnityEngine;

namespace SoulSTG.ActorControllers.Actions
{
    [Serializable]
    public sealed class AnimatorSetTrigger : IAction
    {
        [SerializeField]
        private string triggerName;

        [SerializeField]
        private bool immediateUpdate;

        public UniTask InvokeAsync(Actor actor, CancellationToken cancellationToken)
        {
            var animator = actor.GetAbility<SceneViewController>().SceneView.Animator;
            animator.SetTrigger(triggerName);
            if (immediateUpdate)
            {
                animator.Update(0.0f);
            }
            return UniTask.CompletedTask;
        }
    }
}
