using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG;
using SoulSTG.ActorControllers;
using SoulSTG.ActorControllers.SpawnActions;
using UnityEngine;

namespace HK
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static async UniTask SpawnAsync(this ActorSpawnActions self, Actor owner, Actor prefab, Vector3 position, Quaternion rotation, FloatContainer floatContainer, CancellationToken cancellationToken)
        {
            var (actor, lifeScope) = TinyServiceLocator.Resolve<GameObjectPool>().Rent(prefab);
            actor.transform.SetPositionAndRotation(position, rotation);
            var scope = CancellationTokenSource.CreateLinkedTokenSource(lifeScope, cancellationToken);
            foreach (var action in self.Actions)
            {
                await action.Value.InvokeAsync(new ISpawnAction.Data(owner, actor, floatContainer, scope.Token));
            }
        }
    }
}