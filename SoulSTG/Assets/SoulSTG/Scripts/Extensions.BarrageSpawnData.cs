using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers;
using SoulSTG.BarrageSystems;

namespace HK
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        public static async UniTask SpawnAsync(this BarrageSpawnData self, Actor owner)
        {
            var spawnPoint = self.SpawnPointSelector.Value.GetSpawnPoint(owner);
            foreach (var modifier in self.Modifiers)
            {
                await modifier.Value.InvokeAsync(owner, spawnPoint, owner.GetLifeTimeToken());
            }
        }
    }
}