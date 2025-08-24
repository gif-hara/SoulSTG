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
        public static async UniTask SpawnAsync(this ActorSpawnData self, Container container)
        {
            var (actor, cancellationToken) = TinyServiceLocator.Resolve<GameObjectPool>().Rent(self.ActorPrefab);
            foreach (var modifier in self.Modifiers)
            {
                await modifier.Value.InvokeAsync(actor, container, cancellationToken);
            }
        }
    }
}