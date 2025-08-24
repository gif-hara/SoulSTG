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
        public static async UniTask SpawnAsync(this ActorSpawnData self, Actor owner, Vector3 position, Quaternion rotation, CancellationToken cancellationToken)
        {
            var (actor, lifeScope) = TinyServiceLocator.Resolve<GameObjectPool>().Rent(self.ActorPrefab);
            actor.transform.SetPositionAndRotation(position, rotation);
            var scope = CancellationTokenSource.CreateLinkedTokenSource(lifeScope, cancellationToken);
            foreach (var modifier in self.Modifiers)
            {
                await modifier.Value.InvokeAsync(owner, actor, scope.Token);
            }
        }
    }
}