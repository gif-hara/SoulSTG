using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG;
using SoulSTG.ActorControllers;
using UnityEngine;

namespace HK
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        private static readonly FloatContainer cachedFloatContainer = new();

        public static async UniTask SpawnAsync(this ActorSpawnActions self, Actor owner, Actor prefab, Vector3 position, Quaternion rotation, CancellationToken cancellationToken)
        {
            var (actor, lifeScope) = TinyServiceLocator.Resolve<GameObjectPool>().Rent(prefab);
            actor.transform.SetPositionAndRotation(position, rotation);
            var scope = CancellationTokenSource.CreateLinkedTokenSource(lifeScope, cancellationToken);
            cachedFloatContainer.Clear();
            foreach (var action in self.Actions)
            {
                await action.Value.InvokeAsync(owner, actor, cachedFloatContainer, scope.Token);
            }
        }
    }
}