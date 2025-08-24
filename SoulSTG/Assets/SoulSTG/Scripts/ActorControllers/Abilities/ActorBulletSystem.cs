using Cysharp.Threading.Tasks;
using HK;
using SoulSTG.BarrageSystems;
using UnityEngine.Assertions;

namespace SoulSTG.ActorControllers.Abilities
{
    public class ActorBulletSystem : IActorAbility
    {
        private Actor actor;

        private GameObjectPool gameObjectPool;

        public BarrageSpawnData BarrageSpawnData;

        public void Activate(Actor actor)
        {
            this.actor = actor;
            gameObjectPool = TinyServiceLocator.Resolve<GameObjectPool>();
        }

        public bool TryFire()
        {
            BarrageSpawnData.SpawnAsync(actor).Forget();
            return true;
        }
    }
}
