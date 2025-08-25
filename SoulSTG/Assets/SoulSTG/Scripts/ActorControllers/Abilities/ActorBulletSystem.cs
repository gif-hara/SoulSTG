using Cysharp.Threading.Tasks;
using HK;
using SoulSTG.BarrageSystems;

namespace SoulSTG.ActorControllers.Abilities
{
    public class ActorBulletSystem : IActorAbility
    {
        private Actor actor;

        public BarrageSpawnData BarrageSpawnData;

        public void Activate(Actor actor)
        {
            this.actor = actor;
        }

        public bool TryFire()
        {
            BarrageSpawnData.SpawnAsync(actor).Forget();
            return true;
        }
    }
}
