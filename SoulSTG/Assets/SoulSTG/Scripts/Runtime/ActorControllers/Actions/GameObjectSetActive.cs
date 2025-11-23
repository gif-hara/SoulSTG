using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SoulSTG.ActorControllers.Actions
{
    public class GameObjectSetActive : IAction
    {
        [SerializeField]
        private GameObject target;

        [SerializeField]
        private bool isActive;

        public UniTask InvokeAsync(Actor actor, CancellationToken cancellationToken)
        {
            target.SetActive(isActive);
            return UniTask.CompletedTask;
        }
    }
}
