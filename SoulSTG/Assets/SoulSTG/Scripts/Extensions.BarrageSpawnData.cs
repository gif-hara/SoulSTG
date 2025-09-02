using Cysharp.Threading.Tasks;
using SoulSTG;
using SoulSTG.ActorControllers;
using SoulSTG.BarrageSystems;
using SoulSTG.BarrageSystems.Modifiers;

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
            var floatContainer = new FloatContainer();
            foreach (var modifier in self.Modifiers)
            {
                await modifier.Value.InvokeAsync(new IBarrageModifier.Data(owner, spawnPoint, floatContainer, owner.GetLifeTimeToken()));
            }
        }
    }
}