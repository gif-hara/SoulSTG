using Cysharp.Threading.Tasks;
using SoulSTG;
using SoulSTG.ActorControllers;

namespace HK
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static async UniTask SpawnAsync(this ActorSpawnData self, Actor owner, Container container)
        {
            var (actor, cancellationToken) = TinyServiceLocator.Resolve<GameObjectPool>().Rent(self.ActorPrefab);
            foreach (var modifier in self.Modifiers)
            {
                await modifier.Value.InvokeAsync(owner, actor, container, cancellationToken);
            }
        }
    }
}